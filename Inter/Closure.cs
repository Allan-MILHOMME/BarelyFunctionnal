using Inter.Syntax;
using System;
using System.Collections.Generic;

namespace Inter
{
    public interface Executable
    {
        public void Execute(List<Executable> paras, CallStack currentStack, InstructionData prevInst);
    }

    public class Closure : Executable
    {
        public Closure(Environment env, Function method)
        {
            Environment = env;
            Method = method;
        }

        public Closure()
        {
            Method = new Function(new(), new());
            Environment = new Environment(null, new());
        }

        public Environment Environment { get; }
        public Function Method { get; }

        public void Analyze(List<Executable> parameters, CallStack callStack, InstructionData prevInst, AnalysisData previousData)
        {
            var paras = new Dictionary<Name, Executable>();
            for (var i = 0; i < Method.ParametersNames.Count; i++)
            {
                if (parameters.Count > i)
                    paras[Method.ParametersNames[i]] = parameters[i];
                else
                    paras[Method.ParametersNames[i]] = new Closure();
            }
            var newEnv = new Environment(Environment, paras);
            var currentCall = new CallData(this, paras, prevInst);
            var newStack = callStack.Push(currentCall);

            var index = 0;
            var currentInfluence = new Influence(newEnv);
            foreach (var inst in Method.Instructions)
            {
                foreach (var callData in callStack.Calls)
                    if (callData.Closure == this)
                        if (AreCallCompatible(callData, currentCall, newEnv, newStack, currentInfluence))
                        {
                            // Dans number : two est appelé, puis il appelle dec sur lui-même ce qui détecte une boucle
                            throw new Exception("Loop!");
                        }
                var newAnalysis = new AnalysisData(this);
                inst.Analyze(newEnv, newStack, new InstructionData(index, currentInfluence, inst), newAnalysis);
            }
        }

        public void Execute(List<Executable> parameters, CallStack callStack, InstructionData prevInst)
        {
            var paras = new Dictionary<Name, Executable>();
            for (var i = 0; i < Method.ParametersNames.Count; i++)
            {
                if (parameters.Count > i)
                    paras[Method.ParametersNames[i]] = parameters[i];
                else
                    paras[Method.ParametersNames[i]] = new Closure();
            }
            var newEnv = new Environment(Environment, paras);
            var currentCall = new CallData(this, paras, prevInst);
            var newStack = callStack.Push(currentCall);

            var index = 0;
            var currentInfluence = new Influence(newEnv);
            foreach (var inst in Method.Instructions)
            {
                foreach (var callData in callStack.Calls)
                    if (callData.Closure == this)
                        if (AreCallCompatible(callData, currentCall, newEnv, newStack, currentInfluence))
                        {
                            // Dans number : two est appelé, puis il appelle dec sur lui-même ce qui détecte une boucle
                            throw new Exception("Loop!");
                        }
                inst.Execute(newEnv, newStack, new InstructionData(index, currentInfluence, inst));
            }
        }

        public bool AreCallCompatible(CallData previous, CallData current, Environment newEnv, CallStack newStack, Influence currentInfluence)
        {
            if (previous.PreviousInstruction == null)
                return false;

            return currentInfluence == previous.PreviousInstruction.CurrentInfluence;
        }
    }

    public class UnknownFunction : Executable
    {
        public static UnknownFunction Instance { get; } = new();
        private UnknownFunction() { }
        public void Execute(List<Executable> paras, CallStack currentStack, InstructionData prevInst)
        {
            if (paras.Count > 0)
            {
                var count = new CountFunction();
                paras[0].Execute(new List<Executable> { count }, currentStack, prevInst);
                Console.WriteLine(count.Count);
            }
        }
    }

    public class CountFunction : Executable
    {
        public int Count { get; set; } = 0;
        public void Execute(List<Executable> paras, CallStack currentStack, InstructionData prevInst)
        {
            Count++;
        }
    }
}
