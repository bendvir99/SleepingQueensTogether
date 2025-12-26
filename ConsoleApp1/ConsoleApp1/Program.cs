using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int falls = 0, upps = 0, last_stock= int.Parse(Console.ReadLine()), stock, big_stock = last_stock, small_stock = last_stock, difference, biggest_change = 0;
            double average = 0;
            for (double i = 1; i <8; i++)
            {
                stock = int.Parse(Console.ReadLine());
                average += stock;
                small_stock = Math.Min(small_stock, stock);
                big_stock = Math.Max(big_stock,stock);
                difference = stock - last_stock;
                if (difference < 0)
                    falls++;
                else if (difference > 0)
                    upps++;
                if (Math.Abs(difference)>biggest_change)
                biggest_change = difference;
                last_stock = stock;
            }
            Console.WriteLine(average / 8);
            Console.WriteLine(small_stock);
            Console.WriteLine(big_stock);
            Console.WriteLine(falls);
            Console.WriteLine(upps);
            Console.WriteLine(biggest_change);

        }
    }
}
