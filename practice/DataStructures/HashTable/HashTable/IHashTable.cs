namespace Epam.NetMentoring.HashTable
{
    //IT: must have been public!
    public interface IHashTable
    {
        bool Contains(WordEntity key);

        //IT: use indexers instead!
        void Add(WordEntity key, WordDefinition value);
        WordDefinition Get(WordEntity key);
        
    }
}
