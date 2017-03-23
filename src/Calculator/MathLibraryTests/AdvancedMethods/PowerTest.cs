using MathLib.Exception;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.AdvancedMethods
{
    public class PowerTest
    {
        [Fact]
        public void SimpleCalculateTest()
        {
            Power power = new Power();

            Assert.Equal(25, power.Calculate(5));
        }

        [Fact]
        public void CustomeExponentTest()
        {
            Power power = new Power();

            Assert.Equal(15.625, power.Calculate(2.5, 3));
        }
    }
}
