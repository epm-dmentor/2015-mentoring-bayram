using System.Collections.Generic;

namespace StockExchange
{
    public interface IStockExchange
    {
        event ShareSoldHandler Sold;
        event ShareSellingHandler Selling;

        void Bid(Share share);

        void Register(IBroker broker);
        void UnRegister(IBroker broker);

        bool Buy(string securityId, int amount, IBroker broker);
        string RequestSelling(string securityId, int amount, IBroker broker);
        bool CancelRequest(string requestId);

        BrokerAccountInfo GetAccountInfo(IBroker broker);
        IReadOnlyList<Share> GetSecurities();
    }

}
