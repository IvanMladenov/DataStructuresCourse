using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTheRoot
{
    class Program
    {
        static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());

            var parents = new HashSet<int>();
            var children = new HashSet<int>();

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int parent = edge[0];
                int child = edge[1];

                parents.Add(parent);
                children.Add(child);
            }

            List<int> roots = new List<int>();
            foreach (var parent in parents)
            {
                if (!children.Contains(parent))
                {
                    roots.Add(parent);
                }
            }

            if (roots.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (roots.Count == 1)
            {
                Console.WriteLine(roots[0]);
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }
        }
    }
}
