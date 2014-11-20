using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public class Broker:IBroker
    {
        private string _brokername;
        private double _brokermoney;

        public Broker(string name,double money)
        {
            this._brokername = name;
            this._brokermoney = money;
        }
        public string GetBrokerName()
        {
            return _brokername;
        }

        public void Update(IStock stock)
        {
            Console.WriteLine("Notification for: {0}",_brokername);
            Console.WriteLine("Broker named: {0}, {1} share - {2} with price {3}", stock.BrokerName(), stock.ShareStatus(), stock.GetShare().ShareName, stock.GetShare().SharePrice);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public double GetBrokerMoney()
        {
            return this._brokermoney;
        }




        public void SetBrokerMoney(double money)
        {
            this._brokermoney = money;
        }
    }
}
