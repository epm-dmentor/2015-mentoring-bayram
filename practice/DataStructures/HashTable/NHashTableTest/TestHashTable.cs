using Epam.NetMentoring.HashTable;
using NUnit.Framework;

namespace NHashTableTest
{
    [TestFixture]
    public class TestHashTable
    {
        [Test]
        public void GetValueByKey()
        {
            var good = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Good" };
            var gooddef = new WordDefinition { Definition = "satisfactory in quality" };
            var hashTable = new HashTable();
            hashTable.Add(good,gooddef);

            var result = hashTable.Get(good);

            Assert.AreEqual(result,gooddef);
        }

        [Test]
        public void GetValueByKeyIndex()
        {
            var good = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Good" };
            var gooddef = new WordDefinition { Definition = "satisfactory in quality" };
            var hashTable = new HashTable();
            hashTable.Add(good, gooddef);
            
            Assert.AreEqual(gooddef,hashTable[good]);
        }

        [Test]
        public void TestContainsMethod()
        {
            var good = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Good" };
            var gooddef = new WordDefinition { Definition = "satisfactory in quality" };
            var hashTable = new HashTable();
            hashTable.Add(good, gooddef);

            Assert.IsTrue(hashTable.Contains(good));
        }
    }
}
