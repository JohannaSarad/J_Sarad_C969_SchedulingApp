using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;

namespace J_Sarad_C969_SchedulingApp.model
{
    public static class DB
    {
        
        static MySqlConnection con { get; set; }
        public static MySqlCommand cmd { get; set; }
        public static MySqlDataAdapter adp { get; set; }
        public static DataTable dataTable { get; set; }

        public static void OpenConnection()
        {
           string connectionString = ConfigurationManager.ConnectionStrings["MySqlkey"].ConnectionString;
           con = new MySqlConnection(connectionString);
           con.Open();
        }

        public static void CloseConnection()
        {
            con.Close();
        }

        public static void Query(string query)
        {
            cmd = new MySqlCommand(query, con);
            adp = new MySqlDataAdapter(cmd);
        }

        public static void FillTable(string query)
        {
            Query(query);
            dataTable = new DataTable();
            adp.Fill(dataTable);

        }

        
    }
}
