using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifteen
{
    class Print
    {
        static public void Start()
        {
            Console.WriteLine("Здравствуйте!Введите число:");
            string s = Console.ReadLine();
            int number = Convert.ToInt32(s);
            Game player = new Game(number);
            Random gen = new Random();
            player.Filling(gen);
            Console.Clear();

            player.Printing();
            Console.WriteLine("Выберете число,которое хотите передвинуть");
            int value = Convert.ToInt16(Console.ReadLine());
            player.Shift(value);
            Console.Clear();

            player.Printing();
        }
    }
}
