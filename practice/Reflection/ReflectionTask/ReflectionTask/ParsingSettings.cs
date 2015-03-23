namespace NetMentoring.Epam.ReflectionTask
{
    public class ParsingSettings
    {
        public string Location { get; set; }
        public string Url { get; set; }
        public string Options { get; set; }


        public override int GetHashCode()
        {
            return Location.GetHashCode() ^ Url.GetHashCode() ^ Options.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var parser = obj as ParsingSettings;
            if (parser == null) return false;
            return (Location == parser.Location) && (Url == parser.Url) && (Options == parser.Options);
        }

        public bool Equals(ParsingSettings parser)
        {
            if ((System.Object)parser == null) return false;
            return (Location == parser.Location) && (Url == parser.Url) && (Options == parser.Options);
        }
    }
}
