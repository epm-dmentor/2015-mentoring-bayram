using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WcfServiceLibrary
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,ConcurrencyMode = ConcurrencyMode.Single)]
    public class EvalService:IEvalService
    {
        private readonly List<Eval> _evals = new List<Eval>(); 
        private readonly List<EvalMessage> _evalMessages = new List<EvalMessage>(); 
        public void SubmitEval(Eval eval)
        {
           _evals.Add(eval);
        }

        public Eval GetEval(string submitter)
        {
            try
            {
                var eval = _evals.FirstOrDefault(x => x.Submitter.Equals(submitter));
                if (eval!=null) return eval;
                throw new FaultException<EvalException>(new EvalException{Message = "Not Found exception"});
            }
            catch (FaultException<EvalException> ex)
            {
                var faultContract = new EvalException
                {
                    Message = "Exception during retreiving Eval."+ex.Message,
                    Description = "Cannot find Eval that satifies to : " + submitter
                };
                throw new FaultException<EvalException>(faultContract,new FaultReason("Exception during retrieving Eval"));
            }
            
        }

        public List<Eval> GetEvals()
        {
            return _evals;
        }

        public MessageResponse GetMessage(EvalMessage request)
        {
            var response = new MessageResponse
            {
                ContractVersion = request.ContractVersion,
                EvalData = new Eval
                {
                    Comments = "Output from Message Contract",
                    Submitter = "bayram",
                    TimeSent = DateTime.Today
                }
               
            };
            return response;
        }

    }
}
