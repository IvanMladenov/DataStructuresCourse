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
            test.Add(0);
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(3);

            test.Remove(0);

            Console.WriteLine(test.FirstIndexOf(2));
            Console.WriteLine(test.LastIndexOf(3));
        }
    }
}
