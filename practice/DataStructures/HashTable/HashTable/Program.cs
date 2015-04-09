namespace Epam.NetMentoring.HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var good = new WordEntity {Type = WordEntity.WordType.Adjective, Word = "Good"};
            var go = new WordEntity { Type = WordEntity.WordType.Verb, Word = "Go" };
            var house = new WordEntity { Type = WordEntity.WordType.Noun, Word = "House" };

            var gooddef = new WordDefinition {Definition = "satisfactory in quality"};
            var godef = new WordDefinition { Definition = "to move or proceed, especially to or from something" };
            var housedef = new WordDefinition { Definition = "a building in which people live; residence for human beings" };
            var housedef2 = new WordDefinition {Definition = "Fake"};
            var hashTable = new HashTable();
            
            
            hashTable.Add(good,gooddef);
            hashTable.Add(go,godef);
            hashTable.Add(house,housedef);

            for (var i = 1; i < 130; i++)
            {
                hashTable.Add(new WordEntity{Type = WordEntity.WordType.Adjective,Word = "asda"+i}, new WordDefinition{Definition = "asdasd"+i});
            }

            var test = new WordEntity {Type = WordEntity.WordType.Adjective, Word = "asda" + 4};
            var val = hashTable.Get(test);
            var val1 = hashTable.Get(house);
            var val3 = hashTable[good];
            hashTable[good] = housedef;
            var v = hashTable[good];
        }
    }
}
