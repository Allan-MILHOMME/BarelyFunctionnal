using Pidgin;
using System.Collections.Generic;
using static Pidgin.Parser;

namespace BarelyFunctionnal.Utils
{
    public static class PidginUtils
    {
        public static Parser<TToken, IEnumerable<T>> SurroundedBy<TToken, T, T2>(this Parser<TToken, T> parser, Parser<TToken, T2> ignored)
            => ignored.Then(parser.SeparatedAndTerminated(ignored));

        public static Parser<char, IEnumerable<T>> SurroundedByWhitespaces<T>(this Parser<char, T> parser)
            => parser.SurroundedBy(SkipWhitespaces);
    }
}
