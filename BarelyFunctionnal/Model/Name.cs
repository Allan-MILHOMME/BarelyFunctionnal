using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Execution;
using System;
using System.Collections.Generic;
using Environment = BarelyFunctionnal.Execution.Environment;

namespace BarelyFunctionnal.Model
{
    public class Name : Value
    {
        public string Value { get; }

        public Name(string value)
        {
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Name name &&
                   Value == name.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString()
        {
            return Value;
        }

        public void Compile(List<Name> currentNames)
        {
            if (!currentNames.Contains(this))
                throw new Exception("Unknown name : " + Value);
        }

        public Executable GetValue(Environment stack)
        {
            return stack[this];
        }

        public AnalysisExecutable GetAnalysisValue(AnalysisEnvironment environment)
        {
            return environment[this];
        }
    }
}
