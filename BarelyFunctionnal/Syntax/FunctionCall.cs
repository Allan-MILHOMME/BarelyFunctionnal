using BarelyFunctionnal.Execution;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Syntax
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
            closure.Execute(paras);
        }

        public override string? ToString()
        {
            return Called.ToString();
        }
    }
}
