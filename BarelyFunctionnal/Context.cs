using BarelyFunctionnal.Syntax;
using System.Collections.Generic;
using System.Text;

namespace BarelyFunctionnal
{
    public class Context
    {
        private LinkedList<List<Instruction>> Memory { get; } = new LinkedList<List<Instruction>>();
        private LinkedListNode<List<Instruction>> Pointer { get; set; }

        public Context()
        {
            AddMemory();
            Reset();
        }

        public void IncrementPointer()
        {
            if (Pointer.Next == null)
                AddMemory();
            Pointer = Pointer.Next;
        }

        private void AddMemory()
        {
            Memory.AddLast(new LinkedListNode<List<Instruction>>(new()));
        }

        public void Execute()
        {
            var function = Pointer.Value;
            Reset();
            foreach (var inst in function)
                inst.Execute(this);
        }

        private void Reset()
        {
            Pointer = Memory.First;
        }

        public void Set(Loading function)
        {
            Pointer.Value = function.Instructions;
            Reset();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var i = 0;
            foreach (var function in Memory)
            {
                builder.Append(i++).Append(" : (");
                foreach (var inst in function)
                    builder.Append(inst);
                builder.Append(')').AppendLine();
            }
            return builder.ToString();
        }
    }
}
