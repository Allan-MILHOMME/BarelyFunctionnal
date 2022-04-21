using System.Collections.Generic;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisUnknown : AnalysisPossibleValue
    {
        public static AnalysisUnknown Instance { get; } = new();
        private AnalysisUnknown() { }

        public void Analyse(List<AnalysisPossibleValue> parameters, OccurenceCount? currentOccurenceCount)
        {
            var occCount = new OccurenceCount(currentOccurenceCount);
            foreach (var p in parameters)
                p.Analyse(new(), occCount);
        }
    }
}
