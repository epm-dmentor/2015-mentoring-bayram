using System;

namespace Epam.NetMentoring.FeedProcessor
{
    public class DeltaOne:FeedModel
    {
       
       public decimal TradeIdentifier { get; set; }
       public DateTime MaturityDate { get; set; }
       
    }
}
