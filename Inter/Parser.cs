using BarelyFunctionnal.Utils;
using Inter.Syntax;
using Pidgin;
using System.Collections.Generic;
using System.Linq;
using static Pidgin.Parser;

namespace Inter
{
    public class Parser
    {
        public static Parser<char, InterInstruction> InstructionParser { get; } = Rec(() => OneOf(Try(AssignmentParser!.OfType<InterInstruction>()), Try(MethodCallParser!.OfType<InterInstruction>())));
        public static Parser<char, Name> NameParser { get; } = OneOf(Letter, Digit).AtLeastOnceString().Select(s => new Name(s));
        public static Parser<char, InterValue> ValueParser { get; } = Rec(() =>
            OneOf(Try(NameParser.OfType<InterValue>()), MethodParser!.OfType<InterValue>(), Char('?').ThenReturn(Unknown.Instance).OfType<InterValue>()));
        public static Parser<char, List<Name>> ParametersParser { get; } =
            NameParser.Separated(Char(',').Between(SkipWhitespaces))
            .Between(Char('[').Before(SkipWhitespaces), SkipWhitespaces.Before(Char(']')))
            .Optional().Select(r => r.HasValue ? r.Value.ToList() : new List<Name>());
        public static Parser<char, Function> MethodParser { get; } =
            Map((parameters, insts) => new Function(parameters, insts.ToList()),
                ParametersParser.Before(SkipWhitespaces),
                InstructionParser.SurroundedByWhitespaces().Between(Char('{'), Char('}')));
        public static Parser<char, FunctionCall> MethodCallParser { get; } =
            Map((caller, parameters) => new FunctionCall(caller, parameters.ToList()),
            ValueParser,
            ValueParser.Separated(Char(',').Between(SkipWhitespaces))
            .Between(Char('(').Before(SkipWhitespaces), SkipWhitespaces.Before(Char(')'))).Select(v => v.ToList()));
        public static Parser<char, Assignment> AssignmentParser { get; } =
            Map((name, value) => new Assignment(name, value),
                NameParser.Before(SkipWhitespaces).Before(Char('=')),
                SkipWhitespaces.Then(ValueParser));

        public static Function Parse(string program)
        {
            return MethodParser.ParseOrThrow(program);
        }
    }
}
