using BarelyFunctionnal.Model;
using BarelyFunctionnal.Utils;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Executions
{
    public class ClosureExecution : Execution
    {
        public Dictionary<Instruction, Execution> ChildrenExecution { get; set; } = new();
        public Function Function { get; }
        public List<Instruction> RemainingInstructions { get; }
        public Environment Environment { get; }

        public ClosureExecution(Either<Execution, ExecutionRoot> parent, Function function, Environment env)
            : base(parent)
        {
            Function = function;
            RemainingInstructions = function.Instructions.ToList();
            Environment = env;
        }

        private ClosureExecution(Either<Execution, ExecutionRoot> parent, Function function, Environment env, List<Instruction> insts)
            : base(parent)
        {
            Function = function;
            RemainingInstructions = insts;
            Environment = env;
        }

        public override void ExecuteNext()
        {
            if (RemainingInstructions.Any())
            {
                var instruction = RemainingInstructions.First();
                RemainingInstructions.RemoveAt(0);
                var execution = instruction.Execute(Environment, this);
                if (execution != null)
                    ChildrenExecution[instruction] = execution;
                ExecuteNext();
            }
            else
                ExecuteParent();
        }

        public override Execution Copy(Either<Execution, ExecutionRoot> parent, Dictionary<Environment, Environment> envs)
        {
            var copy = new ClosureExecution(parent, Function, Environment.Copy(envs), RemainingInstructions.ToList());
            var childrenCopy = ChildrenExecution.ToDictionary(v => v.Key, v => v.Value.Copy(copy, envs));
            copy.ChildrenExecution = childrenCopy;
            return copy;
        }
    }
}
