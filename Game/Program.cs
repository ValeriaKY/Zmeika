using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string a;
            int b=0;

            Osnova XYI = new Osnova();
            Console.CursorVisible = false;
            Console.Clear();
            do
            {
                Console.WriteLine("Введите уровень сложности (легко, нормально, сложно)");
                a = Console.ReadLine();
                if ("ЛЕГКО" == a.ToUpper() || "нормально" == a.ToLower() || "сложно" == a.ToLower())
                {
                    b = 1;
                }
            } while (b!=1);
            Console.Clear();
            switch (a.ToLower())
            {
                case "легко":
                    XYI.max_x = 10;
                    XYI.max_y = 10;
                    break;
                case "нормально":
                    XYI.max_x = 15;
                    XYI.max_y = 15;
                    break;
                case "сложно":
                    XYI.max_x = 20;
                    XYI.max_y = 20;
                    break;
                default:
                    break;
            }
            do
            {
                XYI.write_map_next();
                XYI.New_fruct();
                XYI.clear_map();
                XYI.move_pers();
                XYI.Game_Over();
            } while (XYI.end);
        }
    }
}
