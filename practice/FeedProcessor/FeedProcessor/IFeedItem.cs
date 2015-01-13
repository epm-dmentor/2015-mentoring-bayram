using System;

namespace Epam.NetMentoring.FeedProcessor
{
    public interface IFeedItem
    {
        decimal StagingId { get; }
        string SourceTradeRef { get; }
        decimal CounterpartyId { get; }
        decimal PrincipalId { get; }
        DateTime ValuationDate { get; }
        decimal CurrentPrice { get; }
        decimal SourceAccountId { get; }
    }
}
