using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class StockExchange : IStockExchange
    {

        private Share _share;
        private List<Share> _shares;
        private List<BrokerAccount> _accounts;

        public delegate void ShareBought(IStockExchange stock); //Action when share is bought
        public delegate void ShareSold(IStockExchange stock); // Action when share is sold

        public ShareBought OnShareBought; 
        public ShareSold OnShareSold;


        public StockExchange(List<Share> shares) // Constructor which takes as a parameter List of shares which will be sold or bought
        {
            this._shares = shares;
            this._accounts = new List<BrokerAccount>(); // Create account list for brokers who is going to subscribe to StockExchange
        }

        public Share GetShare()
        {
            return this._share; // Method to return share
        }

        public void SubscribeBroker(IBroker broker)
        {
            OnShareBought += broker.UpdateBought; //Subscribe broker in paramater to OnShareBought action(delegate)
            OnShareSold += broker.UpdateSold; //Subscribe broker in paramater to OnShareSold action(delegate)
            
            var account = new BrokerAccount { BrokerName = broker.BrokerName(), MoneyAmount = 1000 };//Create account for newly subscribed broker
            _accounts.Add(account); //Add account to our accounts list

        }

        public void UnsubscribeBroker(IBroker broker)
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

        public void NotifySold() // Implementation of NotifyBought() method.
        {
            if (OnShareSold != null)
            {
                OnShareSold(this);
            }
        }
    }
}
