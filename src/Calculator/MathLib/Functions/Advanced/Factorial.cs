using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    public class Factorial : IAdvancedMethod
    {
        public double Calculate(double operand)
        {
            if (operand.Equals(0))
            {
                return 1;
            }

            return operand * Calculate(operand - 1);
        }
    }
}
