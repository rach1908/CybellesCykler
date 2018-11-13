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
        public List<Rentee> AllRenters()
        {
            List<Rentee> li = new List<Rentee>();
            DataSet ds = new DataSet();
            ds = ExecuteQuery("select * from Renters");
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                //Check to make sure DateTime is not null
                DateTime dt;     
                if (r.IsNull("RegisterDate"))
                {
                    dt = DateTime.MinValue;
                }
                else
                {
                    dt = (DateTime)r["RegisterDate"];
                }
                
                li.Add(new Rentee((int)r["ID"], dt, (string)r["PhoneNumber"], (string)r["PhysAddress"], (string)r["Name"]));
            }
            return li;
        }

        public List<Bike> AllBikes()
        {
            List<Bike> li = new List<Bike>();
            DataSet ds = new DataSet();
            ds = ExecuteQuery("select * from Bikes");
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                li.Add(new Bike((int)r["ID"], (string)r["BikeDescription"], (decimal)r["PricePerDay"]));
            }
            return li;
        }

        public List<Order> AllOrders()
        {
            List<Order> li = new List<Order>();
            List<Rentee> renters = AllRenters();
            List<Bike> bikes = AllBikes();
            DataSet ds = new DataSet();
            ds = ExecuteQuery("select * from Orders");
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                //Check to make sure DateTime is not null
                DateTime dt1;
                DateTime dt2;
                if (r.IsNull("DeliveryDate"))
                {
                    dt1 = DateTime.MinValue;
                }
                else
                {
                    dt1 = (DateTime)r["DeliveryDate"];
                }
                if (r.IsNull("OrderDate"))
                {
                    dt2 = DateTime.MinValue;
                }
                else
                {
                    dt2 = (DateTime)r["OrderDate"];
                }
                Rentee ren = renters.Find(p => p.Id == (int)r["RenteeID"]);
                Bike b = bikes.Find(p => p.Id == (int)r["BikeID"]);
                li.Add(new Order((int)r["OrderID"], dt1, dt2, ren, b));
            }
            return li;
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
            //Check to make sure DateTime is not null
            DateTime dt;
            if (r.IsNull("RegisterDate"))
            {
                dt = DateTime.MinValue;
            }
            else
            {
                dt = (DateTime)r["RegisterDate"];
            }
            Rentee ren = new Rentee((int)r["ID"], dt, (string)r["PhoneNumber"], (string)r["PhysAddress"], (string)r["Name"]);
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
            //Check to make sure DateTime is not null
            DateTime dt1;
            DateTime dt2;
            if (r.IsNull("DeliveryDate"))
            {
                dt1 = DateTime.MinValue;
            }
            else
            {
                dt1 = (DateTime)r["DeliveryDate"];
            }
            if (r.IsNull("OrderDate"))
            {
                dt2 = DateTime.MinValue;
            }
            else
            {
                dt2 = (DateTime)r["OrderDate"];
            }
            Bike b = GetBike((int)r["BikeID"]);
            Rentee ren = GetRentee((int)r["RenteeID"]);
            Order o = new Order((int)r["OrderID"], dt1, dt2, ren, b);
            return o;
        }

        public int NewRentee(Rentee rentee)
        {
            return ExecuteNonQuery("insert into Renters (Name, PhoneNumber, PhysAddress, RegisterDate) " +
                $"values ('{rentee.Name}', '{rentee.PhoneNumber}', '{rentee.Address}', '{rentee.RegisterDate}')");
        }

        public int NewBike(Bike bike)
        {
            return ExecuteNonQuery("insert into Bikes (BikeDescription, PricePerDay) " +
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
                $"OrderDate = '{order.RentDate}, RenteeID = '{order.Rentee.Id}' " +
                $"Where ID = {order.Id}");
        }

        public int DeleteRentee(Rentee rentee)
        {
            List<Order> orders = AllOrders();
            List<Rentee> renters = new List<Rentee>();
            foreach (Order o in orders)
            {
                renters.Add(o.Rentee);
            }
            if (renters.Contains(rentee))
            {
                throw new Exception("You cannot delete a rentee while an order in their name exsists!");
            }
            else
            {
                return ExecuteNonQuery($"delete from renters where ID='{rentee.Id}';");
            }
        }

        public int DeleteBike(Bike bike)
        {
            List<Order> orders = AllOrders();
            List<Bike> bikes = new List<Bike>();
            foreach (Order o in orders)
            {
                bikes.Add(o.Bike);
            }
            if (bikes.Contains(bike))
            {
                throw new Exception("You cannot delete a bike while an order concerning the bike exsists!");
            }
            else
            {
                return ExecuteNonQuery($"delete from bikes where ID='{bike.Id}';");
            }
        }

        public int DeleteOrder(Order order)
        {
            int i = ExecuteNonQuery($"delete from orders where OrderID='{order.Id}';");
            return i;
        }
    }
}
