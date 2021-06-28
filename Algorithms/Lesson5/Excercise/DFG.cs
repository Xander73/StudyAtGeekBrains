using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class DFG
    {
        public static TreeNode SearchDFG(TreeNode node, int value)
        {
            if (node == null)
            {
                return null;
            }

            Stack<TreeNode> nodes = new Stack<TreeNode>();
            nodes.Push(node);
            TreeNode temp;
            while (nodes.Count != 0)
            {
                temp = nodes.Pop();
                Console.WriteLine("Ткущая позиция - " + temp.Value);
                if (temp.Value == value)
                    return temp;

                if (temp.RightChild != null)
                    nodes.Push(temp.RightChild);

                if (temp.LeftChild != null)
                    nodes.Push(temp.LeftChild);
            }
            return null;
        }
    }
}
