using System;
using System.Collections.Generic;
using System.Linq;

namespace RoundDance
{
    class Program
    {
        static int maxSteps;

        static void Main()
        {
            int numberOfEdges = int.Parse(Console.ReadLine());
            int leaderNode = int.Parse(Console.ReadLine());

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int first = edge[0];
                int second = edge[1];

                if (!graph.ContainsKey(first))
                {
                    graph[first] = new List<int>();                    
                }

                if (!graph.ContainsKey(second))
                {
                    graph[second] = new List<int>();                  
                }

                graph[first].Add(second);
                graph[second].Add(first);
            }

            List<int> visited = new List<int>();
            visited.Add(leaderNode);
            FindTheLongestPath(graph, visited, leaderNode, 1);

            Console.WriteLine(maxSteps);
        }

        private static void FindTheLongestPath(Dictionary<int, List<int>> graph, List<int> visited,  int leaderNode, int steps)
        {
            if (steps>maxSteps)
            {
                maxSteps = steps;
            }

            foreach (var node in graph[leaderNode])
            {
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    FindTheLongestPath(graph, visited, node, steps + 1);
                }                
            }
        }
    }
}
