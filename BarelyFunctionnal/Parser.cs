using BarelyFunctionnal.Syntax;
using BarelyFunctionnal.Utils;
using Pidgin;
using System.Collections.Generic;
using System.Linq;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace BarelyFunctionnal
{
    public class Parser
    {
        public static Parser<char, Instruction> InstructionParser { get; } = Rec(() =>
        OneOf(Try(NativeFunctionParser.OfType<Instruction>()), LoadingParser.OfType<Instruction>()));
        public static Parser<char, NativeFunction> NativeFunctionParser { get; } =
            OneOf(Char('+'), Char('!'), Char('?'), Char('&'), Char('>')).Select(c => NativeFunction.From(c));

        public static Parser<char, Loading> LoadingParser { get; } =
            InstructionParser.SurroundedByWhitespaces().Between(Char('('), Char(')')).Select(l => new Loading(l.ToList()));

        public static List<Instruction> Parse(string program)
        {
            return InstructionParser.SurroundedByWhitespaces().Before(End).ParseOrThrow(program).ToList();
        }
    }
}
