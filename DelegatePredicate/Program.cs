using DelegatePredicate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePredicate 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            products.Add(new Product("TV", 900.00));
            products.Add(new Product("Mouse", 50.00));
            products.Add(new Product("Tablet", 350.50));
            products.Add(new Product("HD Case", 80.90));

            //products.RemoveAll(p => p.Price >= 100.00);
            products.RemoveAll(ProductTest);

            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }


            Console.ReadKey();
        }

        private static bool ProductTest(Product p)
        {
            return p.Price >= 100.00;
        }
    }
}
