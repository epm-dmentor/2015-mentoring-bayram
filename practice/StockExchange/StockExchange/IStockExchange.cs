namespace StockExchange
{

    public interface IStockExchange
    {
       
        void SellShare(Share share,int amount,IBroker broker);
        void ApplyForShareSell(Share share, int amount, IBroker broker);
        //void BuyShare(Share share,int amount,IBroker broker);
        void NotifyBought(DealInfo dealInfo);
        void NotifySold(DealInfo dealInfo);
       

    }
}
