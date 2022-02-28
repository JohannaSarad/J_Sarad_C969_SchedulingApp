using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_Sarad_C969_SchedulingApp.model
{
    class Customer
    {
        //global data table
        public static DataTable dtCustomer { get; set; }

        //global properties
        public string currentCustomerName { get; set; }
        public static DataRow currentCustObj { get; set; }
        public string currentCustId { get; set; }
        public bool isValidCustomer { get; set; }

        //public Customer() { }

        public static void FillCustomer()
        {
            //Fix ME!!! add try catch or move to DB method with try catch
            //fill dtCustomer data table with customer information from database
            try
            {
                DB.OpenConnection();
                string query = "select customerId as 'Customer ID', customerName as 'Customer Name', phone as 'Phone', " +
                    "address as 'Address', city as 'City', country as 'Country' " +
                    "from customer t1 inner join address t2 on t1.addressId=t2.addressId inner join city t3 on " +
                    "t2.cityId=t3.cityId inner join country t4 on t3.countryId=t4.countryId";
                DB.Query(query);
                dtCustomer = new DataTable();
                DB.adp.Fill(dtCustomer);
                FormatPhone(dtCustomer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!" + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public static ArrayList FillArray()
        {
            ArrayList array = new ArrayList();
            
            //fill array ArrayList from dtCustomer data table, format string objects and return array
            foreach (DataRow row in Customer.dtCustomer.Rows)
            {
                string format = $"{row["Customer Name"]} . {row["Phone"]} . {row["Address"]} . {row["City"]}" +
                     $" . {row["Country"]}";
                    array.Add(format);
            }
            return array;
        }

        public void UpdateCustomer(string id)
        {
            //update current customer object to customer with selected id
            foreach (DataRow row in dtCustomer.Rows)
            {
                if (row["Customer ID"].ToString() == id)
                {
                    currentCustObj = row;
                }
            }
        }
        public void DeleteCustomer(string id)
        {
            //delete customer with selected id from database
            try
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
                    "delete a1, a2, a3, a4 from customer as a1 " +
                    "inner join address as a2 on a1.addressId = a2.addressId " +
                    "inner join city as a3 on a2.cityId = a3.cityId " +
                    "inner join country as a4 on a3.countryId = a4.countryId where customerId = @ID";
                DB.NonQuery(query3);
                DB.cmd.Parameters.AddWithValue("@ID", id);
                DB.cmd.ExecuteNonQuery();
                string query4 = "set FOREIGN_KEY_CHECKS = 1";
                DB.NonQuery(query4);
                DB.cmd.ExecuteNonQuery();
                DB.currentIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured" + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public static void FormatPhone(DataTable table)
        {
            for(int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["Phone"] = Convert.ToInt64(table.Rows[i]["Phone"]);
            }
        }

        public void  ValidateCustomer(string name)
        {
            foreach (DataRow row in dtCustomer.Rows)
            {
                if (row["Customer Name"].ToString().ToUpper() == name.ToUpper())
                {
                    //if user input customer name is exactly a name in the database
                    //MessageBox.Show(row["Customer Name"].ToString().ToUpper() + ", " + txtName.Text.ToUpper());
                    isValidCustomer = true;
                    currentCustId = row["Customer ID"].ToString();
                    break;
                }
                else
                {
                    isValidCustomer = false;
                }
            }
        }
    }
}
