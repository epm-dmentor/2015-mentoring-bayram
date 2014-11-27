namespace StockExchange
{
    public interface IStockEventSubscriber
    {
        void OnBought(IStockExchange stockExchange);
        void OnSold(IStockExchange stockExchange); 
    }
}