using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class DealInfo
    {
        private readonly DateTime _dealDate;

        public DealInfo(string sharename, double shareprice, int shareamount, DateTime dealDate)
        {
            this.ShareName = sharename;
            this.SharePrice = shareprice;
            this.ShareAmount = shareamount;
            this._dealDate = dealDate;
            
        }


        public string ShareName { get; private set; }

        public double SharePrice { get; private set; }

        public int ShareAmount { get; private set; }

        public DateTime DealDate
        {
            get { return this._dealDate; }
        }
    }
}
