using System;
using MathLib.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MathLib.Functions.Basic
{
    public class Division : ISimpleMethod
    {
        private List<double> operands;

        public Division()
        {
            operands = new List<double>();
        }
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

        public double Calculate(double firstOperand, double secondOperand)
        {
            if (isDoubleZero(secondOperand))
            {
                throw new DivideByZeroException();
            }

            return firstOperand / secondOperand;
        }

        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }

        private bool isDoubleZero(double num)
        {
            return (Math.Abs(num) < double.Epsilon);
        }
    }
}
