using BarelyFunctionnal.Executions;
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

            var executions = new List<ExecutionRoot>();
            var executionRoot = new ExecutionRoot(exe => executions.Add(exe));
            executions.Add(executionRoot);
            var environment = Environment.Empty;

            foreach (var function in functions)
            {
                var env = new Environment(environment, function.ParametersToDictionary(new()));
                var exe = new ClosureExecution(executionRoot, function, env);
                executionRoot.Children.Add(exe);
                exe.ExecuteNext();
                environment = new Environment(environment, exe.Environment.Values);
            }
        }
    }
}
