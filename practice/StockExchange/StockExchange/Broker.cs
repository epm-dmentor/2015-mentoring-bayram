using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class Broker:IBroker,IStockEventSubscriber
    {
        public Broker(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        #region Methods

        /// <summary>
        /// Method which invokes StockExchange's BuyShare() method passing share and itself.
        /// </summary>
        /// <param name="share"></param>
        /// <param name="amount"></param>
        /// <param name="stockExchange"></param>
        
        public void SellShare(Share share,int amount,IStockExchange stockExchange)
        {
            stockExchange.BuyShare(share,amount,this); 
        }

        /// <summary>
        /// Method which invokes StockExchange's SellShare() method passing share and itself.
        /// </summary>
        /// <param name="share"></param>
        /// <param name="amount"></param>
        /// <param name="stockExchange"></param>
        
        public void BuyShare(Share share,int amount,IStockExchange stockExchange)
        {
            stockExchange.SellShare(share,amount, this); 
        }

       
        /// <summary>
        /// Method which is invoked by NotifyBought from StockExchange to update broker about bought share
        /// </summary>
        /// <param name="dealInfo"></param>
        
        public void OnBought(DealInfo dealInfo)
        {
            Console.WriteLine("Notification for broker {0} : Share {1} bought, amount is - {2} with price {3} on {4}", this.Name, 
                dealInfo.ShareName, dealInfo.ShareAmount,dealInfo.SharePrice,dealInfo.DealDate);
        }

        /// <summary>
        /// Method which is invoked by NotifySold from StockExchange to update broker about sold share
        /// </summary>
        /// <param name="dealInfo"></param>
        
        public void OnSold(DealInfo dealInfo)
        {
            Console.WriteLine("Notification for broker {0} : Share {1} sold, amount is - {2} with price {3} on {4}", this.Name,
                dealInfo.ShareName, dealInfo.ShareAmount, dealInfo.SharePrice, dealInfo.DealDate);
        }
        #endregion
        
    }
}
