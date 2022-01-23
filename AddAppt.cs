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
    public partial class AddAppt : Form
    {
        DataTable customerSearch;
        DataTable userSearch;
        public AddAppt()
        {
            InitializeComponent();
        }

        private void AddAppt_Load(object sender, EventArgs e)
        {
            DB.currentIndex = -1;

            DB.OpenConnection();
            
            string query = "Select customerId as 'Customer Id', customerName as 'Customer Name' from customer";
            DB.Query(query);
            customerSearch = new DataTable();
            DB.adp.Fill(customerSearch);
            
            string query2 = "Select userID from user";
            DB.Query(query2);
            userSearch = new DataTable();
            DB.adp.Fill(userSearch);
            
            DB.CloseConnection();
            display();
        }

        private void dgvCustSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DB.currentIndex = e.RowIndex;
        }

        private void display() 
        {
            dgvCustSearch.DataSource = customerSearch;
            dgvCustSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustSearch.ReadOnly = true;
            dgvCustSearch.MultiSelect = false;
            dgvCustSearch.AllowUserToAddRows = false;
            dgvCustSearch.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCustSearch.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCustSearch.RowHeadersVisible = false;

            txtUserID.Text = DB.currentUserID.ToString();

            cbType.Items.Add("Presentation");
            cbType.Items.Add("SCRUM");
            cbType.Items.Add("Consultation");

            /*for (int i = 0; i < userSearch.Rows.Count; i++)
            {
                cbUserId.Items.Add(userSearch.Rows[i].ToString());
            }*/


        }

        private void btnSelectCust_Click(object sender, EventArgs e)
        {
            txtCustID.Text = dgvCustSearch.Rows[DB.currentIndex].Cells["Customer ID"].Value.ToString();
            txtName.Text = dgvCustSearch.Rows[DB.currentIndex].Cells["Customer Name"].Value.ToString();
        }
    }  
}
