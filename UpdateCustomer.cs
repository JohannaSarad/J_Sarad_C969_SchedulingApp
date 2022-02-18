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
            string phone = txtPhone.Text.Replace("-", String.Empty);
            int i;
            if ((string.IsNullOrEmpty(txtName.Text)) || (string.IsNullOrEmpty(txtAddress.Text)) ||
               (string.IsNullOrEmpty(txtPhone.Text)) || (string.IsNullOrEmpty(cbCity.Text)) ||
               (string.IsNullOrEmpty(txtCountry.Text)))
            {
                MessageBox.Show("Please Fill out all required fields");
            }
            else if ((!Int32.TryParse(phone, out i)) || (phone.Length != 7))
            {
                MessageBox.Show("Phone Number must be 7 digits");
            }
            else
            {
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
                DB.cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                DB.cmd.Parameters.AddWithValue("@city", cbCity.Text);
                DB.cmd.Parameters.AddWithValue("@country", txtCountry.Text);
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
        private void displayControls()
        {
            cbCity.Items.Add("Los Angeles");
            cbCity.Items.Add("Madrid");
            cbCity.Items.Add("Tokyo");
            //txtCustID.Text = Customer.currentCustObj["Customer ID"].ToString();
            txtName.Text = Customer.currentCustObj["Customer Name"].ToString();
            txtAddress.Text = Customer.currentCustObj["Address"].ToString();
            txtPhone.Text = Customer.currentCustObj["Phone"].ToString();
            cbCity.Text = Customer.currentCustObj["City"].ToString();
            txtCountry.Text = Customer.currentCustObj["Country"].ToString();

            //currentID = Convert.ToInt32(txtCustID.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCity.SelectedItem == "Los Angeles")
            {
                txtCountry.Text = "United States";
            }
            else if (cbCity.SelectedItem == "Tokyo")
            {
                txtCountry.Text = "Japan";
            }
            else if (cbCity.SelectedItem == "Madrid")
            {
                txtCountry.Text = "Spain";
            }
        }
    }
}
