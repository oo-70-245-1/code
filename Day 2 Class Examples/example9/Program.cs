using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example9
{
    class DisposeTest : IDisposable
    {

        public void Dispose()
        {
            Console.WriteLine("Cleaning up DisposeTest");
        }
    }

    class DestructTest
    {
        ~DestructTest()
        {
            Console.WriteLine("Cleaning up DestructTest");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                DestructTest t2 = new DestructTest();
            }
            //GC.Collect(3, GCCollectionMode.Forced);
            Console.WriteLine("top");
            using (DisposeTest t = new DisposeTest())
            {

            }
            Console.WriteLine("bottom");
        }
    }
}
