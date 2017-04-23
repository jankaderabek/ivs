using MathLib.Exception;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.BasicMethods
{
    /// <summary>
    /// Test multiplication
    /// </summary>
    public class MultiplicationTest
    {
        /// <summary>
        /// Test simple multiplication
        /// </summary>
        [Fact]
        public void SimpleMultiplicationTest()
        {
            Multiplication multiplication = new Multiplication();
            multiplication.AddOperand(5);
            multiplication.AddOperand(5);

            Assert.Equal(25, multiplication.Calculate());
        }

        /// <summary>
        /// Test multipliucation in float
        /// </summary>
        [Fact]
        public void FloatMultiplicationTest()
        {
            Multiplication multiplication = new Multiplication();
            multiplication.AddOperand(0.5);
            multiplication.AddOperand(0.5);

            Assert.Equal(0.25, multiplication.Calculate());
        }

        /// <summary>
        /// Test minimum operands
        /// </summary>
        [Fact]
        public void MinimumOperandsTest()
        {
            Multiplication multiplication = new Multiplication();

            Assert.Throws(typeof(OneOrMoreOperandsRequiredExeption), () => multiplication.Calculate());
        }

        /// <summary>
        /// Test one operand
        /// </summary>
        [Fact]
        public void OneOperandTest()
        {
            Multiplication multiplication = new Multiplication();
            multiplication.AddOperand(5);

            Assert.Equal(5, multiplication.Calculate());
        }

        /// <summary>
        /// Test with many operands
        /// </summary>
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

        /// <summary>
        /// Test Calculate method with two operands
        /// </summary>
        [Fact]
        public void OverloadCalculateTest()
        {
            Multiplication multiplication = new Multiplication();

            Assert.Equal(100, multiplication.Calculate(10, 10));
        }
    }
}
