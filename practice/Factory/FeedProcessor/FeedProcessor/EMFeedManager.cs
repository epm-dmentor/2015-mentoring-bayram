namespace Epam.NetMentoring.FeedProcessor
{
    public class EmFeedManager:FeedManager
    {
        private readonly IFeedProcessor _feedProcessor = new EmFeedProcessor();

        public override IFeedProcessor FeedProcessor
        {
            get { return _feedProcessor; }
        }
    }
}
