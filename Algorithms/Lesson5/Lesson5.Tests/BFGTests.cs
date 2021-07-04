using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson5.Tests
{
    [TestClass]
    public class BFGTests
    {
        [TestMethod]
        public void SearchBFG_SeachFirstElement_FirstElementReturned()
        {
            MyTree mt = new MyTree();

            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);
            mt.AddItem(7);
            mt.AddItem(8);
            mt.AddItem(9);
            mt.AddItem(10);
            mt.AddItem(11);

            TreeNode execute = new TreeNode { Value = 1 };
            var actual = BFG.SearchBFG(mt.Root, 1);

            Assert.AreEqual(execute, actual);
        }

        [TestMethod]
        public void SearchBFG_SeachLastElement_LastElementReturned()
        {
            MyTree mt = new MyTree();

            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);
            mt.AddItem(7);
            mt.AddItem(8);
            mt.AddItem(9);
            mt.AddItem(10);
            mt.AddItem(11);

            TreeNode execute = new TreeNode { Value = 11 };
            var actual = BFG.SearchBFG(mt.Root, 11);

            Assert.AreEqual(execute, actual);
        }

        [TestMethod]
        public void SearchBFG_SeachNotExistElement_NullReturned()
        {
            MyTree mt = new MyTree();

            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);
            mt.AddItem(7);
            mt.AddItem(8);
            mt.AddItem(9);
            mt.AddItem(10);
            mt.AddItem(11);

            TreeNode execute = null;
            var actual = BFG.SearchBFG(mt.Root, 110);

            Assert.AreEqual(execute, actual);
        }

        public void SearchBFG_RootIsNull_NullReturned()
        {
            MyTree mt = new MyTree();


            TreeNode execute = null;
            var actual = BFG.SearchBFG(mt.Root, 110);

            Assert.AreEqual(execute, actual);
        }

        [TestMethod]
        public void SearchBFG_SeachCharElement_NotEqualReturned()
        {
            MyTree mt = new MyTree();

            mt.AddItem(1);
            mt.AddItem(2);
            mt.AddItem(3);
            mt.AddItem(4);
            mt.AddItem(5);
            mt.AddItem(6);
            mt.AddItem(7);
            mt.AddItem(8);
            mt.AddItem(9);
            mt.AddItem(10);
            mt.AddItem(11);

            TreeNode execute = new TreeNode { Value = 1 };
            var actual = BFG.SearchBFG(mt.Root, '1');

            Assert.AreNotEqual(execute, actual);
        }

    }
}