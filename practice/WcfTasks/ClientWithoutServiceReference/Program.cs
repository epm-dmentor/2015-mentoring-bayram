using System;
using System.ServiceModel;
using WcfServiceLibrary;

namespace ClientWithoutServiceReference
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var channelFactory = new ChannelFactory<IEvalService>("HttpBindingEval"))
            {
                var channel = channelFactory.CreateChannel();
                var eval = new Eval {Comments = "Test", Submitter = "Bayram", TimeSent = DateTime.Today};
                
                try
                {
                    channel.SubmitEval(eval);
                    channel.GetMessage(new EvalMessage() {ContractVersion = "1.1", Id = 1});
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var serviceresponse = channel.GetEvals();

                foreach (var item in serviceresponse)
                {
                    Console.WriteLine(item.Comments);
                }

                Console.ReadKey();
            }
        }
    }
}
