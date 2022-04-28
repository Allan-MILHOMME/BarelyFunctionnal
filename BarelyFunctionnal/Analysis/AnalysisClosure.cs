using BarelyFunctionnal.Model;
using System.Collections.Generic;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisClosure : AnalysisExecutable
    {
        public AnalysisEnvironmentNode Environment { get; }
        public Function Function { get; }
        public AnalysisClosure(AnalysisEnvironmentNode env, Function function)
        {
            Environment = env;
            Function = function;
        }

        public AnalysisClosure()
        {
            Function = new Function(new(), new());
            Environment = new AnalysisEnvironmentNode(new AnalysisEnvironment(null, new()));
        }

        public void Analyse(List<AnalysisExecutable> parameters)
        {



            var paras = Function.ParametersToAnalysisDictionary(parameters);
            var newEnv = Environment.AddParameters(paras);

            foreach (var inst in Function.Instructions)
                newEnv.Analyse(inst);
        }
    }
}
