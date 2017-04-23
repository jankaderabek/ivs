using System.Collections.Generic;
using System.Linq;
using MathLib.Exception;
using MathLib.Interfaces;


namespace MathLib.Functions.Basic
{
    /// <summary>
    /// Represents substraction.
    /// </summary>
    public class Substraction : ISimpleMethod
    {
        private readonly List<double> operands;
        public Substraction()
        {
            operands = new List<double>();
        }
        /// <summary>
        /// Substract all mambers of operands
        /// </summary>
        /// <returns>result of substraction</returns>
        public double Calculate()
        {
            if (!operands.Any())
            {
                throw new OneOrMoreOperandsRequiredExeption();
            }

            double result = operands.First();

            foreach (var operand in operands.Skip(1))
            {
                result -= operand;
            }

            return result;
        }
        /// <summary>
        /// Substract secondOperand from firstOperand
        /// </summary>
        /// <param name="firstOperand">first operand of substraction</param>
        /// <param name="secondOperand">second operand of substraction</param>
        /// <returns>result of substraction</returns>
        public double Calculate(double firstOperand, double secondOperand)
        {
            return firstOperand - secondOperand;
        }
        /// <summary>
        /// Add operand for substraction.
        /// After all operand will be added, you can substract them by calling 
        /// calculate mathod.
        /// </summary>
        /// <param name="operand">value</param>
        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }
    }
}