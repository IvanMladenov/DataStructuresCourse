using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> test = new LinkedList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);

            Console.WriteLine(test.Count);
            test.Remove(2);
            Console.WriteLine(test.Count);
        }
    }
}
