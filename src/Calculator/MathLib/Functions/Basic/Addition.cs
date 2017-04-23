using System.Collections.Generic;
using MathLib.Exception;
using MathLib.Interfaces;

namespace MathLib.Functions.Basic
{
    /// <summary>
    /// Represents addition
    /// </summary>
    public class Addition : ISimpleMethod
    {
        private readonly List<double> operands;

        public Addition()
        {
            operands = new List<double>();
        }
        ///<summary>
        /// sum all mambers of operands
        ///</summary>
        /// <returns>result of sumation</returns>
        public double Calculate()
        {
            if (operands.Count == 0)
            {
                throw new OneOrMoreOperandsRequiredExeption();
            }
            
            return sum(operands);
        }
        /// <summary>
        /// Add first and second operand.
        /// </summary>
        /// <param name="firstOperand">first operand of addition</param>
        /// <param name="secondOperand">second operand of addition</param>
        /// <returns>result of addition</returns>
        public double Calculate(double firstOperand, double secondOperand)
        {
            return firstOperand + secondOperand;
        }
        /// <summary>
        /// Add operand for addition.
        /// After all operand will be added, you can sum them by calling 
        /// calculate mathod.
        /// </summary>
        /// <param name="operand">value</param>
        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }
        /// <summary>
        /// sum all mambers of operands
        /// </summary>
        /// <param name="operands">values for addition</param>
        /// <returns></returns>
        private double sum(List<double> operands)
        {
            double result = 0;

            foreach (var operand in operands)
            {
                result += operand;
            }
            

            return result;
        }
    }
}