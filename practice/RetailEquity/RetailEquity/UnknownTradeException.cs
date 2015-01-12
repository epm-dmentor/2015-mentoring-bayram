using System;

namespace Epam.NetMentoring.RetailEquity
{
    public class UnknownTradeException:Exception
    {
        public UnknownTradeException()
        {
            
        }

        public UnknownTradeException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
