using System;
using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Executions
{
    public class ExecutionRoot
    {
        public bool ReadNextNatural { get; set; } = true;
        public int NaturalInput { get; set; } = 0;
        public Action<ExecutionRoot> Split { get; }
        public List<Execution> Children { get; set; } = new();

        public ExecutionRoot(Action<ExecutionRoot> split)
        {
            Split = split;
        }

        private ExecutionRoot(bool read, int input, Action<ExecutionRoot> split)
        {
            ReadNextNatural = read;
            NaturalInput = input;
            Split = split;
        }

        public ExecutionRoot Copy(Dictionary<Environment, Environment> envs)
        {
            var copy = new ExecutionRoot(ReadNextNatural, NaturalInput, Split);
            var childrenCopy = Children.Select(child => child.Copy(copy, envs)).ToList();
            copy.Children = childrenCopy;
            return copy;
        }
    }
}
