namespace Epam.NetMentoring.FeedProcessor
{
    public interface IFeedManagerFactory
    {
        FeedManager CreateFeedManager(string feedType);
    }
}
