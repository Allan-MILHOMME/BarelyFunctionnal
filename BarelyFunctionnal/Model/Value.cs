using BarelyFunctionnal.Executions;
using System.Collections.Generic;

namespace BarelyFunctionnal.Model
{
    public interface Value
    {
        public void Compile(List<Name> currentNames);
        public Executable GetValue(Environment stack);
    }
}
