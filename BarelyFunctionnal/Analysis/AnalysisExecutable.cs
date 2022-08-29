using BarelyFunctionnal.Model;
using System.Collections.Generic;

namespace BarelyFunctionnal.Analysis
{
    public interface AnalysisExecutable
    {
        public void Analyse(List<AnalysisExecutable> paras, List<Value> parameterValues, AnalysisCallData callData);
    }
}
