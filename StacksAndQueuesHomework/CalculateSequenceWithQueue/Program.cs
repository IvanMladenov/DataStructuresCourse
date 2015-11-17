using System;
using System.Collections;
using System.Collections.Generic;

namespace CalculateSequenceWithQueue
{
    internal class Program
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            for (int i = 0; i < 50; i++)
            {
                int currentS = queue.Dequeue();
                Console.Write(currentS + " ");
                queue.Enqueue(currentS+1);
                queue.Enqueue(2*currentS+1);
                queue.Enqueue(currentS+2);
            }
        }
    }
}