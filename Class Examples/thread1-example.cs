using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace threading1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(t1);
                t.Start(i);
                threads.Add(t);
            }

            for (int i = 0; i < threads.Count; i++)
                threads[i].Join();

        }

        public static void t1(object tn)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine("Thread {0} - {1}", (int)tn, i);
        }
    }
}
