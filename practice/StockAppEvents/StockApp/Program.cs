using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Share apple = new Share {ShareName = "AAPL", SharePrice = 4555};
            Stock stock =new Stock(100000);
            Broker broker1 = new Broker("bayram",45000);
            Broker broker2 = new Broker("Alex",10000);
            stock.SubscribeBroker(broker1);
            stock.SubscribeBroker(broker2);
            stock.ShareBought(broker1,apple);
            Console.ReadKey();
        }
    }
}
