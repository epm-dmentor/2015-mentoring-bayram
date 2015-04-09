using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.HashTable
{
    public class HashTable : IHashTable
    {
        private const int InitialSize = 128;
        private int _size = InitialSize;

        //IT: need to count total element count instead of buckets count - resizing will not work!
        private int _count;
        private HashBucket[] _table = new HashBucket[InitialSize];

        private int Compress(WordEntity key)
        {
            //multiply by a prime number (31) to make uniform distribution better
            return Math.Abs((key.GetHashCode() * 31) % _size);
        }

        public bool Contains(WordEntity key)
        {
            var hash = Compress(key);
            var bucket = _table[hash];

            return _table[hash] != null && bucket.Contains(key);
        }

        public void Add(WordEntity key, WordDefinition value)
        {
            if (IsResizeNeeded)
                Resize();

            var node = new HashItem(key, value);
            var hash = Compress(key);
            if (_table[hash] == null)
            {
                _table[hash] = new HashBucket(node);
                _count++;
            }
            else
            {
                //IT: count issue
                _table[hash].Add(node);
                _count++;
            }
        }

        private bool IsResizeNeeded
        {
            //we need resize in case filling percent of the array more or equal 90%
            get { return _size > 0 && (float)_count / _size >= 0.9; }
        }

        private void Resize()
        {
            _size = _size * 2;
            Array.Resize(ref _table,_size);
        }

        public WordDefinition Get(WordEntity key)
        {
            var hash = Compress(key);
            var bucket = _table[hash];
            if (bucket == null)
                throw new KeyNotFoundException("Cannot retrieve value from given key " + key.Word);

            return bucket.Get(key);
        }

        public WordDefinition this[WordEntity key]
        {
            get { return Get(key); }
            set
            {
                var hash = Compress(key);
                var bucket = _table[hash];

                if (value == null && bucket != null)
                {
                    bucket.Remove(key);
                    _count--;
                }
                else
                {
                    if (bucket == null)
                    {
                        Add(key, value);
                       
                    }
                    else
                    {
                        //IT: resizing and count not incremented!
                        bucket.Set(key, value);
                        _count++;
                    }
                }

            }
        }
    }
}
