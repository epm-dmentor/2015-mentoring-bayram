using System;

namespace NetMentoring.Epam.ReflectionTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new ConfigProvider();
            var serviceSettings = provider.GetSettings<ServiceSettings>();
            var parsingSettings = provider.GetSettings<ParsingSettings>();
            
            Console.WriteLine("ServiceSettings Properties: {0}; {1};",serviceSettings.Connection,serviceSettings.Service);
            Console.WriteLine("ParsingSetting Properties: {0}; {1}; {2}",parsingSettings.Location,parsingSettings.Options,parsingSettings.Url);
            
            Console.WriteLine(serviceSettings.GetType());
            Console.ReadKey();
        }
    }
}
