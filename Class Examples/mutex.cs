using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace mutexexample2
{
    class Program
    {
        public static Mutex m = new Mutex();
        public static readonly int LOOP = 50000;
        public static long gvar = 0;

        static public void produce()
        {
            m.WaitOne();
            for (int i = 0; i < LOOP; i++)
                gvar++;
            m.ReleaseMutex();
        }

        static public void consume()
        {
			// Wait for the lock to be available
			// If no other thread has it locked then it is
			// by default available
            m.WaitOne();
            for (int i = 0; i < LOOP; i++)
                gvar--;
			
			// release/unlock the mutex lock
            m.ReleaseMutex();
        }

        static void Main(string[] args)
        {
			// Example using a mutex lock
			// Create 2 threads that use the same mutex lock variable
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
