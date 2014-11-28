using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    class AnyOtherSubscriber:IStockEventSubscriber
    {
        private readonly string _name;

        #region Constructor
        public AnyOtherSubscriber(string name)
        {
            this._name = name;
        }
        #endregion

        #region Methods
        public void OnBought(DealInfo dealInfo)
        {
            Console.WriteLine("Notification for subscriber {0} : Share {1} bought, amount is - {2} with price {3} on {4}", this._name,
               dealInfo.ShareName, dealInfo.ShareAmount, dealInfo.SharePrice, dealInfo.DealDate);
        }

        public void OnSold(DealInfo dealInfo)
        {
            Console.WriteLine("Notification for subscriber {0} : Share {1} sold, amount is - {2} with price {3} on {4}", this._name,
                dealInfo.ShareName, dealInfo.ShareAmount, dealInfo.SharePrice, dealInfo.DealDate);
        }
        #endregion
    }
}
