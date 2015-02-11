using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    public abstract class FeedManager
    {
        public abstract IFeedProcessor FeedProcessor { get; }

        //IT: in that case it might be useful to mark it as virtual, as it will give you an opportunity to override in a derived class
        //but if the method contains some code you want to protect from changing you should not mark it as virtual
        public void Process(IEnumerable<FeedItem> feeditems)
        {            
            foreach (var item in feeditems)
            {
                FeedProcessor.Validate(item);
                FeedProcessor.Save(FeedProcessor.Match(item));
            }
        } 
    }
}