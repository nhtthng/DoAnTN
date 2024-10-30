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
        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=SANTA\\SQLEXPRESS;Initial Catalog=QuanLyPKTN_Final;User ID=sa;Password=123;Trust Server Certificate=True";
            SqlConnection conn = new SqlConnection(strcon); // khởi tạo 
            return conn;
        }
    }
    
    public class DB_Access
    {
        // tạo chuỗi kết nối cơ sở dữ liệu
        
    }
}
