using MathLib.Exception;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.BasicMethods
{
    public class AdditionTest
    {
        [Fact]
        public void SimpleAdditionTest()
        {
            Addition addition = new Addition();
            addition.AddOperand(5);
            addition.AddOperand(5);

            Assert.Equal(10, addition.Calculate());
        }

        [Fact]
        public void FloatAdditionTestt()
        {
            Addition addition = new Addition();
            addition.AddOperand(5.2);
            addition.AddOperand(5.2);

            Assert.Equal(10.4, addition.Calculate());
        }

        [Fact]
        public void MinimumOperandsTest()
        {
            Addition addition = new Addition();

            Assert.Throws(typeof(OneOrMoreOperandsRequiredExeption), () => addition.Calculate());
        }

        [Fact]
        public void OneOperandTest()
        {
            Addition addition = new Addition();
            addition.AddOperand(5);

            Assert.Equal(5, addition.Calculate());
        }

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
    }
}
