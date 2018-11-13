using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Entities;

namespace DataAccessTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SQLDataBaseConnectionTest()
        {
            //Bike with ID 1 in the Database has a price per day of 150
            decimal price = 150;

            DBHandler db = new DBHandler(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCyklerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            Bike b = db.GetBike(1);

            Assert.AreEqual(price, b.PricePerDay);
        }
    }
}
