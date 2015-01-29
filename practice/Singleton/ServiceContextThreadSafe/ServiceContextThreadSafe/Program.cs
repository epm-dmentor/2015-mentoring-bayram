namespace Epam.NetMentoring.ServiceContextThreadSafe
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = ServiceContext.Instance();
            service.ConnectionUrl = "http://127.0.0.1";
            service.Port = 8080;
            service.Timeout = 10000;

            var service2 = ServiceContext.Instance();
        }
    }
}
