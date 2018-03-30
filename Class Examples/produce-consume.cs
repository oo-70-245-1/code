using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace mutexexample2
{
    class Program
    {
        public static readonly int LOOP = 50000;
        public static long gvar = 0;

        static public void produce()
        {
            for (int i = 0; i < LOOP; i++)
                gvar++;
        }

        static public void consume()
        {
            for (int i = 0; i < LOOP; i++)
                gvar--;
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(produce));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(consume));
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine(gvar);
        }
    }
}
