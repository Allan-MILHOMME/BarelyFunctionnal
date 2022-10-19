using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Execution;
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

        public void Execute(Environment environment)
        {
            environment[Name] = Value.GetValue(environment);
        }

        public void Analyse(AnalysisEnvironment environment, AnalysisCallData data)
        {
            environment[Name] = Value.GetAnalysisValue(environment);
        }
    }
}