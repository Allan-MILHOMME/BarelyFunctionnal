using BarelyFunctionnal.Execution;
using BarelyFunctionnal.Syntax;
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
            var instructions = new List<Instruction>();
            foreach (var arg in args)
            {
                var program = File.ReadAllText(arg);
                var function = Parser.Parse(program);
                functions.Add(function);
                Compiler.CompileMain(function, names);
                names.AddRange(function.ParametersNames);
                instructions.AddRange(function.Instructions);
            }

            var mergedFunction = new Function(names, instructions);
            var environment = Environment.Empty;
            var closure = new Closure(environment, mergedFunction);
            closure.Execute(new(), false);
        }
    }
}
