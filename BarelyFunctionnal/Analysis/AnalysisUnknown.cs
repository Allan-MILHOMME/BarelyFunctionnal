using BarelyFunctionnal.Model;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisUnknown : AnalysisExecutable
    {
        public static AnalysisUnknown Instance { get; } = new();
        private AnalysisUnknown() { }

        public void Analyse(List<AnalysisExecutable> parameters, List<Value> parameterValues, AnalysisCallData callData)
        {
            if (parameters.First() is AnalysisClosure closure)
                closure.Environment.Split(closure);
        }
    }
}
