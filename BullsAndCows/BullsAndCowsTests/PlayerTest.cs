namespace BullsAndCowsTests
{
    using System;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCows;

    /// <summary>
    /// Summary description for PlayerTest
    /// </summary>
    [TestClass]
    public class PlayerTest
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestNewplayerConstructorName()
        {
            string name = "Ivan Ivanov";
            Player player = new Player(name);

            Assert.AreEqual(player.Name, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNewPlayerConstructorNullName()
        {
            string name = null;
            Player player = new Player(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNewPlayerConstructorEmptyName()
        {
            string name = string.Empty;
            Player player = new Player(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewPlayerConstructorShortName()
        {
            string name = "di";
            Player player = new Player(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewPlayerConstructorLongName()
        {
            string name = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut";
            Player player = new Player(name);
        }

        [TestMethod]
        public void TestNewplayerConstructorAttempts()
        {
            string name = "Ivan Ivanov";
            Player player = new Player(name);
            player.Attempts = 20;

            Assert.AreEqual(player.Attempts, 20);
        }

        [TestMethod]
        public void TestNewPlayerConstructorHasCheated()
        {
            string name = "Ivan Ivanov";
            Player player = new Player(name);
            player.HasCheated = false;

            Assert.AreEqual(player.HasCheated, false);
        }

        [TestMethod]
        public void TestPlayerToString()
        {
            string name = "Ivan Ivanov";
            int attempts = 20;
            Player player = new Player(name);
            player.Score = attempts;
            string actual = player.ToString();

            StringBuilder expected = new StringBuilder();
            expected.AppendFormat("{0,-10} --> {1, 5}", name, attempts);
            
            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
