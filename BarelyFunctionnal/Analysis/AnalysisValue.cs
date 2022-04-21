using System.Collections.Generic;
using System.Linq;

namespace BarelyFunctionnal.Analysis
{
    public class AnalysisValue : AnalysisPossibleValue
    {
        public List<AssignmentEvent> Events { get; }

        public AnalysisValue(List<AssignmentEvent> events)
        {
            Events = events;
        }

        public void Analyse(List<AnalysisPossibleValue> parameters, OccurenceCount? currentOccurenceCount)
        {
            var l = Events.ToList();
            l.Reverse();
            foreach (var e in l)
            {
                if (e.Count == null)
                {
                    e.Value.Analyse(parameters, currentOccurenceCount);
                    break;
                }
            }
            // TODO
        }
    }
}
