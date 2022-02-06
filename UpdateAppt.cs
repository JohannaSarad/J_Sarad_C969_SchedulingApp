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
            DateTime date = dtpDate.Value.Date;
            TimeSpan startTime = dtpStart.Value.TimeOfDay;
            TimeSpan endTime = dtpEnd.Value.TimeOfDay;
            DateTime startAppt = date.Add(startTime).AddSeconds(-date.Add(startTime).Second);
            DateTime endAppt = date.Add(endTime).AddSeconds(-date.Add(endTime).Second);

            Appointment.IsOverlap(startAppt, endAppt);
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
                MessageBox.Show("The appointment start time cannot be later than the appointment end time.");
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
                    "UPDATE appointment SET type = @Type, start = @Start, end = @End " +
                    "WHERE appointment.appointmentID = @ApptID";
                DB.NonQuery(query);
                DB.cmd.Parameters.AddWithValue("@Type", cbType.Text.ToString());
                DB.cmd.Parameters.AddWithValue("@ApptID", txtApptId.Text.ToString());
                DB.cmd.Parameters.AddWithValue("@start", Appointment.UniversalTime(date, startTime));
                DB.cmd.Parameters.AddWithValue("@end", Appointment.UniversalTime(date, endTime));
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
    }
}
