namespace Epam.NetMentoring.SingletonWithoutLock
{
    public sealed class ServiceContext
    {
        private static readonly ServiceContext instance=new ServiceContext();
        public string ConnectionUrl { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }

        static ServiceContext()
        {
        }

        private ServiceContext()
        {
        }

        public static ServiceContext Instance
        {
            get { return instance; }
        }

    }
}
