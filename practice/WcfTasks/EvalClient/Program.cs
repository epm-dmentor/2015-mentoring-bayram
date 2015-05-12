using System;
using System.Linq;
using System.ServiceModel;
using EvalClient.ServiceReference1;

namespace EvalClient
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var channelmex = new EvalServiceClient("BasicHttpBinding_IEvalService"))
            {
                var eval = new Eval { Comments = "Test", Submitter = "Bayram", TimeSent = DateTime.Today };
                
                try
                {
                    channelmex.SubmitEval(eval);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Evals from MEX: {0}", channelmex.GetEvals().FirstOrDefault().Submitter);
                
                try
                {
                    var evalresult = channelmex.GetEval("Bayra");
                    if (evalresult!=null)
                        Console.WriteLine(evalresult.Comments+" "+evalresult.Submitter+" "+evalresult.TimeSent.ToString("yyyy-MM-dd"));
                }
                catch (FaultException<EvalException> ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }

                var request = new EvalMessage {ContractVersion = "1.0.0.0"};

                try
                {
                    var proxy = ((IEvalService) channelmex);
                    
                    var response = proxy.GetMessage(new EvalMessage() {ContractVersion = "sdf", Id = 1});
                        channelmex.GetMessage(ref request.ContractVersion, 1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }

            }

            Console.ReadKey();
        }
    }
}
