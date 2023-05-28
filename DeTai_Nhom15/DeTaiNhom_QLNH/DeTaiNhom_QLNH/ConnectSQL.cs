using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DeTaiNhom_QLNH
{
    public class ConnectSQL
    {
        string connectionString;
        public ConnectSQL()
        {
            connectionString = "database = NganHang; Integrated Security = true";
        }
        public SqlConnection GetConnect()
        {          
            return new SqlConnection(connectionString);
        } 

    }
}
