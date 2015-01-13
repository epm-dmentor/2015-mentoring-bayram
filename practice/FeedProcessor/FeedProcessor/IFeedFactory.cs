namespace Epam.NetMentoring.FeedProcessor
{
    public interface IFeedFactory
    {
        IFeedProcessor CreateFeedProcessor(string feedType);
    }
}
