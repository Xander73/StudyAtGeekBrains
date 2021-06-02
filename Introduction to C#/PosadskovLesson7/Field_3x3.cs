using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosadskovLesson7
{
    class Field_3x3
    {

        public Field_3x3()
        {
            //CheckWinByLoop();


        }

        static void CheckWinByLoop()
        {
            InitField();           
            PrintField();
            do
            {
                playerMove();
                Console.WriteLine("Ваш ход на поле");
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                AiMove();
                Console.WriteLine("Ход Компа на поле");
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
        }

        #region Функции ДЗ проверки через цикл
        private static bool CheckWin(char sym)
        {
            {
                //if (field[0, 0] == sym && field[0, 1] == sym && field[0, 2] == sym)
                //{
                //    return true;
                //}
                //if (field[1, 0] == sym && field[1, 1] == sym && field[1, 2] == sym)
                //{
                //    return true;
                //}
                //if (field[2, 0] == sym && field[2, 1] == sym && field[2, 2] == sym)
                //{
                //    return true;
                //}

                //if (field[0, 0] == sym && field[1, 0] == sym && field[2, 0] == sym)
                //{
                //    return true;
                //}
                //if (field[0, 1] == sym && field[1, 1] == sym && field[2, 1] == sym)
                //{
                //    return true;
                //}
                //if (field[0, 2] == sym && field[1, 2] == sym && field[2, 2] == sym)
                //{
                //    return true;
                //}

                //if (field[0, 0] == sym && field[1, 1] == sym && field[2, 2] == sym)
                //{
                //    return true;
                //}
                //if (field[2, 0] == sym && field[1, 1] == sym && field[0, 2] == sym)
                //{
                //    return true;
                //}
            }

            if (CheckDiagonals(sym))
            {
                return true;
            }
            else if (CheckLines(sym))
            {
                return true;
            }
            else if (CheckColumns(sym))
            {
                return true;
            }
            return false;
        }

        private static bool CheckDiagonals(char sym)
        {

            bool diagonal = true;
            bool revDiagonal = true;
            for (int i = 0; i < SIZE_X; i++)
            {
                if (field[i, i] != sym)
                {
                    diagonal = false;
                }

                if (field[i, SIZE_X - 1 - i] != sym)
                {
                    revDiagonal = false;
                }
            }

            return diagonal || revDiagonal;
        }

        private static bool CheckLines(char sym)
        {
            bool resultate = true;
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] != sym)
                    {
                        resultate = false;
                    }
                }

                if (resultate)
                {
                    return true;
                }
                else
                {
                    resultate = true;
                }
            }
            return false;
        }

        private static bool CheckColumns(char sym)
        {
            bool resultate = true;
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    if (field[j, i] != sym)
                    {
                        resultate = false;
                    }
                }

                if (resultate)
                {
                    return true;
                }
                else
                {
                    resultate = true;
                }
            }
            return false;
        }
        #endregion

        #region переменные
        static int SIZE_X = 3;
        static int SIZE_Y = 3;

        static char[,] field = new char[SIZE_Y, SIZE_X];

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();
        #endregion

        private static void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("-------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }

        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void playerMove()
        {
            int x, y;
            do
            {
                Console.WriteLine("Координат по строке ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_Y);
                y = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Координат по столбцу ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_X);
                x = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static void AiMove()
        {
            int x, y;
            do
            {
                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);
        }
    }
}
