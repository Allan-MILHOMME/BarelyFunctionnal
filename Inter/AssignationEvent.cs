namespace Inter
{
    public class AssignationEvent
    {
        public OccurenceNumber? Occurences { get; }
        public AnalysisValue Value { get; }

        public AssignationEvent()
        {
            Value = new StaticAnalysisValue(new Closure());
        }
    }
}
