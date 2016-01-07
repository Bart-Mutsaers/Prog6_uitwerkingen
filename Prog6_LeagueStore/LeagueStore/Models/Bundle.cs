using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeagueStore.Models
{
    public class Bundle
    {
        public Bundle()
        {
            this.Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public double RiotPoints { get; set; }

        public String BannerUrl { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}