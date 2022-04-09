using Inter.Syntax;
using System.Collections.Generic;

namespace Inter
{
    public class AnalysisData
    {
        public Closure Closure { get; }
        public Dictionary<Name, AnalysisVariable> Parameters { get; }
        public InstructionData? PreviousIntruction { get; }
        public AnalysisData? PreviousAnalysis { get; }

        public AnalysisData(Closure closure, Dictionary<Name, AnalysisVariable> param, AnalysisData data, InstructionData inst)
        {
            Closure = closure;
            PreviousAnalysis = data;
            Parameters = param;
            PreviousIntruction = inst;
        }

        public AnalysisData(Closure closure)
        {
            Closure = closure;
            Parameters = new();
        }
    }
}
