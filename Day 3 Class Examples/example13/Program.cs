using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example13
{
    abstract class Position
    {
        public abstract string Title { get; }
    }

    class Manager : Position
    {
        public override string Title
        {
            get { return "Manager"; }
        }
    }

    class Clerk : Position
    {
        public override string Title
        {
            get { return "Clerk"; }
        }
    }

    class Programmer : Position
    {
        public override string Title
        {
            get { return "Programmer"; }
        }
    }

    static class Factory
    {
        public static Position Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new Manager();
                case 1:
                    return new Clerk();
                default:
                    return new Programmer();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Position id = {0}, position = {1}", 0, Factory.Get(0));
        }
    }
}
