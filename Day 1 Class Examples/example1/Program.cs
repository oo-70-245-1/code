using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example1
{
    class Program
    {
        private int x;
        protected int y;
        public int z;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            //Test t = new Test();
            //t
            string s = "hello, ";
            s += "world";
            Console.WriteLine("hello, " + s + s + s + "some other string" + s + "something");
            Console.WriteLine("hello, {0.2} {1} {2} {3}", s, s, s, s);
        }
    }

    class Test : Program
    {

    }
}
