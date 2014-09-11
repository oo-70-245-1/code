using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example12
{
    class MyException : Exception
    {
        public MyException(string msg) : base(msg)
        {
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //throw new Exception("this is a boring exception");
            throw new MyException("this is a fun exception");
        }
    }
}
