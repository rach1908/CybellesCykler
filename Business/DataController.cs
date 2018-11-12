﻿using System;
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
    }
}
