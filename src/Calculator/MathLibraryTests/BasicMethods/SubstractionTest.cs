using MathLib.Exception;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.BasicMethods
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
        public void FloatSubstractionTest()
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

        [Fact]
        public void OverloadCalculateTest()
        {
            Substraction substraction = new Substraction();

            Assert.Equal(10, substraction.Calculate(20, 10));
        }
    }
}
