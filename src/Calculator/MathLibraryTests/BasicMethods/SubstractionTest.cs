using MathLib.Exception;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.BasicMethods
{
    /// <summary>
    /// Test substraction
    /// </summary>
    public class SubstractionTest
    {
        /// <summary>
        /// Test simple substraction
        /// </summary>
        [Fact]
        public void SimpleSubstractionTest()
        {
            Substraction substraction = new Substraction();
            substraction.AddOperand(5);
            substraction.AddOperand(2);

            Assert.Equal(3, substraction.Calculate());
        }

        /// <summary>
        /// Test float substraction
        /// </summary>
        [Fact]
        public void FloatSubstractionTest()
        {
            Substraction substraction = new Substraction();
            substraction.AddOperand(5.2);
            substraction.AddOperand(5.5);

            Assert.Equal(-0.3, substraction.Calculate(), 10);

        }

        /// <summary>
        /// Test minimum operands
        /// </summary>
        [Fact]
        public void MinimumOperandsTest()
        {
            Substraction substraction = new Substraction();

            Assert.Throws(typeof(OneOrMoreOperandsRequiredExeption), () => substraction.Calculate());
        }

        /// <summary>
        /// Test one operands
        /// </summary>
        [Fact]
        public void OneOperandTest()
        {
            Substraction substraction = new Substraction();
            substraction.AddOperand(5);

            Assert.Equal(5, substraction.Calculate());
        }

        /// <summary>
        /// Test many operands
        /// </summary>
        [Fact]
        public void MoreOperandsTest()
        {
            Substraction substraction = new Substraction();
            substraction.AddOperand(5);
            substraction.AddOperand(5);
            substraction.AddOperand(5);
            substraction.AddOperand(5);

            Assert.Equal(-10, substraction.Calculate());
        }

        /// <summary>
        /// Test Calculate method with two operands
        /// </summary>
        [Fact]
        public void OverloadCalculateTest()
        {
            Substraction substraction = new Substraction();

            Assert.Equal(10, substraction.Calculate(20, 10));
        }
    }
}
