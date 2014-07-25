using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows;

namespace BullsAndCowsTests
{
    [TestClass]
    public class NumbersComparerTest
    {
        [TestMethod]
        public void TestNewNumberComparerConstructor()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1000, 1000);
            Assert.AreEqual(numbersComparer.GetNumberOfBulls(), 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNewNumberComparerConstructorRange()
        {
            NumbersComparer numbersComparer = new NumbersComparer(999, 999);
        }
    }
}
