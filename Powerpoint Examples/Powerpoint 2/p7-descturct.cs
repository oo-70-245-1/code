using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace destructor
{
    class DisposeTest : IDisposable
    {

        public void Dispose()
        {
            Console.WriteLine("Cleaning up DisposeTest!");
        }
    }

    class DestructTest
    {
        ~DestructTest()
        {
            Console.WriteLine("Cleaning up Destruct Test");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                DestructTest t2 = new DestructTest();

            }

            Console.WriteLine("top");
            using (DisposeTest t = new DisposeTest())
            {

            }
            Console.WriteLine("bottom");
        }
    }
}
