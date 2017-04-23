using System;
using System.Linq;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;

namespace StandardDeviation
{
    /// <summary>
    /// This class contains two static method for load numbers from stdin 
    /// and compute therir standard deviation.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Parse numbers divided by whitespaces from stdin.
        /// </summary> 
        static double[] NumParse()
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
                Environment.Exit(-1);
            }

            return null;
        }
        /// <summary>
        /// Compute standard deviation of field of double numbers.
        /// </summary>
        /// <param name="values">source values for compute</param>
        /// <returns></returns>
        static double Compute(double[] values)
        {
            double tmp;

            Addition addition = new Addition();
            Division division = new Division();
            Substraction substraction = new Substraction();
            Power power = new Power();
            Root root = new Root();
            
            //sum of all values
            foreach (var num in values)
            {
                addition.AddOperand(num);
            }

            var sum = addition.Calculate();

            // calculate average value
            var avg = division.Calculate(sum, values.Length);

            addition = new Addition();

            // substract avg value from all input values
            // power the inter-result
            // and sum all results
            foreach (var num in values)
            {
                tmp = substraction.Calculate(num, avg);
                tmp = power.Calculate(tmp);
                addition.AddOperand(tmp);
            }

            tmp = addition.Calculate();
            //divide sum of resulst by their count
            tmp = division.Calculate(tmp, values.Length);


            return root.Calculate(tmp);

        }

        static void Main()
        {
            double[] numbers = NumParse();

            Console.WriteLine("reslult: " + Compute(numbers));
        }
    }
}
