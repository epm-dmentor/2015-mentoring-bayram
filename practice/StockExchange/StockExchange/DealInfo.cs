using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public class DealInfo
    {
        public string ShareName { get; set; }
        public double SharePrice { get; set; }
        public int ShareAmount { get; set; }
        public DateTime DealDate { get; set; }
    }
}
