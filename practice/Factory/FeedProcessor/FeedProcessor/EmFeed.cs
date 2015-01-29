using System;

namespace Epam.NetMentoring.FeedProcessor
{
    public class EmFeed:FeedItem
    {
    
       public decimal AssetValue { get; set; }
       public decimal AssetGmv { get; set; }
       
       public EmFeed(FeedItem feedItem)
       {
           base.CurrentPrice = feedItem.CurrentPrice;

       }

        public EmFeed()
        {
            
        }
    }
}
