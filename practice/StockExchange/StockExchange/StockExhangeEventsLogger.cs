using System;

namespace StockExchange
{
    /// <summary>
    /// An object to logg all stock exchange events
    /// </summary>
    public class StockExhangeEventsLogger: IStockEventSubscriber
    {
        public void OnSold(DealInfo dealInfo)
        {
            Console.WriteLine("Sold! : Share {0} sold, amount is - {1} with price {2} on {3}", dealInfo.ShareName, dealInfo.ShareAmount, dealInfo.SharePrice, dealInfo.DealDate);
        }

        public void OnSelling(DealInfo dealInfo)
        {
            Console.WriteLine("New request for selling has come : Share {0} sold, amount is - {1} with price {2} on {3}", dealInfo.ShareName, dealInfo.ShareAmount, dealInfo.SharePrice, dealInfo.DealDate);
        }
    }
}
