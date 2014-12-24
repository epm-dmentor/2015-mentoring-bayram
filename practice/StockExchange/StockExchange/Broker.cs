using System;
using System.Collections.Generic;
using System.Data;

namespace StockExchange
{
    public class Broker : IBroker
    {
        private readonly object _syncRequests = new object();

        private IStockExchange _stockExchange;
        private readonly IList<string> _requests = new List<string>();

        public string Name { get; private set; }        

        public Broker(string name)
        {
            Name = name;
        }


        /// <summary>
        /// Method which is invoked by NotifySold from StockExchange to update broker about sold share
        /// </summary>
        /// <param name="dealInfo"></param>
        public void OnSold(DealInfo dealInfo)
        {
            Console.WriteLine("Broker {0} reacted on selling a share {1}", Name, dealInfo.SecurityId);
        }


        public void OnSelling(DealInfo dealInfo)
        {
            Console.WriteLine("Broker {0} reacted on a selling request of a share {1}", Name, dealInfo.SecurityId);
            //react on selling request
        }

        public bool RequestSelling(string securityId, int amount)
        {
            if (_stockExchange == null)
                throw new NoNullAllowedException("Stock exchange has not been settled");

            var requestId = _stockExchange.RequestSelling(securityId, amount, this);

            if (String.IsNullOrWhiteSpace(requestId))
                return false;

            lock (_syncRequests)
            {
                _requests.Add(requestId);
            }

            return true;
        }

        public void RequestFulfiled(string requestId)
        {
            lock (_syncRequests)
            {
                _requests.Remove(requestId);
            }
        }

        public bool Buy(string securityId, int amount)
        {
            if (_stockExchange == null)
                throw new NoNullAllowedException("Stock exchange has not been settled");

            return _stockExchange.Buy(securityId, amount, this);
        }


        public void Settle(IStockExchange stockExchange)
        {
            if (_stockExchange != null)
                throw new ArgumentException("Stock exchange has been already settled");

            _stockExchange = stockExchange;
        }

        public void UnSettle(IStockExchange stockExchange)
        {
            _stockExchange = null;
        }

    }
}
