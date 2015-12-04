using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ChatService
{
    /** 
     * De klasse die we gebruiken als data contract.
     * Dit is een klasse met dezelfde prroperties als ChatMsg. 
     * Waarom hergebruiken we niet gewoon ChatMsg?
     * We willen niet dat de client weet wat ons data model is.
     * Nu kunnen we de database veranderen zondat dat het data contract veranderd. 
     */ 
    [DataContract]
    public class Message
    {
        public Message()
        {

        }

        public Message(ChatMsg msg)
        {
            this.Content = msg.Message;
            this.TimeStamp = msg.TimeStamp;
            this.User = msg.User;
        }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }

        [DataMember]
        public string User { get; set; }
    }
}