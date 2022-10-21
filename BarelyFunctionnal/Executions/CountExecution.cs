using BarelyFunctionnal.Utils;
using System.Collections.Generic;

namespace BarelyFunctionnal.Executions
{
    public class CountExecution : Execution
    {
        public CountFunction Function { get; }

        public CountExecution(Either<Execution, ExecutionRoot> parent, CountFunction function) : base(parent)
        {
            Function = function;
        }

        public override void ExecuteNext()
        {
            Function.Inc();
            ExecuteParent();
        }

        public override Execution Copy(Either<Execution, ExecutionRoot> parent, Dictionary<Environment, Environment> envs)
        {
            return new CountExecution(parent, Function.Copy());
        }
    }
}
