using MathLib.Exception;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.AdvancedMethods
{
    public class FactorialTest
    {
        [Fact]
        public void SimpleCalculateTest()
        {
            Factorial factorial = new Factorial();

            Assert.Equal(120, factorial.Calculate(5));
        }
    }
}
