using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{

    public interface IStockExchange
    {
       
        void SellShare(Share share,int amount,IBroker broker);
        void BuyShare(Share share,int amount,IBroker broker);
        void NotifyBought(DealInfo dealInfo);
        void NotifySold(DealInfo dealInfo);
       

    }
}
