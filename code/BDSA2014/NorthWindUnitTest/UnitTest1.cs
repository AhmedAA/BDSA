using System;
using System.Linq;
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
            using (var repo = new NorthWindContext())
            {

                var order = new Order
                {
                    OrderDate = DateTime.Today,
                    Id = _repo.Orders.LastOrDefault().Id++,
                    ShipName = "test1",
                    ShipAddress = "test2",
                    ShipCity = "test3",
                    ShipRegion = "test4",
                    ShipPostalCode = "test5",
                    ShipCountry = "test6"
                };
                _repo.Orders.Add(order);
                _repo.SaveChanges();

                Assert.AreEqual(_repo.Orders.Last(), order);
                //TODO If true delete test order? 
            }
        }
        //Hvad er mere værd at teste? 
    }
}
