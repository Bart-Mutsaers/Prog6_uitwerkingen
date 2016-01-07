using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeagueStore.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public String Role { get; set; }

        public String ImageUrl { get; set; }
    }
}