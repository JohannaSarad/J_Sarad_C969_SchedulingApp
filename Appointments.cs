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
    public partial class Appointments : Form
    {
        DataTable apptTable;
        //public int currentIndex;
        public Appointments()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu form = new MainMenu();
            form.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAppt form = new AddAppt();
            form.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DB.currentIndex >= 0)
            {
                this.Hide();
                UpdateAppt form = new UpdateAppt();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select an Appointment to Update");
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            DB.currentIndex = -1;
            
            
            
            DB.OpenConnection();
            string query = "select appointmentID as 'Appointment ID', type as 'Appointment Type', userId as 'User ID', customerId as 'Customer ID', customerName as 'Name', start as 'Date', start as 'Start Time', end as ' End Time' from customer join appointment using (customerId)";
            DB.Query(query);
            apptTable = new DataTable();
            DB.adp.Fill(apptTable);
            
            DB.CloseConnection();
            for(int i = 0; i < apptTable.Rows.Count; i++ )
            {
                apptTable.Rows[i]["Date"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)apptTable.Rows[i]["Date"],
                    TimeZoneInfo.Local);
                apptTable.Rows[i]["Start Time"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)apptTable.Rows[i]["Start Time"], 
                    TimeZoneInfo.Local);
                apptTable.Rows[i]["End Time"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)apptTable.Rows[i]["End Time"],
                    TimeZoneInfo.Local);
            }
            display();
        }

        private void display()
        {
            dgvAppointments.DataSource = apptTable;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.MultiSelect = false;
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvAppointments.Columns["Start Time"].DefaultCellStyle.Format = "HH:mm tt";
            dgvAppointments.Columns["End Time"].DefaultCellStyle.Format = "HH:mm tt";

            cbApptType.Items.Add("Presentation");
            cbApptType.Items.Add("SCRUM");
            cbApptType.Items.Add("Consultation");
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DB.currentIndex = e.RowIndex;
        }

       
    }
}
