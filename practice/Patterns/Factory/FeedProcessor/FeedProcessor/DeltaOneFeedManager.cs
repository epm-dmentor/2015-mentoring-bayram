namespace Epam.NetMentoring.FeedProcessor
{
    public class DeltaOneFeedManager:FeedManager
    {
        private readonly IFeedProcessor _feedProcessor = new DeltaOneFeedProcessor();


        public override IFeedProcessor FeedProcessor
        {
            get { return _feedProcessor; }
        }
    }
}
