using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSimilarSQLNotation.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.Append($"{Id}, ");
            ret.Append($"{Name}, ");
            ret.Append($"{Price.ToString("F2", CultureInfo.InvariantCulture)}, ");
            ret.Append($"{Category.Name}, ");
            ret.Append($"{Category.Tier}");

            return ret.ToString();
        }
    }
}
