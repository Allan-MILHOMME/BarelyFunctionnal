using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Execution;
using System.Collections.Generic;

namespace BarelyFunctionnal.Model
{
    public interface Value
    {
        public void Compile(List<Name> currentNames);
        public Executable GetValue(Environment stack);
        public AnalysisValue GetAnalysisValue(AnalysisEnvironment environment);
    }
}
