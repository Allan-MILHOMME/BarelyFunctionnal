﻿using BarelyFunctionnal.Execution;
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
            foreach (var arg in args)
            {
                var program = File.ReadAllText(arg);
                var function = Parser.Parse(program);
                functions.Add(function);
                Compiler.CompileMain(function, names);
                names.AddRange(function.ParametersNames);
            }

            var environment = Environment.Empty;
            foreach (var function in functions)
                new Closure(environment, function).Execute(new());
        }
    }
}
