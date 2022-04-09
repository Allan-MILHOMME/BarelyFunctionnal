using BarelyFunctionnal.Execution;
using System.Collections.Generic;

namespace BarelyFunctionnal.Syntax
{
    public interface Instruction
    {
        public abstract void Compile(List<Name> currentNames);
        public abstract void Execute(Environment environement);
    }
}
