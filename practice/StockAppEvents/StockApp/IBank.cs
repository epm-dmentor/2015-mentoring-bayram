using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public interface IBank
    {
        double Transaction(double money);
    }
}
