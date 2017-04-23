using System;
using MathLib.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MathLib.Functions.Basic
{
    /// <summary>
    /// Represents division
    /// </summary>
    public class Division : ISimpleMethod
    {
        private List<double> operands;

        public Division()
        {
            operands = new List<double>();
        }
        /// <summary>
        /// divide all mambers of operands
        /// </summary>
        /// <returns>result of division</returns>
        public double Calculate()
        {
            if (!operands.Any())
            {
                throw new Exception.OneOrMoreOperandsRequiredExeption();
            }

            if (operands.Count == 1)
            {
                return operands.First();
            }

            double result = operands.First();

            foreach (double operand in operands.Skip(1))
            {
                if (isDoubleZero(operand))
                {
                    throw new DivideByZeroException();
                }

                result = result / operand;
            }

            return result;
        }
        /// <summary>
        /// Divide first operad by second operand.
        /// </summary>
        /// <param name="firstOperand">first operand of division</param>
        /// <param name="secondOperand">second operand of division</param>
        /// <returns>result of division</returns>
        public double Calculate(double firstOperand, double secondOperand)
        {
            if (isDoubleZero(secondOperand))
            {
                throw new DivideByZeroException();
            }

            return firstOperand / secondOperand;
        }
        /// <summary>
        /// Add operand for division.
        /// After all operand will be added, you can divide them by calling 
        /// calculate mathod.
        /// </summary>
        /// <param name="operand">value</param>
        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }
        /// <summary>
        /// Determinate if given number is zero.
        /// </summary>
        /// <param name="num">value</param>
        /// <returns></returns>
        private bool isDoubleZero(double num)
        {
            return (Math.Abs(num) < double.Epsilon);
        }
    }
}
