using System;
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
        public void AddMethodTest()
        {
            var good = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Good" };
            var gooddef = new WordDefinition { Definition = "satisfactory in quality" };
            var bad = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Bad" };
            var baddef = new WordDefinition { Definition = "Not satisfactory in quality" };


            var hashTable = new HashTable();
            hashTable.Add(good, gooddef);
            hashTable.Add(bad, baddef);
            Assert.AreSame(gooddef,hashTable[good]); 
            Assert.AreSame(baddef,hashTable[bad]);
        }
        [Test]
        public void ContainsCheck()
        {
            var good = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Good" };
            var gooddef = new WordDefinition { Definition = "satisfactory in quality" };
            var bad = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Bad" };
            var baddef = new WordDefinition { Definition = "Not satisfactory in quality" };
            
            
            var hashTable = new HashTable();
            hashTable.Add(good, gooddef);
            hashTable.Add(bad,baddef);
            Assert.IsTrue(hashTable.Contains(good));
            Assert.IsTrue(hashTable.Contains(bad));
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
        public void GetThrowException()
        {
            var good = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Good" };
            var gooddef = new WordDefinition { Definition = "satisfactory in quality" };
            var bad = new WordEntity { Type = WordEntity.WordType.Adjective, Word = "Bad" };
            var hashTable = new HashTable();
            hashTable.Add(good, gooddef);
            
            Assert.Throws<Exception>(() => hashTable.Get(bad));
        }
        
    }
}
