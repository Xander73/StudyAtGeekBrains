using System;
using System.Collections.Generic;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph gr = new Graph();
            List<string> list = new List<string>();
            gr.DFG(list, gr.Nodes[0], "F");
            //gr.BFG(list, gr.Nodes[0], "G");

            Console.WriteLine();
            Console.WriteLine("Текущий полученный путь");

            foreach (var item in list)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
