using BarelyFunctionnal.Utils;
using System;
using System.Collections.Generic;

namespace BarelyFunctionnal.Executions
{
    public class UnknownFunction : Executable
    {
        public static UnknownFunction Instance { get; } = new();
        private UnknownFunction() { }

        public static bool Execute(UnknownExecution execution)
        {
            if (execution.Parameters.Count == 0)
                return false;

            var mode = CountFunction.Count(execution.Parameters[1]);

            if (mode == 0 && execution.Parameters.Count > 2)
                Console.WriteLine(CountFunction.Count(execution.Parameters[2]));

            if (mode == 1)
            {
                if (execution.Root.ReadNextNatural)
                {
                    execution.Root.ReadNextNatural = false;
                    execution.Root.NaturalInput = int.Parse(Console.ReadLine()!);
                }

                if (execution.Root.NaturalInput == 0)
                    execution.Root.ReadNextNatural = true;
                else
                {
                    execution.Root.NaturalInput--;
                    return true;
                }
            }

            if (mode == 2)
                if (new Random().Next() % 2 == 0)
                    return true;

            return false;
        }

        public Executable Copy(Dictionary<Environment, Environment> envs)
        {
            return Instance;
        }

        public Execution GetExecution(Either<Execution, ExecutionRoot> parent, List<Executable> paras)
        {
            return new UnknownExecution(parent, paras);
        }
    }
}
