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
            
            var stock = new StockExchange();
            
            var broker = new Broker("Bayram");
            var broker1 = new Broker("Azat");
            
            stock.Register(broker);
            stock.OnShareBought += broker.UpdateBought;

            stock.Subscribe(broker);
            stock.Subscribe(broker1);
           
            broker1.BuyShare(share,stock);
            broker1.BuyShare(share,stock);
            broker1.SellShare(share1,stock);
           
            
            Console.ReadKey();
        }
    }
}
