using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommonDB
    {
        readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCyklerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public CommonDB(string conString)
        {
            connectionString = conString;
        }

        //Opgaven siger at denne metode skal returnere en int, men UML-diagrammet siger det skal være en Bool?
        //Jeg vælger int da et <0 check i den metode der kalder kan fylde samme rolle som bool.
        protected int ExecuteNonQuery(string query)
        {
            int AffectedRows = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand(query, con))
            {
                con.Open();
                AffectedRows = com.ExecuteNonQuery();
            }

            return AffectedRows;

        }

        protected DataSet ExecuteQuery(string query)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.Fill(ds);

            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                throw new Exception("No results");
            }
            return ds;
        }
    }
}
