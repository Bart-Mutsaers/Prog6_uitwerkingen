using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeagueManager.Service.Model;
using System.Linq;

namespace LeagueManager.Test
{
    [TestClass]
    public class DatabaseTest
    {
        [TestInitialize]
        public void Init()
        {
            using (var context = new MyContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Game");
                context.Database.ExecuteSqlCommand("DELETE FROM Setup");
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestContext()
        {
            //1. arrange
            var context = new MyContext();

            context.Setups.Add(new Setup()
            {
                Jungle = "Shaco",
                PlayerName = "Linksonder"
            });

            
            //2. act
            context.SaveChanges();

            //3. assert
            var result = context.Setups.ToList();
            Assert.AreEqual(1, result.Count);
        }
    }
}
