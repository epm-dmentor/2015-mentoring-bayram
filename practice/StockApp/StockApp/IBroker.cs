using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockApp
{
    public interface IBroker
    {
        string GetBrokerName();
        double GetBrokerMoney();
        void SetBrokerMoney(double money);
        void Update(IStock stock);
    }
}
