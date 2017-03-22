using System;
using MathLib.Exception;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.BasicMethods
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
        public void FloatDivisionTest()
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

        [Fact]
        public void OverloadCalculateTest()
        {
            Division division = new Division();

            Assert.Equal(2, division.Calculate(40, 20));
        }
    }
}
