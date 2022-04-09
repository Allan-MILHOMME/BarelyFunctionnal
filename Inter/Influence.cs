using Inter.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Inter
{
    public class Influence
    {
        public Dictionary<Name, InterValue> Dict { get; } = new();

        public Influence(Environment env)
        {
            foreach (var name in env.GetNames())
                Dict[name] = name;
        }

        public static bool operator ==(Influence? a, Influence? b)
        {
            if (a is null || b is null)
                return a == b;

            return a.Equals(b);
        }

        public static bool operator !=(Influence? a, Influence? b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Influence b)
                return false;

            foreach (var entry in Dict)
                if (b.Dict.ContainsKey(entry.Key))
                    if (!b.Dict[entry.Key].Equals(Dict[entry.Key]))
                        return false;

            return true;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Dict);
        }

        public override string ToString()
        {
            return string.Join(", ", Dict
                .Where(prop => !prop.Value.Equals(prop.Key))
                .Select(prop => prop.Key + " => " + prop.Value));
        }
    }
}
