using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int number = sequence[0];
            int count = 1;
            int currentNumber = sequence[0];
            int currentCount = 1;

            for (int i = 1; i < sequence.Count; i++)
            {
                if(sequence[i] == currentNumber)
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > count)
                    {
                        count = currentCount;
                        number = currentNumber;
                    }

                    currentNumber = sequence[i];
                    currentCount = 1;
                }
            }

            if (currentCount > count)
            {
                count = currentCount;
                number = currentNumber;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
