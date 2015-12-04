using MyBlogStarter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter
{
    public class EntityBlogRepository: IBlogRepository

    {

        MyContext dbContext;

        public EntityBlogRepository()
        {
            dbContext = new MyContext();
        }


        List<Domain.Blog> IBlogRepository.GetAll()
        {
            return dbContext.Blogs.ToList();
        }

        Domain.Blog IBlogRepository.Create(Domain.Blog Blog)
        {
            dbContext.Blogs.Add(Blog);
            dbContext.SaveChanges();
            return Blog;
        }

        void IBlogRepository.Delete(Domain.Blog Blog)
        {
            dbContext.Blogs.Remove(dbContext.Blogs.First(p => p.Id == Blog.Id));
            dbContext.SaveChanges();
        }

        public Domain.Blog Get(int BlogID)
        {
            return (dbContext.Blogs.First(p => p.Id == BlogID));
        }

    }
}
