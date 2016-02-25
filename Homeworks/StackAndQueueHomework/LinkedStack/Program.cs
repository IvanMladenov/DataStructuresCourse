using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new LinkedStack<int>();

            for (int i = 0; i < 50; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Pop());

            int[] arr = stack.ToArray();

            Console.WriteLine(arr[0]);
            Console.WriteLine(arr.Length);
        }
    }
}
