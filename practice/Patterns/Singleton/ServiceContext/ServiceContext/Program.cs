namespace Epam.NetMentoring.ServiceContext
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var service = ServiceContext.Instance;
            service.ConnectionUrl = "http://127.0.0.1";
            service.Port = 8080;
            service.Timeout = 10000;

            //var secondservice = ServiceContext.Instance;
        }
    }
}
