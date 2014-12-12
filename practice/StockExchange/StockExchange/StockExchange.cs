using System;
using System.Collections.Generic;
using System.Linq;

namespace StockExchange
{
    public class StockExchange : IStockExchange
    {
        #region Fields

        private readonly List<Share> _shares;
        private readonly List<BrokerAccount> _accounts = new List<BrokerAccount>();
        public ShareBought OnShareBought;
        public ShareSold OnShareSold;
        public AppliedForShareSell OnAppliedForShareSell;
        private readonly ILogger _logger;
        #endregion

        #region Constructor
        public StockExchange(List<Share> shares)
        {
            this._shares = shares;
            this._logger=new Logger();
        }
        #endregion
       

        #region Methods


        /// <summary>
        ///Method which is invoked when broker applies for share 
        /// </summary>
        /// <param name="share"></param>
        /// <param name="amount"></param>
        /// <param name="broker"></param>
        public void ApplyForShareSell(Share share, int amount, IBroker broker)
        {
            var dealInfo = new DealInfo(share.ShareName, share.SharePrice, amount, DateTime.UtcNow);
            
            NotifyAppliedOnShareSell(dealInfo);
            
            var brokeraccount = _accounts.FirstOrDefault(x => x.BrokerShares.Contains(share));
            var amountofshares = 0;
            
            if (brokeraccount != null)
            {
                amountofshares = brokeraccount.BrokerShares.Select(x => x.ShareAmount).FirstOrDefault();
            }
            if (amount <= amountofshares)
            {
                BuyShare(share, amount, broker);
            }
            else if (amount >= amountofshares)
            {
                _logger.WriteInfo("You do not have enough amount of shares to sell...");
            }

        }
        /// <summary>
        /// StockExchange sells share, when Broker buys
        /// </summary>
        /// <param name="share"></param>
        /// <param name="amount"></param>
        /// <param name="broker"></param>
        /// 
        public void SellShare(Share share,int amount, IBroker broker) 
        {
            var brokername = broker.Name;
            var shareprice = share.SharePrice;
            var account = _accounts.FirstOrDefault(x => x.BrokerName.Equals(brokername));
            var shareindex = _shares.IndexOf(share);
            if (account ==null)
            {
                var message =
                    String.Format("Account for {0} does not exist. Please contact StockExchange to create account.",
                        broker.Name);
                _logger.WriteInfo(message);
                
            }
            else
            {
                var brokermoney = account.MoneyAmount;
                if (brokermoney < shareprice && !_shares.Contains(share) && _shares[shareindex].ShareAmount < amount)
                {
                    var message =
                        "INFO for " + brokername +
                        " : Insufficient funds or Non Existent share. Please contact StockExchange" +
                        " to resolve your issue.";
                   _logger.WriteInfo(message);
                }
                else
                {
                    var bankcommission = shareprice * amount * 0.01 / 100;
                    brokermoney = brokermoney - shareprice * amount - bankcommission;
                    share.ShareAmount = share.ShareAmount - amount;
                    _shares[shareindex] = share;
                    account.MoneyAmount = brokermoney;

                    var dealInfo = new DealInfo(share.ShareName, share.SharePrice, amount, DateTime.UtcNow);
            
                    NotifySold(dealInfo);
                }   
            }
            
        }

        /// <summary>
        /// //StockExchange buys share, when Broker applies to sell his/her share below method is private. 
        /// </summary>
        /// <param name="share"></param>
        /// <param name="amount"></param>
        /// <param name="broker"></param>
        
        private void BuyShare(Share share,int amount, IBroker broker) 
        {

            var brokername = broker.Name;
            var shareprice = share.SharePrice;
            var account = _accounts.FirstOrDefault(x => x.BrokerName.Equals(brokername));
            var shareindex = _shares.IndexOf(share);
            if (account==null)
            {
                var message =
                    String.Format("Account for {0} does not exist. Please contact StockExchange to create account.",
                        broker.Name);
                _logger.WriteInfo(message);
            }
            else
            {
                var brokermoney = account.MoneyAmount;
                if (!_shares.Contains(share) && _shares[shareindex].ShareAmount < amount)
                {
                    var message = String.Format("INFO for {0} : Non Existent share. Please contact StockExchange" +
                                                " to resolve your issue.", brokername);
                    _logger.WriteInfo(message);
                }
                else
                {
                    var bankcommission = shareprice * amount * 0.01 / 100;
                    brokermoney = brokermoney + shareprice * amount - bankcommission;
                    share.ShareAmount = share.ShareAmount + amount;
                    _shares[shareindex] = share;
                    account.MoneyAmount = brokermoney;

                    var dealInfo = new DealInfo(share.ShareName, share.SharePrice, amount, DateTime.UtcNow);
            
                    NotifyBought(dealInfo);
                }
            }
            
        }
        
        /// <summary>
        /// Notification sent to all subscribers when share bought
        /// </summary>
        public void NotifyBought(DealInfo dealInfo) 
        {
            if (OnShareBought != null) 
            {
                OnShareBought(dealInfo); 
            }
        }

        /// <summary>
        /// Notification sent to all subscribers when share sold
        /// </summary>
        public void NotifySold(DealInfo dealInfo)
        {
            
            var handler = OnShareSold;
            if (handler != null)
            {
                handler(dealInfo);
            }
        }
        
        
        /// <summary>
        /// Notification sent to all subscribers when share bought
        /// </summary>
        /// <param name="dealInfo"></param>

        public void NotifyAppliedOnShareSell(DealInfo dealInfo)
        {
            if (OnAppliedForShareSell != null)
            {
                OnAppliedForShareSell(dealInfo);
            }
        }

        /// <summary>
        /// Register broker and add 1000 USD to his account
        /// BrokerAccount is used only in StockExchange so no need to make setter private.
        /// </summary>
        /// <param name="broker"></param>
        /// <param name="shares"></param>
        public void Register(Broker broker,List<Share> shares)
        {
            var account = new BrokerAccount { BrokerName = broker.Name, MoneyAmount = 1000,BrokerShares = shares};
            _accounts.Add(account);
        }
        #endregion

   }
}
