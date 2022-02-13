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
        //Appointment appointment = new Appointment();
        DataTable customerSearch;
        //Appointments appointment = new Appointments();
        //bool allowSave;
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
            displayControls();
        }

        private void dgvCustSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DB.currentIndex = e.RowIndex;
        }
        
        private void displayControls() 
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

            //cbType.Text = "--select Appointment Type--";
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
            DateTime date = dtpDate.Value.Date;
            TimeSpan startTime = dtpStart.Value.TimeOfDay;
            TimeSpan endTime = dtpEnd.Value.TimeOfDay;
            DateTime startAppt = date.Add(startTime).AddSeconds(-date.Add(startTime).Second);
            DateTime endAppt = date.Add(endTime).AddSeconds(-date.Add(endTime).Second);
            string userId = txtUserID.Text;

            Appointment.IsOverlap(startAppt, endAppt, userId);
            Appointment.IsBusinessHours(dtpDate.Value, dtpStart.Value, dtpEnd.Value);

            if (!Appointment.isBusinessHours)
            {
                MessageBox.Show("Appointment on " + dtpDate.Value.ToLongDateString() + " from " +
                        dtpStart.Value.ToShortTimeString() + " to " + dtpEnd.Value.ToShortTimeString() +
                        "\nis outside of business hours and can not be set." +
                        "\n\nBusiness Hours are 8:00 AM to 5:00 PM Monday through Friday.",
                        "Appointment Outside of Business Hours");
            }
            else if (Appointment.isOverlap)
            {
                MessageBox.Show($"There is an overlapping appointment for {Appointment.UserName} with " +
                        $"{Appointment.CustomerName} from \n " +
                        $"{Appointment.StartTime} to {Appointment.EndTime}", "Overlapping Appointment");
            }
            else if (startAppt > endAppt)
            {
                MessageBox.Show("The appointment start time cannot be later than the appointment end time");
            }
            else if (startAppt == endAppt)
            {
                MessageBox.Show("The appointment start time cannot be the same as the appointment end time");
            }
            else if ((string.IsNullOrEmpty(txtCustID.Text)) ||
                (string.IsNullOrEmpty(txtName.Text)))
            {
                MessageBox.Show("Please select a Customer for this appointment",
                   "Missing Field Information");
            }
            else if (string.IsNullOrEmpty(cbType.Text))
            {
                MessageBox.Show("Please Select an Appointment Type for this Appointment",
                    "Missing Field Infromation");
            }
            else
            {
                DB.OpenConnection();

                string query =
                    "INSERT INTO appointment (customerId, userId, title, description, location, contact, " +
                    "type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES (@custID, @userID, @title, @description, @location, @contact, @type, @url, @start, " +
                    "@end, CURDATE(), @user, CURDATE(), @user)";
                DB.NonQuery(query);
                DB.cmd.Parameters.AddWithValue("@custID", txtCustID.Text);
                DB.cmd.Parameters.AddWithValue("@userID", txtUserID.Text);
                DB.cmd.Parameters.AddWithValue("@title", "none");
                DB.cmd.Parameters.AddWithValue("@description", "none");
                DB.cmd.Parameters.AddWithValue("@location", "none");
                DB.cmd.Parameters.AddWithValue("@contact", "none");
                DB.cmd.Parameters.AddWithValue("@type", cbType.Text.ToString());
                DB.cmd.Parameters.AddWithValue("@url", "none");
                DB.cmd.Parameters.AddWithValue("@start", Appointment.UniversalTime(date, startTime));
                DB.cmd.Parameters.AddWithValue("@end", Appointment.UniversalTime(date, endTime));
                DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                DB.cmd.ExecuteNonQuery();

                DB.CloseConnection();
                this.Hide();
                Appointments form = new Appointments();
                form.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointments form = new Appointments();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }  
}
