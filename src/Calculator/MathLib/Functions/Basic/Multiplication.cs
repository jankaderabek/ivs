using System;
using MathLib.Interfaces;
using System.Collections.Generic;

namespace MathLib.Functions.Basic
{
    public class Multiplication : ISimpleMethod
    {
        private List<double> operands;
        public Multiplication() {
            operands = new List<double>();
        }
        public double Calculate()
        {
            if (operands.Count == 0)
            {
                throw new Exception.OneOrMoreOperandsRequiredExeption();
            }
            if (operands.Count == 1) return operands[0];
                double result = operands[0] * operands[1];
            for (int i = 2; i < operands.Count; i++)
            {
                result = result * operands[i];
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
