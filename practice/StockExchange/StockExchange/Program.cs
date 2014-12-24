using System;

namespace StockExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            var epamSec = new Share("EPAM", 47.15m, 500);
            var luxSec = new Share("LXFT", 36.68m, 500);
            var googlSec = new Share("GOOGL", 505.55m, 100);
            var googSec = new Share("GOOG", 503.70m, 100);
            var msftSec = new Share("MSFT", 45.88m, 50);

            IStockExchange stockExchange =
                new StockExchange(new[] { epamSec, luxSec, googlSec, googSec, msftSec });

            var bayram = new Broker("Bayram");
            var azat = new Broker("Azat");
            var igor = new Broker("Igor Tkachenko");

            var eventsLogger = new StockExhangeEventsLogger();
            stockExchange.Sold += eventsLogger.OnSold;
            stockExchange.Selling += eventsLogger.OnSelling;

            stockExchange.Register(bayram);
            stockExchange.Register(azat);
            stockExchange.Register(igor);

            bayram.Buy("GOOG", 1);
            azat.Buy("MSFT", 10);
            igor.Buy("EPAM", 15);

            azat.RequestSelling("MSFT", 2);

            stockExchange.UnRegister(bayram);
            stockExchange.UnRegister(azat);
            stockExchange.UnRegister(igor);

            stockExchange.Sold -= eventsLogger.OnSold;
            stockExchange.Selling -= eventsLogger.OnSelling;

            Console.ReadKey();
        }
    }
}
