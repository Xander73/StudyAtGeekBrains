using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson4
{
    public class MyTree : ITree
    {
        public TreeNode Root { get; private set; }

        /// <summary>
        /// В исходном интерфейсе из ДЗ сигнатура было с типом void, 
        /// менять исходный код интерфейса не стал, поэтому метод ничего не возвращает
        /// </summary>
        /// <param name="value"></param>
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

        private TreeNode CreateTree(int n, List<int> list, ref int index)
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

        /// <summary>
        /// Тоже самое, для Юнит тестов нужен public, поэтом public
        /// Метод может не возвращать значения, т.к. передоваемый по ссылке список 
        /// по рекурсии заполнится всеми значениями, но подобные методы требуют возвращения результата
        /// </summary>
        /// <returns></returns>
        public List<int> TreeToList(List<int> list, TreeNode node)
        {
            if (node != null)
            {
                list.Add(node.Value);
                TreeToList(list, node.LeftChild);
                TreeToList(list, node.RightChild);
                return list;
            }
            return null;
        }

        /// <summary>
        /// Сигнатура метода в интерфесе не содержит необходимых аргументов, 
        /// поэтому пришлось писать еще один метод TreeNode CheckNode (TreeNode, int)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

            TreeNode tempNode = CheckNode(node.LeftChild, value);

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
                    (begin + end) / 2 + node.Value.ToString().Length / 2 + (node.Value.ToString().Length == 1? 2:1));

            Console.SetCursorPosition(coordinateXBeginEndValueToString.Key <= 1 ? 1 : coordinateXBeginEndValueToString.Key, line);
            Console.Write("(" + node.Value + ")");

            //int mid = begin + (begin + end) / 2;
            int mid =  (end - begin) / 4;
            for (int i = coordinateXBeginEndValueToString.Key - 1; i > begin + mid; --i)
            {
                if (i <= begin + mid + 1)
                {
                    Console.SetCursorPosition(i <= 1 ? 1 : i, ++line);
                    Console.Write('/');
                    if (node.LeftChild == null)
                    {
                        Console.SetCursorPosition((i - 2) <= 1 ? 1 : (i - 2), ++line);
                        Console.Write("null");
                    }
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
                PrintNode(node.LeftChild, begin, (begin + end) / 2, ++line);
            }


            //---------------------------------------------

            
            line -= 2;
            for (int i = coordinateXBeginEndValueToString.Value; i < end - mid; ++i)
            {
                if (i >= end - mid - 1)
                {
                    Console.SetCursorPosition(i >= (Console.BufferWidth - 1) ? Console.BufferWidth - 1 : i, ++line);
                    Console.Write('\\');
                    if (node.RightChild == null)
                    {
                        Console.SetCursorPosition(i >= (Console.BufferWidth - 4) ? Console.BufferWidth - 4 : i, ++line);
                        Console.Write("null");
                    }
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
                PrintNode(node.RightChild, (begin + end) / 2, end, ++line);
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
