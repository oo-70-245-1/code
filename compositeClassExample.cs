using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace compositeexample
{
    public interface IEmployed
    {
        int EmpID { get; set; }
        string Name { get; set; }
    }

    public class Employee : IEmployed, IEnumerable<IEmployed>
    {
        private List<IEmployed> _subordiantes = new List<IEmployed>();

        public int EmpID { get; set; }
        public string Name { get; set; }

        public void AddSubordinate(IEmployed subordiante)
        {
            _subordiantes.Add(subordiante);
        }

        public void RemoveSubordinate(IEmployed subdorinate)
        {
            _subordiantes.Remove(subdorinate);
        }

        public IEmployed GetSubordinate(int index)
        {
            return _subordiantes[index];
        }

        public IEnumerator<IEmployed> GetEnumerator()
        {
            foreach (IEmployed subordinate in _subordiantes)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Contractor : IEmployed
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee Rahul = new Employee { EmpID = 1, Name = "Rahul" };
            Employee Amit = new Employee { EmpID = 2, Name = "Amit" };
            Employee Mohan = new Employee { EmpID = 3, Name = "Mohan" };

            Rahul.AddSubordinate(Amit);
            Rahul.AddSubordinate(Mohan);

            Employee Rita = new Employee { EmpID = 4, Name = "Rita" };
            Employee Hari = new Employee { EmpID = 5, Name = "Hari" };

            Amit.AddSubordinate(Rita);
            Amit.AddSubordinate(Hari);

            Console.WriteLine("EmpID={0}, Name={1}", Rahul.EmpID, Rahul.Name);

            foreach (Employee manager in Rahul)
            {
                Console.WriteLine("\n EmpID={0}, Name={1}", manager.EmpID, manager.Name);

                foreach (Employee emp in manager)
                {
                    Console.WriteLine(" \t EmpID={0},Name={1}", emp.EmpID, emp.Name);
                }
            }
        }
    }
}
