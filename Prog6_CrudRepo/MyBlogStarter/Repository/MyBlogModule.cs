using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyBlogStarter.Repository
{
    class MyBlogModule: NinjectModule
    {
        public override void Load()
        {

            bool isRuntime = !DesignerProperties.GetIsInDesignMode(new DependencyObject());

            if(isRuntime)
            {
                this.Bind<IBlogRepository>().To<EntityBlogRepository>();
            }
            else
            {
                this.Bind<IBlogRepository>().To<DummyBlogRepository>();
            }
        }
    }
}

