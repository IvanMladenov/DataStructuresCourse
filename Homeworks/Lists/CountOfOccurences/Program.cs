using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var counted = SplitAndCount(sequence);

            foreach (var pair in counted)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value} times");
            }


        }

        private static SortedDictionary<int, int> SplitAndCount(List<int> list)
        {
            var data = new SortedDictionary<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!data.ContainsKey(list[i]))
                {
                    data.Add(list[i], 0);
                }

                data[list[i]]++;
            }

            return data;
        }
    }
}
