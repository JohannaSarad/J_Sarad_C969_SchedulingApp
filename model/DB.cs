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
        public static int currentIndex { get; set; }
        public static int currentUserID { get; set; }
        public static string currentUser { get; set; }
        public static string currentApptId { get; set; }

        public static TimeZone CurrentTimeZone { get; }

        static MySqlConnection con { get; set; }
        public static MySqlCommand cmd { get; set; }
        public static MySqlDataAdapter adp { get; set; }
        
        //this probably won't work when I get to making appointments
       

        public static MySqlDataReader reader;
       
        

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

        public static void NonQuery(string query)
        {
            cmd = new MySqlCommand(query, con);
            
            //cmd.ExecuteNonQuery();
        }


        public static void UpdateDatabase(string query)
        {
            NonQuery(query);
        }
    }
}
