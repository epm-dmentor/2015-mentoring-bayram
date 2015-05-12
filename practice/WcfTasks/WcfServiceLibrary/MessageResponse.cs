using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WcfServiceLibrary
{
    [MessageContract]
    public class MessageResponse
    {
        [MessageHeader]
        public string ContractVersion { get; set; }
       
        [MessageBodyMember]
        public Eval EvalData { get; set; }
    }
}
