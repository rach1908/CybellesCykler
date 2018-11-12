using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public class DBHandler : CommonDB
    {
        public DBHandler(string conString) : base(conString)
        {
        }

        public Rentee GetRentee(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ExecuteQuery("Select top 1 * from Renters where id = " + id);
            }
            catch (Exception)
            {
                throw ;
            }
            DataRow r = ds.Tables[0].Rows[0];
            Rentee ren = new Rentee((int)r["ID"], (DateTime)r["RegisterDate"], (string)r["PhoneNumber"], (string)r["PhysAddress"], (string)r["Name"]);
            return ren;
        }

        public Bike GetBike(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ExecuteQuery("Select top 1 * from Bikes where id = " + id);
            }
            catch (Exception)
            {
                throw;
            }
            DataRow r = ds.Tables[0].Rows[0];
            Bike b = new Bike((int)r["ID"], (string)r[";BikeDescription"], (decimal)r["PricePerDay"]);
            return b;
        }

        public Order GetOrder(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ExecuteQuery("Select top 1 * from Orders where id = " + id);
            }
            catch (Exception)
            {
                throw;
            }

            DataRow r = ds.Tables[0].Rows[0];
            Bike b = GetBike((int)r["BikeID"]);
            Rentee ren = GetRentee((int)r["RenteeID"]);
            Order o = new Order((int)r["OrderID"], (DateTime)r["DeliveryDate"], (DateTime)r["RentDate"], ren, b);
            return o;
        }

        public int NewRentee(Rentee rentee)
        {
            return ExecuteNonQuery("insert into Renters (Name, PhoneNumber, PhysAddress, RegisterDate) " +
                $"values ('{rentee.Name}', '{rentee.PhoneNumber}', '{rentee.Address}', '{rentee.RegisterDate}')");
        }

        public int NewBike(Bike bike)
        {
            return ExecuteNonQuery("insert into Renters (BikeDescription, PricePerDay) " +
                $"values ('{bike.BikeDescription}', '{bike.PricePerDay}')");
        }

        public int NewOrder(Order order)
        {
            return ExecuteNonQuery("insert into Orders (BikeID, DeliveryDate, OrderDate, RenteeID) " +
                $"values ('{order.Bike.Id}', '{order.DeliveryDate}', '{order.RentDate}', '{order.Rentee.Id}')");
        }

        public int UpdateRentee(Rentee rentee)
        {
            return ExecuteNonQuery($"update Renters set Name = '{rentee.Name}', PhoneNumber = '{rentee.PhoneNumber}', " +
                $"PhysAddress = '{rentee.Address}, RegisterDate = '{rentee.RegisterDate}' " +
                $"Where ID = {rentee.Id}");
        }

        public int UpdateBike(Bike bike)
        {
            return ExecuteNonQuery($"update Bikes set BikeDescription = '{bike.BikeDescription}', PricePerDay = '{bike.PricePerDay}' " +
                $"Where ID = {bike.Id}");
        }

        public int UpdateOrder(Order order)
        {
            return ExecuteNonQuery($"update Orders set BikeID = '{order.Bike.Id}', DeliveryDate = '{order.DeliveryDate}', " +
                $"OrderDate = '{order.RentDate}, RenteeID = '{order.Rentee.Id}'" +
                $"Where ID = {order.Id}");
        }
    }
}
