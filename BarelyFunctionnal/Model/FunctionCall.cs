using BarelyFunctionnal.Executions;
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

        public void Compile(List<Name> currentNames)
        {
            Called.Compile(currentNames);
            foreach (var param in Parameters)
                param.Compile(currentNames);
        }

        public Execution? Execute(Environment stack, Execution parent)
        {
            var closure = Called.GetValue(stack);
            var paras = Parameters.Select(p => p.GetValue(stack)).ToList();
            var execution = closure.GetExecution(parent, paras);
            execution.ExecuteNext();
            return execution;
        }

        public override string? ToString()
        {
            return Called.ToString();
        }
    }
}
