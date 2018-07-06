using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvosTest;
using System.Numerics;
using System.Collections.Generic;

namespace UnitTestTribonacci
{
    [TestClass]
    public class TribonacciTest
    {
        List<BigInteger> expectedValues;
        Tribonacci tribonacci;


        [TestInitialize]
        public void TestInit()
        {
            expectedValues = new List<BigInteger>() {
                1,1,1,3,5,9,17,31,57,105,193,355
            };
            tribonacci = new Tribonacci();
        }

        [TestMethod]
        public void TestRecursive()
        {
            //act
            for (int i = 0; i < expectedValues.Count; i++)
            {
                //assert
                Assert.AreEqual(expectedValues[i], tribonacci.GetValueRecursive(i));
            }


            Assert.ThrowsException<ArgumentException>(() => tribonacci.GetValueRecursive(-1));

        }

        [TestCleanup]
        public void TestClean()
        {
            expectedValues = null;
            tribonacci = null;
        }

        [TestMethod]
        public void TestRecursiveMeoize()
        {
            //act
            for (int i = 0; i < expectedValues.Count; i++)
            {
                //assert
                Assert.AreEqual(expectedValues[i], tribonacci.GetValueRecursiveMemoize(i));
            }

            Assert.ThrowsException<ArgumentException>(() => tribonacci.GetValueRecursiveMemoize(-1));

        }
        [TestMethod]
        public void TestLoop()
        {
            //act
            for (int i = 0; i < expectedValues.Count; i++)
            {
                //assert
                Assert.AreEqual(expectedValues[i], tribonacci.GetValueLoop(i));
            }

            Assert.ThrowsException<ArgumentException>(() => tribonacci.GetValueLoop(-1));

        }

        [TestMethod]
        public void TestRange()
        {
            //arrange
            var expValues = new List<BigInteger>() {
               3,5,9,17,31
           };

            //act
            var res = tribonacci.GetRange(3, 7).ToList();


            //assert
            Assert.AreEqual(expValues.Count, res.Count);

            for (int i = 0; i < res.Count; i++)
            {
                Assert.AreEqual(expValues[i], res[i]);
            }

            Assert.ThrowsException<ArgumentException>(()=>tribonacci.GetRange(-1, 100));
            Assert.ThrowsException<ArgumentException>(()=>tribonacci.GetRange(1000, 100));
        }

    }
}
