using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using NorthWind.Model;

namespace NorthWindTest2
{
    [TestClass]
    public class UnitTest1
    {
        private Repository _repo = new Repository();

        [TestMethod]
        public void CreateAndGetOrderTest()
        {

            var order = new Order
            {
                ShipName = "test1",
                ShipAddress = "test2",
                ShipCity = "test3",
                ShipRegion = "test4",
                ShipPostalCode = "test5",
                ShipCountry = "test6"
            };
            _repo.CreateOrder(order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry);

            Assert.AreEqual(_repo.Orders.Last(), order);
            //TODO If true delete test order?  === Yes! But not possible in our implementation yet...
        }
    }
}
