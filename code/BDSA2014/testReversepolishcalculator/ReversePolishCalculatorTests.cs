using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using reversepolishcalculator;

namespace testReversepolishcalculator
{
    [TestClass]
    public class ReversePolishCalculatorTests
    {
        
        [TestMethod]
        public void TestSeveral()
        {
            var rpc = new ReversePolishCalculatorV2("3 2 + 7 * 5 / 3 -");
            Assert.AreEqual(4.0, rpc.Result());
        }

        [TestMethod]
        public void TestOperatorPow()
        {
            var rpc = new ReversePolishCalculatorV2("10 2 ^");
            Assert.AreEqual(100.0, rpc.Result());
        }

        [TestMethod]
        public void TestOperatorAdd()
        {
            var rpc = new ReversePolishCalculatorV2("7 7 +");
            Assert.AreEqual(14, rpc.Result());
        }

        [TestMethod]
        public void TestOperatorSub()
        {
            var rpc = new ReversePolishCalculatorV2("7 8 -");

            Assert.AreEqual(-1, rpc.Result());
        }

        [TestMethod]
        public void TestOperatorDivide()
        {
            var rpc = new ReversePolishCalculatorV2("9 4 /");
            Assert.AreEqual(2.25, rpc.Result());
        }

        [TestMethod]
        public void TestOperatorMultiply()
        {
            var rpc = new ReversePolishCalculatorV2("7 7 *");
            Assert.AreEqual(49, rpc.Result());
        }

        [TestMethod]
        public void TestDivideByZeroPos()
        {
            var rpc = new ReversePolishCalculatorV2("1 0 /");
            Assert.AreEqual(Double.PositiveInfinity, rpc.Result());
        }

        [TestMethod]
        public void TestDivideByZeroNeg()
        {
            var rpc = new ReversePolishCalculatorV2("-1 0 /");
            Assert.AreEqual(Double.NegativeInfinity, rpc.Result());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestNotEnoughValues()
        {
            new ReversePolishCalculatorV2("8 +");
        }

        [TestMethod]
        public void TestAbs()
        {
            var rpc = new ReversePolishCalculatorV2("-1 abs");
            Assert.AreEqual(1, rpc.Result());
        }

        [TestMethod]
        public void TestSquareRootPos()
        {
            var rpc = new ReversePolishCalculatorV2("9 sqrt");
            Assert.AreEqual(3, rpc.Result());
        }

        [TestMethod]
        public void TestSquareRootNeg()
        {
            var rpc = new ReversePolishCalculatorV2("-4 sqrt");
            Assert.AreEqual(Double.NaN, rpc.Result());
        }
    }
}
