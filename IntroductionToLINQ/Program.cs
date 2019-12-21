using IntroductionToLINQ.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //To work with LINQ (Language Integrated Query) it's necessary define a datasource and a query expression
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0).ToList();
            Print<Product>("TIER 1 AND PRICE < 900:", r1);

            // Show only products' name that have categories equal to Tools
            var r2 = products.Where(p => p.Category.Name.Equals("Tools"))
                .Select(p => p.Name);
            Print<string>("NAMES OF PRODUCTS FROM TOOLS", r2);

            var r3 = products
                .Where(p => p.Name[0].Equals('C'))
                .Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print<object>("NAMES STARTED WITH 'C' AND ANONYMOUS TYPE", r3);

            var r4 = products.Where(p => p.Category.Tier == 1)
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name);
            Print<Product>("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            var r5 = r4.Skip(2).Take(4);
            Print<Product>("SKIP 2 AND TAKE 4 FROM ABOVE LIST", r5);

            var r6 = products.First();
            Console.WriteLine($"First test 1: \n{r6}");

            // Get the first element from a datasource. If there isn't any item, it returns null
            var r7 = products.Where(p => p.Price > 3000).FirstOrDefault();
            Console.WriteLine($"\nFirst Or Default test 2: \n{r7}");

            // Important using this if we're sure if it will return just one item or nothing
            // Otherwise, an exception will be launched
            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine($"Single Or Default Test1: {r8}");


            // There is no ID equals to 30, so r9 will be null
            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine($"\nSingle Or Default Test2: {r9}");

            var r10 = products.Max(p => p.Price);
            Console.WriteLine($"\nMax Price: {r10}");

            var r11 = products.Min(p => p.Price);
            Console.WriteLine($"\nMin Price: {r11}");

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine($"\nCategory 1 Sum Prices: {r12}");

            // If there is not any category the function Average throws an exception
            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine($"\nCategory 1 Average Prices: {r13}");

            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty().Average();
            Console.WriteLine($"\nCategory 5 Average Prices with DefaultIfEmpty: {r14}");

            // 0.0 means the first value to seed
            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x,y) => x + y);
            Console.WriteLine($"\nCategory 1 aggregate sum: {r15}\n");

            var r16 = products.GroupBy(p => p.Category);

            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine($"Category {group.Key.Name}:");

                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void Print<T>(string message, IEnumerable collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();
        }
    }
}
