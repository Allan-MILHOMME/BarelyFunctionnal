using BarelyFunctionnal.Analysis;
using BarelyFunctionnal.Execution;
using BarelyFunctionnal.Model;
using System.Collections.Generic;
using System.IO;

namespace BarelyFunctionnal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var names = new List<Name>();
            var functions = new List<Function>();
            foreach (var arg in args)
            {
                var program = File.ReadAllText(arg);
                var function = Parser.Parse(program);
                functions.Add(function);
                Compiler.CompileMain(function, names);
                names.AddRange(function.ParametersNames);
            }

            var analysisEnvironment = new EnvironmentNode(Environment.Empty);
            foreach (var function in functions)
            {
                foreach (var env in analysisEnvironment.GetEnvironments())
                {
                    var closure = new Closure(env, function);
                    closure.Execute(new(), false);
                    var newEnv = closure.Function.ParametersToAnalysisDictionary(new());
                    analysisEnvironment = analysisEnvironment.AddParameters(newEnv);
                }
            }

            var environment = Environment.Empty;
            foreach (var function in functions)
            {
                var closure = new Closure(environment, function);
                closure.Execute(new());
                var newEnv = closure.Function.ParametersToDictionary(new());
                environment = new Environment(environment, newEnv);
            }
        }
    }
}
