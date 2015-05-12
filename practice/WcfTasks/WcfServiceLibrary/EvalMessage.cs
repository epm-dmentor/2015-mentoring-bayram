using System.ServiceModel;

namespace WcfServiceLibrary
{
    [MessageContract]
    public class EvalMessage
    {
        [MessageHeader]
        public string ContractVersion { get; set; }

        [MessageBodyMember]
        public int Id { get; set; }
    }
}
