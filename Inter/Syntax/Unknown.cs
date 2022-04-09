using System.Collections.Generic;

namespace Inter.Syntax
{
    public class Unknown : InterValue
    {
        public static Unknown Instance { get; } = new Unknown();

        private Unknown() { }

        public void Compile(List<Name> currentNames) { }

        public Executable GetValue(Environment stack, CallStack currentStack)
        {
            return UnknownFunction.Instance;
        }

        public override bool Equals(object? o)
        {
            return o == Instance;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
