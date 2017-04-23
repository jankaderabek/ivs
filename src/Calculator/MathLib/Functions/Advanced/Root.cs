using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    /// <summary>
    /// Provides methods for square or general root.
    /// </summary>
    public class Root : IAdvancedMethod
    {
        /// <summary>
        /// Calculate square root of specified number.
        /// </summary>
        /// <param name="operand"></param>
        /// <returns>square root of specified number</returns>
        public double Calculate(double operand)
        {
            return Math.Sqrt(operand);
        }
        /// <summary>
        /// Calculate n-th root of specified number.
        /// </summary>
        /// <param name="operand">root of this value will be computed</param>
        /// <param name="exponent">n</param>
        /// <returns></returns>
        public double Calculate(double operand, int exponent)
        {
            return Math.Pow(operand, (1.0 / exponent));
        }
    }
}
