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

        void AddOperand(double operand);
    }
}
