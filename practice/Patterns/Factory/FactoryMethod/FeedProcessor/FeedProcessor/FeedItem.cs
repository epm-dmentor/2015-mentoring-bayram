using System;

namespace Epam.NetMentoring.FeedProcessor
{
    public class FeedItem
    {
        public decimal StagingId { get; set; }
        public string SourceTradeRef { get; set; }
        public decimal CounterpartyId { get; set; }
        public decimal PrincipalId { get; set; }
        public DateTime ValuationDate { get; set; }
        public decimal CurrentPrice { get; set; }
        public string SourceAccountId { get; set; }
        
    }
}
