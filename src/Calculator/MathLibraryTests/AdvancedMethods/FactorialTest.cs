using MathLib.Exception;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.AdvancedMethods
{
    /// <summary>
    /// Test factorial
    /// </summary>
    public class FactorialTest
    {
        /// <summary>
        /// Test simple factorial
        /// </summary>
        [Fact]
        public void SimpleCalculateTest()
        {
            Factorial factorial = new Factorial();

            Assert.Equal(120, factorial.Calculate(5));
        }
    }
}
