using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generics
{
    class Program
    {
        static void swap<T>(ref T lhs,ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        static void Main(string[] args)
        {
			// example of a templated/generic swap
            int a, b;
            a = 10;
            b = 20;
            Console.WriteLine(a.ToString() + " " + b.ToString());
            swap(ref a, ref b);
            Console.WriteLine(a.ToString() + " " + b.ToString());

        }
    }
}
