using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingInterfaceComparable.Entities;

namespace UsingInterfaceComparable
{

    // To use IComparable, I need to implement it in my class Employee
    public class Program
    {
        public static void Main(string[] args)
        {
            OrderListOfObjects();
        }

        private static void OrderListOfObjects()
        {
            string path = @"c:\temp\employees.txt";

            try
            {
                List<Employee> employees = new List<Employee>();
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        employees.Add(new Employee(sr.ReadLine()));
                    }

                    employees.Sort();

                    foreach (Employee employee in employees)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }

        private static void OrderSimpleListOfString()
        {
            // When using a simple collection of people name
            // there is no problem sort it. 

            string path = @"c:\temp\in.txt";
            try
            {

                using (StreamReader sr = File.OpenText(path))
                {
                    List<string> list = new List<string>();

                    while (!sr.EndOfStream)
                        list.Add(sr.ReadLine());

                    list.Sort();

                    foreach (string str in list)
                        Console.WriteLine(str);



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
