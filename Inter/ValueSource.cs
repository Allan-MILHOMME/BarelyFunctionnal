using Inter.Syntax;
using LanguageExt;

namespace Inter
{
    public class ValueSource
    {
        public Either<Name, Function> Source { get; }

        public ValueSource(Either<Name, Function> e)
        {
            Source = e;
        }
    }
}
