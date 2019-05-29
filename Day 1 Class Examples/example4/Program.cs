using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example4
{
    class Math
    {
        public int pow(int num, int power)
        {
            int tmp = 1;
            for(int i = 0; i < power; i++)
            {
                tmp *= num;
            }
            return tmp;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n2;
            int n1;
            Console.WriteLine("Please enter a number and a power:");
			// Using console input and function calls to implment power
            n1 = Int32.Parse(Console.ReadLine());
            n2 = Int32.Parse(Console.ReadLine());
            Math m = new Math();
            Console.WriteLine("The value is {0}", m.pow(n1, n2));
        }
    }
}
