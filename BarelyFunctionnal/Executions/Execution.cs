using BarelyFunctionnal.Utils;
using System.Collections.Generic;

namespace BarelyFunctionnal.Executions
{
    public abstract class Execution
    {
        public Either<Execution, ExecutionRoot> Parent { get; }

        public Execution(Either<Execution, ExecutionRoot> parent)
        {
            Parent = parent;
        }

        public abstract void ExecuteNext();

        public void ExecuteParent()
        {
            Parent.Do(left => left.ExecuteNext(), right => { });
        }

        public ExecutionRoot Root => Parent.Select(left => left.Root, right => right);

        public abstract Execution Copy(Either<Execution, ExecutionRoot> parent, Dictionary<Environment, Environment> envs);
    }
}
