using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    /// <summary>
    /// Represents factorial operation
    /// </summary>
    public class Factorial : IAdvancedMethod
    {
        /// <summary>
        /// Calculate factorial by recursive method.
        /// Max value for calculation is 69 to prevent stack od double overflow.
        /// </summary>
        /// <param name="operand">input value</param>
        /// <returns>factorial of input value</returns>
        public double Calculate(double operand)
        {
            if (operand.Equals(0))
            {
                return 1;
            }
            if (operand > 69)
            {
                return Double.NaN;
            }

            return operand * Calculate(operand - 1);
        }
    }
}
