using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace threading1
{
    class Program
    {
        static volatile int counter = 0;
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(t1));
            
            Thread thread2 = new Thread(new ThreadStart(t2));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine(Program.counter);

        }

        public static void t1()
        {
            for (int i = 0; i < 99999; i++)
                Program.counter++;
        }

        public static void t2()
        {
            for (int i = 0; i < 99999; i++)
                Program.counter--;
        }
    }
}
