using BarelyFunctionnal.Syntax;
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

        public void Execute(List<Executable> parameters)
        {
            var paras = Function.ParametersToDictionary(parameters);
            var newEnv = new Environment(Environment, paras);

            foreach (var inst in Function.Instructions)
                inst.Execute(newEnv);
        }
    }

    public class UnknownFunction : Executable
    {
        public static UnknownFunction Instance { get; } = new();
        private UnknownFunction() { }
        public void Execute(List<Executable> paras)
        {

        }
    }
}
