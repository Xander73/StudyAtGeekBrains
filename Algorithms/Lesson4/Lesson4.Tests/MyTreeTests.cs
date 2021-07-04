using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lesson4.Tests
{
    [TestClass]
    public class MyTreeTests
    {
        [TestMethod]
        public void AddItem_1Add_1Returned()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);

            TreeNode expected = new TreeNode { Value = 1 };
            var actual = mt.GetNodeByValue(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddItem_6Elements_6CountReturned()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);

            int expected = 6;
            var actual = mt.TreeToList(new System.Collections.Generic.List<int> (), mt.Root).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddItem_LastElement_6Returned()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);

            TreeNode expected = new TreeNode { Value = 6 };
            var actual = mt.GetNodeByValue(6);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddItem_CharAdd_NotEqualReturned()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem('6');

            TreeNode expected = new TreeNode { Value = 6 };
            var actual = mt.GetNodeByValue(6);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void AddItem_2EqualsElements_2ElementsCountReturned()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(1); 

            int expected = 2;
            var actual = mt.TreeToList(new System.Collections.Generic.List<int> (), mt.Root).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]    
        public void TreeToList_1Element_ListReturned()
        {
            var expected = new List<int> ().GetType();

            MyTree mt = new MyTree();
            mt.AddItem(1);

            List<int> list = new List<int>();

            var actual = mt.TreeToList(list, mt.Root).GetType();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TreeToList_0Elements_nullReturned()
        {
            object expected = null;

            MyTree mt = new MyTree();

            List<int> list = new List<int>();

            var actual = mt.TreeToList(list, mt.Root);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TreeToList_8Element_ListReturned()
        {
            var expected = new List<int>().GetType();

            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);

            List<int> list = new List<int>();

            var actual = mt.TreeToList(list, mt.Root).GetType();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TreeToList_nullNode_NullReturned()
        {
            object expected = null;

            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);
            mt.AddItem(1);

            List<int> list = new List<int> ();

            var actual = mt.TreeToList(list, null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TreeToList_ListAndTreeIsNull_nullReturned()
        {
            MyTree mt = null;

            List<int> list = null;
            try
            {
                var actual = mt.TreeToList(list, mt.Root);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [TestMethod]
        public void CheckNode_1Element_RootNode()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);

            var actual = mt.CheckNode(mt.Root, 1);

            var expected = mt.Root;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckNode_LastElement_LastElementNode()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);

            var actual = mt.CheckNode(mt.Root, 6);

            var expected = new TreeNode { Value = 6 };

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckNode_NotExistElement_NullElementNode()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);

            var actual = mt.CheckNode(mt.Root, 10);

            object execute = null;

            Assert.AreEqual(execute, actual);
        }

        [TestMethod]
        public void CheckNode_TreeIsNull_NullReferenseExeptionElementNode()
        {
            MyTree mt = null;
            try
            {
                var actual = mt.CheckNode(mt.Root, 6);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }

        }

        [TestMethod]
        public void CheckNode_RootIsNull_NullElementNode()
        {
            MyTree mt = new MyTree();

            var actual = mt.CheckNode(null, 10);

            object execute = null;

            Assert.AreEqual(execute, actual);
        }

        [TestMethod]
        public void RemoveItem_3Remove_3Notreturned()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);

            mt.RemoveItem(3);

            List<int> actual = new List<int>();
            mt.TreeToList(actual, mt.Root);

            List<int> expected = new List<int> {1, 2, 4, 5, 6 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveItem_FirstElementRemove_FirstElementNotReturned()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);

            mt.RemoveItem(1);

            List<int> actual = new List<int>();
            mt.TreeToList(actual, mt.Root);

            List<int> expected = new List<int> { 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveItem_NotExistElementRemove_AllElementReturned()
        {
            MyTree mt = new MyTree();
            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);

            mt.RemoveItem(10);
            List<int> actual = new List<int>();
            mt.TreeToList(actual, mt.Root);

            List<int> expected = new List<int> { 1, 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveItem_TreeIsNull_NullReferenseExeptionReturned()
        {
            MyTree mt = null;
            try
            {
                mt.RemoveItem(10);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [TestMethod]
        public void RemoveItem_TreeWith0ElementsRemove_nullReturned()
        {
            MyTree mt = new MyTree();

            mt.RemoveItem(10);
            List<int> actual = new List<int>();
            mt.TreeToList(actual, mt.Root);

            List<int> expected = new List<int> ();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}