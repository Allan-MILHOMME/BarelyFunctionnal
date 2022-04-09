using System.Collections.Generic;

namespace Inter.Syntax
{
    public interface InterValue
    {
        public void Compile(List<Name> currentNames);
        public Executable GetValue(Environment stack, CallStack currentStack);
    }
}
