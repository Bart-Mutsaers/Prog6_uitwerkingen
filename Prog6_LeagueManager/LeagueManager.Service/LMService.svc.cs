using LeagueManager.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LeagueManager.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LMService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LMService.svc or LMService.svc.cs at the Solution Explorer and start debugging.
    public class LMService : ILMService
    {
        public int SendSetup(SetupContract setup)
        {
                var setupModel = new Setup()
                {
                    PlayerName = setup.PlayerName,
                    Top = setup.Top,
                    Jungle = setup.Jungle,
                    Mid = setup.Mid,
                    Supp = setup.Supp,
                    Adc = setup.Adc
                };

             using (var context = new MyContext())
             {
                 var game = context.Games.FirstOrDefault(m => m.PlayerTwo == null);

                 if(game != null)
                 {
                     game.PlayerTwo = setupModel;
                     game.Winner = game.PlayerOne;
                     game.TimeStamp = DateTime.Now;
                 }
                 else
                 {
                     game = new Game()
                     {
                         PlayerOne = setupModel,
                         TimeStamp = DateTime.Now,
                     };

                     context.Games.Add(game);
                 }

                context.SaveChanges();
                return game.Id;
            }
        }


        public GameContract GetGameResult(int gameId)
        {
            using(var context = new MyContext())
            {
                var game = context.Games.Find(gameId);

                if (game == null)
                    return null;

                var gameContract = new GameContract();
               
                gameContract.Id = game.Id;
                gameContract.TimeStamp = game.TimeStamp;
                gameContract.PlayerOne = new SetupContract(game.PlayerOne);

                if(game.PlayerTwo != null)
                    gameContract.PlayerTwo = new SetupContract(game.PlayerTwo);
                
                if(game.Winner != null)
                    gameContract.Winner = new SetupContract(game.Winner);

                return gameContract;
               
            }
        }
    }
}
