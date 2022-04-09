using BarelyFunctionnal.Syntax;
using System.Collections.Generic;

namespace BarelyFunctionnal
{
    public class Compiler
    {
        public static void CompileMain(Function main, List<Name> declaredNames)
        {
            main.Compile(declaredNames);
        }
    }
}
