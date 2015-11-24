using System;
using System.Collections.Generic;
using System.Linq;

namespace TreesAndTreeLikeStructures
{

    class Program
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < nodesCount - 1; i++)
            {
                int[] pair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Tree<int> parentNode = GetTreeNodeByValue(pair[0]);
                Tree<int> childNode = GetTreeNodeByValue(pair[1]);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());
            Tree<int> parent = null;
            foreach (var tree in nodeByValue.Values)
            {
                if (tree.Parent == null)
                {
                    Console.WriteLine($"Root node: {tree.Value}");
                    parent = tree;
                    break;
                }
            }

            List<int> leafs = new List<int>();
            List<int> midleNodes = new List<int>();
            GetTreeLeafs(leafs, midleNodes, parent);
            Console.WriteLine($"Leaf nodes: {string.Join(", ", leafs)}");
            Console.WriteLine($"Middle nodes: {string.Join(", ", midleNodes)}");
        }

        private static void GetTreeLeafs(List<int> leafs, List<int> midleNodes, Tree<int> parent)
        {
            if (parent.Children.Count == 0)
            {
                leafs.Add(parent.Value);
            }

            if (parent.Children.Count > 0 && parent.Parent != null)
            {
                midleNodes.Add(parent.Value);
            }

            foreach (var child in parent.Children)
            {
                GetTreeLeafs(leafs, midleNodes, child);
            }
        }

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }
    }
}
