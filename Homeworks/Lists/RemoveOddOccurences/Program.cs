using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveOddOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> removed =  RemoveOddCountNumbers(sequence);

            Console.WriteLine(string.Join(" ", removed));

            
        }

        private static List<int> RemoveOddCountNumbers(List<int> list)
        {
            Dictionary<int, int> data = new Dictionary<int, int>();
            List<int> output = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!data.ContainsKey(list[i]))
                {
                    data.Add(list[i], 0);
                }

                data[list[i]]++;
            }

            foreach (var number in list)
            {
                if (data[number] % 2 == 0)
                {
                    output.Add(number);
                }
            }

            return output;
        }
    }
}
