using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7
{
    public class Exercise
    {
        public  int N = 3;
        public  int M = 3;
        public void Print2(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write(a[i, j] + "\t");
                Console.Write("\n\r\n");
            }
        }

        /// <summary>
        /// Пример из методички. Для него писать Юнит тесты не стал. 
        /// </summary>
        /// <param name="A"></param>
        public void NumberWaysManual(int[,] A)
        {
            int i, j;
            for (j = 0; j < M; j++)
                A[0, j] = 1; // Первая строка заполнена единицами
            for (i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }
            Print2(N, M, A);
        }


        /// <summary>
        /// Зача в ДЗ тоже самое, что и задача в методичке по поиску количества маршрутов из методички.
        /// Чтобы не повторять его, переписал этот метод через рекурсию.
        /// Пример из методички взял для контроля корректности рекурсивного метода. 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="A"></param>
        public void NumberWaysRecursion(int n, int m, int[,] A)
        {
            if (n == 0 && m == 0)
            {
                Array.Clear(A, 0, A.Length);

            }
            if (m == M)
            {
                ++n;
                m = 0;
            }

            if (n == N)
            {
                return;
            }

            if (n == 0 || m == 0)
            {
                A[n, m] = 1;
                NumberWaysRecursion(n, ++m, A);
            }
            else
            {
                A[n, m] = A[n - 1, m] + A[n, m - 1];
                NumberWaysRecursion(n, ++m, A);
            }

        }

        /// <summary>
        /// Метод количества вариантов.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumberVariants(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            n = Math.Abs(n);
            if (n == 1)
                return 1;
            if (n % 2 == 0)
            {
                return NumberVariants(n - 1) + NumberVariants(n / 2);
            }
            return NumberVariants(n - 1);
        }
    }
}
