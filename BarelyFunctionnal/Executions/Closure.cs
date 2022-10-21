using BarelyFunctionnal.Model;
using BarelyFunctionnal.Utils;
using System.Collections.Generic;

namespace BarelyFunctionnal.Executions
{
    public class Closure : Executable
    {
        public Environment Environment { get; }
        public Function Function { get; }

        public Closure() : this(new(null, new()), new(new(), new())) { }

        public Closure(Environment env, Function function)
        {
            Environment = env;
            Function = function;
        }

        public Executable Copy(Dictionary<Environment, Environment> envs)
        {
            return new Closure(Environment.Copy(envs), Function);
        }

        public Execution GetExecution(Either<Execution, ExecutionRoot> parent, List<Executable> paras)
        {
            var parameters = Function.ParametersToDictionary(paras);
            var env = new Environment(Environment, parameters);

            return new ClosureExecution(parent, Function, env);
        }
    }
}
