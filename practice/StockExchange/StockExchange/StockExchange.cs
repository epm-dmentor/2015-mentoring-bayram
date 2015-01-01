using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

        public event ShareSoldHandler Sold;
        public event ShareSellingHandler Selling;
        
        #region Methods
        
        ///// <summary>
        ///// Register broker and add 1000 USD to his account
        ///// </summary>
        ///// <param name="broker"></param>
        public void Register(IBroker broker)
        {
            var account = new BrokerAccount(broker.Name, 1000);
            _accounts.Add(account);
            broker.Settle(this);
        }
        /// <summary>
        /// Removes broker account from list of accounts
        /// </summary>
        /// <param name="broker"></param>
        public void UnRegister(IBroker broker)
        {
            var account = _accounts.FirstOrDefault(x => x.AccountId.Equals(broker.Name));
            _accounts.Remove(account);
            broker.UnSettle(this);
        }

        protected virtual void OnSold(DealInfo dealinfo)
        {
            var handler = Sold;
            if (handler != null) handler(dealinfo);
        }


        protected virtual void OnSelling(DealInfo dealinfo)
        {
            var handler = Selling;
            if (handler != null) handler(dealinfo);
        }

        public void Bid(Share share)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Buy method to buy share
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="amount"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public bool Buy(string securityId, int amount, IBroker broker)
        {
            var brokername = broker.Name;
            var securityIdShare = _shares.FirstOrDefault(x => x.SecurityId.Equals(securityId));

            if (securityIdShare == null) return false;

            var shareprice = securityIdShare.CurrentPrice;
            var share = securityIdShare;
            var account = _accounts.FirstOrDefault(x => x.AccountId.Equals(brokername));
            var shareindex = _shares.IndexOf(share);
            
            if (account == null)
            {
                var message =
                    String.Format("Account for {0} does not exist. Please contact StockExchange to create account.",
                        broker.Name);
                throw new NonExistingAccountException(message);
            }
            
            var brokermoney = account.Balance;

            if (!_shares.Contains(share) && _shares[shareindex].Amount < amount)
            {
                var message = String.Format("INFO for {0} : Non Existent share. Please contact StockExchange" +
                                            " to resolve your issue.", brokername);
                throw new NonExistingShareExeption(message);
            }

            var bankcommission = shareprice * amount * (decimal)0.01 / 100;
            brokermoney = brokermoney - shareprice * amount - bankcommission;
            var shareAfterBuy = new Share(securityId, shareprice, share.Amount - amount);
            var brokerShare = new Share(securityId, shareprice, amount);
            _shares[shareindex] = shareAfterBuy;
            account.Balance = brokermoney;
            account.BrokerShares.Add(brokerShare);
            
            var dealInfo = new DealInfo(share.SecurityId, share.CurrentPrice, amount, DateTime.UtcNow);
            
            OnSold(dealInfo);
            
            return true;
        }


        /// <summary>
        /// When broker is request to sell share below method is invoked, returns random requestId
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="amount"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public string RequestSelling(string securityId, int amount, IBroker broker)
        {

            var share = _shares.FirstOrDefault(x => x.SecurityId.Equals(securityId));

            if (share == null) throw new NonExistingShareExeption("No Share Found");
            
            var dealInfo = new DealInfo(securityId, share.CurrentPrice, amount, DateTime.UtcNow);
            var random = new Random();
            var requestId = random.Next(1, 1000);
            
            OnSelling(dealInfo);

            return requestId.ToString(CultureInfo.InvariantCulture);
            
        }

        public bool CancelRequest(string requestId)
        {
            
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns account info for given broker
        /// </summary>
        /// <param name="broker"></param>
        /// <returns></returns>

        public BrokerAccountInfo GetAccountInfo(IBroker broker)
        {
            var brokerAccount = _accounts.FirstOrDefault(x => x.AccountId.Equals(broker.Name));

            if (brokerAccount != null)
                return new BrokerAccountInfo(brokerAccount.AccountId, brokerAccount.Balance,
                    brokerAccount.BrokerShares);
            throw new NonExistingAccountException("Account does not exist. Please check with Stock Exchange.");
        }

        /// <summary>
        /// returns all securities 
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Share> GetSecurities()
        {
            var readonlyshares = new ReadOnlyCollection<Share>(_shares);
            return readonlyshares;
        }

        
        #endregion

      
    }

    
}
