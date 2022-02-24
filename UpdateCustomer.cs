using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using J_Sarad_C969_SchedulingApp.model;

namespace J_Sarad_C969_SchedulingApp
{
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            displayControls();
        }
        //Button Click Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Replace("-", String.Empty).Replace("(", String.Empty).Replace(")", String.Empty);
            long i;

            if ((string.IsNullOrEmpty(txtName.Text)) || (string.IsNullOrEmpty(txtAddress.Text)) ||
               (string.IsNullOrEmpty(txtPhone.Text)) || (string.IsNullOrEmpty(cbCity.Text)) ||
               (string.IsNullOrEmpty(txtCountry.Text)))
            {
                //alert user that there are empty text fields
                MessageBox.Show("Please Fill out all required fields");
            }
            else if ((!Int64.TryParse(phone, out i)) || (phone.Length != 10))
            {
                //alert user to input a valid telephone number with only digits
                MessageBox.Show("Phone Number must be 10 digits");
            }
            else
            {
                try
                {
                    //update customer in database
                    DB.OpenConnection();
                    string query =
                        "UPDATE customer, address, city, country SET customerName = @Name, address = @Address, " +
                        "phone = @phone, city = @city, country = @country " +
                        "WHERE customer.addressId = address.addressId AND address.cityId = city.cityId " +
                        "AND city.countryId = country.countryId AND customer.customerId = @ID";
                    DB.NonQuery(query);
                    //DB.cmd.Parameters.AddWithValue("@ID", currentID);
                    DB.cmd.Parameters.AddWithValue("@ID", Customer.currentCustObj["Customer ID"]);
                    DB.cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    DB.cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    DB.cmd.Parameters.AddWithValue("@phone", i);
                    DB.cmd.Parameters.AddWithValue("@city", cbCity.Text);
                    DB.cmd.Parameters.AddWithValue("@country", txtCountry.Text);
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
            //close UpdateCustomer form and open Customers form
            this.Hide();
            Customers form = new Customers();
            form.ShowDialog();
        }
        
        //combobox index changed event
        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //automatically set country based on city selection
            if (cbCity.Text == "Los Angeles")
            {
                txtCountry.Text = "United States";
            }
            else if (cbCity.Text == "Tokyo")
            {
                txtCountry.Text = "Japan";
            }
            else if (cbCity.Text == "Madrid")
            {
                txtCountry.Text = "Spain";
            }
        }

        //display formatting
        private void displayControls()
        {
            //cbCity combobox formatting
            cbCity.Items.Add("Los Angeles");
            cbCity.Items.Add("Madrid");
            cbCity.Items.Add("Tokyo");
            cbCity.Text = Customer.currentCustObj["City"].ToString();

            //textBox fomratting
            txtName.Text = Customer.currentCustObj["Customer Name"].ToString();
            txtAddress.Text = Customer.currentCustObj["Address"].ToString();
            txtPhone.Text = Customer.currentCustObj["Phone"].ToString();
            txtCountry.Text = Customer.currentCustObj["Country"].ToString();
        }
    }
}
