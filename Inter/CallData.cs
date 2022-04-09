using Inter.Syntax;
using System.Collections.Generic;

namespace Inter
{
    public class CallData
    {
        public Closure Closure { get; }
        public Dictionary<Name, Executable> Parameters { get; }
        public InstructionData? PreviousInstruction { get; set; }

        public CallData(Closure closure, Dictionary<Name, Executable> param, InstructionData prevInst)
        {
            Closure = closure;
            Parameters = param;
            PreviousInstruction = prevInst;
        }

        public override string? ToString()
        {
            return PreviousInstruction?.ExecutedInstruction.ToString();
        }
    }
}
