namespace FindTheRoot
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            int numberOfPairs = int.Parse(Console.ReadLine());
            string[] pairs = new string[numberOfPairs];

            for (int i = 0; i < numberOfPairs; i++)
            {
                int parent = int.Parse(pairs[i][0].ToString());
                int child = int.Parse(pairs[i][2].ToString());
            }
        }
    }
}