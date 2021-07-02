using Lesson7;
using System;

namespace Geekbrains
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Console.WriteLine("Метод из методички");
            Exercise ex = new Exercise();
            int[,] A = new int[ex.N, ex.M];
            ex.NumberWaysManual(A);
            int[,] B = new int[ex.N, ex.M];
            ex.NumberWaysRecursion(0, 0, B);

            ex.Print2(ex.N, ex.M, B);

            Console.WriteLine("\nКоличество вариантов");
            Console.WriteLine(ex.NumberVariants(16));
        }



    }
}
