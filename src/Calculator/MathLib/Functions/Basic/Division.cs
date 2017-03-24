using System;
using MathLib.Interfaces;
using System.Collections.Generic;

namespace MathLib.Functions.Basic
{
    public class Division : ISimpleMethod
    {
        private List<double> operands;

        public Division(){
            operands = new List<double>();
        }
        public double Calculate()
        {
            if (operands.Count == 0 )
            {
                throw new Exception.OneOrMoreOperandsRequiredExeption();
            }
            if (operands[0].Equals(0)) return 0;
            if (operands.Count == 1) return operands[0];
            if (operands[1].Equals(0)){
                throw new DivideByZeroException();
            }
            double result = operands[0]/operands[1];
            for (int i = 2; i < operands.Count; i++)
            {
                if (operands[i].Equals(0)) {
                    throw new DivideByZeroException();
                }
                result = result / operands[i];
            }
            return result;
        }

        public double Calculate(double firstOperand, double secondOperand)
        {
            return firstOperand / secondOperand;
        }

        public void AddOperand(double operand)
        {
            operands.Add(operand);
        }
    }
}
