namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static HashSet<int> parents;

        private static HashSet<int> children;

        private static Dictionary<int, List<int>> tree;

        private static void Main(string[] args)
        {
            var numberOfNodes = int.Parse(Console.ReadLine());

            parents = new HashSet<int>();
            children = new HashSet<int>();
            tree = new Dictionary<int, List<int>>();

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var parent = line[0];
                var child = line[1];

                if (!tree.ContainsKey(parent))
                {
                    tree.Add(parent, new List<int>());
                }

                tree[parent].Add(child);
                parents.Add(parent);
                children.Add(child);
            }

            int pathsSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            Console.WriteLine("Root node: {0}", FindRootNode());

            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", FindLeafNodes()));

            Console.WriteLine("Middle nodes: {0}", string.Join(", ", FindMiddleNodes()));

            var longestPath = new LinkedList<int>();
            FindLongestPath(FindRootNode(), new LinkedList<int>(), ref longestPath);
            Console.WriteLine("Longest path:\n{0} (length = {1})", string.Join(" -> ", longestPath), longestPath.Count);

            FindSubtreeWithSum(subtreeSum);

            Console.WriteLine("Paths of sum {0}:", pathsSum);
            FindPathsOfSum(pathsSum, 0, FindRootNode(), new LinkedList<int>());
        }

        private static void FindLongestPath(int root, LinkedList<int> currentPath, ref LinkedList<int> longestPath)
        {
            currentPath.AddLast(root);
            if (!parents.Contains(root))
            {
                if (currentPath.Count > longestPath.Count)
                {
                    foreach (var number in currentPath)
                    {
                        longestPath.AddLast(number);
                    }
                }
                return;
            }

            foreach (var child in tree[root])
            {
                FindLongestPath(child, currentPath, ref longestPath);
                currentPath.RemoveLast();
            }
        }

        private static void FindPathsOfSum(int sum, int currentSum, int root, LinkedList<int> path)
        {
            path.AddLast(root);
            currentSum += root;

            if (!parents.Contains(root))
            {
                if (sum == currentSum)
                {
                    Console.WriteLine(string.Join(" -> ", path));
                }

                return;
            }

            foreach (var child in tree[root])
            {
                FindPathsOfSum(sum, currentSum, child, path);
                path.RemoveLast();
            }
        }

        private static void CalcTreeSum(int parent, ref int sum)
        {
            sum += parent;

            if (!tree.ContainsKey(parent))
            {
                return;
            }

            foreach (var child in tree[parent])
            {
                CalcTreeSum(child, ref sum);
            }
        }

        private static void FindSubtreeWithSum(int subtreeSum)
        {
            var subtreeFound = false;
            foreach (var parent in parents)
            {
                var sum = 0;
                CalcTreeSum(parent, ref sum);

                if (subtreeSum == sum)
                {
                    subtreeFound = true;
                    var nodes = new List<int>();
                    GetCurrentSubtree(parent, nodes);
                    Console.WriteLine("Subtrees of sum {0}:\n {1}", subtreeSum, string.Join(" + ", nodes));
                }
            }

            if (!subtreeFound)
            {
                Console.WriteLine("Subtrees of sum {0}: no such subtree", subtreeSum);
            }
        }

        private static void GetCurrentSubtree(int parent, List<int> nodes)
        {
            nodes.Add(parent);
            if (!tree.ContainsKey(parent))
            {
                return;
            }

            foreach (var child in tree[parent])
            {
                GetCurrentSubtree(child, nodes);
            }
        }

        private static List<int> FindLeafNodes()
        {
            var leafs = new List<int>();
            foreach (var child in children)
            {
                if (!parents.Contains(child))
                {
                    leafs.Add(child);
                }
            }

            leafs.Sort();

            return leafs;
        }

        private static List<int> FindMiddleNodes()
        {
            var middles = new List<int>();
            foreach (var child in children)
            {
                if (parents.Contains(child))
                {
                    middles.Add(child);
                }
            }

            middles.Sort();

            return middles;
        }

        private static int FindRootNode()
        {
            foreach (var parent in parents)
            {
                if (!children.Contains(parent))
                {
                    return parent;
                }
            }

            throw new InvalidOperationException("This structure is not a tree");
        }
    }
}