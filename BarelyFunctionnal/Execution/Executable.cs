using System.Collections.Generic;

namespace BarelyFunctionnal.Execution
{
    public interface Executable
    {
        public void Execute(List<Executable> paras, bool copyEnvironment);
    }
}
