using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example10
{
    class Program
    {
        class EvenInt
        {
            int val = 0;

            public delegate void CallbackFun(int newval, int oldval);
            public event CallbackFun Changed;

            public int Value
            {
                get { return val; }
                set
                {
                    if (Changed != null)
                        Changed(value, val);
                    val = value;
                }
            }
        }
        static void Main(string[] args)
        {
            EvenInt num = new EvenInt();
            num.Changed += new EvenInt.CallbackFun(num_Changed);
            num.Changed += new EvenInt.CallbackFun(num_Changed2);

            num.Value = 20;
            num.Value += 10;
        }

        static void num_Changed2(int newval, int oldval)
        {
            Console.WriteLine("numchanged2");
        }

        static void num_Changed(int newval, int oldval)
        {
            Console.WriteLine("Changed from {0} to {1}", oldval, newval);
        }
    }
}
