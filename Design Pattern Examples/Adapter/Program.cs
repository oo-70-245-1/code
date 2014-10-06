using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adapterexample
{
    public interface ITarget
    {
        List<string> GetEmployeeList();
    }
    public class ThirdPartyBillingSystem
    {
        private ITarget employeesource;
        public ThirdPartyBillingSystem(ITarget src)
        {
            employeesource = src;
        }
        public void ShowEmployeeList()
        {
            List<string> employee = employeesource.GetEmployeeList();

            foreach (string emp in employee)
            {
                Console.WriteLine(emp);
            }
        }
    }
    public class HRSystem
    {
        public string[][] GetEmployees()
        {
            string[][] employees = new string[4][];
            employees[0] = new string[] { "100", "Deepak", "Team Leader" };
            employees[1] = new string[] { "101", "Rohit", "Developer" };
            employees[2] = new string[] { "102", "Nathan", "Developer" };
            employees[3] = new string[] { "103", "Bob", "Tester" };
            return employees;
        }
    }

    public class EmployeeAdapter : HRSystem, ITarget
    {

        public List<string> GetEmployeeList()
        {
            List<string> employeeList = new List<string>();
            string[][] employees = GetEmployees();
            foreach (string[] employee in employees)
            {
                employeeList.Add(String.Format("{0},{1},{2}", employee[0], employee[1], employee[2]));
            }
            return employeeList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ITarget target = new EmployeeAdapter();
            ThirdPartyBillingSystem client = new ThirdPartyBillingSystem(target);
            client.ShowEmployeeList();

        }
    }
}
