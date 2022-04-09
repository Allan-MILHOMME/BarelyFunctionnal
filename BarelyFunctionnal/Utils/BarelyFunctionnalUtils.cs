using BarelyFunctionnal.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Utils
{
    public static class BarelyFunctionnalUtils
    {
        public static List<Instruction> PointerToCurrentStack()
        {
            return new List<Instruction> { NativeFunction.Plus, NativeFunction.Exec };
        }

        public static List<Instruction> PointerToCurrentStackValues()
        {
            return PointerToCurrentStack().Concat(new List<Instruction> { NativeFunction.Plus, NativeFunction.Plus }).ToList();
        }

        public static List<Instruction> PointerToPreviousStackValues()
        {
            return PointerToCurrentStack().Concat(new List<Instruction> { NativeFunction.Exec, NativeFunction.Plus, NativeFunction.Plus }).ToList();
        }

        public static List<Instruction> SetLastUsedAddress()
        {
            return new List<Instruction> { NativeFunction.Address, NativeFunction.Plus, NativeFunction.Plus, NativeFunction.Copy };
        }

        public static List<Instruction> PointerToLastUsedAddress()
        {
            return new List<Instruction> { NativeFunction.Plus, NativeFunction.Exec };
        }



        public static List<Instruction> Forward(int amount)
        {
            return Enumerable.Repeat((Instruction)NativeFunction.Plus, amount).ToList();
        }

        public static List<Instruction> Load(List<Instruction> insts)
        {
            return new List<Instruction> { new Loading(insts) };
        }

        public static List<Instruction> Load(params Instruction[] insts)
        {
            return Load(insts.ToList());
        }
    }
}
