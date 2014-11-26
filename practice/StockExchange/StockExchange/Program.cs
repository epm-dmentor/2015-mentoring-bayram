using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            var share = new Share {SharName = "AAPL", SharePrice = 501};
            var share1 = new Share { SharName = "GOOGL", SharePrice = 740 };
            
            var stock =new StockExchange(new List<Share>{share,share1});
            
            var broker = new Broker("Bayram");
            var broker1 = new Broker("Azat");
            stock.SubscribeBroker(broker);
            stock.SubscribeBroker(broker1);
           
            broker1.BuyShare(share,stock);
            broker1.BuyShare(share,stock);
            broker1.SellShare(share1,stock);
           
            
            Console.ReadKey();
        }
    }
}
