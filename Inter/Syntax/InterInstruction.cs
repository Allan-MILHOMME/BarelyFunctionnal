using System.Collections.Generic;

namespace Inter.Syntax
{
    public interface InterInstruction
    {
        public abstract void Compile(List<Name> currentNames);
        public abstract void Analyze(Environment environement, CallStack currentStack, InstructionData prevInst, AnalysisData previousData);
        public abstract void Execute(Environment environement, CallStack currentStack, InstructionData prevInst);
    }
}
