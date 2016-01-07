using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueStore.Models.ViewModels
{
    public class BundleVM
    {
        public Bundle Bundle { get; set; }

        public int[] ProductIds { get; set; }

        public List<Product> Products { get; set; }
    }
}