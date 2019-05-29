using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example5
{
    class Program
    {
        static int fact(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * fact(n - 1);
        }
        static void Main(string[] args)
        {
			// Example of recursive function
            Console.WriteLine("{0}", fact(3));
        }
    }
}
