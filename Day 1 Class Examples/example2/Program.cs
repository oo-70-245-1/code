using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2;
            Console.WriteLine("Please enter 2 numbers");
            n1 = Int32.Parse(Console.ReadLine());
            n2 = Int32.Parse(Console.ReadLine());
			// Basic arithmetic examples
            Console.WriteLine("{0} + {1} = {2}", n1, n2, n1 + n2);
            Console.WriteLine("{0} * {1} = {2}", n1, n2, n1 * n2);
            Console.WriteLine("{0} / {1} = {2}", n1, n2, n1 / n2);
            Console.WriteLine("{0} - {1} = {2}", n1, n2, n1 - n2);
            Console.Read();
        }
    }
}
