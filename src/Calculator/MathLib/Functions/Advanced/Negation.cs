using System;
using MathLib.Interfaces;

namespace MathLib.Functions.Advanced
{
    public class Negation : IAdvancedMethod
    {
        public double Calculate(double operand)
        {
            return operand = -1*operand;
        }
    }
}
