using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    public class BFG
    {
        public static TreeNode SearchBFG (TreeNode node, int value)
        {
            if (node == null)
            {
                return null;
            }
                        
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(node);
            TreeNode temp;

            while(nodes.Count != 0)
            {
                temp = nodes.Dequeue();
                Console.WriteLine("Ткущая позиция - " + temp.Value);

                if (temp.Value == value)
                    return temp;

                if (temp.LeftChild != null)
                {
                    nodes.Enqueue(temp.LeftChild);
                }

                if (temp.RightChild != null)
                {
                    nodes.Enqueue(temp.RightChild);
                }
            }
            return null;
        }
    }
}
