namespace StockExchangeInterfaces
{
    public interface IStockEventSubscriber
    {
        void OnSelling(DealInfo dealInfo);
        void OnSold(DealInfo dealInfo); 
    }
}