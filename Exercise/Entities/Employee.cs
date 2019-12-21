using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Entities
{
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Employee(string csvEmployee)
        {
            string[] emp = csvEmployee.Split(';');

            Name = emp[0];
            Email = emp[1];
            Salary = Convert.ToDouble(emp[2]);
        }
    }
}
