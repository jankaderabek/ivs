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
    public class DivisionTest
    {
        [Fact]
        public void SimpleDivisionTest()
        {
            Division division = new Division();
            division.AddOperand(8);
            division.AddOperand(2);

            Assert.Equal(4, division.Calculate());
        }

        [Fact]
        public void FloatDivisionTestt()
        {
            Division division = new Division();
            division.AddOperand(5);
            division.AddOperand(2);

            Assert.Equal(2.5, division.Calculate());
        }

        [Fact]
        public void MinimumOperandsTest()
        {
            Division division = new Division();

            Assert.Throws(typeof(OneOrMoreOperandsRequiredExeption), () => division.Calculate());
        }

        [Fact]
        public void DivideByZeroTest()
        {
            Division division = new Division();
            division.AddOperand(5);
            division.AddOperand(0);

            Assert.Throws(typeof(DivideByZeroException), () => division.Calculate());
        }

        [Fact]
        public void OneOperandTest()
        {
            Division division = new Division();
            division.AddOperand(5);

            Assert.Equal(5, division.Calculate());
        }

        [Fact]
        public void MoreOperandsTest()
        {
            Division division = new Division();
            division.AddOperand(100);
            division.AddOperand(2);
            division.AddOperand(2);
            division.AddOperand(5);

            Assert.Equal(5, division.Calculate());
        }
    }
}
