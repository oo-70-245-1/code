using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace factory1
{
    class Program
    {
        abstract class Position
        {
            public abstract string Title { get; }
        }

        class Clerk : Position
        {
            public override string Title
            {
                get { return "Clerk"; }
            }
        }

        class Manager : Position
        {
            public override string Title
            {
                get { return "Manager"; }
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
                    case 2:
                        return new Clerk();
                    default:
                        return new Programmer();
                }
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Position position = Factory.Get(i);
                Console.WriteLine("Where id = {0}, position = {1}", i, position.Title);
            }
        }
    }
}
