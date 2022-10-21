using BarelyFunctionnal.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Executions
{
    public class UnknownExecution : Execution
    {
        public List<Executable> Parameters { get; }
        public bool Executed { get; set; }
        public Execution? Child { get; set; }

        public UnknownExecution(Either<Execution, ExecutionRoot> parent, List<Executable> values) : base(parent)
        {
            Parameters = values;
        }

        public override void ExecuteNext()
        {
            if (!Executed)
            {
                Executed = true;
                var execute = UnknownFunction.Execute(this);
                if (execute)
                {
                    Child = Parameters[0].GetExecution(this, new());
                    Child.ExecuteNext();
                }
            }
            else
                ExecuteParent();
        }

        public override Execution Copy(Either<Execution, ExecutionRoot> parent, Dictionary<Environment, Environment> envs)
        {
            var parameters = Parameters.Select(p => p.Copy(envs)).ToList();
            var copy = new UnknownExecution(parent, parameters);
            copy.Child = Child?.Copy(copy, envs);
            return copy;
        }
    }
}
