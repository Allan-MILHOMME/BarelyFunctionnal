using System;
using System.IO;

namespace BarelyFunctionnal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mainFunction = Parser.Parse(File.ReadAllText(args[0]));
            var context = new Context();
            foreach (var inst in mainFunction)
                inst.Execute(context);
            Console.WriteLine(context);
        }
    }
}
