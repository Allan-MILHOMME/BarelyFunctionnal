
using Inter.Syntax;

namespace Inter
{
    public class InstructionData
    {
        public int Index { get; }
        public Influence CurrentInfluence { get; }
        public InterInstruction ExecutedInstruction { get; }

        public InstructionData(int index, Influence ci, InterInstruction ei)
        {
            Index = index;
            CurrentInfluence = ci;
            ExecutedInstruction = ei;
        }
    }
}
