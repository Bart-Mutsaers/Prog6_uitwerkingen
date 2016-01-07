using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueManager.WPF.ViewModel
{
    public class TeamViewModel : ViewModelBase
    {
        private string top;
        public string Top
        {
            get { return top; }
            set { top = value; RaisePropertyChanged("Top"); }
        }

        private string jungle;
        public string Jungle
        {
            get { return jungle; }
            set { jungle = value; RaisePropertyChanged("Jungle"); }
        }

        private string mid;
        public string Mid
        {
            get { return mid; }
            set { mid = value; RaisePropertyChanged("Mid"); }
        }

        private string adc;
        public string Adc
        {
            get { return adc; }
            set { adc = value; RaisePropertyChanged("Adc"); }
        }

        private string supp;
        public string Supp
        {
            get { return supp; }
            set { supp = value; RaisePropertyChanged("Supp"); }
        }


        internal void MapSetup(LMService.SetupContract setupContract)
        {
            this.Adc = setupContract.Adc;
            this.Top = setupContract.Top;
            this.Mid = setupContract.Mid;
            this.Jungle = setupContract.Jungle;
            this.Supp = setupContract.Supp;
        }
    }
}
