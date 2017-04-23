using MathLib.Exception;
using MathLib.Functions.Advanced;
using MathLib.Functions.Basic;
using Xunit;

namespace MathLibraryTests.AdvancedMethods
{
    /// <summary>
    /// Test root
    /// </summary>
    public class RootTest
    {
        /// <summary>
        /// Test simple root
        /// </summary>
        [Fact]
        public void SimpleCalculateTest()
        {
            Root root = new Root();

            Assert.Equal(5, root.Calculate(25));
        }

        /// <summary>
        /// Test root with custom exponent
        /// </summary>
        [Fact]
        public void CustomeExponentTest()
        {
            Root root = new Root();

            Assert.Equal(2, root.Calculate(8, 3));
        }

        /// <summary>
        /// Test float
        /// </summary>
        [Fact]
        public void FloatTest()
        {
            Root root = new Root();
            var result = root.Calculate(14);

            Assert.InRange(result, 3.7, 3.8);
        }
    }
}
