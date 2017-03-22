﻿using MathLib.Exception;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.BasicMethods
{
    public class MultiplicationTest
    {
        [Fact]
        public void SimpleMultiplicationTest()
        {
            Multiplication multiplication = new Multiplication();
            multiplication.AddOperand(5);
            multiplication.AddOperand(5);

            Assert.Equal(25, multiplication.Calculate());
        }

        [Fact]
        public void FloatMultiplicationTest()
        {
            Multiplication multiplication = new Multiplication();
            multiplication.AddOperand(0.5);
            multiplication.AddOperand(0.5);

            Assert.Equal(0.25, multiplication.Calculate());
        }

        [Fact]
        public void MinimumOperandsTest()
        {
            Multiplication multiplication = new Multiplication();

            Assert.Throws(typeof(OneOrMoreOperandsRequiredExeption), () => multiplication.Calculate());
        }

        [Fact]
        public void OneOperandTest()
        {
            Multiplication multiplication = new Multiplication();
            multiplication.AddOperand(5);

            Assert.Equal(5, multiplication.Calculate());
        }

        [Fact]
        public void MoreOperandsTest()
        {
            Multiplication multiplication = new Multiplication();
            multiplication.AddOperand(5);
            multiplication.AddOperand(2);
            multiplication.AddOperand(2);
            multiplication.AddOperand(2);

            Assert.Equal(40, multiplication.Calculate());
        }

        [Fact]
        public void OverloadCalculateTest()
        {
            Multiplication multiplication = new Multiplication();

            Assert.Equal(100, multiplication.Calculate(10, 10));
        }
    }
}