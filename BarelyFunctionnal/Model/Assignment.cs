using BarelyFunctionnal.Executions;
using System.Collections.Generic;

namespace BarelyFunctionnal.Model
{
    public class Assignment : Instruction
    {
        public Name Name { get; }
        public Value Value { get; }

        public Assignment(Name name, Value value)
        {
            Name = name;
            Value = value;
        }

        public void Compile(List<Name> currentNames)
        {
            Name.Compile(currentNames);
            Value.Compile(currentNames);
        }

        public Execution? Execute(Environment environment, Execution parent)
        {
            environment[Name] = Value.GetValue(environment);
            return null;
        }
    }
}