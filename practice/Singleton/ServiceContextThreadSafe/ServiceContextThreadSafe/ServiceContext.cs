using System.Threading;

namespace Epam.NetMentoring.ServiceContextThreadSafe
{
    //IT: public!
    internal sealed class ServiceContext
    {
        //IT: better name is syncObj
        private static readonly object Lock = new object();
        private static ServiceContext _instance;

        public string ConnectionUrl { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }

        private ServiceContext() {}

        public static ServiceContext Instance()
        {
            if (_instance != null) return _instance;

            //IT: if you use Monitor.Enter you do not need to use block inside: { ... }
            //IT: simpler construction is lock(syncObj) { ... }, it's more evident :) but you can use both
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
