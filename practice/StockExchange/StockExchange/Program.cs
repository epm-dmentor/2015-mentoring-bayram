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
            var share = new Share("AAPL", 301, 100);
            var share1 = new Share("GOOGL", 740,125);
            
            
            var list = new List<Share> {share, share1};
            var stock = new StockExchange(list);
            
            var broker = new Broker("Bayram");
            var broker1 = new Broker("Azat");
            var othersubscriber = new AnyOtherSubscriber("Student");

            stock.Register(broker,list);
            
            stock.OnShareBought += broker.OnBought;
            stock.OnShareSold += broker.OnSold;
            stock.OnShareBought += broker1.OnBought;
            stock.OnShareSold += broker1.OnSold;
            stock.OnShareSold += othersubscriber.OnSold;
            stock.OnShareBought += othersubscriber.OnBought;
            stock.OnAppliedForShareSell += broker.OnApplyForSell;

            broker1.BuyShare(share,2,stock);
            broker.ApplyForSell(share,3,stock);



            //broker.SellShare(share1,3,stock);
            
            
            Console.ReadKey();
        }
    }
}
