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
        
        #endregion

        #region Constructor
        public StockExchange(List<Share> shares)
        {
            this._shares = shares;
        }
        #endregion
       

        #region Methods
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
            if (account == null)
            {
                Console.WriteLine("Account for {0} does not exist. Please contact StockExchange to create account.",broker.Name);
            }
            else
            {
                var brokermoney = account.MoneyAmount;
                if (brokermoney < shareprice && !_shares.Contains(share) && _shares[shareindex].ShareAmount < amount)
                {
                    Console.WriteLine("INFO for {0} : Insufficient funds or Non Existent share. Please contact StockExchange" +
                                      " to resolve your issue.", brokername);
                }
                else
                {
                    var bankcommission = shareprice * amount * 0.01 / 100;
                    brokermoney = brokermoney - shareprice * amount - bankcommission;
                    share.ShareAmount = share.ShareAmount - amount;
                    _shares[shareindex] = share;
                    account.MoneyAmount = brokermoney;

                    var dealInfo = new DealInfo
                    {
                        DealDate = DateTime.UtcNow,
                        ShareAmount = amount,
                        ShareName = share.SharName,
                        SharePrice = shareprice
                    };
                    NotifySold(dealInfo);
                }   
            }
            
        }

        /// <summary>
        /// //StockExchange buys share, when Broker sells
        /// </summary>
        /// <param name="share"></param>
        /// <param name="amount"></param>
        /// <param name="broker"></param>
        
        public void BuyShare(Share share,int amount, IBroker broker) 
        {

            var brokername = broker.Name;
            var shareprice = share.SharePrice;
            var account = _accounts.FirstOrDefault(x => x.BrokerName.Equals(brokername));
            var shareindex = _shares.IndexOf(share);
            if (account == null)
            {
                Console.WriteLine("Account for {0} does not exist. Please contact StockExchange to create account.", broker.Name);
            }
            else
            {
                var brokermoney = account.MoneyAmount;
                if (!_shares.Contains(share) && _shares[shareindex].ShareAmount < amount)
                {
                    Console.WriteLine("INFO for {0} : Non Existent share. Please contact StockExchange" +
                                      " to resolve your issue.", brokername);
                }
                else
                {
                    var bankcommission = shareprice * amount * 0.01 / 100;
                    brokermoney = brokermoney + shareprice * amount - bankcommission;
                    share.ShareAmount = share.ShareAmount + amount;
                    _shares[shareindex] = share;
                    account.MoneyAmount = brokermoney;

                    var dealInfo = new DealInfo
                    {
                        DealDate = DateTime.UtcNow,
                        ShareAmount = amount,
                        ShareName = share.SharName,
                        SharePrice = shareprice
                    };
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
        /// //Add account to our accounts list with default account money amount of 1000 USD
        /// </summary>
        /// <param name="broker"></param>
        
        public void Register(Broker broker)
        {
            var account = new BrokerAccount { BrokerName = broker.Name, MoneyAmount = 1000 };
            _accounts.Add(account);
        }
        #endregion

    }
}
