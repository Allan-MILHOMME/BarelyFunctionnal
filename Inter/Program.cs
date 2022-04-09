using System.IO;

namespace Inter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = File.ReadAllText(args[0]);
            var method = Parser.Parse(program);
            Compiler.CompileMain(method);
            new Closure(new Environment(null, new()), method).Execute(new(), new(), null!);
        }
    }
}
