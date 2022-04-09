using Inter.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Inter
{
    public class Function : InterValue
    {
        public Function(List<Name> parametersNames, List<InterInstruction> instructions)
        {
            ParametersNames = parametersNames;
            Instructions = instructions;

        }

        public List<Name> ParametersNames { get; }
        public List<InterInstruction> Instructions { get; }

        public void Compile(List<Name> currentNames)
        {
            var nameList = currentNames.Concat(ParametersNames).ToList();

            foreach (var instruction in Instructions)
                instruction.Compile(nameList);
        }

        public Executable GetValue(Environment stack, CallStack currentStack)
        {
            return new Closure(stack, this);
        }
    }
}
