using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lesson2.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        LinkedList ll = new LinkedList();

        #region AddNode
        [TestMethod]
        public void AddNode_Add1Node_Count1Returned()
        {
            ll.AddNode(9);
            int actual = ll.Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNode_Add1Node_Value9Returned()
        {
            ll.AddNode(9);
            int actual = ll.Node.Value;
            int expected = 9;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNode_Add1Node_ValueMinus5Returned()
        {
            ll.AddNode(-5);
            int actual = ll.Node.Value;
            int expected = -5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNode_Add10Nodes_Expected0_Count10Returned()
        {
            for (int i = 0; i < 10; ++i)
            ll.AddNode(i);
            int actual = ll.Count;
            int expected = 0;

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void AddNode_Add10Nodes_Expected0_Values10NodsReturned()
        {
            int[] actual = new int[10];
            int[] expected = new int[10];
            for (int i = 0; i < 10; ++i)
            {
                ll.AddNode(i);
                expected [i] = 0;
            }

            for (int i = 0; ll.Node != null; ll.Node = ll.Node.NextNode, ++i)
            {
                actual[i] = ll.Node.Value;
            }



            CollectionAssert.AreNotEqual(expected, actual);
        }
        #endregion

        #region GetCount
        [TestMethod]
        public void GetCount_0Add_0Returned ()
        {
            int expexted = 0;
            int actual = ll.GetCount();

            Assert.AreEqual(expexted, actual);
        }

        [TestMethod]
        public void GetCount_1Add_1Returned()
        {
            ll.AddNode(88);
            int expexted = 1;
            int actual = ll.GetCount();

            Assert.AreEqual(expexted, actual);
        }
        
        [TestMethod]
        public void GetCount_1Deleted_9Returned()
        {
            for (int i = 0; i < 10; ++i)
                ll.AddNode(88);
            ll.RemoveNode(1);
            int expexted = 9;
            int actual = ll.GetCount();

            Assert.AreEqual(expexted, actual);
        }

        [TestMethod]
        public void GetCount_Expected1_0Returned()
        {
            ll.AddNode(88);
            ll.RemoveNode(0);
            int expexted = 1;
            int actual = ll.GetCount();

            Assert.AreNotEqual(expexted, actual);
        }

        [TestMethod]
        public void GetCount_Expected0_10Returned()
        {
            for (int i = 0; i < 10; ++i)
                ll.AddNode(88);
            int expexted = 0;
            int actual = ll.GetCount();

            Assert.AreNotEqual(expexted, actual);
        }
        #endregion

        #region AddAfter
        [TestMethod]
        public void AddAfter_AddAfterFirstPosition99_99Returned()
        {
            ll.AddNode(1);
            var tempNode = ll.Node;
            ll.AddNode(2);
            int expected = 99;
            ll.AddNode(3);
            ll.AddNodeAfter(tempNode, 99);
            int actual = tempNode.NextNode.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddAfter_AddAfterLastPosition99_99Returned()
        {
            ll.AddNode(1);
            var tempNode = ll.Node;
            ll.AddNodeAfter(tempNode, 99);
            int expected = 99;
            var actual = tempNode.NextNode.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddAfter_AddAfter99_99Returned()
        {
            ll.AddNode(1);
            ll.AddNode(2);
            var tempNode = ll.Node;
            int expected = 99;
            ll.AddNode(3);
            ll.AddNodeAfter(tempNode, 99);
            int actual = tempNode.NextNode.Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddAfter_AddAfter99_3Returned()
        {
            ll.AddNode(1);
            ll.AddNode(2);
            var tempNode = ll.Node;
            int expected = 3;
            ll.AddNode(3);
            ll.AddNodeAfter(tempNode, 99);
            int actual = tempNode.NextNode.Value;

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void AddAfter_AddAfter99_CharReturned()
        {
            ll.AddNode(1);
            ll.AddNode(2);
            var tempNode = ll.Node;
            char expected = 'f';
            ll.AddNode(3);
            ll.AddNodeAfter(tempNode, 99);
            int actual = tempNode.NextNode.Value;

            Assert.AreNotEqual(expected, actual);
        }

        #endregion

        #region FindeNode
        [TestMethod]
        public void FindeNode_Enter2_Value2Returned()
        {
            int expected = 2;
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);

            int actual = ll.FindNode(2).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindeNode_Enter3_Value3Returned()
        {
            int expected = 3;
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);

            int actual = ll.FindNode(3).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindeNode_Enter1_Value1Returned()
        {
            int expected = 1;
            ll.AddNode(1);

            int actual = ll.FindNode(1).Value;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindeNode_Enter1_Expected4_ExceptionReturned()
        {
            int actual = 0;
            try
            {                
                ll.AddNode(1);

               actual  = ll.FindNode(4).Value;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }

        }

        [TestMethod]
        public void FindeNode_Enter1_ExpectedMinus1_ExceptionReturned()
        {
            int actual = 0;
            try
            {
                ll.AddNode(1);

                actual = ll.FindNode(-1).Value;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }

        }
        #endregion

        #region RemoveNode
        [TestMethod]
        public void RemoveNode_FirstElement_0Returned()
        {
            int expected = 0;
            ll.AddNode(1);
            ll.RemoveNode(ll.FindNode(1));
            int actual = ll.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNode_LastElement_2Returned()
        {
            int expected = 2;
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            ll.RemoveNode(ll.FindNode(3));
            int actual = ll.Count;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RemoveNode_Element_2Returned()
        {
            int expected = 2;
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            ll.RemoveNode(ll.FindNode(2));
            int actual = ll.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNode_NULL_ExeptionReturned()
        {
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            try
            {
                ll.RemoveNode(null);
            }
            catch (Exception ex)
            {
                    Assert.IsTrue(ex is ArgumentNullException);
            }

        }

        [TestMethod]
        public void RemoveNode_3ElementEnter_3Expected_Count2Returned()
        {
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            int expected = ll.Count;
            ll.RemoveNode(ll.FindNode(2));
            int actual = ll.Count;

            Assert.AreNotEqual(expected, actual);
        }
        #endregion

        #region RemoveNode_index
        [TestMethod]
        public void RemoveNodeIndex_FirstElement_0Returned()
        {
            int expected = 0;
            ll.AddNode(1);
            ll.RemoveNode(0);
            int actual = ll.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNodeIndex_LastElement_2Returned()
        {
            int expected = 2;
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            ll.RemoveNode(ll.Count - 1);
            int actual = ll.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNodeIndex_1Index_2Returned()
        {
            int expected = 2;
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            ll.RemoveNode(1);
            int actual = ll.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNodeIndex_NULL_ExeptionReturned()
        {
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            try
            {
                ll.RemoveNode(5);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is IndexOutOfRangeException);
            }

        }

        [TestMethod]
        public void RemoveNodeIndex_3ElementEnter_3Expected_Count2Returned()
        {
            ll.AddNode(1);
            ll.AddNode(2);
            ll.AddNode(3);
            int expected = ll.Count;
            ll.RemoveNode(ll.FindNode(2));
            int actual = ll.Count;

            Assert.AreNotEqual(expected, actual);
        }
        #endregion




    }
}