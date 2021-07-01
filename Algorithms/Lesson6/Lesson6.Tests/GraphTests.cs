using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Lesson6.Tests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void BFG_FirstElementSearch_FirstElementReturned()
        {
            List<string> expected = new List<string> { "A" };
            Graph gr = new Graph();
            List<string> actual = new List<string>();
            gr.BFG(actual, gr.Nodes[0], "A");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BFG_LastElementSearch_LastElementReturned()
        {
            List<string> expected = new List<string> { "AB", "AC", "BD", "CE", "DF", ""};
            Graph gr = new Graph();
            List<string> actual = new List<string>();
            gr.BFG(actual, gr.Nodes[0], "F");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BFG_NotElementSearch_EmptyStringReturned()
        {
            List<string> expected = new List<string> ();
            Graph gr = new Graph();
            List<string> actual = new List<string>();
            gr.BFG(actual, gr.Nodes[0], "G");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BFG_NodeIsNull_EmptyListReturned()
        {
            List<string> expected = new List<string> ();
            Graph gr = new Graph();
            List<string> actual = new List<string>();
            gr.BFG(actual, null, "F");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BFG_SearchPathListIsNull_NullReferenseExceptionReturned()
        {
            List<string> expected = new List<string>();
            Graph gr = new Graph();
            List<string> actual = null;
            try
            {
                gr.BFG(actual, gr.Nodes[0], "F");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [TestMethod]
        public void DFG_FirstElementSearch_FirstElementReturned()
        {
            List<string> expected = new List<string> { "A" };
            Graph gr = new Graph();
            List<string> actual = new List<string>();
            gr.DFG(actual, gr.Nodes[0], "A");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DFG_LastElementSearch_LastElementReturned()
        {
            List<string> expected = new List<string> { "AB", "BC", "CD", "DE", "EF" };
            Graph gr = new Graph();
            List<string> actual = new List<string>();
            gr.DFG(actual, gr.Nodes[0], "F");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DFG_NotElementSearch_EmptyStringReturned()
        {
            List<string> expected = new List<string>();
            Graph gr = new Graph();
            List<string> actual = new List<string>();
            gr.DFG(actual, gr.Nodes[0], "G");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DFG_NodeIsNull_EmptyListReturned()
        {
            List<string> expected = new List<string>();
            Graph gr = new Graph();
            List<string> actual = new List<string>();
            gr.DFG(actual, null, "F");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DFG_SearchPathListIsNull_NullReferenseExceptionReturned()
        {
            List<string> expected = new List<string>();
            Graph gr = new Graph();
            List<string> actual = null;
            try
            {
                gr.DFG(actual, gr.Nodes[0], "F");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }
    }
}
