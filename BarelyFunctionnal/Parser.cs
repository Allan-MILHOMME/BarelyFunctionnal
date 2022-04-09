using BarelyFunctionnal.Syntax;
using BarelyFunctionnal.Utils;
using Pidgin;
using System.Collections.Generic;
using System.Linq;
using static Pidgin.Parser;

namespace BarelyFunctionnal
{
    public class Parser
    {
        public static Parser<char, Instruction> InstructionParser { get; } = Rec(() => OneOf(Try(AssignmentParser!.OfType<Instruction>()), Try(FunctionCallParser!.OfType<Instruction>())));
        public static Parser<char, Name> NameParser { get; } = OneOf(Letter, Digit).AtLeastOnceString().Select(s => new Name(s));
        public static Parser<char, Value> ValueParser { get; } = Rec(() =>
            OneOf(Try(NameParser.OfType<Value>()), FunctionParser!.OfType<Value>(), Char('?').ThenReturn(Unknown.Instance).OfType<Value>()));
        public static Parser<char, List<Name>> ParametersParser { get; } =
            NameParser.Separated(Char(',').Between(SkipWhitespaces))
            .Between(Char('[').Before(SkipWhitespaces), SkipWhitespaces.Before(Char(']')))
            .Optional().Select(r => r.HasValue ? r.Value.ToList() : new List<Name>());
        public static Parser<char, Function> FunctionParser { get; } =
            Map((parameters, insts) => new Function(parameters, insts.ToList()),
                ParametersParser.Before(SkipWhitespaces),
                InstructionParser.SurroundedByWhitespaces().Between(Char('{'), Char('}')));
        public static Parser<char, FunctionCall> FunctionCallParser { get; } =
            Map((caller, parameters) => new FunctionCall(caller, parameters.ToList()),
            ValueParser.Before(SkipWhitespaces),
            ValueParser.Separated(Try(Char(',').Between(SkipWhitespaces)))
            .Between(Char('(').Before(SkipWhitespaces), SkipWhitespaces.Before(Char(')'))).Select(v => v.ToList()));
        public static Parser<char, Assignment> AssignmentParser { get; } =
            Map((name, value) => new Assignment(name, value),
                NameParser.Before(SkipWhitespaces).Before(Char('=')),
                SkipWhitespaces.Then(ValueParser));

        public static Function Parse(string program)
        {
            return FunctionParser.ParseOrThrow(program);
        }
    }
}
