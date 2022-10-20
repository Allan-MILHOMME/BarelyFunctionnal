using BarelyFunctionnal.Model;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Execution
{
    public class Environment
    {
        public static Environment Empty { get; } = new(null, new());
        public Dictionary<Name, Executable> Values { get; }
        public Environment? ParentEnvironment { get; }

        public Environment(Environment? parent, Dictionary<Name, Executable> values)
        {
            ParentEnvironment = parent;
            Values = values;
        }

        public Executable this[Name name]
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

        public Environment Copy(Dictionary<Environment, Environment> envs)
        {
            if (envs.ContainsKey(this))
                return envs[this];

            var env = new Environment(ParentEnvironment?.Copy(envs), Values.ToDictionary(p => p.Key, p => p.Value));
            envs[this] = env;
            foreach (var entry in env.Values)
                env[entry.Key] = entry.Value.Copy(envs);
            return env;
        }
    }
}
