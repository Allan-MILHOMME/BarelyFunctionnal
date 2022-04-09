using Inter.Syntax;
using System.Collections.Generic;

namespace Inter
{
    public class Compiler
    {
        public static void CompileMain(Function main)
        {
            main.Compile(new List<Name>());
        }
    }
}
