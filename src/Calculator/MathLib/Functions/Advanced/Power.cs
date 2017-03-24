using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    public class Power : IAdvancedMethod
    {
        public double Calculate(double operand)
        {
            return operand * operand;
        }

        public double Calculate(double operand, double exponent)
        {
           return Math.Pow(operand, exponent);
        }
    }
}
