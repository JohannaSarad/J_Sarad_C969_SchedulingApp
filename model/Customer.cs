using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_Sarad_C969_SchedulingApp.model
{
    class Customer
    {
        public static DataTable dtCustomer { get; set; }
        public static DataRow currentCustObj { get; set; }
        //public int CurrentCustomerIndex = -1;
        //private string ID { get; set; }
        //private string Name { get; set; } 
        //private string Phone { get; set; }
        //private string Address { get; set; }
        //private string City { get; set; }
        //private string Country { get; set; }
        public static string currentCustId { get; set; }

        public Customer() { }

        public void FillCustomer()
        {
            DB.OpenConnection();
            string query = "select customerId as 'Customer ID', customerName as 'Customer Name', phone as 'Phone', " +
                "address as 'Address', city as 'City', country as 'Country' " +
                "from customer t1 inner join address t2 on t1.addressId=t2.addressId inner join city t3 on " +
                "t2.cityId=t3.cityId inner join country t4 on t3.countryId=t4.countryId";
            DB.Query(query);
            dtCustomer = new DataTable();
            DB.adp.Fill(dtCustomer);
            DB.CloseConnection();
        }

        //public Customer(string id, string name, string phone, string address, string city, string country)
        //{
        //    ID = id;
        //    Name = name;
        //    Phone = phone;
        //    Address = address;
        //    City = city;
        //    Country = country;
        //}

        public void UpdateCustomer(string id)
        {
            foreach (DataRow row in dtCustomer.Rows)
            {
                if (row["Customer ID"].ToString() == id)
                {
                    //ID = row["Customer ID"].ToString();
                    //Name = row["Customer Name"].ToString();
                    //Phone = row["Phone"].ToString();
                    //Address = row["Address"].ToString();
                    //City = row["City"].ToString();
                    //Country = row["Country"].ToString();
                    currentCustObj = row;
                }
            }
        }
        public void DeleteCustomer(string id)
        {
            DB.OpenConnection();
            string query = "set FOREIGN_KEY_CHECKS = 0";
            DB.NonQuery(query);
            DB.cmd.ExecuteNonQuery();
            string query2 = "delete from appointment WHERE customerId = @ID";
            DB.NonQuery(query2);
            DB.cmd.Parameters.AddWithValue("@ID", id);
            DB.cmd.ExecuteNonQuery();
            string query3 =
                "delete a1, a2, a3, a4 from country as a1 " +
                "inner join city as a2 on a1.countryId = a2.countryId " +
                "inner join address as a3 on a2.cityId = a3.cityId " +
                "Inner Join customer as a4 on a3.addressId = a4.addressId where customerId = @ID";
            DB.NonQuery(query3);
            DB.cmd.Parameters.AddWithValue("@ID", id);
            DB.cmd.ExecuteNonQuery();
            string query4 = "set FOREIGN_KEY_CHECKS = 1";
            DB.NonQuery(query4);
            DB.cmd.ExecuteNonQuery();
            DB.CloseConnection();
            DB.currentIndex = -1;
        }
    }
}
