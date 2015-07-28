namespace FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    internal class Program
    {
        private static void Main()
        {
            int numberOfPairs = int.Parse(Console.ReadLine());
            HashSet<int> parentNodes = new HashSet<int>();
            int[] childNodes = new int[numberOfPairs];

            for (int i = 0; i < numberOfPairs; i++)
            {
                string[] currentPair = Console.ReadLine().Split();
                int parent = int.Parse(currentPair[0]);
                int child = int.Parse(currentPair[1]);

                parentNodes.Add(parent);
                childNodes[i] = child;
            }

            List<int> roots = new List<int>();
            foreach (var parent in parentNodes)
            {
                if (!childNodes.Contains(parent))
                {
                    roots.Add(parent);
                }
            }

            if (roots.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if(roots.Count==1)
            {
                Console.WriteLine(roots[0]);
            }
            else
            {
                Console.WriteLine("Forest is not a tree!");
            }
        }
    }
}