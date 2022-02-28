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
    //FIX ME!! Phone formatting not working in displayControls.

    public partial class Customers : Form
    {
        //create instance of Customer class
        Customer customer = new Customer();
        
        public Customers()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            //reset global variables
            DB.currentIndex = -1;
            //there should not be a customer id set for this customer yet

            displayControls();
        }

        
        //dgvCustomers Cell Click Event
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            //update current index, and current customer id
            DB.currentIndex = e.RowIndex;
            customer.currentCustId = Customer.dtCustomer.Rows[DB.currentIndex]["Customer ID"].ToString();
            //updates static currentCustObj
            customer.UpdateCustomer(customer.currentCustId);
            
        }

        //Button Click Events
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DB.currentIndex >= 0)
            {
                //close Customers form and open UpdateCustomer form
                this.Hide();
                UpdateCustomer form = new UpdateCustomer();
                form.ShowDialog();
            }
            else
            {
                //alert user to select a row to update
                MessageBox.Show("Please Select a Customer to Update");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //close Cutomers form and open AddCustomers form
            this.Hide();
            AddCustomer form = new AddCustomer();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close Customers form and exit application
            Application.Exit();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            //close Customers form and open MainMenu form
            this.Hide();
            MainMenu form = new MainMenu();
            form.ShowDialog();
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DB.currentIndex >= 0) {
                //delete selected customer from database
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", " ", 
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    customer.DeleteCustomer(customer.currentCustId);
                    displayControls();
                }
                dgvCustomers.ClearSelection();
                DB.currentIndex = -1;
            }
            else
            {
                //alert user to select a row to update
                MessageBox.Show("Please Select a Customer to Delete");
            }
        }

        //diplay formatting
        private void displayControls()
        {
            //dgvCustomers formatting

            Customer.FillCustomer();

            dgvCustomers.DataSource = Customer.dtCustomer;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCustomers.RowHeadersVisible = false;
            
            //
            dgvCustomers.Columns["Phone"].DefaultCellStyle.Format = "(###) ###-####";
        }
    }
}
