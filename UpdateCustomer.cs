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
        public int currentID;
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            using (Customers custForm = (Customers)Application.OpenForms["Customers"])
            {
                txtCustID.Text = custForm.dgvCustomers.Rows[DB.currentIndex].Cells["ID"].Value.ToString().Trim();
                txtName.Text = custForm.dgvCustomers.Rows[DB.currentIndex].Cells["Name"].Value.ToString();
                txtAddress.Text = custForm.dgvCustomers.Rows[DB.currentIndex].Cells["Address"].Value.ToString().Trim();
                txtPhone.Text = custForm.dgvCustomers.Rows[DB.currentIndex].Cells["Phone"].Value.ToString();
                txtCity.Text = custForm.dgvCustomers.Rows[DB.currentIndex].Cells["City"].Value.ToString();
                txtCountry.Text = custForm.dgvCustomers.Rows[DB.currentIndex].Cells["Country"].Value.ToString();
            }
            currentID = Convert.ToInt32(txtCustID.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            DB.OpenConnection();
            string query = "UPDATE customer, address, city, country SET customerName = @Name, address = @Address, phone = @phone, city = @city, country = @country WHERE customer.addressId = address.addressId AND address.cityId = city.cityId AND city.countryId = country.countryId AND customer.customerId = @ID";
            DB.NonQuery(query);
            DB.cmd.Parameters.AddWithValue("@ID", currentID);
            DB.cmd.Parameters.AddWithValue("@Name", txtName.Text);
            DB.cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            DB.cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            DB.cmd.Parameters.AddWithValue("@city", txtCity.Text);
            DB.cmd.Parameters.AddWithValue("@country", txtCountry.Text);
            DB.cmd.ExecuteNonQuery();
            DB.CloseConnection();
            
            this.Close();
            Customers form = new Customers();
            form.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers form = new Customers();
            form.ShowDialog();
        }
    }
}
