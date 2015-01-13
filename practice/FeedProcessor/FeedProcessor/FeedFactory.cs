namespace Epam.NetMentoring.FeedProcessor
{
    public class FeedFactory:IFeedFactory
    {
        public IFeedProcessor CreateFeedProcessor(string feedType)
        {
            switch (feedType)
            {
                case "EmFeed":return new EmFeedProcessor();
                case "DeltaOne": return new DeltaOneFeedProcessor();
                default : return new EmFeedProcessor();
            }
        }
    }
}
