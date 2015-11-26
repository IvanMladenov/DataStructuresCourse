using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LongestPathInTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());

            List<Tree> nodes = new List<Tree>();

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int parentValue = edge[0];
                int childValue = edge[1];

                var currentParent = nodes.FirstOrDefault(x => x.Value == parentValue);
                var currentChild = nodes.FirstOrDefault(x => x.Value == childValue);
                if (currentParent == null)
                {
                    currentParent = new Tree(parentValue);
                    nodes.Add(currentParent);
                }

                if (currentChild == null)
                {
                   currentChild = new Tree(childValue);
                   nodes.Add(currentChild);
                }

                currentParent.Children.Add(currentChild);
                currentChild.Parent = currentParent;
            }

            var root = nodes.FirstOrDefault(x => x.Parent == null);
            UpdateDistances(root);
            var leafs = nodes.Where(x => x.Children.Count == 0).OrderByDescending(x=>x.DistanceValue).ToArray();
            
            List<int> path = new List<int>();
            var bestLeafDistance = leafs[0];
            while (bestLeafDistance!=null)
            {
                path.Add(bestLeafDistance.Value);
                bestLeafDistance = bestLeafDistance.Parent;
            }

            List<int> secondPath = new List<int>();
            for (int i = 1; i < leafs.Length; i++)
            {
                var currentNode = leafs[i];
                while (currentNode.Parent!=null)
                {
                    if (path.Contains(currentNode.Value))
                    {
                        secondPath.Clear();
                        break;
                    }
                    secondPath.Add(currentNode.Value);
                    currentNode = currentNode.Parent;
                }

                if (currentNode.Parent==null)
                {
                    break;
                }
            }

            secondPath.Reverse();
            Console.WriteLine(string.Join("->", path) + "->" + string.Join("->", secondPath));
            Console.WriteLine(path.Sum() + secondPath.Sum());
        }

        private static void UpdateDistances(Tree root)
        {
            foreach (var child in root.Children)
            {
                child.DistanceValue += root.DistanceValue;
                UpdateDistances(child);
            }
        }
    }

    class Tree
    {
        public Tree(int value)
        {
            this.Value = value;
            this.Children = new List<Tree>();
            DistanceValue = Value;
        }

        public int DistanceValue { get; set; }

        public int Value { get; set; }

        public Tree Parent { get; set; }

        public List<Tree> Children { get; set; }
    }
}
