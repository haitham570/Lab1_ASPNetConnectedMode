using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration; //required for configurationManager

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class UtilityDB
    {
        /// <summary>
        /// This method return an active connection object
        /// version 1
        /// </summary>
        /// <returns>object of type sqlConnection</returns>
        //public static SqlConnection ConnectDB()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = "server=DESKTOP-J3IRNQF\\SQLEXPRESS;database=EmployeeDB;user=sa;password=123456789";
        //    conn.Open();
        //    return conn;
        //}

        //version 2
        public static SqlConnection ConnectDB()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            conn.Open();
            return conn;
        }
    }
}