using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeagueStore.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public double Gold { get; set; }

        public String ItemUrl { get; set; }
    }
}

