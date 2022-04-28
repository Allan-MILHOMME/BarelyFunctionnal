using BarelyFunctionnal.Model;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisEnvironment
    {
        public Dictionary<Name, AnalysisExecutable> Values { get; }
        public AnalysisEnvironment? ParentEnvironment { get; }
        public AnalysisEnvironmentNode Node { get; set; } = null!;

        public AnalysisEnvironment(AnalysisEnvironment? parent, Dictionary<Name, AnalysisExecutable> values)
        {
            ParentEnvironment = parent;
            Values = values;
        }

        public AnalysisExecutable this[Name name]
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

        public AnalysisEnvironment Split()
        {
            var newEnv = new AnalysisEnvironment(ParentEnvironment?.Split(), Values.ToDictionary(p => p.Key, p => p.Value));
            Node.Split(newEnv);
            Node = Node.Value.Right!.Item1;
            return newEnv;
        }
    }
}
