using System.Collections.Generic;

namespace BarelyFunctionnal.Execution
{
    public class CountFunction : Executable
    {
        // TODO Remove static, les appels a cette fonction peuvent etre l'un dans l'autre
        private int CountValue { get; set; }
        private CountFunction() { }
        public void Execute(List<Executable> paras)
        {
            CountValue++;
        }

        public static int Count(Executable exe)
        {
            var countFunction = new CountFunction();
            exe.Copy(new()).Execute(new List<Executable> { countFunction });
            return countFunction.CountValue;
        }

        public Executable Copy(Dictionary<Environment, Environment> envs)
        {
            return new CountFunction();
        }
    }
}
