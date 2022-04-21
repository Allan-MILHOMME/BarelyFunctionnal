using BarelyFunctionnal.Model;
using System.Collections.Generic;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisClosure : AnalysisPossibleValue
    {
        public AnalysisEnvironment Environment { get; }
        public Function Function { get; }
        public AnalysisClosure(AnalysisEnvironment env, Function function)
        {
            Environment = env;
            Function = function;
        }

        public AnalysisClosure()
        {
            Function = new Function(new(), new());
            Environment = new AnalysisEnvironment(null, new());
        }

        public void Analyse(List<AnalysisPossibleValue> parameters, OccurenceCount? currentOccurenceCount)
        {
            var paras = Function.ParametersToAnalysisDictionary(parameters);
            var newEnv = new AnalysisEnvironment(Environment, paras);

            foreach (var inst in Function.Instructions)
                inst.Analyse(newEnv, currentOccurenceCount);
        }
    }
}
