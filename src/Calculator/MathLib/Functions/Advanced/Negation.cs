using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    /// <summary>
    /// Represents negation of number
    /// </summary>
    public class Negation : IAdvancedMethod
    {
        /// <summary>
        /// Number negation
        /// </summary>
        /// <param name="operand">value for negation</param>
        /// <returns>-1* value</returns>
        public double Calculate(double operand)
        {
            return operand = -1 * operand;
        }
    }
}
