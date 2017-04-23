using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    /// <summary>
    /// Represents logarithm operation.
    /// </summary>
    public class Logarithm : IAdvancedMethod
    {
        /// <summary>
        /// Calculate logarithm value with base equal number 10
        /// </summary>
        public double Calculate(double operand)
        {
            if (operand <= 0)
            {
                throw new Exception.InvalidArgumentOfLogarithm();
            }

            return Math.Log(operand, 10);
        }
    }
}
