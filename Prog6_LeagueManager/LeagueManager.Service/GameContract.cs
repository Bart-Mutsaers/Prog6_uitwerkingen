using LeagueManager.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LeagueManager.Service
{
    [DataContract]
    public class GameContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public SetupContract PlayerOne { get; set; }

        [DataMember]
        public SetupContract PlayerTwo { get; set; }

        [DataMember]
        public SetupContract Winner { get; set; }

        [DataMember]
        public DateTime TimeStamp { get; set; }
    }
}
