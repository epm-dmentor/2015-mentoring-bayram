using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApplication
{
    interface IBroker
    {
        string GetBrokerName();
        void SetBrokerMoney(double money);
        double GetBrokerMoney();
        void SoldNotification(Stock stock, IBroker broker, Share share);
        void BoughtNotification(Stock stock, IBroker broker, Share share);
        void AppliedNotification(Stock stock, IBroker broker, Share share);
    }
}
