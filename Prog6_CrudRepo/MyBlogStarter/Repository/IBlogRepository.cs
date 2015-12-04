using MyBlogStarter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter
{
    public interface IBlogRepository
    {

    // GetAll, Add en Delete

        List<Blog> GetAll();
        Blog Create(Blog Blog);
        void Delete(Blog Blog);
        Blog Get(int BlogID);
    }
}
