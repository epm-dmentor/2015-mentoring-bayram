using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    class Program
    {
        static void Main(string[] args)
        {

            var feedItems = new List<FeedItem>
            {
                new EmFeed{CounterpartyId = 1212, SourceAccountId = "asdasd", AssetGmv = 2323,AssetValue = 5656, ValuationDate = new DateTime(2008, 3, 1, 7, 0, 0), CurrentPrice = 45,PrincipalId = 45, StagingId = 56, SourceTradeRef = "MARS"},
                new EmFeed{CounterpartyId = 1212, SourceAccountId = "asdasd", AssetGmv = 2323,AssetValue = 5656, ValuationDate = new DateTime(2008, 3, 1, 7, 0, 0), CurrentPrice = 45,PrincipalId = 45, StagingId = 56, SourceTradeRef = "MARS"},
                new EmFeed{CounterpartyId = 1212, SourceAccountId = "asdasd", AssetGmv = 2323,AssetValue = 5656, ValuationDate = new DateTime(2008, 3, 1, 7, 0, 0), CurrentPrice = 45,PrincipalId = 45, StagingId = 56, SourceTradeRef = "MARS"},
                new EmFeed{CounterpartyId = 1212, SourceAccountId = "asdasd", AssetGmv = 2323,AssetValue = 5656, ValuationDate = new DateTime(2008, 3, 1, 7, 0, 0), CurrentPrice = 45,PrincipalId = 45, StagingId = 56, SourceTradeRef = "MARS"},
                new EmFeed{CounterpartyId = 1212, SourceAccountId = "asdasd", AssetGmv = 2323,AssetValue = 5656, ValuationDate = new DateTime(2008, 3, 1, 7, 0, 0), CurrentPrice = 45,PrincipalId = 45, StagingId = 56, SourceTradeRef = "MARS"},
                 
            };

            

            var factory = new FeedFactory();
            
            factory.CreateFeedProcessor("EmFeed").ProcessFeedItems(feedItems);
            
            Console.ReadKey();

        }
    }
}
