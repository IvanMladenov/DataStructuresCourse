using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayStack;

namespace SequenceNM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int m = nm[1];
            Queue<Item> queue = new Queue<Item>();
            queue.Enqueue(new Item(nm[0], null));

            while (queue.Count>0)
            {
                var item = queue.Dequeue();

                if (item.Value<m)
                {
                    queue.Enqueue(new Item(item.Value+1, item));
                    queue.Enqueue(new Item(item.Value+2, item));
                    queue.Enqueue(new Item(item.Value*2, item));
                }
                if (item.Value==m)
                {
                    PrintResult(item);
                    return;
                }
            }

            Console.WriteLine("(no solution)");
        }

        private static void PrintResult(Item item)
        {
            ArrayStack<int> output = new ArrayStack<int>();

            while (item!=null)
            {
                output.Push(item.Value);
                item = item.Previouse;
            }

            Console.WriteLine(string.Join(" -> ", output.ToArray()));
        }
    }
}
