using Inter.Syntax;
using System.Collections.Generic;

namespace Inter
{
    public class Assignment : InterInstruction
    {
        public Assignment(Name name, InterValue value)
        {
            Name = name;
            Value = value;
        }

        public Name Name { get; }
        public InterValue Value { get; }

        public void Compile(List<Name> currentNames)
        {
            Name.Compile(currentNames);
            Value.Compile(currentNames);
        }

        public AnalysisData Analyze(Environment environement, CallStack currentStack, InstructionData prevInst, AnalysisData previousData)
        {
            Execute(environement, currentStack, prevInst);
            return previousData;
        }

        public void Execute(Environment stack, CallStack currentStack, InstructionData prevInst)
        {
            prevInst.CurrentInfluence.Dict[Name] = Value;
            stack[Name] = Value.GetValue(stack, currentStack);
        }
    }
}
