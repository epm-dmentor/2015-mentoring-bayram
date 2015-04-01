using Epam.NetMentoring.HashTable;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.Adapter
{
    //using dependency injection
    public class HashTableContainer : IContainer
    {
        private readonly HashBucket _bucket;

        public HashTableContainer(HashBucket bucket)
        {
            _bucket = bucket;
        }

        public int Count
        {
            get { return _bucket.GetBucketElements().Count(); }
        }

        public IEnumerable<object> Items
        {
            get { return _bucket.GetBucketElements().Select(x => x.Value); }
        }
    }

    //using inheritance
    public class HashBucketContainer : HashBucket, IContainer
    {
        public int Count
        {
            get { return GetBucketElements().Count(); }
        }

        public IEnumerable<object> Items
        {
            get { return GetBucketElements().Select(x => x.Value); }
        }
    }
}
