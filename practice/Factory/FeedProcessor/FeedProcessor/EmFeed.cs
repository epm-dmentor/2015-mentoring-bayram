using System;
//IT: unused namespace

namespace Epam.NetMentoring.FeedProcessor
{
    public class EmFeed:FeedItem
    {
    
       public decimal AssetValue { get; set; }
       public decimal AssetGmv { get; set; }
       
        //IT: it's not very good approach!
       public EmFeed(FeedItem feedItem)
       {
           base.CurrentPrice = feedItem.CurrentPrice;

       }

        public EmFeed()
        {
            
        }
    }
}
