using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.HashTable
{
    internal class HashBucket
    {
        private readonly IList<HashItem> _hashItems; 
        
        public HashBucket(HashItem hashItem)
        {
            _hashItems=new List<HashItem> {hashItem};
        }

        public void Add(HashItem hashItem)
        {
            _hashItems.Add(hashItem);
        }

        public IEnumerable<HashItem> GetBucketElements()
        {
            return _hashItems;
        }

        public void Remove(WordEntity key)
        {
            _hashItems.Remove(_hashItems.FirstOrDefault(x => x.Key.Equals(key)));
        }

        /// <summary>
        /// Add new value into the bucket if it does not exist
        /// or update value if such a key already exist
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(WordEntity key, WordDefinition value)
        {
            var hashItem = _hashItems.FirstOrDefault(i => i.Key.Equals(key));

            if (hashItem == null)
                Add(new HashItem(key, value));
            else
            {
                hashItem.Value = value;
            }
        }

        public bool Contains(WordEntity key)
        {
            return _hashItems.Any(i => i.Key.Equals(key));
        }

        public WordDefinition Get(WordEntity key)
        {
            var result =
                _hashItems
                    .Where(x => x.Key.Equals(key))
                    .Select(x => x.Value)
                    .FirstOrDefault();

            if (result == null)
                throw new KeyNotFoundException("Cannot retrieve value from given key " + key.Word);

            return result;
        }
    }
}
