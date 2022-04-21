using BarelyFunctionnal.Model;
using System.Collections.Generic;

namespace BarelyFunctionnal.Execution
{
    public class Closure : Executable
    {
        public Closure(Environment env, Function function)
        {
            Environment = env;
            Function = function;
        }

        public Closure()
        {
            Function = new Function(new(), new());
            Environment = new Environment(null, new());
        }

        public Environment Environment { get; }
        public Function Function { get; }

        public void Execute(List<Executable> parameters, bool copyEnvironment)
        {
            var paras = Function.ParametersToDictionary(parameters);
            var env = copyEnvironment ? Environment.Copy() : Environment;
            var newEnv = new Environment(env, paras);

            foreach (var inst in Function.Instructions)
                inst.Execute(newEnv);
        }
    }
}
