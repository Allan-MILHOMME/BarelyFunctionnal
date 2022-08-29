using System;

namespace BarelyFunctionnal.Utils
{
    public class Either<L, R> where L : notnull where R : notnull
    {
        public L? Left { get; }
        public R? Right { get; }

        public Either(L t) { Left = t; }
        public Either(R t2) { Right = t2; }

        public Res Select<Res>(Func<L, Res> left, Func<R, Res> right)
        {
            if (Left != null)
                return left(Left);
            return right(Right!);
        }

        public void Do(Action<L> left, Action<R> right)
        {
            if (Left != null)
                left(Left);
            else
                right(Right!);
        }

        public static implicit operator Either<L, R>(L left)
        {
            return new Either<L, R>(left);
        }

        public static implicit operator Either<L, R>(R right)
        {
            return new Either<L, R>(right);
        }

        public override string? ToString()
        {
            return Select(left => left.ToString(), right => right.ToString());
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Either<L, R> either)
                return false;
            return Select(left => left.Equals(either.Left), right => right.Equals(either.Right));
        }

        public override int GetHashCode()
        {
            return Select(l => l.GetHashCode(), r => r.GetHashCode());
        }
    }
}
