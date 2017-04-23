using MathLib.Exception;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.BasicMethods
{
    /// <summary>
    /// Test addition
    /// </summary>
    public class AdditionTest
    {
        /// <summary>
        /// Test addition with two operands
        /// </summary>
        [Fact]
        public void SimpleAdditionTest()
        {
            Addition addition = new Addition();
            addition.AddOperand(5);
            addition.AddOperand(5);

            Assert.Equal(10, addition.Calculate());
        }

        /// <summary>
        /// Test addition in float
        /// </summary>
        [Fact]
        public void FloatAdditionTest()
        {
            Addition addition = new Addition();
            addition.AddOperand(5.2);
            addition.AddOperand(5.2);

            Assert.Equal(10.4, addition.Calculate());
        }

        /// <summary>
        /// Test minimum operands
        /// </summary>
        [Fact]
        public void MinimumOperandsTest()
        {
            Addition addition = new Addition();

            Assert.Throws(typeof(OneOrMoreOperandsRequiredExeption), () => addition.Calculate());
        }

        /// <summary>
        /// Test with one operand
        /// </summary>
        [Fact]
        public void OneOperandTest()
        {
            Addition addition = new Addition();
            addition.AddOperand(5);

            Assert.Equal(5, addition.Calculate());
        }

        /// <summary>
        /// Test with many operands
        /// </summary>
        [Fact]
        public void MoreOperandsTest()
        {
            Addition addition = new Addition();
            addition.AddOperand(5);
            addition.AddOperand(5);
            addition.AddOperand(5);
            addition.AddOperand(5);

            Assert.Equal(20, addition.Calculate());
        }

        /// <summary>
        /// Test Calculate method with two operands
        /// </summary>
        [Fact]
        public void OverloadCalculateTest()
        {
            Addition addition = new Addition();

            Assert.Equal(20, addition.Calculate(10, 10));
        }
    }
}
