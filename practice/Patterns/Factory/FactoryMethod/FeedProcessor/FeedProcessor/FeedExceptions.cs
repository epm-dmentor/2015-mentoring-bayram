using System;

namespace Epam.NetMentoring.FeedProcessor
{
    public class FeedExceptions:Exception
    {

    }

    public class InvalidCounterpartyException : Exception
    {
        public InvalidCounterpartyException()
        {
            
        }

        public InvalidCounterpartyException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
