using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApplication
{
    class BuySellEvents
    {
        public event EventHandler<Share> SellEvent;
        public event EventHandler<Share> BuyEvent;

        protected virtual void OnSellEvent()
        {
            var handler = SellEvent;
           
            if (handler != null)
            {
                handler(this,new Share());
            }
        }

        protected virtual void OnBuyEvent()
        {
            var handler = BuyEvent;
            
            if (handler != null)
            {
                handler(this, new Share());
            }
        }

    }
}
