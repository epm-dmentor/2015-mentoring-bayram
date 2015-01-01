
namespace StockExchangeInterfaces
{
    public interface IBroker : IStockEventSubscriber
    {
        string Name { get; }

        bool RequestSelling(string securityId, int amount);
        bool Buy(string securityId, int amount);
        void RequestFulfiled(string requestId);

        void Settle(IStockExchange stockExchange);
        void UnSettle(IStockExchange stockExchange);
    }
}
