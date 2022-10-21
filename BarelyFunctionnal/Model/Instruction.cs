using BarelyFunctionnal.Executions;
using System.Collections.Generic;

namespace BarelyFunctionnal.Model
{
    public interface Instruction
    {
        public abstract void Compile(List<Name> currentNames);
        public abstract Execution? Execute(Environment environement, Execution parent);
    }
}
