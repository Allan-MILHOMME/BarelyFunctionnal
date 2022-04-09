using BarelyFunctionnal.Execution;
using System.Collections.Generic;

namespace BarelyFunctionnal.Syntax
{
    public interface Value
    {
        public void Compile(List<Name> currentNames);
        public Executable GetValue(Environment stack);
    }
}
