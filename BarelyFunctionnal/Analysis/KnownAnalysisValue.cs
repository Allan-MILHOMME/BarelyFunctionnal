using BarelyFunctionnal.Execution;

namespace BarelyFunctionnal.Analysis
{
    public class KnownAnalysisValue : AnalysisValue
    {
        public Closure Value { get; }

        public KnownAnalysisValue(Closure value)
        {
            Value = value;
        }
    }
}
