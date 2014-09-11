using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[10];
            for (int i = 0; i < x.Length; i++)
                x[i] = i;

            foreach (int z in x)
                Console.WriteLine(z);

            List<int> lst1 = new List<int>();
            for (int i = 0; i < 10; i++)
                lst1.Add(i);

            foreach (int z in lst1)
                Console.WriteLine(z);

            ArrayList al1 = new ArrayList();
            for (int i = 0; i < 10; i++)
                al1.Add(i);

            foreach (int z in al1)
                Console.WriteLine(z);

            int w = (int)al1[0];
        }
    }
}
