using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceNM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<Item> queue = new Queue<Item>();

            int finalValue = nm[1];
            Item firstItem = new Item(nm[0]);
            queue.Enqueue(firstItem);

            while (queue.Count>0)
            {
                var currentItem = queue.Dequeue();

                if (currentItem.Value==finalValue)
                {
                    var stack = new Stack<int>();
                    while (currentItem!=null)
                    {
                        stack.Push(currentItem.Value);
                        currentItem = currentItem.PrevItem;
                    }

                    Console.WriteLine(string.Join(" -> ", stack));
                    return;
                }
                else if (currentItem.Value<finalValue)
                {
                    var first = new Item(currentItem.Value+1){PrevItem = currentItem};
                    var second = new Item(currentItem.Value+2){PrevItem = currentItem};
                    var third = new Item(currentItem.Value*2){PrevItem = currentItem};

                    queue.Enqueue(first);
                    queue.Enqueue(second);
                    queue.Enqueue(third);
                }
            }

            Console.WriteLine("(no solution)");
        }
    }
}
