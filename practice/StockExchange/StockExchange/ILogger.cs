using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchange
{
    public interface ILogger
    {
        void WriteInfo(string message);
    }
}
