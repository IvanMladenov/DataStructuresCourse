namespace ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            Stack<int> stack = new Stack<int>();

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", numbers));

            for (int i = 0; i < numbers.Length; i++)
            {
                stack.Push(numbers[i]);
            }

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}