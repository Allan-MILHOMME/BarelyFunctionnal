using BarelyFunctionnal.Utils;
using System.Collections.Generic;

namespace BarelyFunctionnal.Executions
{
    public interface Executable
    {
        public Executable Copy(Dictionary<Environment, Environment> envs);
        public Execution GetExecution(Either<Execution, ExecutionRoot> parent, List<Executable> paras);
    }
}
