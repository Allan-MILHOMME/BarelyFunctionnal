using System;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Execution
{
    public class UnknownFunction : Executable
    {
        public static UnknownFunction Instance { get; } = new();
        private UnknownFunction() { }
        public void Execute(List<Executable> paras, bool copyEnvironment)
        {
            if (paras.Any())
            {
                var option = CountFunction.Count(paras.First());

                if (option == 0 && paras.Count > 2)
                    if (int.TryParse(Console.ReadLine(), out var intValue))
                        for (var i = 0; i < intValue; i++)
                            paras[1].Execute(new(), false);

                if (option == 1 && paras.Count > 2)
                    Console.WriteLine(CountFunction.Count(paras[1]));

                if (option == 2 && paras.Count > 2)
                    for (var i = 0; i < new Random().Next(); i++)
                        paras[1].Execute(new(), false);
            }
        }
    }
}
