using System;
using System.Linq;

namespace Epam.NetMentoring.HashTable
{
    public class HashTable : IHashTable
    {
        private const int InitialSize = 128;
        private int _size = InitialSize;
        private int _count;
        private HashBucket[] table = new HashBucket[InitialSize];
       
        private int Compress(WordEntity key)
        {
            return Math.Abs((key.GetHashCode()*31)%_size);
        }

        public bool Contains(WordEntity key)
        {
            var hash = Compress(key);
            return table[hash] != null;
        }

        public void Add(WordEntity key, WordDefinition value)
        {
            if (_count >= _size)
            {
                _size = _size*2;
            }
            var node = new HashItem(key, value);
            var hash = Compress(key);

            for (var i = 0; i < _size; i++)
            {
                if (i == hash && table[hash] == null)
                {
                    table[hash] = new HashBucket(node);
                    _count++;
                }
                else if (i == hash && table[hash] != null)
                {
                    table[hash].Add(node);
                }
            }

        }

        public WordDefinition Get(WordEntity key)
        {
            var hash = Compress(key);
            if (table[hash] == null) throw new Exception("Cannot retrieve value from given key " + key.Word);
            var hashItems = table[hash].GetBucketElements();
            var result = 
                hashItems
                    .Where(x => x.Key.Equals(key))
                    .Select(x => x.Value)
                    .FirstOrDefault();
            return result;
        }

        public WordDefinition this[WordEntity key]
        {
            get { return Get(key); }
            set
            {
                //IT: if ht[v] = null
                var hash = Compress(key);
                var hashItems = table[hash].GetBucketElements();
                if (hashItems != null)
                {
                    hashItems.FirstOrDefault(x => x.Key.Equals(key)).Value = value;
                }
            }
        }
    }
}
