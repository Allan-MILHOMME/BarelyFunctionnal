using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Execution;
using BarelyFunctionnal.Utils;
using System.Collections.Generic;

namespace BarelyFunctionnal.Model
{
    public interface Value
    {
        public void Compile(List<Name> currentNames);
        public Executable GetValue(Environment stack);
        public AnalysisExecutable GetAnalysisValue(AnalysisEnvironment environment);
        public Either<Name, AnalysisExecutable> GetAnalysisSource(AnalysisEnvironment environment);
    }
}
