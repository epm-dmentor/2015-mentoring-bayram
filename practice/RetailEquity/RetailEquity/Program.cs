using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.RetailEquity
{
    class Program
    {
        static void Main(string[] args)
        {
            var trades = new List<ITrade> {new Trade("Option", "NyOption", 52), 
                                           new Trade("Future","LdnFuture",31),
                                           new Trade("Option","SgpOption",72)};
            var factory = new FilterFactory();
            var barclaysTrades = factory.CreateFilter("Barclays").Match(trades);
            var bofaTrades = factory.CreateFilter("Bofa").Match(trades);
            var connacordTrades = factory.CreateFilter("Connacord").Match(trades);
            
            Console.ReadKey();
        }
    }
}
