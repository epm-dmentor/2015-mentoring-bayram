using System;
using System.Collections.Generic;
using System.Linq;

namespace StockExchange
{
    public class StockExchange : IStockExchange
    {
        private readonly IList<Share> _shares;
        private readonly IList<BrokerAccount> _accounts = new List<BrokerAccount>();

        public StockExchange(IEnumerable<Share> shares)
        {
            _shares = new List<Share>(shares);
        }
       

        #region Methods

        public void Buy(Share share, int amount, IBroker broker)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///Method which is invoked when broker applies for share 
        /// </summary>
        /// <param name="share"></param>
        /// <param name="amount"></param>
        /// <param name="broker"></param>
        public void RequestSelling(Share share, int amount, IBroker broker)
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
        public void Sell(Share share,int amount, IBroker broker) 
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


        public event ShareSoldHandler Sold;

        public event ShareSellingHandler Selling;

        public void Bid(Share share)
        {
            throw new NotImplementedException();
        }

        public void Register(IBroker broker)
        {
            throw new NotImplementedException();
        }

        public void UnRegister(IBroker broker)
        {
            throw new NotImplementedException();
        }

        public bool Buy(string securityId, int amount, IBroker broker)
        {
            throw new NotImplementedException();
        }

        public string RequestSelling(string securityId, int amount, IBroker broker)
        {
            throw new NotImplementedException();
        }

        public bool CancelRequest(string requestId)
        {
            throw new NotImplementedException();
        }

        public BrokerAccountInfo GetAccountInfo(IBroker broker)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Share> GetSecurities()
        {
            throw new NotImplementedException();
        }
    }
}
