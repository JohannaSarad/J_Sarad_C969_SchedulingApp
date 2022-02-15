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
        //public int currentIndex;
        Customer customer = new Customer();
        
        public Customers()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            DB.currentIndex = -1;
            displayControls();
        }

        private void displayControls()
        {

            customer.FillCustomer();
            dgvCustomers.DataSource = Customer.dtCustomer;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCustomers.RowHeadersVisible = false;
            //FIX ME!! Phone formatting not working.
            dgvCustomers.Columns["Phone"].DefaultCellStyle.Format = "###-####";
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            DB.currentIndex = e.RowIndex;
            Customer.currentCustId = Customer.dtCustomer.Rows[DB.currentIndex]["Customer ID"].ToString();
            customer.UpdateCustomer(Customer.currentCustId);
            
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
                customer.DeleteCustomer(Customer.currentCustId);
                displayControls();
                dgvCustomers.ClearSelection();
            }
            else
            {
                MessageBox.Show("Please Select a Customer to Delete");
            }
        }
    }
}
