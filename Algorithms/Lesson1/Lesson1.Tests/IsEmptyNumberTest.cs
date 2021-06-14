using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lesson1;

namespace Lesson1.Tests
{
    [TestClass]
    public class IsEmptyNumberTest
    {
        
        
        [TestMethod]
        public void Start_1_Empty()
        {
            string actual = "";
            string expected = "Empty";

            actual = IsEmptyNumber.IsEmpty(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Start_4_NotEmpty()
        {
            string actual = "";
            string expected = "Not empty";

            actual = IsEmptyNumber.IsEmpty(4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Start_Minus1_Empty()
        {
            string actual = "";
            string expected = "Wrong parameter";

            actual = IsEmptyNumber.IsEmpty(-1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Start_Wrong_0_Empty()
        {
            string actual = "";
            string expected = "Wrong parameter";

            actual = IsEmptyNumber.IsEmpty(0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Start_Wrong_6_Empty()
        {
            string actual = "";
            string expected = "Empty";

            actual = IsEmptyNumber.IsEmpty(6);

            Assert.AreNotEqual(expected, actual);
        }
    }
}
