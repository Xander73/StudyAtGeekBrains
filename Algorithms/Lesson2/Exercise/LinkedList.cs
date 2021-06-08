using Lesson2.Interfaces;
using System;

namespace Lesson2
{
    public class LinkedList : ILinkedList
    {
        public Node Node { get; set; }
        public  Node HeadNode { get; set; }
        public  Node TailNode { get; set; }
        public  int Count { get; set; }
        
        public LinkedList()
        {
            Node = new Node();
        }

        public void AddNode(int value)
        {
            if (Count == 0)
            {
                Node.Value = value;
                TailNode = Node;
                HeadNode = Node;
                ++Count;
                return;
            }

            Node tempNode = HeadNode;
            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }

            Node newNode = new Node();
            newNode.Value = value;
            newNode.PrevNode = tempNode;
            tempNode.NextNode = newNode;
            TailNode = newNode;
            ++Count;
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            Node newNode = new Node();
            newNode.Value = value;

            if (node.NextNode == null)
            {                
                node.NextNode = newNode;
                newNode.PrevNode = node;
                TailNode = newNode;
            }            
            else
            {                
                newNode.NextNode = node.NextNode;
                node.NextNode = newNode;
                newNode.NextNode.PrevNode = newNode;
                newNode.PrevNode = node;
            }
            
            ++Count;
        }

        public Node FindNode(int searchValue)
        {
            Node tempNode = HeadNode;
            while (tempNode.Value != searchValue)
            {
                if ((tempNode = tempNode.NextNode) == null)
                {
                    Console.WriteLine("Ничего не найдено");
                    throw new ArgumentOutOfRangeException();
                }                    
            }
            return tempNode;
        }

        public int GetCount() => Count;

        public void RemoveNode(int index)
        {
            if (index > Count || index < 0)
            {
                Console.WriteLine("Индек больше количества элементов");
                throw new IndexOutOfRangeException();
            }

            Node tempNode = HeadNode;
            for (int i = 0; i < index; ++i)
            {
                tempNode = tempNode.NextNode;
            }
            if (tempNode.NextNode == null && tempNode.PrevNode == null)
            {
                HeadNode = null;
                TailNode = null;
                tempNode = null;
            }
            else if (tempNode.NextNode == null)
            {
                TailNode = tempNode.PrevNode;
                tempNode.PrevNode.NextNode = null;
            }
            else if (tempNode.PrevNode == null)
            {
                HeadNode = tempNode.NextNode;
                tempNode.NextNode.PrevNode = null;
            }
            else
            {
                tempNode.PrevNode.NextNode = tempNode.NextNode;
                tempNode.NextNode.PrevNode = tempNode.PrevNode;
            }

            --Count;
        }

        public void RemoveNode(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            if (node.NextNode == null && node.PrevNode == null)
            {
                HeadNode = null;
                TailNode = null;
                node = null;
            }
            else if (node.NextNode == null)
            {
                TailNode = node.PrevNode;
                node.PrevNode.NextNode = null;
            }
            else if (node.PrevNode == null)
            {
                HeadNode = node.NextNode;
                node.NextNode.PrevNode = null;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }

            --Count;
        }
    }
}
