using System.Collections.Generic;
using System.Linq;

//was gived from another solution, so namespace is wrong
namespace Epam.NetMentoring.HashTable
{
    public class HashBucket
    {
        private readonly IList<HashItem> _hashItems;

        public HashBucket() {}

        public HashBucket(HashItem hashItem)
        {
            _hashItems = new List<HashItem> { hashItem };
        }

        public void Add(HashItem hashItem)
        {
            _hashItems.Add(hashItem);
        }

        public IEnumerable<HashItem> GetBucketElements()
        {
            return _hashItems;
        }

        public void Remove(object key)
        {
            _hashItems.Remove(_hashItems.FirstOrDefault(x => x.Key.Equals(key)));
        }

        public bool Contains(object key)
        {
            return _hashItems.Any(i => i.Key.Equals(key));
        }

        public object Get(object key)
        {
            var result =
                _hashItems
                    .Where(x => x.Key.Equals(key))
                    .Select(x => x.Value)
                    .FirstOrDefault();

            if (result == null)
                throw new KeyNotFoundException("Cannot retrieve value from given key " + key.GetHashCode());

            return result;
        }


    }

    public class HashItem
    {
        public HashItem(object key, object value)
        {
            Key = key;
            Value = value;
        }

        public object Key { get; set; }
        public object Value { get; set; }
    }

    

}
