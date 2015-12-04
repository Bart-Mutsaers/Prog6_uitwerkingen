using MyBlogStarter.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter.Repository
{
    public class MyContext: DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {

        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
