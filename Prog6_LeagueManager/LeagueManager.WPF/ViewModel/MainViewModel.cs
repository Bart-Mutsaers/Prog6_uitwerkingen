using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace LeagueManager.WPF.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        //Private fields
        private string _playername;
        private LMService.ILMService service;
        private Timer timer;

        //Public properties
        public List<string> Champions { get; set; }
        public TeamViewModel MyTeam { get; set; }
        public TeamViewModel EnemyTeam { get; set; }
        public ICommand SendSetupCommand { get; set; }
        public ICommand NewGameCommannd { get; set; }
        public string Winner { get; set; }
        public int GameId { get; set; }

        public bool CanSendSetup { get; set; }

        public MainViewModel()
        {
            timer = new Timer();
            service = new LMService.LMServiceClient();
            timer.Interval = 2000;
            timer.Elapsed += timer_Elapsed;

            MyTeam = new TeamViewModel();
            EnemyTeam = new TeamViewModel();
            SendSetupCommand = new RelayCommand(SendSetup);
            NewGameCommannd = new RelayCommand(NewGame);
            CanSendSetup = true;
            //Deze halen we later op vanuit de server
            Champions = new List<string>(){
              "Shaco",
              "Sona",
              "Vayne",
              "Leblanc",
              "Aatrox"
            };

            //Default setup
            MyTeam.Top = "Aatrox";
            MyTeam.Jungle = "Shaco";
            MyTeam.Mid = "Leblanc";
            MyTeam.Adc = "Vayne";
            MyTeam.Supp = "Sona";
        }

        private void NewGame()
        {
            this.MyTeam = new TeamViewModel();
            this.EnemyTeam = new TeamViewModel();
            this.Winner = null;
            this.CanSendSetup = true;
            RaisePropertyChanged("MyTeam");
            RaisePropertyChanged("EnemyTeam");
            RaisePropertyChanged("CanSendSetup");

        }



        private void SendSetup()
        {
            
            LMService.SetupContract setup = new LMService.SetupContract();
            setup.Adc = MyTeam.Adc;
            setup.Jungle = MyTeam.Jungle;
            setup.Mid = MyTeam.Mid;
            setup.Supp = MyTeam.Supp;
            setup.Top = MyTeam.Top;
            setup.PlayerName = "Linksonder";

            this.GameId = service.SendSetup(setup);
            timer.Start();
        }

        public void ShowWinner()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                WinnerDialog dialog = new WinnerDialog();
                dialog.ShowDialog();
            });
          
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var game = service.GetGameResult(this.GameId);

            if (game.Winner != null)
            {
                timer.Stop();
                this.Winner = game.Winner.PlayerName;
                this.CanSendSetup = false;
                RaisePropertyChanged("CanSendSetup");
                if (game.PlayerOne.PlayerName == this._playername)
                {
                    this.EnemyTeam.MapSetup(game.PlayerTwo);
                }
                else
                {
                    this.EnemyTeam.MapSetup(game.PlayerOne);
                }
                ShowWinner();
            }

           
        }

        
    }
}