using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public interface IStockExchange
    {
        void SubscribeBroker(IBroker broker);
        void UnsubscribeBroker(IBroker broker);
        void SellShare(Share share,IBroker broker);
        void BuyShare(Share share,IBroker broker);
        void NotifyBought();
        void NotifySold();
        Share GetShare();

    }
}
