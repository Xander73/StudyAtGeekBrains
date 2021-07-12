using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Lesson8.Tests
{
    [TestClass]
    public class BucketSortClassTests
    {
        [TestMethod]
        public void BucketSort_ListWithUnsorted5Elements_SortedListReturned()
        {
            List<int> expected = new List<int> { 1, 2, 3, 4, 5 };
            List<int> tempList = new List<int> { 2, 5, 1, 3, 4 };
            var actual = BucketSortClass.BucketSort(tempList);

            CollectionAssert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void BucketSort_ListWithUnsorted1Element_SortedListReturned()
        {
            List<int> expected = new List<int> { 1 };
            List<int> tempList = new List<int> { 1 };
            var actual = BucketSortClass.BucketSort(tempList);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BucketSort_ListWithUnsortedList_SortedListFromArgumetnReturned()
        {
            List<int> expected = new List<int> { 1, 2, 3, 4, 5 };
            List<int> tempList = new List<int> { 2, 5, 1, 3, 4 };
            var actual = BucketSortClass.BucketSort(tempList);

            CollectionAssert.AreEqual(tempList, actual);
        }

        [TestMethod]
        public void BucketSort_nullList_ArgumentNullExeptionReturned()
        {
            List<int> expected = new List<int> { 1, 2, 3, 4, 5 };
            List<int> tempList = null; 

            try
            {
                var actual = BucketSortClass.BucketSort(tempList);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is ArgumentNullException);
            }  
        }

        [TestMethod]
        public void BucketSort_EmptyList_SortedListFromArgumetnReturned()
        {
            List<int> expected = new List<int> { 1, 2, 3, 4, 5 };
            List<int> tempList = new List<int> { 2, 5, 1, 3, 4 };
            var actual = BucketSortClass.BucketSort(tempList);

            CollectionAssert.AreEqual(tempList, actual);
        }
    }


}