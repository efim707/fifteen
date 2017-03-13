using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            Print.Start();
            Console.WriteLine("Хотите сыграть еще раз: да/нет ");
            string answer = Convert.ToString(Console.ReadLine());

            if (answer == "да")
            {
                Console.Clear();
                Print.Start();
            }
            else
            {
                Console.WriteLine("Спасибо за игру!");
            }


            Console.ReadLine();
        }
    }
}
