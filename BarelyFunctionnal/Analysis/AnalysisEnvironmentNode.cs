using BarelyFunctionnal.Model;
using BarelyFunctionnal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisEnvironmentNode
    {
        public Either<AnalysisEnvironment, Pair<AnalysisEnvironmentNode>> Value { get; set; }

        public AnalysisEnvironmentNode(Either<AnalysisEnvironment, Pair<AnalysisEnvironmentNode>> value)
        {
            Value = value;
            if (value.Left != null)
                value.Left.Node = this;
        }

        public AnalysisEnvironmentNode AddParameters(Dictionary<Name, AnalysisExecutable> values)
        {
            return Value.Select(left => new AnalysisEnvironmentNode(new AnalysisEnvironment(left, values)),
                                right => new(right));
        }

        public void Analyse(List<Instruction> instructions, List<Value> parameterValues, AnalysisCallData? callData, Function function, AnalysisClosure closure)
        {
            Value.Do(left =>
            {
                var newCallData = new AnalysisCallData(callData, function, closure);
                if (callData != null)
                    callData.ChildrenCalls.Add(callData);
                if (SearchLoop(newCallData))
                    throw new Exception("Loop");

                foreach (var instruction in instructions)
                    instruction.Analyse(left, newCallData);
            },
            right => right.Do(node => node.Analyse(instructions, parameterValues, callData, function, closure)));
        }

        public bool SearchLoop(AnalysisCallData newCallData)
        {
            foreach (var possibleParent in newCallData.FindParent(newCallData.Closure))
            {
                var innerCalls = newCallData.GetInnerCallsAfter(possibleParent);
                var test = newCallData.FindParent(newCallData.Closure).ToList();
                var maxEnvSize = innerCalls.Max(c => c.GetEnvSize());
                if (SearchNextLoopWithBase(innerCalls, possibleParent, 0, maxEnvSize))
                    return true;
            }
            return false;
        }

        public bool SearchNextLoopWithBase(IEnumerable<AnalysisCallData> childLoop, AnalysisCallData parent, int index, int maxEnvSize)
        {
            if (index == maxEnvSize)
                return true;

            var possibleMostRecentParents = parent.FindParent(parent.Closure);
            foreach (var mostRecentParent in possibleMostRecentParents)
            {
                var parentInnerCalls = parent.GetInnerCallsAfter(mostRecentParent);
                if (!CheckLoopEquivalence(childLoop, parentInnerCalls))
                    continue;
                else
                {
                    possibleMostRecentParents = mostRecentParent.FindParent(parent.Closure);
                    return SearchNextLoopWithBase(parentInnerCalls, mostRecentParent, index + 1, maxEnvSize);
                }
            }

            return false;
        }

        public bool CheckLoopEquivalence(IEnumerable<AnalysisCallData> childLoop, IEnumerable<AnalysisCallData> parentLoop)
        {
            foreach (var call in childLoop)
            {
                var childLoopCallNumber = childLoop.Count(childCall => childCall.Function == call.Function);
                var parentLoopCallNumber = parentLoop.Count(parentCall => parentCall.Function == call.Function);

                if (childLoopCallNumber == 0 && parentLoopCallNumber != 0)
                    return false;
                if (childLoopCallNumber < parentLoopCallNumber)
                    return false;
            }

            foreach (var call in parentLoop)
            {
                var childLoopCallNumber = childLoop.Count(childCall => childCall.Function == call.Function);
                var parentLoopCallNumber = parentLoop.Count(parentCall => parentCall.Function == call.Function);

                if (childLoopCallNumber != 0 && parentLoopCallNumber == 0)
                    return false;
            }

            return true;
        }

        // Should only be used if Value is an environment, not a node
        public void Split(AnalysisEnvironment newEnv)
        {
            Value = new Pair<AnalysisEnvironmentNode>(
                new AnalysisEnvironmentNode(Value.Left!),
                new AnalysisEnvironmentNode(newEnv)
            );
        }

        public void Split(AnalysisClosure closure)
        {
            Value.Do(
                left => left.Split(),
                right =>
                {
                    Value.Right!.Item1.Split(closure);
                    Value.Right!.Item2.Split(closure);
                });
        }
    }
}
