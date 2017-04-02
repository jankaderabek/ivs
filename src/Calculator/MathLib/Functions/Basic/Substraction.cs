using System.Collections.Generic;
using System.Linq;
using MathLib.Exception;
using MathLib.Interfaces;

namespace MathLib.Functions.Basic
{
    public class Substraction : ISimpleMethod
    {
        private readonly List<double> operands;

        public Substraction()
        {
            operands = new List<double>();
        }

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

        public double Calculate(double firstOperand, double secondOperand)
        {
            return firstOperand - secondOperand;
        }

        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }
    }
}