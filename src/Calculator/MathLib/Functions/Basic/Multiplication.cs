using MathLib.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MathLib.Functions.Basic
{
    public class Multiplication : ISimpleMethod
    {
        private List<double> operands;
        /// <summary>
        /// Represents multiplication
        /// </summary>
        public Multiplication()
        {
            operands = new List<double>();
        }
        /// <summary>
        /// multiply all mambers of operands
        /// </summary>
        /// <returns>result of multipication</returns>
        public double Calculate()
        {
            if (!operands.Any())
            {
                throw new Exception.OneOrMoreOperandsRequiredExeption();
            }

            double result = operands.First();

            foreach (var operand in operands.Skip(1))
            {
                result *= operand;
            }

            return result;
        }
        /// <summary>
        /// Multiplay first and second operand.
        /// </summary>
        /// <param name="firstOperand">first operand of multiplication</param>
        /// <param name="secondOperand">second operand of multiplication</param>
        /// <returns>result of multipication</returns>
        public double Calculate(double firstOperand, double secondOperand)
        {
            return firstOperand * secondOperand;
        }
        /// <summary>
        /// Add operand for multipication.
        /// After all operand will be added, you can multiply them by calling 
        /// calculate mathod.
        /// </summary>
        /// <param name="operand">value</param>
        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }
    }
}
