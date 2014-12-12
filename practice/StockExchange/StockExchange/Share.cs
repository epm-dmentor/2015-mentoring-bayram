using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class Share
    {
        private string _shareName;
        private double _sharePrice;
        private int _shareAmount;
        
        public Share(string sharename, double shareprice, int shareamount)
        {
            this._shareName = sharename;
            this._sharePrice = shareprice;
            this._shareAmount = shareamount;
        }

        public string ShareName
        {
            get { return this._shareName; }
            
        }

        public double SharePrice
        {
            get { return this._sharePrice; }
        }

        public int ShareAmount
        {
            get { return this._shareAmount; }
            set { this._shareAmount = value; }
        }
    }
}
