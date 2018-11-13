using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess;
using Services;

namespace Business
{
    public class DataController
    {
        private DBHandler Handler;
        public DataController(string conString)
        {
            Handler = new DBHandler(conString);
        }
        public List<IPersistable> GetEntities(string entity)
        {
            List<IPersistable> li = new List<IPersistable>();
            switch (entity.ToUpper())
            {
                case "RENTEE":
                    li.AddRange(Handler.AllRenters());
                    return li;
                case "ORDER":
                    li.AddRange(Handler.AllOrders());
                    return li;
                case "BIKE":
                    li.AddRange(Handler.AllBikes());
                    return li;
                default:
                    return li;
            }
        }

        public IPersistable GetEntity(string entity, int id)
        {
            switch (entity.ToUpper())
            {
                case "RENTEE":
                    return Handler.AllRenters().Find(p => p.Id == id);
                case "ORDER":
                    return Handler.AllOrders().Find(p => p.Id == id);
                case "BIKE":
                    return Handler.AllBikes().Find(p => p.Id == id);
                default:
                    return null;
            }
        }

        public bool NewEntity(IPersistable entity)
        {
            if (entity is Bike)
            {
                if (Handler.NewBike(entity as Bike)>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (entity is Rentee)
            {
                if (Handler.NewRentee(entity as Rentee)>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (entity is Order)
            {
                if (Handler.NewOrder(entity as Order)>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            throw new Exception("Object is not a valid type (should be impossible)");
        }

        public bool UpdateEntity(IPersistable entity)
        {
            if (entity is Bike)
            {
                if (Handler.UpdateBike(entity as Bike) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (entity is Rentee)
            {
                if (Handler.UpdateRentee(entity as Rentee) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (entity is Order)
            {
                if (Handler.UpdateOrder(entity as Order) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            throw new Exception("Object is not a valid type (should be impossible)");
        }

        public bool DeleteEntity(IPersistable entity)
        {
            if (entity is Bike)
            {
                try
                {
                    if (Handler.DeleteBike(entity as Bike) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {

                    throw new Exception("You cannot delete a bike while an order concerning the bike exsists!");
                }
               
            }
            if (entity is Rentee)
            {
                try
                {
                    if (Handler.DeleteRentee(entity as Rentee) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {

                    throw new Exception("You cannot delete a rentee while an order in their name exsists!");
                }
                
            }
            if (entity is Order)
            {
                if (Handler.DeleteOrder(entity as Order) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            throw new Exception("Object is not a valid type (should be impossible)");
        }
    }
}
