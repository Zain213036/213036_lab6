using System;
namespace MyApplication
{

    class Question1
    {
        static void Main(string[] args)
        {
            double x = 98, y = 0;
            double result = 0;
            try
            {
                result = SafeDivision(x, y);
                Console.WriteLine($" {x} divide by {y} ={result}");
            }

            catch (DivideByZeroException e)

            {
                Console.WriteLine("Attempt divide by zero");
            }

        }

        static double SafeDividion(double a, double b)
        {
            if (b == 0)
            {
                throw new System.DivideByzeroExeption();
                return a / b;
            }
        }

    }
}
