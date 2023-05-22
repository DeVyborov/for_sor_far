using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vyborov_test_1.Classes
{
    public static class SQLclass
    {
        public static SqlConnection str = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=авторизация;Integrated Security=True");

        public static void OpenConnection()
        {
            str.Open();
        }

        public static void CloseConnection() 
        {
            str.Close();
        }
    }
}
