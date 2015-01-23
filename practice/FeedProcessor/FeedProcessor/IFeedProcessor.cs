﻿using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    public interface IFeedProcessor
    {
        IEnumerable<ValidationError> Validate(FeedItem feeditem);
        FeedItem Match(FeedItem feeditem);
        void Save(FeedItem matchedaccount);
    }
}
