using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.HashTable
{
    public class HashTable : IHashTable
    {
        //bucket size is const. Should fetch to envrironment automaticly
        private const int _size = 128;
        //List<HashTableBucket>
        //List<Bucket>
        private readonly List<HashItem>[] table = new List<HashItem>[_size];

        //private int CompressHashCode(int hashCode)
        //private int Compress(int hashCode)


        private static int GetHash(WordEntity key)
        {
            //Must be calculated inside an object
            return Math.Abs(key.Word.Aggregate(7, (current, t) => current * 31 + t) % 128);
        }

        public bool Contains(WordEntity key)
        {
            var hash = GetHash(key);
            return table[hash] != null;
        }

        public void Add(WordEntity key, WordDefinition value)
        {
            if (Contains(key)) throw new Exception("There is already such key in HashTable.");

            var node = new HashItem(key, value);
            var hash = GetHash(key);

            for (var i = 0; i < _size; i++)
            {
                if (i == hash && table[hash] == null)
                {
                    table[hash] = new List<HashItem> { node };
                }
                else if (i == hash && table[hash] != null)

                    table[hash].Add(node);

            }

        }

        public WordDefinition Get(WordEntity key)
        {
            var hash = GetHash(key);

            if (table[hash] == null) throw new Exception("Cannot retrieve value from given key " + key.Word);
            var res = 
                table[hash]
                    .Where(x => x.Key.Equals(key))
                    .Select(x => x.Value)
                    .FirstOrDefault();

            return res;
        }

        public WordDefinition this[WordEntity key]
        {
            get { return Get(key); }
            set
            {
                var hash = GetHash(key);
                table[hash].FirstOrDefault(x => x.Key.Equals(key)).Value = value;
            }
        }
    }
}
