using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingComparisonDelegate.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append($"Name: {Name} - ");
            msg.Append($"Price: R$ {Price.ToString("F2", CultureInfo.InvariantCulture)}");

            return msg.ToString();
        }
    }
}
