using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCoSoVatChat
{
    public class DatabaseConnection
    {
        
        public static SqlConnection GetConnection()
        {
           string connectionString =
           @"Server=.\SQLEXPRESS;
              Database=QuanLyCoSoVatChatcs;
              Integrated Security=True;
              TrustServerCertificate=True;"; return new SqlConnection(connectionString);
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            return conn;
        }
    }
}
