using System;
using NUnit.Framework;
using NUnit.VisualStudio.TestAdapter;
using Lesson4._1;

namespace Lesson4._2_class_work_NUnit_Test_
{
    [TestFixture]
    public class NUnitTest
    {
        [Test]
        public void NTestSum()
        {
            myClass cl = new myClass();
            var tolerance = 0.01;
            double testSum = 2 + 6;
            double realSum = cl.MethodSum(2, 6);
            Assert.AreEqual(testSum, realSum, tolerance);
        }

        [Test]
        public void NTestMulti()
        {
            myClass cl = new myClass();
            var tolerance = 0.01;
            double testMulty = 2 * 6;
            double realMulty = cl.MethodMulty(2, 6);
            Assert.AreEqual(testMulty, realMulty, tolerance);
        }

        [Test]
        public void NTestDiv()
        {
            myClass cl = new myClass();
            var tolerance = 1;
            double testDiv = 6 / 2;
            double realDiv = cl.MethodDiv(6, 2);
            Assert.AreEqual(testDiv, realDiv, tolerance);
        }

        [Test]
        // [ExpectedException(typeof(DivideByZeroException))] //Only < 3 version
        public void NTestDivZero()
        {
            myClass cl = new myClass();
            // cl.MethodDiv(6, 0);
            Assert.Throws<DivideByZeroException>(() => cl.MethodDiv(6, 0));
        }

        [Test]
        public void NTestSub()
        {
            myClass cl = new myClass();
            var tolerance = 1;
            double testSub = 2 - 6;
            double realSub = cl.MethodSub(2, 6);
            Assert.AreEqual(testSub, realSub, tolerance);
        }

    }
   
}
