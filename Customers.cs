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
        DataTable custTable;
        //public int currentIndex;
        
        public Customers()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            DB.currentIndex = -1;
            displayDGV();
        }

        private void displayDGV()
        {
           DB.OpenConnection();
            string query = "select customerId as 'ID', customerName as 'Name', phone as 'Phone', " +
                "address as 'Address', city as 'City', country as 'Country' " +
                "from customer t1 inner join address t2 on t1.addressId=t2.addressId inner join city t3 on " +
                "t2.cityId=t3.cityId inner join country t4 on t3.countryId=t4.countryId";
            DB.Query(query);
            custTable = new DataTable();
            DB.adp.Fill(custTable);
            DB.CloseConnection();
            dgvCustomers.DataSource = custTable;
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
            DB.currentIndex = e.RowIndex;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DB.currentIndex >= 0)
            {
                this.Hide();
                UpdateCustomer form = new UpdateCustomer();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select a Customer to Update");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomer form = new AddCustomer();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu form = new MainMenu();
            form.ShowDialog();
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DB.currentIndex >= 0) {
                DB.OpenConnection();
                string query = "set FOREIGN_KEY_CHECKS = 0";
                DB.NonQuery(query);
                DB.cmd.ExecuteNonQuery();
                string query2 = "delete from appointment WHERE customerId = @ID";
                DB.NonQuery(query2);
                DB.cmd.Parameters.AddWithValue("@ID", dgvCustomers.Rows[DB.currentIndex].Cells["ID"].Value.ToString());
                DB.cmd.ExecuteNonQuery();
                string query3 = 
                    "delete a1, a2, a3, a4 from country as a1 " +
                    "inner join city as a2 on a1.countryId = a2.countryId " +
                    "inner join address as a3 on a2.cityId = a3.cityId " +
                    "Inner Join customer as a4 on a3.addressId = a4.addressId where customerId = @ID";
                DB.NonQuery(query3);
                DB.cmd.Parameters.AddWithValue("@ID", dgvCustomers.Rows[DB.currentIndex].Cells["ID"].Value.ToString());
                DB.cmd.ExecuteNonQuery();
                string query4 = "set FOREIGN_KEY_CHECKS = 1";
                DB.NonQuery(query4);
                DB.cmd.ExecuteNonQuery();
                DB.CloseConnection();
                DB.currentIndex = -1;
                displayDGV();

                
            }
            else
            {
                MessageBox.Show("Please Select a Customer to Delete");
            }
        }
    }
}
