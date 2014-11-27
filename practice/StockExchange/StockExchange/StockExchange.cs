using System;
using System.Collections.Generic;
using System.Linq;

namespace StockExchange
{
    public class StockExchange : IStockExchange
    {
        private Share _share;
        private readonly List<BrokerAccount> _accounts = new List<BrokerAccount>();

        public ShareBought OnShareBought;
        public ShareSold OnShareSold;

        public Share GetShare()
        {
            return this._share; // Method to return share
        }

        public void Subscribe(IBroker broker)
        {
            OnShareBought += broker.UpdateBought; //Subscribe broker in paramater to OnShareBought action(delegate)
            OnShareSold += broker.UpdateSold; //Subscribe broker in paramater to OnShareSold action(delegate)
            
            var account = new BrokerAccount { BrokerName = broker.BrokerName(), MoneyAmount = 1000 };//Create account for newly subscribed broker
            _accounts.Add(account); //Add account to our accounts list

        }

        public void Unsubscribe(IBroker broker)
        {
            if (OnShareBought != null) OnShareBought -= broker.UpdateBought;
            if (OnShareSold != null) OnShareSold -= broker.UpdateSold;
        }

        public void SellShare(Share share, IBroker broker) //StockExchange sells share, when Broker buys
        {
            this._share = share;
            string brokername = broker.BrokerName();//get Brokername who wants to buy share
            var shareprice = share.SharePrice;//get shareprice
            var account = _accounts.FirstOrDefault(x => x.BrokerName.Equals(brokername));//get Broker Account from Accounts List
            if (account != null) // check if account is not null
            {
                var brokermoney = account.MoneyAmount; // get broker's money amount on his account
                if (brokermoney < shareprice) // Check if broker has enough money on his account to purchase share
                {
                    Console.WriteLine("INFO for {0} : Insufficient funds. Please ask StockExchange" +
                                      " to add more money to your account.", brokername); // Notify broker if he has not enough money
                }
                else
                {
                    double bankcommission = shareprice * 0.01 / 100;//calculate bank commission
                    brokermoney = brokermoney - shareprice - bankcommission; //calculate broker's money after transaction
                    account.MoneyAmount = brokermoney;// set broker's money value after transaction
                    NotifySold(); //Notify all subscribers
                }
            }

        }

        public void BuyShare(Share share, IBroker broker) //StockExchange buys share, when Broker sells
        {
            this._share = share;
            string brokername = broker.BrokerName(); //get Brokername who wants to sell share
            var shareprice = share.SharePrice;// get SharePrice
            var account = _accounts.FirstOrDefault(x => x.BrokerName.Equals(brokername));//get Broker Account from Accounts List
            if (account != null) //check if account is not null
            {
                var brokermoney = account.MoneyAmount; // get broker's money amount on his account.
                double bankcommission = shareprice * 0.01 / 100; //calculate bank commission
                brokermoney = brokermoney + shareprice - bankcommission; //calculate broker's money after transaction
                account.MoneyAmount = brokermoney; // set broker's money value after transaction
                NotifyBought(); // notify all subscribers
            }

        }

        public void NotifyBought() // Implementation of NotifyBought() method.
        {
            if (OnShareBought != null) //Check if OnshareBought is not null
            {
                OnShareBought(this); 
            }
        }

        public void NotifySold()
        {
            //to avoid null reference exception
            var handler = OnShareSold;
            if (handler != null)
            {
                handler(this);
            }
        }

        public void Register(Broker broker)
        {
            var account = new BrokerAccount { BrokerName = broker.BrokerName(), MoneyAmount = 1000 };//Create account for newly subscribed broker
            _accounts.Add(account); //Add account to our accounts list
        }
    }
}
