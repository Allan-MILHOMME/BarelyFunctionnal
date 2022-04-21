namespace BarelyFunctionnal.Analysis
{
    public class AssignmentEvent
    {
        public OccurenceCount? Count { get; }
        public AnalysisPossibleValue Value { get; }

        public AssignmentEvent(AnalysisPossibleValue value, OccurenceCount? count)
        {
            Value = value;
            Count = count;
        }
    }
}
