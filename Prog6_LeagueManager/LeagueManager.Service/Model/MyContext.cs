using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeagueManager.Service.Model
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=Azure")
        {
            Database.SetInitializer(new MyDbInitializer());
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Setup> Setups { get; set; }
    }
}