using System.Collections.Generic;

namespace BarelyFunctionnal.Execution
{
    public class CountFunction : Executable
    {
        private static int CountValue { get; set; }
        public static CountFunction Instance { get; } = new();
        private CountFunction() { }
        public void Execute(List<Executable> paras, bool copyEnvironment)
        {
            CountValue++;
        }

        public static int Count(Executable exe)
        {
            CountValue = 0;
            exe.Execute(new List<Executable> { Instance }, true);
            return CountValue;
        }
    }
}
