using Epam.NetMentoring.HashTable;
using NUnit.Framework;

namespace NHashTableTest
{
    [TestFixture]
    public class WrongHashCodeTests
    {
        private class WrongWordEntity : WordEntity
        {
            public override int GetHashCode()
            {
                return 10;
            }
        }

        [Test]
        public void DifferentObjectsWithTheSameHashCodeMustBeSaved()
        {
            var key = new WrongWordEntity {Type = WordEntity.WordType.Adjective, Word = "word 1"};
            var value = new WordDefinition {Definition = "Definition 1"};

            var key2 = new WrongWordEntity {Type = WordEntity.WordType.Adjective, Word = "word 2"};
            var value2 = new WordDefinition {Definition = "Definition 2"};

            IHashTable hTable = new HashTable();
            hTable.Add(key, value);
            hTable.Add(key2, value2);

            var actualValue1 = hTable.Get(key);
            Assert.That(actualValue1, Is.EqualTo(value));

            var actualValue2 = hTable.Get(key2);
            Assert.That(actualValue2, Is.EqualTo(value2));
        }

        //IT: we need a posobility to replayce values 
        [Test]
        public void ElementReplacementMustWork()
        {
            var key = new WrongWordEntity { Type = WordEntity.WordType.Adjective, Word = "word 1" };
            var value1_1 = new WordDefinition { Definition = "Definition 1-1" };
            var value1_2 = new WordDefinition { Definition = "Definition 1-2" };

            var key2 = new WrongWordEntity { Type = WordEntity.WordType.Adjective, Word = "word 2" };
            var value2_1 = new WordDefinition { Definition = "Definition 2-1" };
            var value2_2 = new WordDefinition { Definition = "Definition 2-2" };

            IHashTable hTable = new HashTable();
            hTable.Add(key, value1_1);
            hTable.Add(key2, value2_1);

            hTable.Add(key, value1_2);
            hTable.Add(key2, value2_2);

            var actualValue1 = hTable.Get(key);
            Assert.That(actualValue1, Is.EqualTo(value1_2));

            var actualValue2 = hTable.Get(key2);
            Assert.That(actualValue2, Is.EqualTo(value2_2));
        }
    }
}