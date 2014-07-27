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


        [TestMethod]
        public void TestGetNumberOfBullsIn1234ComparedTo1567()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 1567);
            Assert.AreEqual(1, numbersComparer.GetNumberOfBulls());
        }

        [TestMethod]
        public void TestGetNumberOfBullsIn1234ComparedTo5267()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 5267);
            Assert.AreEqual(1, numbersComparer.GetNumberOfBulls());
        }

        [TestMethod]
        public void TestGetNumberOfBullsIn1234ComparedTo5637()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 5637);
            Assert.AreEqual(1, numbersComparer.GetNumberOfBulls());
        }

        [TestMethod]
        public void TestGetNumberOfBullsIn1234ComparedTo5674()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 5674);
            Assert.AreEqual(1, numbersComparer.GetNumberOfBulls());
        }

        [TestMethod]
        public void TestGetNumberOfBullsIn1234ComparedTo1267()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 1267);
            Assert.AreEqual(2, numbersComparer.GetNumberOfBulls());
        }

        [TestMethod]
        public void TestGetNumberOfBullsIn1234ComparedTo1243()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 1243);
            Assert.AreEqual(2, numbersComparer.GetNumberOfBulls());
        }

        //fffffffffffffff

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo1567()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 1567);
            Assert.AreEqual(0, numbersComparer.GetNumberOfCows());
        }

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo5267()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 5267);
            Assert.AreEqual(0, numbersComparer.GetNumberOfCows());
        }

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo5637()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 5637);
            Assert.AreEqual(0, numbersComparer.GetNumberOfCows());
        }

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo5674()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 5674);
            Assert.AreEqual(0, numbersComparer.GetNumberOfCows());
        }

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo1267()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 1267);
            Assert.AreEqual(0, numbersComparer.GetNumberOfCows());
        }

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo1243()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 1243);
            Assert.AreEqual(2, numbersComparer.GetNumberOfCows());
        }

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo2145()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 1245);
            Assert.AreEqual(1, numbersComparer.GetNumberOfCows());
        }

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo2153()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 1253);
            Assert.AreEqual(1, numbersComparer.GetNumberOfCows());
        }

        [TestMethod]
        public void TestGetNumberOfCowsIn1234ComparedTo2143()
        {
            NumbersComparer numbersComparer = new NumbersComparer(1234, 2143);
            Assert.AreEqual(4, numbersComparer.GetNumberOfCows());
        }
    }
}
