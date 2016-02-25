namespace LinkedStack
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
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