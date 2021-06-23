using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lesson2.Tests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void Search_FirstElement_0IndexReturned()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int expected = 0;

            int actual = Search.BinarySearch(arr, 0, arr.Length - 1, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Search_LastElement_8IndexReturned()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int expected = 8;

            int actual = Search.BinarySearch(arr, 0, arr.Length - 1, 9);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Search_6MidleElement_5IndexReturned()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int expected = 5;

            int actual = Search.BinarySearch(arr, 0, arr.Length - 1, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Search_Null_ExeptionReturned()
        {
            int[] arr = null;
            NullReferenceException expected = new NullReferenceException();

            try
            {
                int actual = Search.BinarySearch(arr, 0, arr.Length - 1, 1);
            }
            catch (Exception ex)
            {
                    Assert.IsTrue(ex is NullReferenceException);
            } 
        }

        [TestMethod]
        public void Search_0Lenght_ExeptionReturned()
        {
            int[] arr = new int [0];
            NullReferenceException expected = new NullReferenceException();

            try
            {
                int actual = Search.BinarySearch(arr, 0, arr.Length - 1, 1);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentNullException);
            }
        }

        [TestMethod]
        public void Search_NotFoundValue_ExeptionReturned()
        {
            int[] arr = { 1, 2, 3, 4 };
            NullReferenceException expected = new NullReferenceException();

            try
            {
                int actual = Search.BinarySearch(arr, 0, arr.Length - 1, 9);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is KeyNotFoundException);
            }
        }
    }
}
