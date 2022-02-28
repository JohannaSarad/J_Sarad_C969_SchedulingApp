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
        string country;
        
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            displayControls();
        }
        
        //Button Click Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            long i;
            string phone = txtPhone.Text.Replace("-", String.Empty).Replace("(", String.Empty).Replace(")", String.Empty);
            //MessageBox.Show($"{phone}, {phone.Length}");
            
           
            if ((string.IsNullOrEmpty(txtName.Text)) || (string.IsNullOrEmpty(txtAddress.Text)) ||
                (string.IsNullOrEmpty(txtPhone.Text)))
            {
                //alert user that there are empty text fields
                MessageBox.Show("Please Fill out all required fields");
            }
            else if ((!Int64.TryParse(phone, out i)) || (phone.Length < 10) || (phone.Length > 15))
            {
                //alert user to input valid ten digit phone number
                MessageBox.Show("Phone Number must be between 10 and 15 digits");
            }
            else if (cbCity.SelectedIndex == 0)
            {
                //alert user to select a city from combobox
                MessageBox.Show("Please Select a City");
            }
            else {
                //add customer to database
                try
                {
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
                    DB.cmd.Parameters.AddWithValue("@phone", i);
                    DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                    DB.cmd.ExecuteNonQuery();

                    string query4 = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@name, LAST_INSERT_ID(), @bit, CURDATE(), @user, CURDATE(), @user)";
                    DB.NonQuery(query4);
                    DB.cmd.Parameters.AddWithValue("@name", txtName.Text);
                    DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                    DB.cmd.Parameters.AddWithValue("@bit", 0);
                    DB.cmd.ExecuteNonQuery();

                    this.Hide();
                    Customers form = new Customers();
                    form.ShowDialog();
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close AddCustmoer form and open Customers form
            this.Hide();
            Customers form = new Customers();
            form.ShowDialog();
        }

        //combobox selected index changed event
        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //automatically select country base on city selection
            if (cbCity.Text == "Los Angeles")
            {
                country = "United States";
            }
            else if (cbCity.Text == "Tokyo")
            {
                country = "Japan";
            }
            else if (cbCity.Text == "Madrid")
            {
                country = "Spain";
            }
        }

        //display formatting
        private void displayControls()
        {
            //combobox formatting
            cbCity.Items.Add("--select city--");
            cbCity.Items.Add("Los Angeles");
            cbCity.Items.Add("Madrid");
            cbCity.Items.Add("Tokyo");
            cbCity.SelectedIndex = 0;
        }
    }
}
