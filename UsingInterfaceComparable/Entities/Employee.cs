using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingInterfaceComparable.Entities
{
    public class Employee : IComparable
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string csvEmployee)
        {
            string[] vect = csvEmployee.Split(',');

            Name = vect[0];
            Salary = double.Parse(vect[1], CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append($"Name: {Name} - ");
            msg.Append($"Salary: R$ {Salary.ToString("F2", CultureInfo.InvariantCulture)}");

            return msg.ToString();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Employee))
                throw new Exception("This object is not a Employee Type");

            Employee other = obj as Employee;

            return Name.CompareTo(other.Name);
        }
    }
}
