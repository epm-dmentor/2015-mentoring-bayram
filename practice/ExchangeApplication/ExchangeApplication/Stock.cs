using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApplication
{
    class Stock
    {
        
        private List<IBroker> _brokers = new List<IBroker>();
        private Bank bank = new Bank();
        private double StockMoney;
        public void AddBroker(IBroker broker)
        {
            _brokers.Add(broker);
        }

        public void RemoveBroker(IBroker broker)
        {
            _brokers.Remove(broker);
        }

        public void BuyShare(IBroker buyer, Share share)
        {
            var buySellEvents = new BuySellEvents();
            
            buySellEvents.BuyEvent += BuyEventHandler;

            BuyEventHandler(this, share);
            double currentBrokerMoney = buyer.GetBrokerMoney();
            double moneyAfterTransaction = bank.Transaction(share.SharePrice);
            buyer.SetBrokerMoney(currentBrokerMoney-moneyAfterTransaction);
            this.StockMoney = StockMoney + moneyAfterTransaction;
            foreach (var broker in _brokers)
            {
                broker.BoughtNotification(this,buyer,share);
            }
        }

        void BuyEventHandler(object sender, Share e)
        {
            double commission = e.SharePrice*0.1/100;
            Console.WriteLine("Transaction for share: {0} was bought. Banks took commission of 0,1% " +
                              "from {1},which makes {2}",e.ShareName,e.SharePrice,commission);
            
        }

        public void SellShare(IBroker seller, Share share)
        {
            var buySellEvents = new BuySellEvents();
            buySellEvents.SellEvent += SellEventHandler;
            SellEventHandler(this,share);
            double currentBrokerMoney = seller.GetBrokerMoney();
            double moneyAfterTransaction = bank.Transaction(share.SharePrice);
            seller.SetBrokerMoney(currentBrokerMoney + moneyAfterTransaction);
            this.StockMoney = StockMoney - moneyAfterTransaction;
            
            foreach (var broker in _brokers)
            {
                broker.SoldNotification(this, seller, share);
            }
        }

        void SellEventHandler(object sender, Share e)
        {
            double commission = e.SharePrice * 0.1 / 100;
            Console.WriteLine("Transaction for share: {0} was sold. Banks took commission of 0,1% " +
                              "from {1},which makes {2}", e.ShareName, e.SharePrice, commission);
            
        }

        public void ApplyForShare(IBroker brokerName, Share share)
        {
            foreach (var broker in _brokers)
            {
                broker.AppliedNotification(this, brokerName, share);
            }
        }
      

    }
}
