using System;

namespace Lesson_7_2
{
    class Cross
    {
        static int SIZE_X = 3;
        static int SIZE_Y = 3;

        static char[,] field = new char[SIZE_Y, SIZE_X];

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();

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

        private static void PlayerStep()
        {
            int x;
            int y;
            do
            {
                Console.WriteLine($"Введите координаты X Y (1-{SIZE_X})");
                x = Int32.Parse(Console.ReadLine()) - 1;
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static void AiStep()
        {
            int x;
            int y;
            do
            {
                x = random.Next(0, SIZE_X);
                y = random.Next(0, SIZE_Y);
            } while (!IsCellValid(y, x));
            SetSym(y, x, AI_DOT);
        }

        private static bool CheckWin(char sym)
        {
            return Gorizontal(sym);
           

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

            if (field[0, 0] == sym && field[1, 0] == sym && field[2, 0] == sym)
            {
                return true;
            }
            if (field[0, 1] == sym && field[1, 1] == sym && field[2, 1] == sym)
            {
                return true;
            }
            if (field[0, 2] == sym && field[1, 2] == sym && field[2, 2] == sym)
            {
                return true;
            }

            if (field[0, 0] == sym && field[1, 1] == sym && field[2, 2] == sym)
            {
                return true;
            }
            if (field[2, 0] == sym && field[1, 1] == sym && field[0, 2] == sym)
            {
                return true;
            }

            return false;
        }
        public static bool Gorizontal(char a)
        {
            bool c = false;

            for (int j = 0; j < field.GetLength(0); j++)
            {
                int k = 1;
                for (int i = 0; i < field.GetLength(1); i++)
                {
                    if (field[j, i] == a)
                    {

                        c = k == 3 ? true : false;
                        k++;

                    }
                    else
                    {
                        return c;
                    }

                }
                if (c == true)
                    
                break;

            }
            return c;
        }
            static void Main(string[] args)
    {
            InitField();
            PrintField();

            while (true)
            {
                PlayerStep();
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Player Win!");
                    break;
                }
                if (IsFieldFull())
                {
                    Console.WriteLine("DRAW");
                    break;
                }
                AiStep();
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("SkyNet Win!");
                    break;
                }
                if (IsFieldFull())
                {
                    Console.WriteLine("DRAW");
                    break;
                }
            }
        }
  }
}
