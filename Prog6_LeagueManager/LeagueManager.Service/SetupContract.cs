using LeagueManager.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace LeagueManager.Service
{
    [DataContract]
    public class SetupContract
    {
        public SetupContract()
        {

        }

        public SetupContract(Setup setup)
        {
             PlayerName = setup.PlayerName;
             Top = setup.Top;
             Jungle = setup.Jungle;
             Mid = setup.Mid;
             Supp = setup.Supp;
             Adc = setup.Adc;
        }

        [DataMember]
        public String PlayerName { get; set; }
        [DataMember]
        public String Top { get; set; }
        [DataMember]
        public String Jungle { get; set; }
        [DataMember]
        public String Mid { get; set; }
        [DataMember]
        public String Supp { get; set; }
        [DataMember]
        public String Adc { get; set; }
    }
}
