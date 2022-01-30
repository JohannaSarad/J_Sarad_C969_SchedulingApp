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
    public partial class UpdateAppt : Form
    {
        public UpdateAppt()
        {
            InitializeComponent();
        }


        private void UpdateAppt_Load(object sender, EventArgs e)
        {
            display();
        }

        private void display()
        {
            cbType.Items.Add("Presentation");
            cbType.Items.Add("SCRUM");
            cbType.Items.Add("Consultation");
            using (Appointments apptForm = (Appointments)Application.OpenForms["Appointments"])
            {
                cbType.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["Appointment Type"].Value.ToString();
                
                txtApptId.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["Appointment ID"].Value.ToString();
                txtUserID.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["User ID"].Value.ToString().Trim();
                txtCustID.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["Customer ID"].Value.ToString().Trim();
                txtName.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["Name"].Value.ToString();
                dtpDate.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["Date"].Value.ToString();
                
                dtpStart.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["Start Time"].Value.ToString();
                dtpEnd.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["End Time"].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DB.OpenConnection();

            //FIX ME!!! How do I update only one 

            string query = "UPDATE appointment SET type = @Type, start = @Start, end = @End WHERE appointment.appointmentID = @ApptID";
            DB.NonQuery(query);
            DB.cmd.Parameters.AddWithValue("@Type", cbType.Text.ToString());
            DB.cmd.Parameters.AddWithValue("@ApptID", txtApptId.Text.ToString());
            DB.cmd.Parameters.AddWithValue("@start", DT.UniversalTime(dtpStart.Text.ToString(), dtpDate.Text.ToString()));
            DB.cmd.Parameters.AddWithValue("@end", DT.UniversalTime(dtpEnd.Text.ToString(), dtpDate.Text.ToString()));
            DB.cmd.ExecuteNonQuery();
            DB.CloseConnection();

            this.Hide();
            Appointments form = new Appointments();
            form.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointments form = new Appointments();
            form.ShowDialog();
        }
    }
}
