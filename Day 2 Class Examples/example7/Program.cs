using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example7
{
    class Program
    {
        class Example
        {
            private int test1;
            public int test2;
            protected int test3;

            public virtual void func(int x) { }
            private void func2() { }
        }

        class Ex2 : Example
        {
            public override void func()
            {
                base.func(x);
            }
        }

        static void Main(string[] args)
        {
            Example e = new Example();
            e.test2 = 2;
        }
    }
}
