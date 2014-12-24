using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StockExchange
{
    public class BrokerAccount
    {
        public BrokerAccount(string accountId, decimal balance)
        {
            AccountId = accountId;
            Balance = balance;
            BrokerShares = new List<Share>();
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
