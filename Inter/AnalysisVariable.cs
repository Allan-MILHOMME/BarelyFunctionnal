using System.Collections.Generic;

namespace Inter
{
    public class AnalysisVariable
    {
        public List<AssignationEvent> Events { get; } = new() { new() };
    }
}