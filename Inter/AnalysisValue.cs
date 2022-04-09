using Inter.Syntax;

namespace Inter
{
    public interface AnalysisValue
    {

    }

    public class StaticAnalysisValue : AnalysisValue
    {
        public Closure Closure { get; }

        public StaticAnalysisValue(Closure closure)
        {
            Closure = closure;
        }
    }

    public class NameAnalysisValue : AnalysisValue
    {
        public Name Name { get; }
        public NameAnalysisValue(Name name)
        {
            Name = name;
        }
    }
}
