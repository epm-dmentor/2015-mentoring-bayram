using System;

namespace Epam.NetMentoring.SingletonWithoutLock
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = ServiceContext.Instance;
            service.ConnectionUrl = "http://127.0.0.1";
            service.Port = 8080;
            service.Timeout = 10000;

            Console.ReadKey();
        }
    }
}
