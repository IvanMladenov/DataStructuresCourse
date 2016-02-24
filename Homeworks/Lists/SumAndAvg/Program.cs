using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAndAvg
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            List<int> list = new List<int>();
            if (input == string.Empty)
            {
                list.Add(0);
            }
            else
            {
                list.AddRange(input.Split(' ').Select(int.Parse));
            }
            Console.WriteLine($"Sum={list.Sum()}, Average={list.Average()}");
        }
    }
}
