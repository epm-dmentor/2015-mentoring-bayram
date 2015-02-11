using System;

namespace StockExchangeInterfaces
{
    public class DealInfo
    {
        public DateTime DealDate { get; private set; }
        public string SecurityId { get; private set; }
        public decimal SharePrice { get; private set; }
        public int ShareAmount { get; private set; }

        public DealInfo(string securityId, decimal sharePrice, int shareAmount, DateTime dealDate)
        {
            SecurityId = securityId;
            SharePrice = sharePrice;
            ShareAmount = shareAmount;
            DealDate = dealDate;            
        }
    }
}
