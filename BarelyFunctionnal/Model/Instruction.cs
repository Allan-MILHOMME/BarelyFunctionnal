using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Execution;
using System.Collections.Generic;

namespace BarelyFunctionnal.Model
{
    public interface Instruction
    {
        public abstract void Compile(List<Name> currentNames);
        public abstract void Execute(Environment environement);
        public abstract void Analyse(AnalysisEnvironment environment);
    }
}
