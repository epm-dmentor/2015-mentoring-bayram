namespace Epam.NetMentoring.HashTable
{
    public class WordDefinition
    {
        public string Definition { get; set; }

        public override int GetHashCode()
        {
            return Definition.GetHashCode();
        }

        public bool Equals(WordDefinition definition)
        {
            if (definition == null)
            {
                return false;
            }
            return Definition == definition.Definition;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var definition = obj as WordDefinition;

            if (definition == null) return false;

            return Definition == definition.Definition;

        }
    }
}
