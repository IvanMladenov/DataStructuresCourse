using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ').ToList();

            words.Sort((a,b)=>a.CompareTo(b));

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
