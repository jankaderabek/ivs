using MathLib.Exception;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.AdvancedMethods
{
    public class LogairthmTest
    {
        [Fact]
        public void SimpleCalculateTest()
        {
            Logarithm logarithm = new Logarithm();

            Assert.Equal(1, logarithm.Calculate(10));
        }

        [Fact]
        public void FloatTest()
        {
            Logarithm logarithm = new Logarithm();
            var result = logarithm.Calculate(9);

            Assert.InRange(result, 0.95, 0.96);
        }

        [Fact]
        public void InvalidLogarithmTest()
        {
            Logarithm logarithm = new Logarithm();

            Assert.Throws(typeof(InvalidArgumentOfLogarithm), () => logarithm.Calculate(0));
        }
    }
}
