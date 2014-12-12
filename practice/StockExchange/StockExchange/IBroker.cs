using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public interface IBroker
    {
        string Name { get; }
        void ApplyForSell(Share share, int amount, IStockExchange stockExchange);
        //void SellShare(Share share,int amount,IStockExchange stockExchange);
        void BuyShare(Share share,int amount,IStockExchange stockExchange);
    }
}
