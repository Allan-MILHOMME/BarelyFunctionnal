namespace BarelyFunctionnal.Analysis
{
    public class OccurenceCount
    {
        public OccurenceCount? Parent { get; }
        public OccurenceCount(OccurenceCount? parent)
        {
            Parent = parent;
        }
    }
}
