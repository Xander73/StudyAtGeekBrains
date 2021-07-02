using Lesson7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        int N = 3;
        int M = 3;

        [TestMethod]
        public void NumberWaysRecursion_3X3ArrayMode_ArrayReturned()
        {
            int[,] expected = new int[,] { { 1, 1, 1 }, { 1, 2, 3 }, { 1, 3, 6 } };
            Exercise ex = new Exercise();
            ex.N = 3;
            ex.M = 3;
            int[,] actual = new int[ex.N, ex.M];

            ex.NumberWaysRecursion(0, 0, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberWaysRecursion_2X2Array_ArrayWith4ElementReturned()
        {
            int[,] expected = new int[,] { { 1, 1 }, { 1, 2 } };
            Exercise ex = new Exercise();
            ex.N = 2;
            ex.M = 2;
            int[,] actual = new int[ex.N, ex.M];

            ex.NumberWaysRecursion(0, 0, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberWaysRecursion_5X5Array_ArrayWith1ElementReturned()
        {
            int[,] expected = new int[,] {
                { 1, 1, 1, 1, 1 },
                { 1, 2, 3, 4, 5 },
                { 1, 3, 6, 10, 15 },
                { 1, 4, 10, 20, 35 },
                { 1, 5, 15, 35, 70 },
                };
            Exercise ex = new Exercise();
            ex.N = 5;
            ex.M = 5;
            int[,] actual = new int[ex.N, ex.M];

            ex.NumberWaysRecursion(0, 0, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberWaysRecursion_NotEmptyArray_ArrayWith1ElementReturned()
        {
            int[,] expected = new int[,] {
                { 1, 1},
                { 1, 2}                 
                };
            Exercise ex = new Exercise();
            ex.N = 2;
            ex.M = 2;
            int[,] actual = new int[ex.N, ex.M];

            for (int i = 0; i < ex.N; ++i)
                for (int j = 0; j < ex.M; ++j)
                    actual[i, j] = 9;

            ex.NumberWaysRecursion(0, 0, actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberWaysRecursion_NullArray_ArrayWith1ElementReturned()
        {
            int[,] expected = new int[,] {
                { 1, 1},
                { 1, 2}
                };
            Exercise ex = new Exercise();
            ex.N = 2;
            ex.M = 2;
            int[,] actual = null;

            try
            {
                ex.NumberWaysRecursion(0, 0, actual);
            }
            catch (Exception e)
            {

                Assert.IsTrue(e is NullReferenceException);
            }
        }

        [TestMethod]
        public void NumberVariants_16_36Returned()
        {
            int expected = 36;
            Exercise ex = new Exercise();
            int actual = ex.NumberVariants(16);

            Assert.AreEqual(expected, actual);            
        }

        [TestMethod]
        public void NumberVariants_1_1Returned()
        {
            int expected = 1;
            Exercise ex = new Exercise();
            int actual = ex.NumberVariants(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberVariants_0_0Returned()
        {
            int expected = 0;
            Exercise ex = new Exercise();
            int actual = ex.NumberVariants(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberVariants_Minus16_36Returned()
        {
            int expected = 36;
            Exercise ex = new Exercise();
            int actual = ex.NumberVariants(-16);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberVariants_Minus1_1Returned()
        {
            int expected = 1;
            Exercise ex = new Exercise();
            int actual = ex.NumberVariants(-1);

            Assert.AreEqual(expected, actual);
        }

    }
}