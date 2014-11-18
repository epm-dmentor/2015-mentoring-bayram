using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApplication
{
    class Share:EventArgs
    {
        public string ShareName { get; set; }
        public double SharePrice { get; set; }
    }
}
