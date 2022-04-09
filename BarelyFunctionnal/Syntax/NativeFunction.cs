using System.Collections.Generic;

namespace BarelyFunctionnal.Syntax
{
    public class NativeFunction : Instruction
    {
        public static NativeFunction Plus { get; } = new NativeFunction('+');
        public static NativeFunction Exec { get; } = new NativeFunction('!');
        public static NativeFunction Unknown { get; } = new NativeFunction('?');
        public static NativeFunction Address { get; } = new NativeFunction('&');
        public static NativeFunction Copy { get; } = new NativeFunction('>');

        public static List<NativeFunction> Functions { get; } = new List<NativeFunction>
        {
            Plus, Exec, Unknown, Address, Copy
        };

        public char Character { get; }
        private NativeFunction(char c) { Character = c; }

        public void Execute(Context context)
        {
            if (this == Plus)
                context.IncrementPointer();
            if (this == Exec)
                context.Execute();
        }

        public static NativeFunction From(char c)
        {
            return Functions.Find(f => f.Character == c);
        }

        public override string ToString()
        {
            return Character.ToString();
        }
    }
}
