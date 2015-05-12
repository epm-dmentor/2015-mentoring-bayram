using System;
using System.Runtime.Serialization;

namespace WcfServiceLibrary
{
    [DataContract]
    public class Eval
    {
        [DataMember]
        public string Submitter;
        [DataMember]
        public DateTime TimeSent;
        [DataMember]
        public string Comments;
    }
}
