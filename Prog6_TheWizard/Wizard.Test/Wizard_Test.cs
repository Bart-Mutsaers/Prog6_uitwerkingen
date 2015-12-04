using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace Wizard.Test.Uitwerking
{
    [TestClass]
    public class Wizard_Test 
    {
        private Wizard.Tovenaar tovenaar;
        private Wizard.Toverstaf staf;
 
        [TestInitialize]
        public void Init()
        {
            staf = new Toverstaf();
            tovenaar = new Tovenaar(staf);
        }

        [TestMethod]
        public void Foramisforameur_goed()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { "Fora", "mis", "Forameur" };
            List<String> ing = new List<String>() { "spinneweb", "oorlel", "slangegif" };

            //2. Act
            String result = tovenaar.Toverspreuk(ing, woorden);

            //3. Assert
            Assert.AreEqual("doe open die poort", result);
        }


        [TestMethod]
        [ExpectedException(typeof(VerkeerdeIngredientenException))]
        public void Foramisforameur_fout_verkeerdeIngredienten()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { "Fora", "mis", "Forameur" };
            List<String> ing = new List<String>() { "spinneweb", "oorlel",  };

            //2. Act
            String result = tovenaar.Toverspreuk(ing, woorden);

            //3. Assert
            Assert.AreEqual("doe open die poort", result);
        }


        [TestMethod]
        [ExpectedException(typeof(VerkeerdeWoordenException))]
        public void Foramisforameur_fout_verkeerdeWoorden()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { "Fora", "mis", "Forameut" };
            List<String> ing = new List<String>() { "spinneweb", "oorlel", "slangegif" };

            //2. Act
            String result = tovenaar.Toverspreuk(ing, woorden);

            //3. Assert
            Assert.AreEqual("doe open die poort", result);
        }


        [TestMethod]
        [ExpectedException(typeof(VerkeerdeIngredientenException))]
        public void Foramisforameur_fout()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { "Fora", "mis", "Forameur" };
            List<String> ing = new List<String>() { "spinneweb", "oorlel" };

            //2. Act
            String result = tovenaar.Toverspreuk(ing, woorden);

            //3. Assert
            Assert.AreEqual("Toverspreuk mislukt", result);
        }
        
        [TestMethod]
        public void FlimFlamFluister_Goed()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { "Flim", "Flam", "Fluister" };
            List<String> ing = new List<String>() { "Kikkerbil", "oorlel", "rattenstaart", "krokodillenoog" };
            
            Mock<IToverstaf> stafMock = new Mock<IToverstaf>();
            Tovenaar t = new Tovenaar(stafMock.Object);

            //2. Act
            String result = t.Toverspreuk(ing, woorden);

            //3. Assert
            //Controlleer of de tovernaar de juiste bewegingen maakt
            stafMock.Verify(s => s.Links(), Times.Once);
            stafMock.Verify(s => s.Rechts(), Times.Once);
            stafMock.Verify(s => s.Omhoog(), Times.Never);

            Assert.AreEqual("Er was licht, en hij zag dat het goed was!", result);
        }

        [TestMethod]
        public void Bandaladik_goed()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { "Ban", "da", "ladik"};
            List<String> ing = new List<String>() { "Kikkerbil", "oorlel", "rattenstaart", "slangegif" };
            Mock<IToverstaf> stafMock = new Mock<IToverstaf>();
            Tovenaar t = new Tovenaar(stafMock.Object);
            
            //2. Act
            String result = t.Toverspreuk(ing, woorden);

            //3. Assert
            //Controlleer of de tovernaar de juiste bewegingen maakt
            Assert.AreEqual("best friends for life", result);
            stafMock.Verify(s => s.Omhoog(), Times.Once);
            stafMock.Verify(s => s.Omlaag(), Times.Once);
            stafMock.Verify(s => s.Links(), Times.Never);
         
            

        }


        /**
         * Deze test gaat niet goed! 
         * We kunnen de spreuk Arma-kro-dilt niet testen, omdat deze gebruik maakt van een zilvere pot.
         * Onze tovenaar heeft altijd een zwarte pot :*( 
         **/
        [TestMethod]
        public void ArmaKroDilt_Goed(){
               //1. Arrange
            List<String> woorden = new List<String>() { "Arma", "kro", "dilt"};
            List<String> ing = new List<String>() { "Kikkerbil", "spinneweb", "oorlel", "rattenstaart", "slangegif", "mensenhaar", "krokodillenoog" };
            Mock<IToverstaf> stafMock = new Mock<IToverstaf>();
            Tovenaar t = new Tovenaar(stafMock.Object);
            
            //2. Act
            String result = t.Toverspreuk(ing, woorden);

            //3. Assert
            //Controlleer of de tovernaar de juiste bewegingen maakt
            Assert.AreEqual("upgrades", result);
        }


        //Bal-sam-sala-bond
        //[ Kikkerbil, spinneweb, mensenhaar, krokodillenoog ]
        //“Genezingstoverij die de verloren levensenergie terugbrengt.”
        //Bewegingen: Links, omhoog, rechts, omlaag (volgorde is belangrijk!)
        //Resultaat: ‘Je bent genezen met 3 energiepunten’
        //** Aantal energie is gelijk aan de energie in je toverstaf **
        [TestMethod]
        public void BalSamSalaBond()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { "Bal", "sam", "sala", "bond" };
            List<String> ing = new List<String>() { "Kikkerbil", "spinneweb", "mensenhaar", "krokodillenoog" };
            
            Mock<IToverstaf> stafMock = new Mock<IToverstaf>();
            stafMock.Setup(staf => staf.HoeveelheidEnergie).Returns(3);
            
            String volgorde = "";
            stafMock.Setup(staf => staf.Omhoog()).Callback(() => volgorde += "omhoog");
            stafMock.Setup(staf => staf.Omlaag()).Callback(() => volgorde += "omlaag");
            stafMock.Setup(staf => staf.Links()).Callback(() => volgorde += "links");
            stafMock.Setup(staf => staf.Rechts()).Callback(() => volgorde += "rechts");

            Tovenaar t = new Tovenaar(stafMock.Object);

            //2. Act
            String result = t.Toverspreuk(ing, woorden);

            //3. Assert
            //Controlleer of de tovernaar de juiste bewegingen maakt
            Assert.AreEqual("Je bent genezen met 3 energiepunten", result);



        }

        [TestMethod]
        [ExpectedException(typeof(GeenIngredientenException))]
        public void GeenIngredienten()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { };
            Mock<IToverstaf> stafMock = new Mock<IToverstaf>();
            Tovenaar t = new Tovenaar(stafMock.Object);

            //2. Act
            String result = t.Toverspreuk(null, woorden);
        }

        [TestMethod]
        [ExpectedException(typeof(GeenToverspreukException))]
        public void GeenToverspreuk()
        {
            //1. Arrange
            List<String> woorden = new List<String>() { "Arma"};
            List<String> ing = new List<String>() { "Kikkerbil"};
            Mock<IToverstaf> stafMock = new Mock<IToverstaf>();
            Tovenaar t = new Tovenaar(stafMock.Object);

            //2. Act
            String result = t.Toverspreuk(ing, woorden);

            //3. Assert
            //Controlleer of de tovernaar de juiste bewegingen maakt
        }
    }
}
