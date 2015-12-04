using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter.Domain
{
    public class Blog
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Content { get; set; }

        public DateTime TimeStamp { get; set; }

        public String Author { get; set; }
    }
}
