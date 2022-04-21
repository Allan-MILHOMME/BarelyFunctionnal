using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Execution;
using System.Collections.Generic;

namespace BarelyFunctionnal.Model
{
    public class Unknown : Value
    {
        public static Unknown Instance { get; } = new Unknown();

        private Unknown() { }

        public void Compile(List<Name> currentNames) { }

        public Executable GetValue(Environment stack)
        {
            return UnknownFunction.Instance;
        }

        public override bool Equals(object? o)
        {
            return o == Instance;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public AnalysisPossibleValue GetAnalysisValue(AnalysisEnvironment environment)
        {
            return AnalysisUnknown.Instance;
        }
    }
}
