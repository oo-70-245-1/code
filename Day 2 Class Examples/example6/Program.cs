using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example6
{
    internal class PassTest
    {
        public PassTest(int x) { }
        public List<int> vals = new List<int>();
    }

    class Program
    {
        static void f1(int x)
        {
            x = 5;
        }

        static void f2(ref int x)
        {
            x = 5;
        }

        static void f3(PassTest t)
        {
            t.vals.Add(5);
        }

        static void f4(ref PassTest t)
        {
            t = new PassTest(5);
            t.vals.Add(10);
        }

        static void Main(string[] args)
        {
            internalexamples.
            int x = 4;
            f1(x);
            Console.WriteLine(x);
            f2(ref x);
            Console.WriteLine(x);
            PassTest t = new PassTest(x);
            Console.WriteLine(string.Join(",", t.vals.ToArray()));
            f3(t);
            Console.WriteLine(string.Join(",", t.vals.ToArray()));
            f4(ref t);
            Console.WriteLine(string.Join(",", t.vals.ToArray()));
        }
    }
}
