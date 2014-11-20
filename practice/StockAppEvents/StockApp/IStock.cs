using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public interface IStock
    {
        void ShareSold(IBroker broker, Share share);
        void ShareBought(IBroker broker, Share share);
        void ShareApplied(IBroker broker, Share share);
        
        void SubscribeBroker(IBroker broker);
        void UnsubscribeBroker(IBroker broker);
        string BrokerName();
        string ShareStatus();
        Share GetShare();
        
    }
}
