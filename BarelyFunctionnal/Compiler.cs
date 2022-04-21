using BarelyFunctionnal.Model;
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
