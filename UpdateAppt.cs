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
        //FIX ME!!! DateTimePickers need a range of dates set.
        
        //create an instance of Appointment class 
        Appointment appointment = new Appointment();
        public UpdateAppt()
        {
            InitializeComponent();
        }
        
        private void UpdateAppt_Load(object sender, EventArgs e)
        {
            //display form controls
            display();
        }

        //Button Click Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime date = dtpDate.Value.Date;
            TimeSpan startTime = dtpStart.Value.TimeOfDay;
            TimeSpan endTime = dtpEnd.Value.TimeOfDay;
            DateTime startAppt = date.Add(startTime).AddSeconds(-date.Add(startTime).Second);
            DateTime endAppt = date.Add(endTime).AddSeconds(-date.Add(endTime).Second);

            //method calls to check for overlapping appointments and appointments outside ofbusiness hours
            appointment.IsOverlap(startAppt, endAppt, DB.currentUserID.ToString());
            appointment.IsBusinessHours(dtpDate.Value, dtpStart.Value, dtpEnd.Value);

            
            if (!appointment.isBusinessHours)
            {
                //alert user if appointment is outside of business hours
                MessageBox.Show("Appointment on " + dtpDate.Value.ToLongDateString() + " from " +
                        dtpStart.Value.ToShortTimeString() + " to " + dtpEnd.Value.ToShortTimeString() +
                        "\nis outside of business hours and can not be set." +
                        "\n\nBusiness Hours are 8:00 AM to 5:00 PM Monday through Friday.",
                        "Appointment Outside of Business Hours");
            }
            else if (appointment.isOverlap)
            {
                //alert user if appointment time is overlapping time of another appointment
                MessageBox.Show($"There is an overlapping appointment for " +
                    $"{Appointment.CurrentApptObj["User Name"]} with " +
                        $"{Appointment.CurrentApptObj["Customer Name"]} from \n " +
                        $"{Appointment.CurrentApptObj["Start Time"]} to " +
                        $"{Appointment.CurrentApptObj["End Time"]}", "Overlapping Appointment");
            }
            else if (startAppt > endAppt)
            {
                //alert user if selected appointment start time is after selected appointment end time
                MessageBox.Show("The appointment start time cannot be later than the appointment end time.");
            }
            else if (startAppt == endAppt)
            {
                //alert user if selected appointment start time is the same as selected appointment end time
                MessageBox.Show("The appointment start time cannot be the same as the appointment end time");
            }
            else if (string.IsNullOrEmpty(cbType.Text))
            {
                //alert user if appointment type is not selected
                MessageBox.Show("Please Select an Appointment Type for this Appointment",
                    "Missing Field Infromation");
            }
            else
            {
                //Update appointment in database
                try
                {
                    DB.OpenConnection();
                    string query =
                        "UPDATE appointment SET type = @Type, start = @Start, end = @End " +
                        "WHERE appointment.appointmentID = @ApptID";
                    DB.NonQuery(query);
                    DB.cmd.Parameters.AddWithValue("@Type", cbType.Text.ToString());
                    DB.cmd.Parameters.AddWithValue("@ApptID", Appointment.CurrentApptObj["Appointment ID"]);
                    DB.cmd.Parameters.AddWithValue("@start", appointment.UniversalTime(date, startTime));
                    DB.cmd.Parameters.AddWithValue("@end", appointment.UniversalTime(date, endTime));
                    DB.cmd.ExecuteNonQuery();
                    this.Hide();
                    Appointments form = new Appointments();
                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured" + ex.Message);
                }
                finally
                {
                    DB.CloseConnection();
                }
            }
        }
    

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close UpdateAppt form and open Appointments form
            this.Hide();
            Appointments form = new Appointments();
            form.ShowDialog();
        }

       
        //display controls formatting filled from selected index object
        private void display()
        {
            //cbType Formatting
            cbType.Items.Add("Presentation");
            cbType.Items.Add("SCRUM");
            cbType.Items.Add("Consultation");
            cbType.Text = Appointment.CurrentApptObj["Appointment Type"].ToString();
            
            //textbox formatting
            txtName.Text = Appointment.CurrentApptObj["Customer Name"].ToString();
            
            //dateTImePicker Formatting
            dtpDate.Value = (DateTime)Appointment.CurrentApptObj["Date"];
            dtpStart.Value = (DateTime)Appointment.CurrentApptObj["Start Time"];
            dtpEnd.Value = (DateTime)Appointment.CurrentApptObj["End Time"];
        }
    }
}
