using MyBlogStarter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter
{
    public class DummyBlogRepository: IBlogRepository
    {

        private List<Blog> bloglist;

        public DummyBlogRepository()
        {

            bloglist = new List<Blog>();

            bloglist.Add(new Blog {
                Id = 0, Title = "Eerste App",
                Content = "Vandaag heb ik mijn eerste C# app geschreven. Ik ben er heel trots op.",
                TimeStamp = new DateTime(2015, 11, 20), Author = "Ger0"
            });
            bloglist.Add(new Blog {
                Id = 1, Title = "Ninject",
                Content = "Het bestuderen van Ninject framework kostte me best wat tijd.",
                TimeStamp = new DateTime(2015, 11, 21), Author = "Ger1"
            });
            bloglist.Add(new Blog {
                Id = 2, Title = "Unit Test",
                Content = "We hebben voor alle core functies unit tests toegevoegd.",
                TimeStamp = new DateTime(2015, 11, 22), Author = "Ger2"
            });

        }
        public List<Domain.Blog> GetAll()
        {
            return bloglist;
        }

        public Domain.Blog Create(Domain.Blog b)
        {
            bloglist.Add(b);
            return b;

        }

        public void Delete(Domain.Blog f)
        {
            bloglist.Remove(bloglist.First(b => b.Id == f.Id));
        }

        Blog IBlogRepository.Get(int fId)
        {
            return (bloglist.First(fig => fig.Id == fId));
        }
    }
}
