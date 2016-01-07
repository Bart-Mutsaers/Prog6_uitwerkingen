using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LeagueManager.Service.Model
{
    [Table("Game")]
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public virtual Setup PlayerOne { get; set; }
        public virtual Setup PlayerTwo { get; set; }
        public virtual Setup Winner { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}