using MyBlogStarter.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter.ViewModels
{
    public class NinjectServiceLocator
    {
        private readonly IKernel kernel;

        public NinjectServiceLocator()
        {
            kernel = new StandardKernel(new MyBlogModule());
        }

        public MainViewModel Main
        {
            get
            {
                return kernel.Get<MainViewModel>();
            }
        }
    }
}
