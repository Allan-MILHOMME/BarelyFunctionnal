using System.Collections.Generic;

namespace BarelyFunctionnal.Analysis
{
    public interface AnalysisPossibleValue
    {
        // TODO Add current OcurrenceCount
        // TODO Valeur self quelque part ? Peut etre en tant que valeur possible ?
        public void Analyse(List<AnalysisPossibleValue> parameters, OccurenceCount? currentOccurenceCount);
    }
}
