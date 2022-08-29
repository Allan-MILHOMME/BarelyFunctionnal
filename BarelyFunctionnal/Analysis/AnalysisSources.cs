using BarelyFunctionnal.Model;
using BarelyFunctionnal.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisSources
    {
        public Dictionary<Name, Either<Name, AnalysisExecutable>> Sources { get; } = new();

        public AnalysisSources() { }

        public AnalysisSources(Dictionary<Name, Either<Name, AnalysisExecutable>> s)
        {
            Sources = s;
        }

        public AnalysisSources(AnalysisEnvironment oldEnv, Function func, List<Value> parameters)
        {
            foreach (var name in oldEnv.GetNames())
                Sources[name] = name;

            for (var i = 0; i < func.ParametersNames.Count; i++)
            {
                if (parameters.Count > i)
                    Sources[func.ParametersNames[i]] = parameters[i].GetAnalysisSource(oldEnv);
                else
                    Sources[func.ParametersNames[i]] = new AnalysisClosure();
            }
        }

        public AnalysisSources AddParent(AnalysisSources parent)
        {
            return new AnalysisSources(Sources.ToDictionary(
                entry => entry.Key,
                entry => entry.Value.Select(
                    left => parent.Sources[left],
                    right => new(right)
                )
            ));
        }

        public override bool Equals(object? a)
        {
            if (a is not AnalysisSources source)
                return false;

            foreach (var entry in Sources)
                if (!source.Sources[entry.Key].Equals(entry.Value))
                    return false;

            return true;
        }
        public override int GetHashCode()
        {
            return Sources.GetHashCode();
        }
    }
}
