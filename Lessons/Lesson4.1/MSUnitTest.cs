using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson4._1
{
    [TestClass]
    public class MSUnitTest
    {
        [TestMethod]
        public void TestSum()
        {
            myClass cl = new myClass();

            var tolerance = 0.01;
            double testSum = 2 + 6;
            double realSum = cl.MethodSum(2, 6);

            Assert.AreEqual(testSum, realSum, tolerance);
        }

        [TestMethod]
        public void TestMulti()
        {
            myClass cl = new myClass();
            var tolerance = 0.01;
            double testMulty = 2 * 6;
            double realMulty = cl.MethodMulty(2, 6);

            Assert.AreEqual(testMulty, realMulty, tolerance);
        }

        [TestMethod]
        public void TestDiv()
        {
            myClass cl = new myClass();

            var tolerance = 0.01;
            double testDiv = 6 / 2;
            double realDiv = cl.MethodDiv(6, 2);

            Assert.AreEqual(testDiv, realDiv, tolerance);

        }

        [TestMethod, ExpectedException(typeof(DivideByZeroException))]
        public void TestDivZero()
        {
            myClass cl = new myClass();

            cl.MethodDiv(6, 0);

        }

        [TestMethod]
        public void TestSub()
        {
            myClass cl = new myClass();
            var tolerance = 0.01;
            double testSub = 2 - 6;
            double realSub = cl.MethodSub(2, 6);
            Assert.AreEqual(testSub, realSub, tolerance);
        }

    }
    
}
