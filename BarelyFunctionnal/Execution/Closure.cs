using BarelyFunctionnal.Model;
using System.Collections.Generic;

namespace BarelyFunctionnal.Execution
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

        public void Analyse(List<Executable> parameters)
        {
            var paras = Function.ParametersToDictionary(parameters);
            var newEnv = new Environment(Environment, paras);

            foreach (var inst in Function.Instructions)
                inst.Execute(newEnv);
        }

        public void Execute(List<Executable> parameters)
        {
            var paras = Function.ParametersToDictionary(parameters);
            var newEnv = new Environment(Environment, paras);

            foreach (var inst in Function.Instructions)
                inst.Execute(newEnv);
        }

        public Executable Copy(Dictionary<Environment, Environment> envs)
        {
            return new Closure(Environment.Copy(envs), Function);
        }
    }
}
