using BarelyFunctionnal.Executions;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Model
{
    public class Function : Value
    {
        public List<Name> ParametersNames { get; }
        public List<Instruction> Instructions { get; }

        public Function(List<Name> parametersNames, List<Instruction> instructions)
        {
            ParametersNames = parametersNames;
            Instructions = instructions;

        }

        public void Compile(List<Name> currentNames)
        {
            var nameList = currentNames.Concat(ParametersNames).ToList();

            foreach (var instruction in Instructions)
                instruction.Compile(nameList);
        }

        public Executable GetValue(Environment stack)
        {
            return new Closure(stack, this);
        }

        public Dictionary<Name, Executable> ParametersToDictionary(List<Executable> parameters)
        {
            var paras = new Dictionary<Name, Executable>();
            for (var i = 0; i < ParametersNames.Count; i++)
            {
                if (parameters.Count > i)
                    paras[ParametersNames[i]] = parameters[i];
                else
                    paras[ParametersNames[i]] = new Closure();
            }
            return paras;
        }
    }
}
