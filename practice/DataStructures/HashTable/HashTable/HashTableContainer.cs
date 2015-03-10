using System.Collections.Generic;
using System.Linq;
using Epam.NetMentoring.Adapter;

namespace Epam.NetMentoring.HashTable
{
    public class HashTableContainer:IContainer
    {
        private readonly HashBucket _bucket;

        public HashTableContainer(HashBucket bucket)
        {
            _bucket = bucket;
        }

        public int Count
        {
            get { return _bucket.GetBucketElements().Count; }
        }

        public IEnumerable<object> Items
        {
            get { return _bucket.GetBucketElements().Select(x=>x.Value.Definition); }
        }
    }
}
