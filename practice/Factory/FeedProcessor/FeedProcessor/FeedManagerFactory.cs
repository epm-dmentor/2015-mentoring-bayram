using System;

namespace Epam.NetMentoring.FeedProcessor
{
    public class FeedManagerFactory : IFeedManagerFactory
    {
        public FeedManager CreateFeedManager(string feedType)
        {
            switch (feedType)
            {
                case "EmFeed": return new EmFeedManager();
                case "DeltaOne":return new DeltaOneFeedManager();
            }

            throw new Exception("Unknow Feed Type Exception");
            
        }
    }
}
