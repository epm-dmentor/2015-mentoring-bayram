using System;

namespace Epam.NetMentoring.ServiceContext
{
    public class ServiceContext
    {
        public string ConnectionUrl { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }

        private static ServiceContext _instance;

        private ServiceContext()
        {
          
        }
        
        public static ServiceContext Instance
        {
            get
            {
                if (_instance == null) return _instance = new ServiceContext();
                throw new Exception("Cannot create object. Service Context already exists.");
            }
        }


      
    }
}
