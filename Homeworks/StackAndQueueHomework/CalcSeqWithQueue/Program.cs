namespace CalcSeqWithQueue
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(n);

            for (int i = 0; i < 50; i++)
            {
                var firstInQueue = queue.Peek();

                queue.Enqueue(firstInQueue + 1);
                queue.Enqueue(2 * firstInQueue + 1);
                queue.Enqueue(firstInQueue + 2);

                Console.Write(queue.Dequeue() + " ");
            }
        }
    }
}