using System;
using MathLib.Interfaces;
using System.Collections.Generic;

namespace MathLib.Functions.Basic
{
    public class Addition : ISimpleMethod
    {
        private List<double> operands;

        public Addition() {
            operands = new List<double>();
        }

        public double Calculate()
        {
            if (operands.Count == 0) {
                throw new Exception.OneOrMoreOperandsRequiredExeption();
            }
            double result = 0;
            foreach (double o in operands)
            {
                result = o + result;
            }
            return result;
        }

        public double Calculate(double firstOperand, double secondOperand)
        {
            return firstOperand + secondOperand;
        }

        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }
    }
}
