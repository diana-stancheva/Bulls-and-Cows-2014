using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCowsTests
{
    [TestClass]
    public class NullPlayerTest
    {
        [TestMethod]
        public void TestNewNullPlayerConstructorName()
        {
            NullPlayer player = new NullPlayer();
            Assert.AreEqual(player.Name, "Unknown Player");
        }

        [TestMethod]
        public void TestNewNullPlayerConstructorAttempts()
        {
            NullPlayer player = new NullPlayer();
            player.Attempts = 20;

            Assert.AreEqual(player.Attempts, 20);
        }

        [TestMethod]
        public void TestNewNullPlayerConstructorHasCheated()
        {
            NullPlayer player = new NullPlayer();
            player.HasCheated = false;

            Assert.AreEqual(player.HasCheated, false);
        }

        [TestMethod]
        public void TestNullPlayerToString()
        {
            int attempts = 20;
            NullPlayer player = new NullPlayer();
            player.Score = attempts;
            string actual = player.ToString();

            StringBuilder expected = new StringBuilder();
            expected.AppendFormat("{0,-10} --> {1, 5}", "Unknown Player", attempts);

            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
