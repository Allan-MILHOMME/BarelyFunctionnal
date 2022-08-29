using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Execution;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Model
{
    public class FunctionCall : Instruction
    {
        public FunctionCall(Value functionName, List<Value> parameters)
        {
            Called = functionName;
            Parameters = parameters;
        }

        public Value Called { get; }
        public List<Value> Parameters { get; }

        public void Analyse(AnalysisEnvironment environment, AnalysisCallData callData)
        {
            var executable = Called.GetAnalysisValue(environment);
            var paras = Parameters.Select(p => p.GetAnalysisValue(environment)).ToList();
            executable.Analyse(paras, Parameters, callData);
        }

        public void Compile(List<Name> currentNames)
        {
            Called.Compile(currentNames);
            foreach (var param in Parameters)
                param.Compile(currentNames);
        }

        public void Execute(Environment stack)
        {
            var closure = Called.GetValue(stack);
            var paras = Parameters.Select(p => p.GetValue(stack)).ToList();
            closure.Execute(paras, false);
        }

        public override string? ToString()
        {
            return Called.ToString();
        }
    }
}
