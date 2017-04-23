using MathLib.Exception;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLib.Functions.Advanced
{
    /// <summary>
    /// test negation
    /// </summary>
    public class NegationTest
    {
        /// <summary>
        /// Test simple positive negation
        /// </summary>
        [Fact]
        public void SimplePositiveNegationTest()
        {
            Negation negation = new Negation();

            Assert.Equal(5, negation.Calculate(-5));
        }

        /// <summary>
        /// Test simple negative negation
        /// </summary>
        [Fact]
        public void SimpleNegativeNegationTest()
        {
            Negation negation = new Negation();

            Assert.Equal(-5, negation.Calculate(5));
        }

        /// <summary>
        /// Test float negation
        /// </summary>
        [Fact]
        public void FloatNegationTest()
        {
            Negation negation = new Negation();

            Assert.Equal(-5.5, negation.Calculate(5.5));
        }
    }
}
