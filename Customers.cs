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
using MySql.Data.MySqlClient;
using System.Configuration;

namespace J_Sarad_C969_SchedulingApp
{
    public partial class Customers : Form
    {
        int currentIndex;
        public Customers()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            DB.OpenConnection();
            string query = "select customerId as 'ID', customerName as 'Name', phone as 'Phone', address as 'Address', city as 'City', country as 'Country' from customer t1 inner join address t2 on t1.addressId=t2.addressId inner join city t3 on t2.cityId=t3.cityId inner join country t4 on t3.countryId=t4.countryId";
            DB.FillTable(query);
            DB.CloseConnection();
            display();
        }

        private void display()
        {
            dgvCustomers.DataSource = DB.dataTable;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCustomers.RowHeadersVisible = false;
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            currentIndex = e.RowIndex;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtCustID.Text = dgvCustomers.Rows[currentIndex].Cells["ID"].Value.ToString().Trim();
            txtCustName.Text = (string)dgvCustomers.Rows[currentIndex].Cells["Name"].Value.ToString();
            txtCustAddress.Text = (string)dgvCustomers.Rows[currentIndex].Cells["Address"].Value.ToString().Trim();
            txtCustPhone.Text = (string)dgvCustomers.Rows[currentIndex].Cells["Phone"].Value.ToString();
            txtCustCity.Text = (string)dgvCustomers.Rows[currentIndex].Cells["City"].Value.ToString();
            txtCustCountry.Text = (string)dgvCustomers.Rows[currentIndex].Cells["Country"].Value.ToString();
        }
    }
}
