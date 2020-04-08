using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   public class Osnova2
    {
        private List<int> snakeX = new List<int>();
        private List<int> snakeY = new List<int>();
        public bool end = true;
        private bool eating = false;
        private int EX;
        private int EY;
        private int endSnakeX;
        private int endSnakeY;
        private const int max_x = 20;
        private const int max_y = 20;
        private double Time = 200;
        ConsoleKeyInfo mKey = new ConsoleKeyInfo('Q', ConsoleKey.Q, false, false, false);
        private string[,] mass = new string[max_x, max_y];
        char hero = '@';
        int pers_x, pers_y;
        int fruct_x, fruct_y;
        Random rand = new Random();
        public Osnova2()
        {
            this.completion_map();
            this.start_poz();
            this.write_map();
        }
        private void start_poz()
        {
            do
            {
                pers_x = rand.Next(0, max_x);
                pers_y = rand.Next(0, max_y);
                fruct_x = rand.Next(0, max_x);
                fruct_y = rand.Next(0, max_y);
            } while (pers_x == fruct_x || pers_x == fruct_y || pers_y == fruct_y || pers_y == fruct_x);
            snakeX.Add(pers_x);
            snakeY.Add(pers_y);

            mass[snakeX[0], snakeY[0]] = hero.ToString();
            mass[fruct_x, fruct_y] = "*";
        }
        private void reversX()
        {
            endSnakeX = snakeX[snakeX.Count - 1];
            endSnakeY = snakeY[snakeY.Count - 1];
            for (int i = snakeX.Count - 1; i > 0; --i)
            {
                snakeX[i] = snakeX[i - 1];
                snakeY[i] = snakeY[i - 1];
            }
        }
        public void completion_map()
        {
            for (int i = 0; i < max_x; i++)
            {
                for (int j = 0; j < max_y; j++)
                {
                    mass[i, j] = " ";
                }
            }
        }
        public void write_map()
        {
            for (int i = 0; i < max_x; i++)
            {
                for (int j = 0; j < max_y; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(mass[i, j]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void write_map_next()
        {
            Console.SetCursorPosition(fruct_y, fruct_x);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("*");
            for (int i = snakeY.Count - 1; i >= 0; --i)
            {
                Console.SetCursorPosition(snakeY[i], snakeX[i]);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("@");
            }

        }
        public void clear_map()
        {
            for (int i = 0; i < max_x; i++)
            {
                for (int j = 0; j < max_y; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }
            }
        }
        public void move_pers()
        {
            if (mKey.Key == ConsoleKey.Q || Console.KeyAvailable == true)
            {
                mKey = Console.ReadKey();
            }
            switch (mKey.Key)
            {
                case ConsoleKey.W:
                    if (snakeX[0] > 0)
                    { reversX(); snakeX[0]--; }
                    break;
                case ConsoleKey.A:
                    if (snakeY[0] > 0)
                    { reversX(); snakeY[0]--; }
                    break;
                case ConsoleKey.S:
                    if (snakeX[0] < max_x - 1)
                    { reversX(); snakeX[0]++; }
                    break;
                case ConsoleKey.D:
                    if (snakeY[0] < max_y - 1)
                    { reversX(); snakeY[0]++; }
                    break;
                default:
                    break;
            }
            // Console.Clear();
            eatingSeeng();
            paintSnake();
            //this.write_map();
        }
        private void eatingSeeng()
        {
            if (eating)
            {
                Time = Time - 1;
                if (EY == endSnakeY && EX == endSnakeX)
                {
                    snakeY.Add(endSnakeY);
                    snakeX.Add(endSnakeX);
                    eating = false;
                }
            }
        }
        private void paintSnake()
        {
            if (snakeY.Count == snakeX.Count)
            {
                completion_map();
                mass[fruct_x, fruct_y] = "*";
                for (int i = 0; i < snakeX.Count; ++i)
                {
                    mass[snakeX[i], snakeY[i]] = hero.ToString();
                }
            }
        }
        public void New_fruct()
        {
            System.Threading.Thread.Sleep((int)Time);
            if (snakeX[0] == fruct_x && snakeY[0] == fruct_y)
            {
                eating = true;
                EX = fruct_x;
                EY = fruct_y;
                do
                {
                    fruct_x = rand.Next(0, max_x);
                    fruct_y = rand.Next(0, max_y);
                } while (snakeX[0] == fruct_x || snakeX[0] == fruct_y || snakeY[0] == fruct_y || snakeY[0] == fruct_x);
            }
        }
        public void Game_Over()
        {
            for (int i = snakeX.Count - 1; i > 0; --i)
            {
                if (i > 0)
                {
                    if (snakeX[0] == snakeX[i] && snakeY[0] == snakeY[i])
                    {
                        Console.WriteLine("Game Over");
                        end = false;
                        break;
                    }

                }
            }
        }
    }
}
