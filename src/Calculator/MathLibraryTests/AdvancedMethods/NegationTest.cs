using MathLib.Exception;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLib.Functions.Advanced
{
    public class NegationTest
    {
        [Fact]
        public void SimplePositiveNegationTest()
        {
            Negation negation = new Negation();

            Assert.Equal(5, negation.Calculate(-5));
        }

        [Fact]
        public void SimpleNegativeNegationTest()
        {
            Negation negation = new Negation();

            Assert.Equal(-5, negation.Calculate(5));
        }

        [Fact]
        public void FloatNegationTest()
        {
            Negation negation = new Negation();

            Assert.Equal(-5.5, negation.Calculate(5.5));
        }
    }
}
