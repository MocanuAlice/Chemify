using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;


namespace Chemify.DataAccess
{
    public class DataBaseHelper
    {
        private static readonly string _connectionString = SQLDataAccess.GetConnectionString();
        public static void Initialisation()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
            }
        }

    }
}
