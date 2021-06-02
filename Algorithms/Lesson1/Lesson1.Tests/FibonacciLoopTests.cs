using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson1.Tests
{
    [TestClass]
    public class FibonacciLoopTests
    {
        [TestMethod]
        public void ProcessingFibonacci_0_0Returned()
        {
            int actual = -100;
            int expected = 0;

            actual = FibonacciLoop.ProcessingFibonacci(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessingFibonacci_1_1Returned()
        {
            int actual = -100;
            int expected = 1;

            actual = FibonacciLoop.ProcessingFibonacci(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessingFibonacci_8_21Returned()
        {
            int actual = -100;
            int expected = 21;

            actual = FibonacciLoop.ProcessingFibonacci(8);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessingFibonacci_Minus5_Minus1Returned()
        {
            int actual = -100;
            int expected = -1;

            actual = FibonacciLoop.ProcessingFibonacci(-5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProcessingFibonacci_Minus1_Minus1Returned()
        {
            int actual = -100;
            int expected = -1;

            actual = FibonacciLoop.ProcessingFibonacci(-1);

            Assert.AreEqual(expected, actual);
        }
    }
}
