using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlConnectionData
    {
        private static readonly string strcon = @"Data Source=SANTA\SQLEXPRESS;Initial Catalog=QuanLyPKTN_Final_2;User ID=sa;Password=123";
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(strcon); // khởi tạo 
            return conn;
        }
        public static void CloseConnection(SqlConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            } 
        }
    }
}
