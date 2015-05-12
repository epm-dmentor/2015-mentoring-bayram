using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var baseAddress = new Uri("http://localhost:8081/EvalService");
                var evalServiceHost = new ServiceHost(typeof(WcfServiceLibrary.EvalService),baseAddress);
                evalServiceHost.AddServiceEndpoint(typeof (WcfServiceLibrary.IEvalService), new WSHttpBinding(), "");
                var serviceBehavior = new ServiceMetadataBehavior {HttpGetEnabled = true};
                evalServiceHost.Description.Behaviors.Add(serviceBehavior);
                evalServiceHost.Open();
                Console.WriteLine("Service is running at "+baseAddress);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }
            Console.ReadKey();
        }
    }
}
