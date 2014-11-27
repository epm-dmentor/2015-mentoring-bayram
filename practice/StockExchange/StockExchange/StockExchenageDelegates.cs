namespace StockExchange
{
    public delegate void ShareBought(IStockExchange stock); //Action when share is bought
    public delegate void ShareSold(IStockExchange stock); // Action when share is sold 
}