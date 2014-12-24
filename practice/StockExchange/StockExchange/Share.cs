
namespace StockExchange
{
    public class Share
    {
        public string SecurityId { get; private set; }
        public decimal CurrentPrice { get; private set; }
        public int Amount { get; private set; }

        public Share(string securityId, decimal sharePrice, int shareAmount)
        {
            SecurityId = securityId;
            CurrentPrice = sharePrice;
            Amount = shareAmount;
        }
    }
}
