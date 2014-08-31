using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example3
{
    class Program
    {
        static void Main(string[] args)
        {
            int tal = 0;
            string tmp;
            Console.WriteLine("Please enter 5 numbers:");
            for (int i = 0; i < 5; i++)
            {
                tmp = Console.ReadLine();
                tal += Int32.Parse(tmp);
            }
            Console.WriteLine("Value of tal = {0}", tal);
        }
    }
}
