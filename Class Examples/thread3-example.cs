using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace threading1
{
    class Program
    {
        const int BUFFER_SIZE = 20;
        static volatile int counter = -1;
        static volatile double []buffer = new double[BUFFER_SIZE];
        static void Main(string[] args)
        {
            for (int i = 0; i < BUFFER_SIZE; i++)
                buffer[i] = -1;
            Thread thread1 = new Thread(new ThreadStart(produce));
            Thread thread2 = new Thread(new ThreadStart(consume));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            //Console.WriteLine(Program.counter);

        }

        public static void produce()
        {
            Random num = new Random();
            while (true)
            {
                while (counter == BUFFER_SIZE - 1) ;
                Program.buffer[counter + 1] = Convert.ToInt32((num.NextDouble() % 10) * 10) + 1;
                Console.WriteLine("Producer value = {0} counter = {1}", Program.buffer[counter + 1], counter + 1);
                counter++;
            }
        }

        public static void consume()
        {
            while (true)
            {
                while (counter == -1) ;
                Console.WriteLine("Consumer value = {0} counter = {1}", buffer[counter], counter);
                Program.buffer[counter] = 0;
                counter--;
            }
        }
    }
}
