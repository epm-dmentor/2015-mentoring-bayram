using System;

namespace Epam.NetMentoring.RetailEquity
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new BankFactory();
            
            var bofaTrade = factory.FilterTrade("Option", "SgpOption", 71);
            var connacordTrade = factory.FilterTrade("Future", "LdnFuture", 30);
            var barclaysTrade = factory.FilterTrade("Option", "NyOption", 52);

            Console.ReadKey();
        }
    }
}
