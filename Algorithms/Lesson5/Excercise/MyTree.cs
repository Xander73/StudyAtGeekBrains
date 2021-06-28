using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson5
{
    public class MyTree : ITree
    {
        public TreeNode Root { get; private set; }
        public void AddItem(int value)
        {
            List<int> list = new List<int>();
            if (Root != null)
            {
                TreeToList(list, Root);
            }

            list.Add(value);
            int index = 0;
            Root = CreateTree(list.Count, list, ref index);
        }

        public TreeNode CreateTree(int n, List<int> list, ref int index)
        {
            TreeNode newNode = null;
            if (n == 0)
            {
                --index;
                return null;
            }
            else
            {
                var nl = n / 2;
                var nr = n - nl - 1;
                newNode = new TreeNode();
                newNode.Value = list[index];

                ++index;
                newNode.LeftChild = CreateTree(nl, list, ref index);
                ++index;
                newNode.RightChild = CreateTree(nr, list, ref index);
            }
            return newNode;
        }

        public List<int> TreeToList(List<int> list, TreeNode node)
        {
            if (node != null)
            {
                list.Add(node.Value);
                TreeToList(list, node.LeftChild);
                TreeToList(list, node.RightChild);
            }
            return list;
        }

        public TreeNode GetNodeByValue(int value)
        {
            return CheckNode(Root, value);           
        }

        public TreeNode CheckNode (TreeNode node, int value)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value == value)
            {
                return node;
            }

            TreeNode tempNode;
            tempNode = CheckNode(node.LeftChild, value);

            return tempNode == null ? CheckNode(node.RightChild, value) : tempNode;

        }

        public TreeNode GetRoot() => Root;
        public void PrintTree()
        {
            PrintNode(Root, 0, Console.BufferWidth, 0);
        }

        private void PrintNode(TreeNode node, int begin, int end, int line)
        {
            
            if (node == null)
            {                
                Console.Write("null");
                return;
            }
            KeyValuePair<int, int> coordinateXBeginEndValueToString =
                    new KeyValuePair<int, int>((begin + end) / 2 - node.Value.ToString().Length / 2 - 1, 
                    (begin + end) / 2 + node.Value.ToString().Length / 2 + 1);

            Console.SetCursorPosition(coordinateXBeginEndValueToString.Key <= 1 ? 1 : coordinateXBeginEndValueToString.Key, line);
            Console.Write("(" + node.Value + ")");

            int mid = begin + (begin + end) / 2;
            for (int i = coordinateXBeginEndValueToString.Key - 1; i > mid / 2; --i)
            {
                if (i <= mid / 2 + 1)
                {
                    Console.SetCursorPosition(i <= 1 ? 1 : i, ++line);
                    Console.Write('/');
                    break;
                }
                else
                {
                    Console.SetCursorPosition(i <= 1 ? 1 : i, line);
                    Console.Write('_');
                }
            }
            if (node.LeftChild != null)
            {
                PrintNode(node.LeftChild, begin, mid - 1, ++line);
            }
            else
            {
                Console.SetCursorPosition(
                    coordinateXBeginEndValueToString.Key - 1 <= 1 ? 1 : coordinateXBeginEndValueToString.Key, line + 1
                    );
                Console.Write('/');
                Console.SetCursorPosition(Console.CursorLeft - 2, line+2);
                Console.Write("null");
            }

            //---------------------------------------------
            
            mid = end - (begin + end) / 2;
            line -= 2;
            for (int i = coordinateXBeginEndValueToString.Value; i < mid + mid / 2; ++i)
            {
                if (i >= mid + mid / 2 - 1)
                {
                    Console.SetCursorPosition(i >= (Console.BufferWidth - 1) ? Console.BufferWidth - 1 : i, ++line);
                    Console.Write('\\');
                    break;
                }
                else
                {
                    Console.SetCursorPosition(i >= (Console.BufferWidth - 1) ? Console.BufferWidth - 1 : i, line);
                    Console.Write('_');
                }
            }
            if (node.RightChild != null)
            {
                PrintNode(node.RightChild, mid, end, ++line);
            }
            else
            {
                Console.SetCursorPosition(
                    (coordinateXBeginEndValueToString.Value + 1) >= (Console.BufferWidth - 1) ?
                    (Console.BufferWidth - 1) : coordinateXBeginEndValueToString.Value, line + 1
                    );
                Console.Write('\\');
                Console.SetCursorPosition(coordinateXBeginEndValueToString.Value, line + 2);
                Console.Write("null");
            }
        }


        public void RemoveItem(int value)
        {
            List<int> list = new List<int>();
            TreeToList(list, Root);

            list = (from item in list where item != value select item).ToList();
            int index = 0;
            Root = CreateTree(list.Count, list, ref index);
        }
    }
}
