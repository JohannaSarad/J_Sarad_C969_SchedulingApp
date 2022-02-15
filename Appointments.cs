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
        //Appointment appointment = new Appointment();
        public DataTable dtCurrentUserAppt;
        //public int currentIndex;
        public Appointments()
        {
            InitializeComponent();
        }

        //closes Appointment Form and opens MainMenu Form
        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu form = new MainMenu();
            form.ShowDialog();
        }
        
        //closes Appointment Form and opens AddAppt Form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAppt form = new AddAppt();
            form.ShowDialog();
        }

        //closes Appointment Form and opens UpdateAppt Form if a row is selected in dgvAppointments
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (DB.currentIndex >= 0)
            {
                this.Hide();
                UpdateAppt form = new UpdateAppt();
                form.ShowDialog();
            }
            //show exception if there is no row selected in dgvAppointments to update
            else
            {
                MessageBox.Show("Please Select an Appointment to Update");
            }
            
        }

        //closes Appointments Form and Exits program
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void Appointments_Load(object sender, EventArgs e)
        {
            DB.currentIndex = -1;
            DB.currentApptId = null;
            
            display();
        }

        private void display()
        {
            Appointment.FillAppointments();
            dtCurrentUserAppt = new DataTable();
            dtCurrentUserAppt = Appointment.dtAppointments.Clone();
            foreach (DataRow row in Appointment.dtAppointments.Rows)
            {
                if (row["User ID"].ToString() == DB.currentUserID.ToString())
                {
                    dtCurrentUserAppt.ImportRow(row);
                }
            }

            dgvAppointments.DataSource = dtCurrentUserAppt;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.MultiSelect = false;
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvAppointments.Columns["Start Time"].DefaultCellStyle.Format = "hh:mm tt";
            dgvAppointments.Columns["End Time"].DefaultCellStyle.Format = "hh:mm tt";

            //cbApptType.DisplayMember = "All Types";
            cbApptType.Items.Add("All Types");
            cbApptType.Items.Add("Presentation");
            cbApptType.Items.Add("SCRUM");
            cbApptType.Items.Add("Consultation");
            cbApptType.SelectedIndex = 0;
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //FIX ME!!! currentIndex may go better in Appointment class
            DB.currentIndex = e.RowIndex;
            //this might need to be an int value
            Appointment.CurrentApptID = dgvAppointments.Rows[DB.currentIndex].Cells["Appointment ID"].Value.ToString();
            Appointment.UpdateAppointment(Appointment.CurrentApptID);
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DB.currentIndex >= 0)
            {
                DB.OpenConnection();
                string query = "DELETE FROM appointment WHERE appointmentId = @appointmentID";
                DB.NonQuery(query);
                DB.cmd.Parameters.AddWithValue("@appointmentID", Appointment.CurrentApptObj["Appointment ID"]);
                DB.cmd.ExecuteNonQuery();
                DB.CloseConnection();
                display();
                DB.currentIndex = -1;
                dgvAppointments.ClearSelection();
            }
            else
            {
                MessageBox.Show("Please Select an Appointment to Delete");
            }
        }

        private void cbApptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbApptType.)
        }

        
    }
}
