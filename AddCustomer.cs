using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using J_Sarad_C969_SchedulingApp.model;

namespace J_Sarad_C969_SchedulingApp
{
    public partial class AddCustomer : Form
    {
        bool AllowedSave;
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }

        private bool AllowSave()
        {
            foreach (Control txt in this.Controls)
            {
                if (txt is TextBox && (!string.IsNullOrEmpty(txt.Text)))
                {
                    AllowedSave = true;
                }
                else
                {
                    AllowedSave = false;
                }
            }
            return AllowedSave;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (AllowedSave)
            {
                /*FIX ME!!! change all of this to a procedure. Figure out if there is a better place to put params
                 * so you don't have to keep repeating them. Figure out syntax to concatinate and wrap long mysql 
                 * statements. Add Try Catch for possible exception either here, or in the DB.OpenConnection Method. */
                 
                DB.OpenConnection();
                
                string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@country, CURDATE(), @user, CURDATE(), @user)";
                DB.NonQuery(query);
                DB.cmd.Parameters.AddWithValue("@country", txtCountry.Text);
                DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                DB.cmd.ExecuteNonQuery();
                
                string query2 = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@city, LAST_INSERT_ID(), CURDATE(), @user, CURDATE(), @user)";
                DB.NonQuery(query2);
                DB.cmd.Parameters.AddWithValue("@city", txtCity.Text);
                DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                DB.cmd.ExecuteNonQuery();
                
                string query3 = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@address, '123 Address', LAST_INSERT_ID(), '12345', @phone, CURDATE(), @user, CURDATE(), @user)";
                DB.NonQuery(query3);
                DB.cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                DB.cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                DB.cmd.ExecuteNonQuery();
                
                string query4 = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@name, LAST_INSERT_ID(), @bit, CURDATE(), @user, CURDATE(), @user)";
                DB.NonQuery(query4);
                DB.cmd.Parameters.AddWithValue("@name", txtName.Text);
                DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                DB.cmd.Parameters.AddWithValue("@bit", 0);
                DB.cmd.ExecuteNonQuery();

                DB.CloseConnection();
            }
            else
            {
                MessageBox.Show("Please Complete all of the Required Customer Information");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers form = new Customers();
            form.ShowDialog();
        }
    }
}
