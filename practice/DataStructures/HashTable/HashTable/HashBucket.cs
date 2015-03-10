using System.Collections.Generic;

namespace Epam.NetMentoring.HashTable
{
    public class HashBucket
    {
        private readonly List<HashItem> _hashItems; 
        
        public HashBucket(HashItem hashItem)
        {
            _hashItems=new List<HashItem> {hashItem};
        }

        public void Add(HashItem hashItem)
        {
            _hashItems.Add(hashItem);
        }

        public List<HashItem> GetBucketElements()
        {
            return _hashItems;
        }
       
    }
}
