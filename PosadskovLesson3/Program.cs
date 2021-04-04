using System;

namespace PosadskovLesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 1, 2, 3, 4, 5 };
            RotateMassiv<int>(mas, -112);

            foreach (var item in mas)
            {
                Console.Write(item);
            }

            Console.ReadKey();
        }

        public static void  RotateMassiv<T> (T[] massiv, int rotate)
        {            
            if (massiv.Length <= 1)
            {
                Console.WriteLine("Массив пустой или слишком короткий.\nМассив должен сожерьжать больше одного элемента.");
                return;
            }

            //отрезаем лишнее, если надо вращать на большее число, чем длина массива
            if ((rotate %= massiv.Length) == 0) 
            {
                return;
            }

            T[] copyMassive = (T[]) massiv.Clone();
            copyMassive.Clone();

            if (rotate > 0)
            {
                int i = rotate, j = 0;
                for (; i < massiv.Length; i++, j++)
                {
                    massiv[j] = copyMassive[i];
                }

                i = 0;
                for (; i < rotate; i++, j++)
                {
                    massiv[j] = copyMassive[i];
                }
            }
            else
            {
                int i = massiv.Length + rotate, j = 0;
                for (; i < massiv.Length; i++, j++)
                {
                    massiv[j] = copyMassive[i];
                }

                i = 0;
                for (; i < massiv.Length + rotate; i++, j++)
                {
                    massiv[j] = copyMassive[i];
                }
            }
            

        }
    }
}
