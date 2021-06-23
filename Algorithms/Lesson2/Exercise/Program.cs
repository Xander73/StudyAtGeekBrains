using System;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedList ll = new LinkedList();

            //for (int i = 0; i < 10; ++i)
            //{
            //    ll.AddNode(i);
            //}

            //ll.AddNodeAfter(ll.FindNode(0), 99);
            //while (ll.Node != null)
            //{
            //    Console.WriteLine(ll.Node.Value);
            //    ll.Node = ll.Node.NextNode;
            //}
            //Console.WriteLine('\n');
            //Console.WriteLine(ll.HeadNode.Value);
            //Console.WriteLine(ll.TailNode.Value);

            int[] arr = new int[10];

            for (int i = 0; i < 10; ++i)
            {
                arr[i] = i;
            }
            Console.WriteLine(Search.BinarySearch(arr, 0, arr.Length - 1,  9)); 

            Console.ReadKey();
        }
    }
}
