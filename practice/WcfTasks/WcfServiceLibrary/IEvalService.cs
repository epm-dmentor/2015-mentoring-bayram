using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface IEvalService
    {
        [OperationContract]
        void SubmitEval(Eval eval);

        [OperationContract]
        [FaultContract (typeof(EvalException))]
        Eval GetEval(string submitter);

        [OperationContract]
        List<Eval> GetEvals();
        
        [OperationContract]
        MessageResponse GetMessage(EvalMessage request);
    }
}
