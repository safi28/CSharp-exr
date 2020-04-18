using System;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double l = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            double o = double.Parse(Console.ReadLine());

            double garden = n * n;
            double b = w * l;
            double wTile = m * o;

            double width = garden - b;
            double tiles = width / wTile;
            double time = tiles * 0.2;

            Console.WriteLine($"Needed tiles = {tiles.ToString("N2")}\nTime: {time} min");
        }

    }
}
