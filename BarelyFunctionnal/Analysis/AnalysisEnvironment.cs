using BarelyFunctionnal.Model;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisEnvironment
    {
        public static AnalysisEnvironment Empty { get; } = new(null, new());
        public Dictionary<Name, AnalysisPossibleValue> Values { get; }
        public AnalysisEnvironment? ParentEnvironment { get; }

        public AnalysisEnvironment(AnalysisEnvironment? parent, Dictionary<Name, AnalysisPossibleValue> values)
        {
            ParentEnvironment = parent;
            Values = values;
        }

        public AnalysisPossibleValue this[Name name]
        {
            get
            {
                if (Values.ContainsKey(name))
                    return Values[name];
                return ParentEnvironment![name];
            }
            set
            {
                if (Values.ContainsKey(name))
                    Values[name] = value;
                else
                    ParentEnvironment![name] = value;
            }
        }

        public IEnumerable<Name> GetNames()
        {
            if (ParentEnvironment != null)
                return Enumerable.Concat(Values.Keys, ParentEnvironment.GetNames());
            return Values.Keys;
        }

        public AnalysisEnvironment Copy()
        {
            return new AnalysisEnvironment(ParentEnvironment?.Copy(), Values.ToDictionary(p => p.Key, p => p.Value));
        }
    }
}
