using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib.Interfaces
{
    public interface ISimpleMethod
    {
        double Calculate();

        double Calculate(double firstOperand, double secondOperand);

        void AddOperand(double operand);
    }
}
