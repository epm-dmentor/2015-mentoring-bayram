namespace Epam.NetMentoring.ServiceContext
{
    public class ServiceContext
    {
        public string ConnectionUrl { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }

        private static ServiceContext _instance;

        private ServiceContext(){}
        
        public static ServiceContext Instance
        {
            get
            {
                //IT: I would avoid such construction as: return _instance = new ServiceContext();
                if (_instance == null)
                    _instance = new ServiceContext();
                    //IT: OLD code: return _instance = new ServiceContext();

                return _instance;
            }
        }
     
    }
}
