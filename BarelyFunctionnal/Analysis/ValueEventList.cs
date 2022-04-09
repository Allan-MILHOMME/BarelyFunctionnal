using System.Collections.Generic;

namespace BarelyFunctionnal.Analysis
{
    public class ValueEventList : AnalysisValue
    {
        public List<AssignmentEvent> Events { get; }

        public ValueEventList(List<AssignmentEvent> events)
        {
            Events = events;
        }
    }
}
