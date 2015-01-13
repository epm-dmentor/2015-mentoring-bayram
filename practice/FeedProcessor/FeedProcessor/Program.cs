using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FeedProcessor
{
    class Program
    {
        static void Main(string[] args)
        {

            var feedItems = new List<IFeedItem>
            {
                new EmFeed(1212, "asdasd", 2323, 5656, new DateTime(2008, 3, 1, 7, 0, 0), 45, 45, 56, 45454),
                new EmFeed(1212, "asdasd", 2323, 5656, new DateTime(2008, 3, 1, 7, 0, 0), 45, 45, 56, 45454),
                new EmFeed(1212, "asdasd", 2323, 5656, new DateTime(2008, 3, 1, 7, 0, 0), 45, 45, 56, 45454),
                new EmFeed(1212, "asdasd", 2323, 5656, new DateTime(2008, 3, 1, 7, 0, 0), 45, 45, 56, 45454),
                new EmFeed(1212, "asdasd", 2323, 5656, new DateTime(2008, 3, 1, 7, 0, 0),45, 45, 56, 45454),
                new EmFeed(1212, "asdasd", 2323, 5656, new DateTime(2008, 3, 1, 7, 0, 0),45, 45, 56, 45454)
            };
            
            
            var factory = new FeedFactory();
            
            factory.CreateFeedProcessor("EmFeed").ProcessFeedItems(feedItems);
            
            Console.ReadKey();

        }
    }
}
