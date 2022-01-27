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
        }

        private void btnSelectCust_Click(object sender, EventArgs e)
        {
            txtCustID.Text = dgvCustSearch.Rows[DB.currentIndex].Cells["Customer ID"].Value.ToString();
            txtName.Text = dgvCustSearch.Rows[DB.currentIndex].Cells["Customer Name"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string date = dtpDate.Text.ToString();
            string startTime = dtpStart.Text.ToString();
            string endTime = dtpEnd.Text.ToString();
            
            DB.OpenConnection();

            string query = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@custID, @userID, @title, @description, @location, @contact, @type, @url, @start, @end, CURDATE(), @user, CURDATE(), @user)";
            DB.NonQuery(query);
            DB.cmd.Parameters.AddWithValue("@custID", txtCustID.Text);
            DB.cmd.Parameters.AddWithValue("@userID", txtUserID.Text);
            DB.cmd.Parameters.AddWithValue("@title", "none");
            DB.cmd.Parameters.AddWithValue("@description", "none");
            DB.cmd.Parameters.AddWithValue("@location", "none");
            DB.cmd.Parameters.AddWithValue("@contact", "none");
            DB.cmd.Parameters.AddWithValue("@type", cbType.Text.ToString());
            DB.cmd.Parameters.AddWithValue("@url", "none");
            DB.cmd.Parameters.AddWithValue("@start", DT.UniversalTime(startTime, date));
            DB.cmd.Parameters.AddWithValue("@end", DT.UniversalTime(endTime, date));
            DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
            DB.cmd.ExecuteNonQuery();

            DB.CloseConnection();
            this.Hide();
            Appointments form = new Appointments();
            form.ShowDialog();
        }
    }  
}
