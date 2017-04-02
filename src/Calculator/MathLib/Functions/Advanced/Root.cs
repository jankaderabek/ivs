using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    public class Root : IAdvancedMethod
    {
        public double Calculate(double operand)
        {
            return Math.Sqrt(operand);
        }

        public double Calculate(double operand, int exponent)
        {
            return Math.Pow(operand, (1.0 / exponent));
        }
    }
}
