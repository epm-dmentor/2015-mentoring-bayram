using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    public abstract class FeedManager
    {
        private IFeedProcessor _feedProcessor;

        public void Process(IEnumerable<FeedItem> feeditems)
        {
            foreach (var item in feeditems)
            {
                _feedProcessor.Validate(item);
                _feedProcessor.Save(_feedProcessor.Match(item));
            }
        } 
    }
}