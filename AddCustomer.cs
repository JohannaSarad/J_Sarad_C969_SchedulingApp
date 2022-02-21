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
        //FIX ME!!! in cbCity_SelectedIndexChanged Function (may need to be changed to text instead of SelectedItem,
        //cause they are throwing an unintended reference comparison error)
        string country;
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            displayControls();
        }

        private void displayControls()
        {
            cbCity.Items.Add("--select city--");
            cbCity.Items.Add("Los Angeles");
            cbCity.Items.Add("Madrid");
            cbCity.Items.Add("Tokyo");
            cbCity.SelectedIndex = 0;
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            int i;
            string phone = txtPhone.Text.Replace("-", String.Empty);
            if ((string.IsNullOrEmpty(txtName.Text)) || (string.IsNullOrEmpty(txtAddress.Text)) ||
                (string.IsNullOrEmpty(txtPhone.Text)))
            {
                MessageBox.Show("Please Fill out all required fields");
            }
            else if ((!Int32.TryParse(phone, out i)) || (phone.Length != 7))
            {
                MessageBox.Show("Phone Number must be 7 digits");
            }
            else if (cbCity.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a City");
            }
            else { 
                //possibly make a customer class and make this into an insertCustomer method
                DB.OpenConnection();
                
                string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@country, CURDATE(), @user, CURDATE(), @user)";
                DB.NonQuery(query);
                DB.cmd.Parameters.AddWithValue("@country", country);
                DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                DB.cmd.ExecuteNonQuery();
                
                string query2 = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@city, LAST_INSERT_ID(), CURDATE(), @user, CURDATE(), @user)";
                DB.NonQuery(query2);
                DB.cmd.Parameters.AddWithValue("@city", cbCity.Text);
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
                this.Hide();
                Customers form = new Customers();
                form.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers form = new Customers();
            form.ShowDialog();
        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbCity.SelectedItem == "Los Angeles")
            {
                country = "United States";
            }
            else if (cbCity.SelectedItem == "Tokyo")
            {
                country = "Japan";
            }
            else if (cbCity.SelectedItem == "Madrid")
            {
                country = "Spain";
            }
        }
    }
}
