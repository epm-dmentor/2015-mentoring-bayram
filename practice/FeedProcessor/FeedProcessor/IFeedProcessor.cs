using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    public interface IFeedProcessor
    {
        void ProcessFeedItems(List<IFeedItem> feeditems);
        void Validate(IFeedItem feeditem);
        string Match(IFeedItem feeditem);
        void Save(string matchedaccount);

    }
}
