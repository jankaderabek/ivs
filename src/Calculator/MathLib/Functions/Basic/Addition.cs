using System.Collections.Generic;
using MathLib.Exception;
using MathLib.Interfaces;

namespace MathLib.Functions.Basic
{
    public class Addition : ISimpleMethod
    {
        private readonly List<double> operands;

        public Addition()
        {
            operands = new List<double>();
        }

        public double Calculate()
        {
            if (operands.Count == 0)
            {
                throw new OneOrMoreOperandsRequiredExeption();
            }
            
            return sum(operands);
        }

        public double Calculate(double firstOperand, double secondOperand)
        {
            return firstOperand + secondOperand;
        }

        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }

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