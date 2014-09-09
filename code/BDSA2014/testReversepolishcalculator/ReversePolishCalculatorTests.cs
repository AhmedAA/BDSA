using Microsoft.VisualStudio.TestTools.UnitTesting;
using reversepolishcalculator;

namespace testReversepolishcalculator
{
    [TestClass]
    public class ReversePolishCalculatorTests
    {
        [TestMethod]
        public void ReturnZeroOnEmptyOrNull()
        {
            Assert.AreEqual(ReversePolishCalculator.Calculate(""), "0");
            Assert.AreEqual(ReversePolishCalculator.Calculate(null), "0");
        }

        [TestMethod]
        public void TestAllOperators()
        {
            Assert.AreEqual(ReversePolishCalculator.Calculate("5 5 +"), "10");
            Assert.AreEqual(ReversePolishCalculator.Calculate("5 5 -"), "0");
            Assert.AreEqual(ReversePolishCalculator.Calculate("5 5 *"), "25");
            Assert.AreEqual(ReversePolishCalculator.Calculate("5 5 /"), "1");
        }

        [TestMethod]
        public void ComplexExpressions()
        {
            Assert.AreEqual(ReversePolishCalculator.Calculate("5 5 + 2 / 4 * 3 3 + +"), "26");
            Assert.AreEqual(ReversePolishCalculator.Calculate("5 30 70 + 20 / *"), "25");
            Assert.AreEqual(ReversePolishCalculator.Calculate("20 50 60 + 40 - 30 - *"), "800");
        }

        [TestMethod]
        public void GivenEquation()
        {
            Assert.AreEqual(ReversePolishCalculator.Calculate("5 1 2 + 4 * + 3 -"), "14");
        }
    }
}
