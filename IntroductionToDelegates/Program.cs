using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDelegates
{
    // Look at where we declare a delegate!
    // It can be declared inside of a class or above it
    delegate double BinaryNumericOperation(double n1, double n2);

    public class Program
    {
        public static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            // BinaryNumericOperation op = CalculationService.Max;

            BinaryNumericOperation op = CalculationService.Sum;
            // double result = op(a, b);
            double result = op.Invoke(a, b);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
