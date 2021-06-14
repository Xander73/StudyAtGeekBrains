using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lesson3.Tests
{
    [TestClass]
    public class BenchmarkClassTests
    {
        [TestMethod]
        public void PointDistanceClass_3And4_10Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            float exersice = 10;

            float actual = bmc.PointDistanceClass(new PointClassFloat(3.0F, 4.0F), new PointClassFloat(3.0F, 4.0F));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceClass_0And0_0Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            float exersice = 0;

            float actual = bmc.PointDistanceClass(new PointClassFloat(0.0F, 0.0F), new PointClassFloat(0.0F, 0.0F));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceClass_3And3_10Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 8.4852809906005859;


            double actual = bmc.PointDistanceClass(new PointClassFloat(3, 3), new PointClassFloat(3, 3));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceClass_NegativeFirstAndPositiveSecondArguments_10Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 2.8284270763397217;

            double actual = bmc.PointDistanceClass(new PointClassFloat(-5, -5), new PointClassFloat(3, 3));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceClass_NullAndNull_10Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            NullReferenceException exersice = new NullReferenceException();
            try
            {
                double actual = bmc.PointDistanceClass(null, null);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is NullReferenceException);
            }
        }




        [TestMethod]
        public void PointDistanceStructFloat_3And4_10Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            float exersice = 10;

            float actual = bmc.PointDistanceStructFloat(new PointStruct(3.0, 4.0), new PointStruct(3.0, 4.0));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructFloat_0And0_0Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            float exersice = 0;

            float actual = bmc.PointDistanceStructFloat(new PointStruct(0.0F, 0.0F), new PointStruct(0.0F, 0.0F));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructFloat_3And3_NumberReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 8.4852809906005859;


            double actual = bmc.PointDistanceStructFloat(new PointStruct(3, 3), new PointStruct(3, 3));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructFloat_NegativeFirstAndPositiveSecondArguments_NumberReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 2.8284270763397217;

            double actual = bmc.PointDistanceStructFloat(new PointStruct(-5, -5), new PointStruct(3, 3));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructFloat_NullAndNull_NullReferenceExceptionReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            char exersice = 'z';
            
                double actual = bmc.PointDistanceStructFloat(new PointStruct(-5, -5), new PointStruct(3, 3));

            Assert.AreNotEqual(exersice.GetType(), actual.GetType());

        }

        //-----------------------------------------------------

        [TestMethod]
        public void PointDistanceStructDouble_3And4_10Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 10;

            double actual = bmc.PointDistanceStructDouble(new PointStruct(3.0, 4.0), new PointStruct(3.0, 4.0));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructDouble_0And0_0Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 0;

            double actual = bmc.PointDistanceStructDouble(new PointStruct(0, 0), new PointStruct(0.0, 0.0));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructDouble_3And3_NumberReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 8.48528137423857;


            double actual = bmc.PointDistanceStructDouble(new PointStruct(3, 3), new PointStruct(3, 3));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructDouble_NegativeFirstAndPositiveSecondArguments_NumberReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 2.8284271247461903;

            double actual = bmc.PointDistanceStructDouble(new PointStruct(-5, -5), new PointStruct(3, 3));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructDouble_NullAndNull_NullReferenceExceptionReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            char exersice = 'z';

            double actual = bmc.PointDistanceStructDouble(new PointStruct(-5, -5), new PointStruct(3, 3));

            Assert.AreNotEqual(exersice.GetType(), actual.GetType());
        }

        //-------------------------------------------------------------------------

        [TestMethod]
        public void PointDistanceStructFloatWithoutSqrt_3And4_10Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 10;

            double actual = bmc.PointDistanceStructDouble(new PointStruct(3.0, 4.0), new PointStruct(3.0, 4.0));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructFloatWithoutSqrt_0And0_0Returned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 0;

            double actual = bmc.PointDistanceStructDouble(new PointStruct(0, 0), new PointStruct(0.0, 0.0));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructFloatWithoutSqrt_3And3_NumberReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 8.48528137423857;


            double actual = bmc.PointDistanceStructDouble(new PointStruct(3, 3), new PointStruct(3, 3));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructFloatWithoutSqrt_NegativeFirstAndPositiveSecondArguments_NumberReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            double exersice = 2.8284271247461903;

            double actual = bmc.PointDistanceStructDouble(new PointStruct(-5, -5), new PointStruct(3, 3));

            Assert.AreEqual(exersice, actual);
        }

        [TestMethod]
        public void PointDistanceStructFloatWithoutSqrt_NullAndNull_NullReferenceExceptionReturned()
        {
            BenchmarkClass bmc = new BenchmarkClass();
            char exersice = 'z';

            double actual = bmc.PointDistanceStructDouble(new PointStruct(-5, -5), new PointStruct(3, 3));

            Assert.AreNotEqual(exersice.GetType(), actual.GetType());
        }
    }
}