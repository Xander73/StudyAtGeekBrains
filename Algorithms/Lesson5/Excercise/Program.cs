using System;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("Поиск в глубину\n");
            DFG.SearchDFG(mt.Root, 11);

            Console.WriteLine();
            Console.WriteLine("Поиск в ширину\n");
            BFG.SearchBFG(mt.Root, 11);
        }
    }
}
