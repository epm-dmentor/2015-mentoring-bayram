using System.Collections.Generic;

namespace StockExchangeInterfaces
{
    public interface IStockExchange
    {
        void Bid(Share share);

        void Register(IBroker broker);
        void UnRegister(IBroker broker);

        void SubscribeBroker(IBroker broker);
        void UnsubscribeBroker(IBroker broker);


        bool Buy(string securityId, int amount, IBroker broker);
        string RequestSelling(string securityId, int amount, IBroker broker);
        bool CancelRequest(string requestId);
        
        BrokerAccountInfo GetAccountInfo(IBroker broker);
        IReadOnlyList<Share> GetSecurities();
    }

}
