namespace StockExchange
{
    public interface IStockEventSubscriber
    {
        void OnBought(DealInfo dealInfo);
        void OnSold(DealInfo dealInfo); 
    }
}