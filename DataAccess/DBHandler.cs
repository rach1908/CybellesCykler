using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    class DBHandler : CommonDB
    {
        public DBHandler(string conString) : base(conString)
        {

        }

        public Rentee GetRentee(int id)
        {
            DataSet ds = ExecuteQuery("Select top 1 from Renters where id = " + id);
            DataRow r = ds.Tables[0].Rows[0];
            Rentee ren = new Rentee((int)r["ID"], (DateTime)r["RegisterDate"], (string)r["PhoneNumber"], (string)r["PhysAddress"], (string)r["Name"]);
            return ren;
        }
    }
}
