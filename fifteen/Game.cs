using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifteen
{
    class Game
    {
        public int[,] Field;
        int size;
        Point[] points;

        public Game(params int[] values) //конструктор
        {

            if (!CheckFieldCreation(values.Length))
            {
                throw new ArgumentException("Невозмжно создать поле такого размера!");
            }

            if (!CheckUniqueNumbers(values))
            {
                throw new ArgumentException("Встречаются одинаковые числа.");
            }
            if (CheckNegativeNumbers(values))
            {
                throw new ArgumentException("Встречаются отрицательные числа.");
            }

            int[] copy = new int[values.Length];
            size = (int)Math.Sqrt(values.Length);
            Field = new int[size, size];
            points = new Point[copy.Length];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int value = values[i * size + j];
                    Field[i, j] = value;
                    points[value] = new Point(j, i);
                }
            }

        }

        public void Filling(Random gen)
        {
            int[] numbers = new int[Field.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = gen.Next(0, Field.Length);
                int y = numbers[i];
                if (i >= 1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        while (numbers[i] == numbers[j])
                        {
                            numbers[i] = gen.Next(0, Field.Length);
                            j = 0;
                            y = numbers[i];
                        }
                        y = numbers[i];
                    }
                }
                Console.WriteLine("{0},{1}", numbers[i], i);
            }

            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j] = numbers[i * Field.GetLength(0) + j];

                }
            }
        }

        public void Printing()
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Console.Write("{0}\t", Field[i, j]);

                }
                Console.WriteLine();
            }
        }


        public int this[int x, int y] //индексатор- доступ к элементам по их индексу
        {
            get
            {
                return Field[x, y];
            }
            set
            {
                Field[x, y] = value;
            }
        }


        private Point GetLocation(int value) // метод, возвращающий месторасположение 
        {
            try
            {
                return points[value];
            }
            finally { }
        }

        private void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        private void swap(ref Point a, ref Point b)
        {
            Point t = a;
            a = b;
            b = t;
        }

        public void Shift(int value)  //передвижение 
        {
            Point position = GetLocation(value);
            Point position0 = GetLocation(0);

            if (!((position.X == position0.X || position.Y == position0.Y)
               && Math.Abs(position.X - position0.X) <= 1
               && Math.Abs(position.Y - position0.Y) <= 1))
            {
                throw new Exception("Нельзя двигать эту фишку!");
            }
            else
                swap(ref Field[position.Y, position.X], ref Field[position0.Y, position0.X]);
            swap(ref points[0], ref points[value]);
        }


        //ограничения


        private bool CheckFieldCreation(int size)
        {
            return ((Math.Sqrt(size) % 1) == 0);
        }


        private bool CheckUniqueNumbers(int[] mas)
        {
            int a;
            for (int i = 0; i < mas.Length; i++)
            {
                a = mas[i];
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] == a)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckNegativeNumbers(int[] values)
        {
            foreach (int i in values)
            {
                return values[i] < 0;
            }
            return true;
        }
    }
}
