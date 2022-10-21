using BarelyFunctionnal.Utils;
using System.Collections.Generic;

namespace BarelyFunctionnal.Executions
{
    public class CountFunction : Executable
    {
        // TODO Remove static, les appels a cette fonction peuvent etre l'un dans l'autre
        private int CountValue { get; set; }
        private CountFunction() { }

        public static int Count(Executable exe)
        {
            // TODO Start new execution
            var root = new ExecutionRoot(root => { });
            var countFunction = new CountFunction();
            var execution = exe.Copy(new()).GetExecution(root, new List<Executable> { countFunction });
            execution.ExecuteNext();
            return countFunction.CountValue;
        }

        public void Inc()
        {
            CountValue++;
        }

        public CountFunction Copy()
        {
            return new CountFunction() { CountValue = CountValue };
        }

        public Executable Copy(Dictionary<Environment, Environment> envs)
        {
            return new CountFunction();
        }

        public Execution GetExecution(Either<Execution, ExecutionRoot> parent, List<Executable> paras)
        {
            return new CountExecution(parent, this);
        }
    }
}
