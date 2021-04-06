using System;

namespace PosadskovLesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintMassivDiagonal();

            //Phonebook();

            //InvertedWord();

            //SeeBatle();

            int[] arr = new int[7];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }

            ShiftArray<int>(arr, -4);

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }
        #region
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

        public static void Phonebook()
        {
            string[,] phonebook = new string[5, 2] { {"Дима", "111-11-11/email@mail.ru" },
                                                    { "Андрей", "222-22-22/email@mail.ru" },
                                                    { "Игорь", "333-33-33/email@mail.ru" },
                                                    { "Юля", "444-44-44/email@mail.ru" },
                                                    { "Барсик", "555-55-55/email@mail.ru" }, };

            for (int i = 0; i < phonebook.Length / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(phonebook[i, j]);
                    if (j != 1) Console.Write(" - ");
                }
                Console.WriteLine('\n'); ;
            }
        }

        public static void InvertedWord()
        {
            Console.WriteLine("Введите слово\n");
            string s = Console.ReadLine();
            Console.WriteLine();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                Console.Write(s[i]);
            }
        }

        public static void SeeBatle()
        {
            char[,] seeMap = new char[10, 10]
            {
                { 'O','X','O','X','O','O','O','O','O','O'},
                { 'O','X','O','O','O','X','O','O','O','O'},
                { 'O','X','O','O','O','X','O','O','O','O'},
                { 'O','X','O','X','O','O','O','O','X','O'},
                { 'O','O','O','O','O','O','O','O','O','O'},
                { 'O','O','O','X','X','X','O','O','O','X'},
                { 'O','X','O','O','O','O','O','O','O','O'},
                { 'O','O','O','O','O','O','X','X','X','O'},
                { 'O','X','X','O','O','O','O','O','O','O'},
                { 'O','O','O','O','O','O','X','X','O','O'}
            };

            for (int i = 0; i < seeMap.Length / 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(seeMap[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(); ;
        }

        public static void RotateMassiv<T>(T[] array, int rotate)
        {
            if (array.Length <= 1)
            {
                Console.WriteLine("Массив пустой или слишком короткий.\nМассив должен сожерьжать больше одного элемента.");
                return;
            }

            //отрезаем лишнее, если надо вращать на большее число, чем длина массива
            if ((rotate %= array.Length) == 0)
            {
                return;
            }

            T[] copyMassive = (T[])array.Clone();
            copyMassive.Clone();

            if (rotate > 0)
            {
                int i = rotate, j = 0;
                for (; i < array.Length; i++, j++)
                {
                    array[j] = copyMassive[i];
                }

                i = 0;
                for (; i < rotate; i++, j++)
                {
                    array[j] = copyMassive[i];
                }
            }
            else
            {
                int i = array.Length + rotate, j = 0;
                for (; i < array.Length; i++, j++)
                {
                    array[j] = copyMassive[i];
                }

                i = 0;
                for (; i < array.Length + rotate; i++, j++)
                {
                    array[j] = copyMassive[i];
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam Тип переменных в массиве="T"></typeparam>
        /// <param Массив="array"></param>
        /// <param Величина сдвига строго в целых числах="shift"></param>
        public static void ShiftArray<T>(T[] array, int shift)
        {
            if (array.Length <= 1)
            {
                Console.WriteLine("Массив пустой или слишком короткий.\nМассив должен содержать больше одного элемента.");
                return;
            }

            //отрезаем лишнее, если надо вращать на большее число, чем длина массива
            //и если сдвиг кратен длине массива, то сдвигать не надо
            if ((shift %= array.Length) == 0)
            {
                return;
            }

            T temp = default;
            if (shift > 0)
            {
                for (int i = 0; i < array.Length - 1; ++i)
                {
                    temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }

                ShiftArray<T>(array, --shift);
            }
            else
            {
                for (int i = 0; i < array.Length - 1; ++i)
                {
                    temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                }
                ShiftArray<T>(array, --shift); // это не баг, а фича ))))))  за счет деления на остаток стремимся к условию ==0 и выходим из цикла
            }
        }
    }
}

        #endregion

        

        