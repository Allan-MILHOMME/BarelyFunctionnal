using System.Collections.Generic;

namespace BarelyFunctionnal.Execution
{
    public interface Executable
    {
        public void Execute(List<Executable> paras);
        public Executable Copy(Dictionary<Environment, Environment> envs);
    }
}
