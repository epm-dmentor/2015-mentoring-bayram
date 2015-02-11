using System.Threading;

namespace Epam.NetMentoring.ServiceContextThreadSafe
{
    public sealed class ServiceContext
    {
       
        private static readonly object SyncObj = new object();
        private static ServiceContext _instance;

        public string ConnectionUrl { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }

        private ServiceContext() {}

        public static ServiceContext Instance()
        {
            if (_instance != null) return _instance;

            lock(SyncObj)
            {
                var tempContext = new ServiceContext();
                Volatile.Write(ref _instance,tempContext);
            }
            
            return _instance;
        }
    }
}
