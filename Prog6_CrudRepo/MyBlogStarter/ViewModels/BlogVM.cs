using MyBlogStarter.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogStarter.ViewModels
{
    public class BlogVM: INotifyPropertyChanged
    {
        // referentie naar bijbehorend model
        private Blog _blog;

        //constructor zonder parameter
        public BlogVM()
        {
            _blog = new Blog();

        }

        //constructor met parameter
        public BlogVM(Blog blog)
        {
            _blog = blog;
        }

        public Blog Blog
        {
            get { return _blog; }
            set { _blog = value; }
        }

        //implementatie van de interface INotifyPropertyChanged
        #region implementation_INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion



        //mapping van de properties van ViewModel op Model
        #region properties van ViewModel op Model
        public int Id
        {
            get { return _blog.Id; }
            set { _blog.Id = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get { return _blog.Title; }
            set { _blog.Title = value; OnPropertyChanged(); }
        }


        public string Content
        {
            get { return _blog.Content; }
            set { _blog.Content = value; OnPropertyChanged(); }
        }


        public DateTime TimeStamp
        {
            get { return _blog.TimeStamp; }
            set { _blog.TimeStamp = value; OnPropertyChanged(); }
        }

        public string Author
        {
            get { return _blog.Author; }
            set { _blog.Author = value; OnPropertyChanged(); }
        }

        #endregion
    }
}
