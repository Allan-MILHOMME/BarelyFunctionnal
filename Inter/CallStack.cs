using System.Collections.Immutable;

namespace Inter
{
    public class CallStack
    {
        public ImmutableStack<CallData> Calls { get; } = ImmutableStack<CallData>.Empty;

        public CallStack(ImmutableStack<CallData> calls)
        {
            Calls = calls;
        }

        public CallStack()
        {
        }

        public CallStack Push(CallData data)
        {
            return new CallStack(Calls.Push(data));
        }
    }
}
