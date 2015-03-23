using System;

namespace NetMentoring.Epam.ReflectionTask
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var provider = new ConfigProviderProd();
            var serviceSettings = provider.GetSettings<ServiceSettings>();
            var parsingSettings = provider.GetSettings<ParsingSettings>();
          
            Console.ReadKey();
        }
    }
}
