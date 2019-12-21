using DelegateAction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Delegate Action represents a void method that has 1 or many arguments

            List<Product> products = new List<Product>();

            products.Add(new Product("TV", 900.00));
            products.Add(new Product("Mouse", 50.00));
            products.Add(new Product("Tablet", 350.50));
            products.Add(new Product("HD Case", 80.90));

            products.ForEach(p => p.Price += p.Price * 0.1);

            //products.ForEach(UpdatePrice);

            //Action<Product> act = UpdatePrice;
            //products.ForEach(act);

            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }

        private static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;
        }
    }
}
