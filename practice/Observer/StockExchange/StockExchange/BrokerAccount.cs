using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StockExchange
{
    public class BrokerAccount
    {
        private string _p1;
        private int _p2;
        private List<Share> _shares;

        public BrokerAccount(string accountId, decimal balance)
        {
            AccountId = accountId;
            Balance = balance;
            BrokerShares = new List<Share>();
        }

        public BrokerAccount(string p1, int p2, List<Share> shares)
        {
            // TODO: Complete member initialization
            this._p1 = p1;
            this._p2 = p2;
            this._shares = shares;
        }

        public string AccountId { get; private set; }
        public decimal Balance { get; set; }
        public IList<Share> BrokerShares { get; private set; }
    }

    public class BrokerAccountInfo
    {
        public BrokerAccountInfo(string accountId, decimal balance, IList<Share> securities)
        {
            AccountId = accountId;
            Balance = balance;
            BrokerShares = new ReadOnlyCollection<Share>(securities);
        }

        public string AccountId { get; private set; }
        public decimal Balance { get; set; }
        public IReadOnlyList<Share> BrokerShares { get; private set; }
    }
}
