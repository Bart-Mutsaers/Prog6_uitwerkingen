using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LeagueManager.Service.Model
{
    [Table("Setup")]
    public class Setup
    {
        [Key]
        public int Id { get; set; }

        public String PlayerName { get; set; }

        public String Top { get; set; }
        public String Jungle { get; set; }
        public String Mid { get; set; }
        public String Supp { get; set; }
        public String Adc { get; set; }
    }
}