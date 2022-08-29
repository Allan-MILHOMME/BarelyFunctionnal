using System;
using System.Collections.Generic;

namespace BarelyFunctionnal.Execution
{
    public class UnknownFunction : Executable
    {
        public static bool ReadNextNatural { get; set; } = true;
        public static int NaturalInput { get; set; } = 0;
        public static UnknownFunction Instance { get; } = new();
        private UnknownFunction() { }
        public void Execute(List<Executable> paras, bool copyEnvironment)
        {
            if (paras.Count > 1)
            {
                var mode = CountFunction.Count(paras[1]);
                if (Execute(mode, paras))
                    paras[0].Execute(new(), false);
            }
        }

        public static bool Execute(int mode, List<Executable> paras)
        {
            if (mode == 0 && paras.Count > 2)
                Console.WriteLine(CountFunction.Count(paras[2]));

            if (mode == 1)
            {
                if (ReadNextNatural)
                {
                    ReadNextNatural = false;
                    NaturalInput = int.Parse(Console.ReadLine()!);
                }

                if (NaturalInput == 0)
                    ReadNextNatural = true;
                else
                {
                    NaturalInput--;
                    return true;
                }
            }

            if (mode == 2)
                if (new Random().Next() % 2 == 0)
                    return true;

            return false;
        }
    }
}
