using DelegateFunc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateFunc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Delegate Func represents a method that return a type TResult and it can have 0 or many parameters of any type

            List<Product> products = new List<Product>();

            products.Add(new Product("TV", 900.00));
            products.Add(new Product("Mouse", 50.00));
            products.Add(new Product("Tablet", 350.50));
            products.Add(new Product("HD Case", 80.90));

            // List<string> list = products.Select(NameUpper).ToList();
            // List<string> list = products.Select(p => p.Name.ToUpper()).ToList();

            Func<Product, string> func = NameUpper;
            List<string> list = products.Select(func).ToList();

            foreach (string s in list)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }

        private static string NameUpper(Product p)
        {
            return p.Name.ToUpper();
        }
    }
}
