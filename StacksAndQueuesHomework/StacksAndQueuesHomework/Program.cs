using System;
using System.Collections;
using System.Linq;

namespace StacksAndQueuesHomework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] numbers = (Console.ReadLine()).Split(' ').Select(int.Parse).ToArray();
            Stack stack = new Stack();
            foreach (var number in numbers)
            {
                stack.Push(number);
            }

            while (stack.Count>0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}