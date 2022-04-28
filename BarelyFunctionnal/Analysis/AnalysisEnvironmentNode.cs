using BarelyFunctionnal.Model;
using BarelyFunctionnal.Utils;
using System.Collections.Generic;

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

        public void Analyse(Instruction instruction)
        {
            Value.Do(left => instruction.Analyse(left),
                     right => right.Do(node => node.Analyse(instruction)));
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
