using BarelyFunctionnal.Execution;
using System.Collections.Generic;

namespace BarelyFunctionnal.Syntax
{
    public BarelyFunctionnalface Value
    {
        public void Compile(List<Name> currentNames);
        public Executable GetValue(Environment stack);
    }
}
