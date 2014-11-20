using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public class Stock:IStock
    {
        public delegate void ShareAction(IStock stock);
        
        public event ShareAction OnShareAction;

        private Bank bank = new Bank();
        private double _stockMoney;
        private Share _share;
        private string _sharestatus;
        private IBroker _broker;

        public Stock(double money)
        {
            this._stockMoney = money;
        }
        
        public void ShareSold(IBroker broker, Share share)
        {
            this._share = share;
            this._broker = broker;
            this._sharestatus = "sold";
            double currentBrokerMoney = broker.GetBrokerMoney();
            double moneyAfterTransaction = bank.Transaction(share.SharePrice);
            broker.SetBrokerMoney(currentBrokerMoney - moneyAfterTransaction);
            this._stockMoney = _stockMoney - moneyAfterTransaction;
            double commission = share.SharePrice * 0.1 / 100;
            Console.WriteLine("Transaction for share: {0} was sold. Banks took commission of 0,1% " +
                              "from {1},which makes {2}", share.ShareName, share.SharePrice, commission);
            if (OnShareAction != null)
            {
                OnShareAction(this);
            }
        }

        public void ShareBought(IBroker broker, Share share)
        {
            this._share = share;
            this._broker = broker;
            this._sharestatus = "bought";
            double currentBrokerMoney = broker.GetBrokerMoney();
            double moneyAfterTransaction = bank.Transaction(share.SharePrice);
            broker.SetBrokerMoney(currentBrokerMoney - moneyAfterTransaction);
            this._stockMoney = _stockMoney + moneyAfterTransaction;
            double commission = share.SharePrice * 0.1 / 100;
            Console.WriteLine("Transaction for share: {0} was bought. Banks took commission of 0,1% " +
                              "from {1},which makes {2}", share.ShareName, share.SharePrice, commission);
            if (OnShareAction != null)
            {
                OnShareAction(this);
            }
        }

        public void ShareApplied(IBroker broker, Share share)
        {
            this._share = share;
            this._broker = broker;
            this._sharestatus = "applied for";
            if (OnShareAction != null)
            {
                OnShareAction(this);
            }
        }
      
        public void SubscribeBroker(IBroker broker)
        {
            OnShareAction += broker.Update;
        }

        public void UnsubscribeBroker(IBroker broker)
        {
            OnShareAction -= broker.Update;
        }


        public string BrokerName()
        {
            return _broker.GetBrokerName();
        }

        public Share GetShare()
        {
            return this._share;
        }


        public string ShareStatus()
        {
            return this._sharestatus;
        }
    }
}
