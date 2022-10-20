using BarelyFunctionnal.Execution;
using BarelyFunctionnal.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Analysis
{
    public class EnvironmentNode
    {
        public Either<Environment, Pair<EnvironmentNode>> Value { get; }

        public EnvironmentNode(Either<Environment, Pair<EnvironmentNode>> value)
        {
            Value = value;
        }

        public List<Environment> GetEnvironments()
        {
            return Value.Select(
                left => new List<Environment>() { left },
                right => right.Item1.GetEnvironments().Concat(right.Item2.GetEnvironments()).ToList()
            );
        }
    }
}
