using System;

namespace BarelyFunctionnal.Utils
{
    public class Pair<T> : Tuple<T, T>
    {
        public Pair(T t1, T t2) : base(t1, t2) { }

        public void Do(Action<T> act)
        {
            act(Item1);
            act(Item2);
        }
    }
}
