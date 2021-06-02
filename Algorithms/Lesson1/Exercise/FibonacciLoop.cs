using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class FibonacciLoop
    {
        public static int ProcessingFibonacci(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Введены некорректные данные");
                return -1;
            }
            else
            {
                return Calculate(number);
            }

        }

        public static int Calculate(int number)
        {

            if (number == 0)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                int prev = 0, result = 1, curResult = 0;
                for (int i = 2; i <= number; i++)
                {
                    curResult = result;
                    result += prev;
                    prev = curResult;
                }
                return result;
            }
        }
    }
}
