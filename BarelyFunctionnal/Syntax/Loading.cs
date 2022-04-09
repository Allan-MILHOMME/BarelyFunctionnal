using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Syntax
{
    public class Loading : Instruction
    {
        public List<Instruction> Instructions { get; }

        public Loading(List<Instruction> insts)
        {
            Instructions = insts;
        }

        public void Execute(Context context)
        {
            context.Set(this);
        }

        public override string ToString()
        {
            return "(" + string.Join("", Instructions.Select(i => i.ToString())) + ")";
        }
    }
}
