namespace Epam.NetMentoring.FeedProcessor
{
    public interface IFeedManagerFactory
    {
        IFeedProcessor CreateFeedProcessor(string feedType);
    }
}
