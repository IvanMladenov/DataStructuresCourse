using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBasedStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new ArrayStack<int>();

            for (int i = 0; i < 50; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Pop());
        }
    }
}
