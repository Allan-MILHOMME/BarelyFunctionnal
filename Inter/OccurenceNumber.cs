namespace Inter
{
    public class OccurenceNumber
    {
        // Si une fonction unknown est executée un nombre variable de fois, on le marque ici
        public OccurenceNumberGenerator? Parent { get; }
        // TODO La précision de cette valeur variera surement selon le niveau
        public int? Index { get; }
    }

    public class OccurenceNumberGenerator
    {
        public OccurenceNumber Occurence { get; }

        public OccurenceNumberGenerator(OccurenceNumber n)
        {
            Occurence = n;
        }
    }
}
