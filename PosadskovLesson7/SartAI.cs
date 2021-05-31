using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosadskovLesson7
{
    class SartAI
    {

        public SartAI()
        {
            CheckWin4Positions();
        }

        static void CheckWin4Positions()
        {
            InitField();
            PrintField();
            do
            {
                movedAI = false;
                playerMove();
                Console.WriteLine("Ваш ход на поле");
                PrintField();
                if (CheckWinNextMove(PLAYER_DOT))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                if (!movedAI)
                {
                    AiMove();
                }
                Console.WriteLine("Ход Компа на поле");
                PrintField();
                if (CheckWinNextMove(AI_DOT))
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
        }

        private static bool CheckWinNextMove(char sym)
        {
            if (CheckAllDiagonalsNextMove(sym))
            {
                return true;
            }
            else if (CheckLinesNextMove(sym))
            {
                return true;
            }
            else if (CheckColumnsNextMove(sym))
            {
                return true;
            }
            return false;
        }

        private static bool CheckAllDiagonalsNextMove(char sym)
        {
            for (int i = 0; i <= SIZE_X - WIN_POINTS; i++)
            {
                if (CheckDiagonalsNextMove(sym, i))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckDiagonalsNextMove(char sym, int shiftDiagonal)
        {
            int countWinChars = 0;
            int revCountWinChars = 0;

            for (int i = 0; i < SIZE_X - shiftDiagonal; i++)
            {
                if (field[i + shiftDiagonal, i] != sym)
                {
                    countWinChars = 0;
                }
                else
                {
                    ++countWinChars;

                    if (countWinChars == WIN_POINTS - 1)
                    {
                        if (isInField(i + shiftDiagonal + 1, i + 1) && field[i + shiftDiagonal + 1, i + 1] == sym)
                        {
                            return true;
                        }

                        if (IsCellValid(i + shiftDiagonal + 1, i + 1))
                        {
                            if (!movedAI)
                            {
                                AiMove(i + shiftDiagonal + 1, i + 1);
                            }                            
                        }
                        else if (IsCellValid(i + shiftDiagonal - WIN_POINTS - 1, i - WIN_POINTS - 1))
                        {
                            if (!movedAI)
                            {
                                AiMove(i + shiftDiagonal - WIN_POINTS - 1, i - WIN_POINTS - 1);
                            }                            
                        }                        
                    }
                }

                if (field[i + shiftDiagonal, SIZE_Y - 1 - i] != sym)
                {
                    revCountWinChars = 0;
                }
                else
                {
                    ++revCountWinChars;
                    if (revCountWinChars == WIN_POINTS - 1)
                    {
                        if (isInField(i + shiftDiagonal + 1, SIZE_Y - 1 - i - 1) && field[i + shiftDiagonal + 1, SIZE_Y - 1 - i - 1] == sym)
                        {
                            return true;
                        }
                        if (IsCellValid(i + shiftDiagonal + 1, SIZE_Y - 1 - i - 1))
                        {
                            if (!movedAI)
                            {
                                AiMove(i + shiftDiagonal + 1, SIZE_Y - 1 - i - 1);
                            }                                
                        }
                        else if (IsCellValid(i + shiftDiagonal - WIN_POINTS - 1, SIZE_Y - 1 - i + WIN_POINTS - 1))
                        {
                            if (!movedAI)
                            {
                                AiMove(i + shiftDiagonal - WIN_POINTS - 1, SIZE_Y - 1 - i + WIN_POINTS - 1);
                            }                                
                        }
                    }
                }
            }

            countWinChars = 0;
            revCountWinChars = 0;

            for (int i = 0; i < SIZE_X - shiftDiagonal; i++)
            {
                if (field[i, i + shiftDiagonal] != sym)
                {
                    countWinChars = 0;
                }
                else
                {
                    ++countWinChars;
                    if (countWinChars == WIN_POINTS - 1)
                    {
                        if (isInField(i + 1, i + shiftDiagonal + 1) && field[i + 1, i + shiftDiagonal + 1] == sym)
                        {
                            return true;
                        }

                        if (IsCellValid(i + 1, i + shiftDiagonal + 1))
                        {
                            if (!movedAI)
                            {
                                AiMove(i + 1, i + shiftDiagonal + 1);
                            }                                
                        }
                        else if (IsCellValid(i - WIN_POINTS - 1, i + shiftDiagonal - WIN_POINTS - 1))
                        {
                            if (!movedAI)
                            {
                                AiMove(i - WIN_POINTS - 1, i + shiftDiagonal - WIN_POINTS - 1);
                            }                                
                        }
                    }
                }

                if (field[i + shiftDiagonal, SIZE_Y - 1 - i - shiftDiagonal] != sym)
                {
                    revCountWinChars = 0;
                }
                else
                {
                    ++revCountWinChars;
                    if (revCountWinChars == WIN_POINTS - 1)
                    {
                        if (isInField(i + 1, SIZE_Y - 1 - i - shiftDiagonal - 1) && field[i + 1, SIZE_Y - 1 - i - shiftDiagonal - 1] == sym)
                        {
                            return true;
                        }
                        if (IsCellValid(i + 1, SIZE_Y - 1 - i - shiftDiagonal - 1))
                        {
                            if (!movedAI)
                            {
                                AiMove(i + 1, SIZE_Y - 1 - i - shiftDiagonal - 1);
                            }                                
                        }
                        else if (IsCellValid(i - WIN_POINTS - 1, SIZE_Y - 1 - i + shiftDiagonal + WIN_POINTS - 1))
                        {
                            if (!movedAI)
                            {
                                AiMove(i - WIN_POINTS - 1, SIZE_Y - 1 - i + shiftDiagonal + WIN_POINTS - 1);
                            }                                
                        }
                    }
                }
            }

            return false;
        }

        private static bool CheckLinesNextMove(char sym)
        {
            int countWinChars = 0;
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] != sym)
                    {
                        countWinChars = 0;
                    }
                    else
                    {
                        ++countWinChars;
                        if (countWinChars == WIN_POINTS - 1)
                        {
                            if (isInField(i, j + 1) && field[i, j + 1] == sym)
                            {
                                return true;
                            }

                            if (IsCellValid(i, j + 1))
                            {
                                if (!movedAI)
                                {
                                    AiMove(i, j + 1);
                                }                                    
                            }
                            else if (IsCellValid(i, j - WIN_POINTS - 1))
                            {
                                if (!movedAI)
                                {
                                    AiMove(i, j - WIN_POINTS - 1);
                                }                                    
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static bool CheckColumnsNextMove(char sym)
        {
            int countWinChars = 0;
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    if (field[j, i] != sym)
                    {
                        countWinChars = 0;
                    }
                    else
                    {
                        ++countWinChars;
                        if (countWinChars == WIN_POINTS - 1)
                        {
                            if (isInField(j + 1, i) && field[j +1, i] == sym)
                            {
                                return true;
                            }

                            if (IsCellValid(j + 1, i))
                            {
                                if (!movedAI)
                                {
                                    AiMove(j + 1, i);
                                }                                    
                            }
                            else if (IsCellValid(j - WIN_POINTS + 1, i))
                            {
                                if (!movedAI)
                                {
                                    AiMove(j - WIN_POINTS + 1, i);
                                }                                    
                            }
                        }
                    }
                }
            }
            return false;
        }

        static bool isInField (int x, int y)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }
            return true;
        }

        #region переменные
        static int SIZE_X = 5;
        static int SIZE_Y = 5;
        static int WIN_POINTS = 4;

        static char[,] field = new char[SIZE_Y, SIZE_X];

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static bool movedAI = false;

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
        private static void AiMove(int x, int y)
        {
            SetSym(x, y, AI_DOT);
            PrintField();
            movedAI = true;
        }        
    }
}
