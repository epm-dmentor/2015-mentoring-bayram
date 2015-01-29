using System.Threading;

namespace Epam.NetMentoring.ServiceContextThreadSafe
{
    internal sealed class ServiceContext
    {
        private static readonly object Lock = new object();
        private static ServiceContext _instance;

        public string ConnectionUrl { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }

        private ServiceContext() {}

        public static ServiceContext Instance()
        {
            if (_instance != null) return _instance;
            Monitor.Enter(Lock);
            {
                var tempContext = new ServiceContext();
                Volatile.Write(ref _instance,tempContext);
            }
            Monitor.Exit(Lock);
            return _instance;
        }
    }
}
