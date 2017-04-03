using System;
using System.Linq;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;

namespace StandardDeviation
{
    class Program
    {

        static double[] numParse()
        {
            string line;
            string sNumbers = "";

            while ((line = Console.ReadLine()) != null && line != "")
            {
                sNumbers += line;
            }

            string[] splitedNumbers = sNumbers.Split();

            try
            {
                var numbers = splitedNumbers.Select(double.Parse).ToArray();

                return numbers;

            }
            catch (Exception)
            {
                Console.WriteLine("input error!");
                System.Environment.Exit(-1);
            }

            return null;
        }

        static double compute(double[] someDoubles)
        {
            double tmp = 0;

            Addition addition = new Addition();
            Division division = new Division();
            Substraction substraction = new Substraction();
            Power power = new Power();
            Root root = new Root();

            foreach (var num in someDoubles)
            {
                addition.AddOperand(num);
            }

            var sum = addition.Calculate();

            var avg = division.Calculate(sum, someDoubles.Length);

            Console.WriteLine("avg: " + avg);

            addition = new Addition();

            foreach (var num in someDoubles)
            {
                tmp = substraction.Calculate(num, avg);
                tmp = power.Calculate(tmp);
                addition.AddOperand(tmp);
            }

            tmp = addition.Calculate();
            tmp = division.Calculate(tmp, someDoubles.Length);

            return root.Calculate(tmp);

        }

        static void Main(string[] args)
        {
            double[] numbers = numParse();

            Console.WriteLine("reslult: " + compute(numbers));
        }
    }
}
