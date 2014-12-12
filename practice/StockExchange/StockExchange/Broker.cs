using System;

namespace StockExchange
{
    public class Broker:IBroker,IStockEventSubscriber
    {

        public string Name { get; private set; }
        private readonly ILogger _logger;
      
        public Broker(string name)
        {
            this.Name = name;
            this._logger=new Logger();
        }

        #region Methods

        /// <summary>
        /// Method which invokes StockExchange's SellShare() method passing share and itself.
        /// </summary>
        /// <param name="share"></param>
        /// <param name="amount"></param>
        /// <param name="stockExchange"></param>

        public void ApplyForSell(Share share, int amount, IStockExchange stockExchange)
        {
            stockExchange.ApplyForShareSell(share,amount,this);
        }
        
  
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
            var message =
                String.Format("Notification for broker {0} : Share {1} bought, amount is - {2} with price {3} on {4}",
                    this.Name,
                    dealInfo.ShareName, dealInfo.ShareAmount, dealInfo.SharePrice, dealInfo.DealDate);
            _logger.WriteInfo(message);
        }
        
        /// <summary>
        /// Method which is invoked by NotifyAppliedForSell from StockExchange to update broker about application to sell share
        /// </summary>
        /// <param name="dealInfo"></param>
        public void OnApplyForSell(DealInfo dealInfo)
        {
            var message =
                String.Format(
                    "Notification for broker {0} : Share {1} applied to be sold, amount is - {2} with price {3} on {4}",
                    this.Name,
                    dealInfo.ShareName, dealInfo.ShareAmount, dealInfo.SharePrice, dealInfo.DealDate);
            _logger.WriteInfo(message);
        }

        /// <summary>
        /// Method which is invoked by NotifySold from StockExchange to update broker about sold share
        /// </summary>
        /// <param name="dealInfo"></param>
        
        public void OnSold(DealInfo dealInfo)
        {
            var message =
                String.Format("Notification for broker {0} : Share {1} sold, amount is - {2} with price {3} on {4}",
                    this.Name,
                    dealInfo.ShareName, dealInfo.ShareAmount, dealInfo.SharePrice, dealInfo.DealDate);
            _logger.WriteInfo(message);
        }
        #endregion

      
    }
}
