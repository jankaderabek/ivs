using MathLib.Exception;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.AdvancedMethods
{
    /// <summary>
    /// Test power
    /// </summary>
    public class PowerTest
    {
        /// <summary>
        /// Test simple power
        /// </summary>
        [Fact]
        public void SimpleCalculateTest()
        {
            Power power = new Power();

            Assert.Equal(25, power.Calculate(5));
        }

        /// <summary>
        /// Test custom exponent
        /// </summary>
        [Fact]
        public void CustomeExponentTest()
        {
            Power power = new Power();

            Assert.Equal(15.625, power.Calculate(2.5, 3));
        }
    }
}
