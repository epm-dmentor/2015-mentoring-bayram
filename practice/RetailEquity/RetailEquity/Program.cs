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

            var barclaysTrades = new BarclaysFilter().Match(trades);
            var bofaTrades = new BOFAFilter().Match(trades);
            var connacordTrades = new ConnacordFilter().Match(trades);
            
            Console.ReadKey();
        }
    }
}
