using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyBlogStarter.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private BlogVM _selectedBlog;

        public BlogVM SelectedBlog
        {
            get { return _selectedBlog; }
            set
            {
                _selectedBlog = value;
                OnPropertyChanged("SelectedBlog");
            }
        }

        private IBlogRepository blogRepository;

        public ObservableCollection<BlogVM> VerzamelingBlogs { get; set; }


        public double Ovalue
        {
            get
            {
                double ovalue = 1;
                if(VerzamelingBlogs.FirstOrDefault(f => f.Id == SelectedBlog.Id) != null)
                {
                    ovalue = 0.5;
                }
                return ovalue;
            }
        }

        public int BlogTotal
        {
            get
            {
                return VerzamelingBlogs.Count;
            }
        }

        //constructor
        public MainViewModel(IBlogRepository repo)
        {
            initialise(repo);
        }

        private void initialise(IBlogRepository repo)
        {
            blogRepository = repo;

            IEnumerable<BlogVM> lijstje = blogRepository.GetAll().Select(f => new BlogVM(f));
            VerzamelingBlogs = new ObservableCollection<BlogVM>(lijstje);

            if(blogRepository.GetAll().Count() > 0)
            {
                SelectedBlog = lijstje.First();
            }
            else
            {
                ClearBlog();
            }

            AddBlogCommand = new RelayCommand(SaveBlog, CanSave);
            ClearBlogCommand = new RelayCommand(ClearBlog, CanClear);
            DelBlogCommand = new RelayCommand(DeleteBlog, CanDelete);
            NextBlogCommand = new RelayCommand(NextBlog, CanNext);
            PrevBlogCommand = new RelayCommand(PrevBlog, CanPrev);

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


        public ICommand AddBlogCommand { get; set; }

        public ICommand ClearBlogCommand { get; set; }

        public ICommand DelBlogCommand { get; set; }

        public ICommand NextBlogCommand { get; set; }
        public ICommand PrevBlogCommand { get; set; }

        private void SaveBlog()
        {
            int id = (blogRepository.Create(SelectedBlog.Blog)).Id; 
            VerzamelingBlogs.Clear();
           
            foreach (var blog in blogRepository.GetAll())
            {
               VerzamelingBlogs.Add(new BlogVM(blog));
            }

            SelectedBlog = VerzamelingBlogs.First(f => f.Id == id);

            OnPropertyChanged("BlogTotal");
            OnPropertyChanged("Ovalue");
            CommandManager.InvalidateRequerySuggested();
        }

        private void ClearBlog()
        {
            int newId = 0;
            if(VerzamelingBlogs.Count > 0)
            {
                newId = (VerzamelingBlogs.Max(f => f.Id) + 1);
            }
            SelectedBlog = new BlogVM {
                Id = newId,
                Content = "",
                Author = ("Me_" + newId),
                TimeStamp = DateTime.Now,
                Title = "Titel " + newId
            };
            OnPropertyChanged("Ovalue");

        }

        private void DeleteBlog()
        {
            if(VerzamelingBlogs.FirstOrDefault(f => f.Id == SelectedBlog.Id) != null)
            {
                blogRepository.Delete(SelectedBlog.Blog);
                var lijstje = blogRepository.GetAll().Select(f => new BlogVM(f));
                VerzamelingBlogs = new ObservableCollection<BlogVM>(lijstje);
                OnPropertyChanged("BlogTotal");
                OnPropertyChanged("Ovalue");
            }
            if(VerzamelingBlogs.Count > 0)
            {
                SelectedBlog = VerzamelingBlogs.First();
                OnPropertyChanged("Ovalue");
            }
            else
            {
                ClearBlog();
            }
        }


        private void PrevBlog()
        {
            int i = VerzamelingBlogs.IndexOf(SelectedBlog) - 1;
            SelectedBlog = VerzamelingBlogs.ElementAt(i);
        }

        private void NextBlog()
        {
            int i = VerzamelingBlogs.IndexOf(SelectedBlog) + 1;
            SelectedBlog = VerzamelingBlogs.ElementAt(i);
        }

        private bool CanSave()
        {
            bool res = false;
            if(SelectedBlog != null)
            {
                if(VerzamelingBlogs.Count > 0)
                {
                    res = VerzamelingBlogs.FirstOrDefault(f => f.Id == SelectedBlog.Id) == null;
                }
                else
                {
                    res = true;
                }
            }
            return res;
        }


        private bool CanClear()
        {
            bool res = false;
            if(SelectedBlog != null)
            {
                if(VerzamelingBlogs.Count > 0)
                {
                    res = VerzamelingBlogs.FirstOrDefault(f => f.Id == SelectedBlog.Id) != null;
                }
            }
            return res;
        }


        private bool CanDelete()
        {
            bool res = true;
            if(SelectedBlog != null)
            {
                if(VerzamelingBlogs.Count == 0)
                {
                    res = false;
                }
            }
            return res;
        }

        private bool CanNext()
        {
            bool res = false;
            if(SelectedBlog != null)
            {
                if(VerzamelingBlogs.Count > 1)
                {
                    if(VerzamelingBlogs.FirstOrDefault(f => f.Id == SelectedBlog.Id) != null)
                    {
                        int i = VerzamelingBlogs.IndexOf(SelectedBlog);
                        res = (i < VerzamelingBlogs.Count - 1);
                    }
                }
            }
            return res;
        }

        private bool CanPrev()
        {
            bool res = false;
            if(SelectedBlog != null)
            {
                if(VerzamelingBlogs.FirstOrDefault(f => f.Id == SelectedBlog.Id) != null)
                {
                    res = (VerzamelingBlogs.IndexOf(SelectedBlog) > 0);
                }
            }
            return res;
        }
    }
}