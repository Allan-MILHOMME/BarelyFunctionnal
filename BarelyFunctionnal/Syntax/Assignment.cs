using BarelyFunctionnal.Execution;
using System.Collections.Generic;

namespace BarelyFunctionnal.Syntax
{
    public class Assignment : Instruction
    {
        public Assignment(Name name, Value value)
        {
            Name = name;
            Value = value;
        }

        public Name Name { get; }
        public Value Value { get; }

        public void Compile(List<Name> currentNames)
        {
            Name.Compile(currentNames);
            Value.Compile(currentNames);
        }

        public void Execute(Environment stack)
        {
            stack[Name] = Value.GetValue(stack);
        }
    }
}
