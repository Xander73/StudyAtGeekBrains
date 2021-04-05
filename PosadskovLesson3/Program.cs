using System;

namespace PosadskovLesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintMassivDiagonal();

            Phonebook();

            Console.ReadKey();
        }

        public static void PrintMassivDiagonal()
        {
            int[][] mas = new int[][] { 
                                        new int[]{ 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[]{ 1, 2, 3, 4, 5 }, 
                                        new int[]{ 1, 2, 3, 4, 5 }, new int[]{ 1, 2, 3, 4, 5 } };

            Console.WriteLine("Исходный массив\n");

            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write(mas[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nВывод элементов по диагонали\n");
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    if (i == j)
                    {
                        Console.Write(mas[i][j] + " ");
                    }
                    else
                    {
                        Console.Write(0 + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void Phonebook ()
        {
            string[,] phonebook = new string[5, 2] { {"Дима", "111-11-11/email@mail.ru" }, 
                                                    { "Андрей", "222-22-22/email@mail.ru" }, 
                                                    { "Игорь", "333-33-33/email@mail.ru" },
                                                    { "Юля", "444-44-44/email@mail.ru" },
                                                    { "Барсик", "555-55-55/email@mail.ru" }, };

            for (int i = 0; i < phonebook.Length/2; i++)
            {
                for (int j = 0; j < 2; j++)
                {                    
                    Console.Write(phonebook[i, j]);
                    if (j != 1) Console.Write(" - ");
                }                
                Console.WriteLine('\n'); ;
            }
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
