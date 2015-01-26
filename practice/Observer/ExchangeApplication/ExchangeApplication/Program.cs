using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var broker1 = new Broker("Bayram",100000);
            var broker2 = new Broker("Azat",201111);
            var broker3 = new Broker("Alex",450000);
            
            var shareApple = new Share {ShareName = "AAPL", SharePrice = 6504.64};
            var shareGoogle = new Share { ShareName = "GOOGL", SharePrice = 1004.44 };
            
            var stock =new Stock();
            
            stock.AddBroker(broker1);
            stock.AddBroker(broker2);
            stock.AddBroker(broker3);
        
            stock.BuyShare(broker1,shareApple);
            stock.SellShare(broker2,shareGoogle);
            stock.ApplyForShare(broker1,shareGoogle);
            
            Console.ReadKey();


        }

      
    }
}
