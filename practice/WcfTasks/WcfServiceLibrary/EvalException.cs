using System.Runtime.Serialization;

namespace WcfServiceLibrary
{
    [DataContract]
    public class EvalException
    {
        [DataMember]
        public string Message { get; set; }
        
        [DataMember]
        public string Description { get; set; }
    }
}
