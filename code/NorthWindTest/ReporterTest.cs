using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWind.Reporting;
using NorthWind.Model;

namespace NorthWindTest
{
    [TestClass]
    public class ReporterTest
    {

        IReporter _reporter = new Reporter(new MemoryRep());

        // Top Orders By Total Price
        [TestMethod]
        public void TopOrdersByTotalPriceSuccessTest()
        {
            var report = _reporter.TopOrdersByTotalPrice(3);
            Assert.IsNotNull(report.Data);
            Assert.IsNull(report.Error);
        }

        [TestMethod]
        public void TopOrdersByTotalPriceCountNegativeTest()
        {
            var report = _reporter.TopOrdersByTotalPrice(-1);
            Assert.IsNull(report.Data);
            Assert.IsNotNull(report.Error);
        }

        [TestMethod]
        public void TopOrdersByTotalPriceCountZeroTest()
        {
            var report = _reporter.TopOrdersByTotalPrice(0);
            Assert.IsNull(report.Data);
            Assert.IsNotNull(report.Error);
        }

        // Top Products By Sale
        [TestMethod]
        public void TopProductsBySaleSuccessTest()
        {
            var report = _reporter.TopProductsBySale(3);
            Assert.IsNotNull(report.Data);
            Assert.IsNull(report.Error);
        }

        [TestMethod]
        public void TopProductsBySaleNegativeTest()
        {
            var report = _reporter.TopProductsBySale(-1);
            Assert.IsNull(report.Data);
            Assert.IsNotNull(report.Error);
        }

        [TestMethod]
        public void TopProductsBySaleZeroTest()
        {
            var report = _reporter.TopProductsBySale(0);
            Assert.IsNull(report.Data);
            Assert.IsNotNull(report.Error);
        }

        // Employee Sale
        [TestMethod]
        public void EmployeeSaleSuccessTest()
        {
            var report = _reporter.EmployeeSale(1);
            Assert.IsNotNull(report.Data);
            Assert.IsNull(report.Error);
        }

        [TestMethod]
        public void EmployeeSaleNegativeTest()
        {
            var report = _reporter.EmployeeSale(-1);
            Assert.IsNull(report.Data);
            Assert.IsNotNull(report.Error);
        }

        [TestMethod]
        public void EmployeeSaleZeroTest()
        {
            var report = _reporter.EmployeeSale(0);
            Assert.IsNull(report.Data);
            Assert.IsNotNull(report.Error);
        }

        [TestMethod]
        public void EmployeeSaleNoneExistingTest()
        {
            var report = _reporter.EmployeeSale(139);
            Assert.IsNull(report.Data);
            Assert.IsNotNull(report.Error);
        }
    }
}
