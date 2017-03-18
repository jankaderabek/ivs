using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLib.Exception;
using MathLib.Functions;
using Xunit;

namespace MathLibraryTests
{
    public class SubstractionTest
    {
        [Fact]
        public void SimpleSubstractionTest()
        {
            Substraction substraction = new Substraction();
            substraction.AddOperand(5);
            substraction.AddOperand(2);

            Assert.Equal(3, substraction.Calculate());
        }

        [Fact]
        public void FloatSubstractionTestt()
        {
            Substraction substraction = new Substraction();
            substraction.AddOperand(5.2);
            substraction.AddOperand(5.5);

            Assert.Equal(-0.3, substraction.Calculate());
        }

        [Fact]
        public void MinimumOperandsTest()
        {
            Substraction substraction = new Substraction();

            Assert.Throws(typeof(OneOrMoreOperandsRequiredExeption), () => substraction.Calculate());
        }

        [Fact]
        public void OneOperandTest()
        {
            Substraction substraction = new Substraction();
            substraction.AddOperand(5);

            Assert.Equal(5, substraction.Calculate());
        }

        [Fact]
        public void MoreOperandsTest()
        {
            Substraction substraction = new Substraction();
            substraction.AddOperand(5);
            substraction.AddOperand(5);
            substraction.AddOperand(5);
            substraction.AddOperand(5);

            Assert.Equal(20, substraction.Calculate());
        }
    }
}
