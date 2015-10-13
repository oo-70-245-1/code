using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uml
{
    class Person
    {
        public string Name;
        public int Age;
    }

    class Professor : Person
    {
        public string Degree;
    }

    class Student : Person
    {
        public string level;
    }

    class Classroom
    {
        public Professor Professor;

        public List<Student> students = new List<Student>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Professor p = new Professor() { Age = 27, Name = "Nathan Adams", Degree = "Bachelor of science" };
            Classroom oo70245 = new Classroom() { Professor = p };
            oo70245.students.Add(new Student() { Name = "Microsoft Bob", Age = 18, level = "Freshman" });
            oo70245.students.Add(new Student() { Name = "Microsoft Bob2", Age = 20, level = "Sophmore" });
        }
    }
}
