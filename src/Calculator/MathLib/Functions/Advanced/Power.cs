using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    /// <summary>
    /// Provides methods for second or n-th power.
    /// </summary>
    public class Power : IAdvancedMethod
    {
        /// <summary>
        /// calculate second power.
        /// </summary>
        /// <param name="operand">operand</param>
        /// <returns>power of operand</returns>
        public double Calculate(double operand)
        {
            return operand * operand;
        }
        /// <summary>
        /// calculate n-th power of operand
        /// </summary>
        /// <param name="operand">operand</param>
        /// <param name="exponent">exponent of power</param>
        /// <returns></returns>
        public double Calculate(double operand, double exponent)
        {
            return Math.Pow(operand, exponent);
        }
    }
}
