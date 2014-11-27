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
        void SellShare(Share share,IStockExchange stockExchange);
        void BuyShare(Share share,IStockExchange stockExchange);
    }
}
