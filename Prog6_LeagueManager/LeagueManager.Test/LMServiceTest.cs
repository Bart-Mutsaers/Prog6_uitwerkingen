using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueManager.Service;
using LeagueManager.Service.Model;
using System.Linq;

namespace LeagueManager.Test
{
    [TestClass]
    public class LMServiceTest
    {
        [TestInitialize]
        public void Init()
        {
            ClearTables();
        }

        public void ClearTables()
        {
            using (var context = new MyContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Game");
                context.Database.ExecuteSqlCommand("DELETE FROM Setup");
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void LMServiceTest_SendSetup_Success()
        {
            //1. Arrange
            ILMService service = new LMService();

            var setup = new SetupContract()
            {
                PlayerName = "Linksonder",
                Top = "Jax",
                Jungle = "Zac",
                Mid = "Katarina",
                Supp = "Sona",
                Adc = "Vayne"
            };

            //2. Act
            int id = service.SendSetup(setup);

            //3. Assert
            using (var context = new MyContext())
            {
                var game = context.Games.First();

                Assert.AreEqual(1, context.Games.Count());
                Assert.IsNotNull(game.PlayerOne);
                Assert.IsNull(game.PlayerTwo);
            }
        }

        [TestMethod]
        public void LMServiceTest_SendSetupTwice_Success()
        {
            //1. Arrange
            ClearTables();
            ILMService service = new LMService();

            var setup = new SetupContract()
            {
                PlayerName = "Linksonder",
                Top = "Jax",
                Jungle = "Zac",
                Mid = "Katarina",
                Supp = "Sona",
                Adc = "Vayne"
            };

            //2. Act
            int id = service.SendSetup(setup);

            setup.PlayerName = "Rechtsboven";

            id = service.SendSetup(setup);

            //3. Assert
            using (var context = new MyContext())
            {
                var game = context.Games.First();

                Assert.AreEqual(1, context.Games.Count());
                Assert.IsNotNull(game.PlayerOne);
                Assert.IsNotNull(game.PlayerTwo);
                Assert.IsNotNull(game.Winner);
                Assert.AreEqual("Linksonder", game.PlayerOne.PlayerName);
            }
        }

        [TestMethod]
        public void LMServiceTest_GetGameResult_Success()
        {

            //1. Arrange
            ILMService service = new LMService();
            ClearTables();
            Game game = null;

            using (var context = new MyContext())
            {
                game = new Game()
                {
                    PlayerOne = new Setup()
                    {
                        PlayerName = "Linksonder"
                    },
                    TimeStamp = new DateTime(1990, 03, 15)
                };

                context.Games.Add(game);
                context.SaveChanges();
            }

            //2. Act
            GameContract result = service.GetGameResult(game.Id);

            //3. Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlayerOne);
            Assert.IsNull(result.PlayerTwo);
            Assert.IsNull(result.Winner);


        }
    }
}
