using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class Broker:IBroker
    {
        private string _name;

        public Broker(string name)
        {
            this._name = name;
        }
        
        public void SellShare(Share share,IStockExchange stockExchange)
        {
            stockExchange.BuyShare(share,this); //Method which invokes StockExchange's BuyShare() method passing share and itself.
        }

        public void BuyShare(Share share,IStockExchange stockExchange)
        {
            stockExchange.SellShare(share, this); //Method which invokes StockExchange's SellShare() method passing share and itself.
        }

        public void UpdateBought(IStockExchange stockExchange)
        {
            //Method which is invoked by NotifyBought from StockExchange to update broker about bought share
            var share = stockExchange.GetShare();
            Console.WriteLine("Notification for broker {0} : Share {1} bought with price {2} ",this._name, share.SharName, share.SharePrice);
        }


        public void UpdateSold(IStockExchange stockExchange)
        {
            //Method which is invoked by NotifySold from StockExchange to update broker about sold share
            var share = stockExchange.GetShare();
            Console.WriteLine("Notification for broker {0} : Share {1} sold with price {2} ",this._name, share.SharName, share.SharePrice);
        }

        public string BrokerName()
        {
            return this._name;
        }
    }
}
