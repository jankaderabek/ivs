using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLib.Exception;
using MathLib.Functions;
using MathLibraryTests;
using Xunit;

namespace Tests
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
