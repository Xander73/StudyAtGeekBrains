using BenchmarkDotNet.Running;
using System;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

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
            mt.AddItem(12);
            mt.AddItem(13);
            mt.AddItem(14);
            mt.AddItem(15);

            mt.PrintTree();

            Console.SetCursorPosition(23, 15);

        }
    }
}
