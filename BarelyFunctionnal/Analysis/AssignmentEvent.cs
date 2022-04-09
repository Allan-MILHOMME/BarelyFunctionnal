namespace BarelyFunctionnal.Analysis
{
    public class AssignmentEvent
    {
        public OccurenceCount? Count { get; }
        public AnalysisValue Value { get; }

        public AssignmentEvent(AnalysisValue value, OccurenceCount? count)
        {
            Value = value;
            Count = count;
        }
    }
}
