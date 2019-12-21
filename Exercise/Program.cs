using Exercise.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            using (StreamReader streamReader = File.OpenText(@"../../FilesCSV/employees.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    employees.Add(new Employee(streamReader.ReadLine()));
                }
            }

            var r1 = employees
                .Where(e => e.Salary > 1_300)
                .OrderBy(e => e.Email);

            Console.WriteLine("Employees email that have salary great than 1300:");
            foreach (Employee e in r1)
            {
                Console.WriteLine(e.Name);  
            }

            Console.ReadKey();
        }
    }
}
