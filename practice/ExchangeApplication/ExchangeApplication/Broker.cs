using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApplication
{
    class Broker:IBroker
    {
        private string _brokerName;

        private double brokerMoney;
       

        public void SetBrokerMoney(double money)
        {
            this.brokerMoney = money;
        }

        public double GetBrokerMoney()
        {
            return brokerMoney;
        }

        public string GetBrokerName()
        {
            return _brokerName;
        }
        
        public Broker(string name,double money)
        {
            this.brokerMoney = money;
            this._brokerName = name;
        }

        public void SoldNotification(Stock stock, IBroker broker, Share share)
        {
            Console.WriteLine("{0} is notified that {1} sold share: {2} with price: {3}" ,_brokerName, broker.GetBrokerName(), share.ShareName,share.SharePrice);
        }

        public void BoughtNotification(Stock stock,IBroker broker, Share share)
        {
            Console.WriteLine("{0} is notified that {1} bought share: {2} with price: {3}", _brokerName, broker.GetBrokerName(), share.ShareName, share.SharePrice);
        }

        public void AppliedNotification(Stock stock, IBroker broker, Share share)
        {
            Console.WriteLine("{0} is notified that {1} applied for share: {2} with price: {3}", _brokerName, broker.GetBrokerName(), share.ShareName, share.SharePrice);
        }

      
    }
}
