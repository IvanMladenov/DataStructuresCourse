using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ReversedList<int> proba = new ReversedList<int>();
            proba.Add(5);
            proba.Add(6);
            proba.Add(7);
            proba.Remove(1);

            Console.WriteLine(proba[1]);

            foreach (var item in proba)
            {
                Console.Write(item + " ");
            }
        }
    }
}
