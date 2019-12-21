using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingComparisonDelegate.Entities;

namespace UsingComparisonDelegate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            products.Add(new Product("TV", 900.0));
            products.Add(new Product("Notebook", 1200.0));
            products.Add(new Product("Tablet", 450.0));

            // As my class doesnt implement IComparable interface, this line throws an exception
            //products.Sort();

            /*
             * There are 3 ways of using delegates
             */
            
            // 1st way: using a function directly in the method Sort
            products.Sort(CompareProducts);

            // 2nd way: referencing a function
            Comparison<Product> comp1 = CompareProducts;
            products.Sort(comp1);

            // 3rd way: using lambda
            // Comparinson receives two parameters of Type Product and return an int type
            Comparison<Product> comp2 = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());

            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }

        private static int CompareProducts(Product p1, Product p2)
        {
            return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
        }
    }
}
