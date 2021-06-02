using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            //IsEmptyNumber.Start();
            //Console.WriteLine(FibonacciRecursion.ProcessingFibonacci()); 
            Console.WriteLine(FibonacciLoop.ProcessingFibonacci(6)); 
        }

        public static int StrangeSum(int[] inputArray)      //O(N3) - сложность O(N в кубе)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum;
        }

    }
}
