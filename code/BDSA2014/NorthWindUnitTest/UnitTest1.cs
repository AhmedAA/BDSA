using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWind.Model;

namespace NorthWindUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Repository _repo = new Repository();

        [TestMethod]
        public void CreateAndGetOrderTest()
        {
            using (var context = new NorthWind.Model.NorthWindContext())
            {
                var newestOrder = (from o in context.Orders
                                   orderby o.Id descending
                                   select o).First();

                var order = new Order
                {
                    OrderDate = DateTime.Today,
                    Id = newestOrder.Id+1,
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
}
