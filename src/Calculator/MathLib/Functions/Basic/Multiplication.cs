using System;
using MathLib.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MathLib.Functions.Basic
{
    public class Multiplication : ISimpleMethod
    {
        private List<double> operands;
        public Multiplication()
        {
            operands = new List<double>();
        }
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

        public double Calculate(double firstOperand, double secondOperand)
        {
            return firstOperand * secondOperand;
        }

        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }
    }
}
