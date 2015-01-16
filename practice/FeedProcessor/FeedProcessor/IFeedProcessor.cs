using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    public interface IFeedProcessor
    {
        void ProcessFeedItems(IEnumerable<FeedModel> feeditems);
    }
}
