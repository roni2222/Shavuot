using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Configuration;

namespace Shavuot
{
    public class Connect
    {
        public static string GetConnectionString()
        {
            string strcon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            return strcon;
        }

        public static OleDbConnection Connection()
        {
            string connectionString = Connect.GetConnectionString();
            OleDbConnection myConnection = new OleDbConnection(connectionString);
            return myConnection;
        }
    }
}