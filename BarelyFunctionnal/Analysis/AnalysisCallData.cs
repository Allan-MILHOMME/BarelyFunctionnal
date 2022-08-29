using BarelyFunctionnal.Model;
using System.Collections.Generic;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisCallData
    {
        public AnalysisCallData? ParentCall { get; }
        public Function Function { get; }
        public AnalysisSources Sources { get; }
        public AnalysisClosure Closure { get; }

        public AnalysisCallData(AnalysisCallData? parent, AnalysisSources sources, Function function, AnalysisClosure closure)
        {
            ParentCall = parent;
            Sources = sources;
            Function = function;
            Closure = closure;
        }

        public IEnumerable<AnalysisCallData> FindParent(AnalysisClosure closure)
        {
            if (ParentCall != null)
            {
                if (ParentCall.Closure == closure)
                    yield return ParentCall;
                foreach (var p in ParentCall.FindParent(closure))
                    yield return p;
            }
        }

        public IEnumerable<AnalysisCallData> GetInnerCallsAfter(AnalysisCallData function)
        {
            if (ParentCall != null && this != function)
            {
                yield return ParentCall!;

                foreach (var p in ParentCall.GetInnerCallsAfter(function))
                    yield return p;
            }
        }

        public AnalysisSources GetSourcesFrom(AnalysisCallData parent)
        {
            return ParentCall!.GetSourcesFrom(parent, Sources);
        }

        private AnalysisSources GetSourcesFrom(AnalysisCallData parent, AnalysisSources current)
        {
            if (this == parent)
                return current;

            return ParentCall!.GetSourcesFrom(parent, current.AddParent(Sources));
        }

        public int GetEnvSize()
        {
            return Function.ParametersNames.Count + (ParentCall?.GetEnvSize() ?? 0);
        }

        public int Depth()
        {
            return 1 + (ParentCall?.Depth() ?? 0);
        }
    }
}
