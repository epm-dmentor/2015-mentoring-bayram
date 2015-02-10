namespace Epam.NetMentoring.HashTable
{
    interface IHashTable
    {
        bool Contains(WordEntity key);
        void Add(WordEntity key, WordDefinition value);
        WordDefinition Get(WordEntity key);
        
    }
}
