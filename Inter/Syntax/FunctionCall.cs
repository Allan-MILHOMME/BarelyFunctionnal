using System.Collections.Generic;
using System.Linq;

namespace Inter.Syntax
{
    public class FunctionCall : InterInstruction
    {
        public FunctionCall(InterValue methodName, List<InterValue> parameters)
        {
            MethodName = methodName;
            Parameters = parameters;
        }

        public InterValue MethodName { get; }
        public List<InterValue> Parameters { get; }

        public AnalysisData Analyze(Environment environement, CallStack currentStack, InstructionData prevInst, AnalysisData previousData)
        {
            Execute(environement, currentStack, prevInst);
            return previousData;
        }

        public void Compile(List<Name> currentNames)
        {
            MethodName.Compile(currentNames);
            foreach (var param in Parameters)
                param.Compile(currentNames);
        }

        public void Execute(Environment stack, CallStack currentStack, InstructionData prevInst)
        {
            var closure = MethodName.GetValue(stack, currentStack);
            var paras = Parameters.Select(p => p.GetValue(stack, currentStack)).ToList();
            closure.Execute(paras, currentStack, prevInst);
        }

        public override string? ToString()
        {
            return MethodName.ToString();
        }
    }
}
