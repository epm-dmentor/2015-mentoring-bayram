using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeApplication
{
    class Bank
    {
        private double _incomingMoney;
        private double _bankTotalMoney;



        public double Transaction(double money)
        {
            this._incomingMoney = money;
            double commision = money*0.1/100;
            _bankTotalMoney = _bankTotalMoney + commision;
            double brokerMoneyAfterComission = _incomingMoney - commision;
            return brokerMoneyAfterComission;
        }

    }
}
