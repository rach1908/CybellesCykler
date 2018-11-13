using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace EntitiesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetPrice()
        {
            //a date range of 10 days.
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(10);
            //New renter, and a bike with a price of 300/day.
            Rentee r = new Rentee(start, "123", "123", "test");
            Bike b = new Bike("New Bike", 300);
            //Order for 10 days, at 300/day. Expected result = 3000
            decimal ExpectedResult = 3000;
            Order o = new Order(end, start, r, b);

            Assert.AreEqual(ExpectedResult, o.GetPrice());
        }
    }
}
