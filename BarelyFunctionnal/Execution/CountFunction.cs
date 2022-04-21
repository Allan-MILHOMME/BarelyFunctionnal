using System.Collections.Generic;

namespace BarelyFunctionnal.Execution
{
    public class CountFunction : Executable
    {
        // TODO Remove static, les appels a cette fonction peuvent etre l'un dans l'autre
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
