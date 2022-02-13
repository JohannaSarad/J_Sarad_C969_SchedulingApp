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
    public partial class Reports : Form
    {
        public string[] Months =
            {"January", "February", "March", "April", "May", "June", "July", "August",
            "September", "October", "November", "December"};

        //public List<string> appointments = new List<string>();
        public string[] users;

        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            displayControls();
            if (Appointment.dtAppointments == null)
            {
                Appointment.FillAppointments();
            }
        }

        private void displayControls()
        {
            for (int i = 0; i < Months.Length; i++)
            {
                cbApptByMonth.Items.Add(Months[i]);
            }
            //for (int i = 0)
        }

        private void cbApptByMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB.OpenConnection();
            string query = "Select start as 'Start', type as 'Type' from appointment";
            DB.Query(query);
            DataTable dtTypeByMonth = new DataTable();
            DB.adp.Fill(dtTypeByMonth);
            DB.CloseConnection();

            for (int i = 0; i < dtTypeByMonth.Rows.Count; i++)
            {
                dtTypeByMonth.Rows[i]["Start"] =
                        TimeZoneInfo.ConvertTimeFromUtc((DateTime)dtTypeByMonth.Rows[i]["Start"],
                        TimeZoneInfo.Local);
            }

            txtReports.Text = "\r\nNumber of each appointment type by Month \r\n\r\n";
            for (int i = 0; i < Months.Length; i++)
            {
                if (Months[i] == cbApptByMonth.Text)
                {
                    txtReports.Text = txtReports.Text + Months[i].ToString() + "\r\n\r\n\t";
                    foreach (DataRow row in dtTypeByMonth.Rows) 
                    {
                        int scrum = 0;
                        int presentation = 0;
                        int consultation = 0;
                        DateTime date = (DateTime)row["Start"];
                        if (Months[i] == date.ToString("MMMM"))
                        {
                            if (row["Type"].ToString() == "Consulation")
                            {
                                consultation++;
                            }
                            if (row["Type"].ToString() == "Presentation")
                            {
                                presentation++;
                            }
                            if (row["Type"].ToString() == "SCRUM")
                            {
                                scrum++;
                            }
                        }
                        txtReports.Text = txtReports.Text + $"Consulation: {consultation} \r\n\t " +
                            $"Presentation: {presentation}\r\n\t SCRUM: {scrum}";
                    }
                }
            }
        }

        private void btnTypeByMonth_Click(object sender, EventArgs e)
        {
            DB.OpenConnection();
            string query = "Select start as 'Start', type as 'Type' from appointment";
            DB.Query(query);
            DataTable dtTypeByMonth = new DataTable();
            DB.adp.Fill(dtTypeByMonth);
            DB.CloseConnection();

            for (int i = 0; i < dtTypeByMonth.Rows.Count; i++)
            {
                dtTypeByMonth.Rows[i]["Start"] =
                        TimeZoneInfo.ConvertTimeFromUtc((DateTime)dtTypeByMonth.Rows[i]["Start"],
                        TimeZoneInfo.Local);
            }

            txtReports.Text = "\rNumber of each appointment type by Month \r\n\r\n\t";
            for (int i = 0; i < Months.Length; i++)
            {


                txtReports.Text = txtReports.Text + Months[i] + "\r\n\t";
                for (int j = 0; j < dtTypeByMonth.Rows.Count; j++)
                {
                    int scrum = 0;
                    int consultation = 0;
                    int presentation = 0;
                    DateTime date = (DateTime)dtTypeByMonth.Rows[j]["Start"];
                    if (Months[i] == (date.ToString("MMMM")))
                    {
                        if (dtTypeByMonth.Rows[j]["Type"].ToString() == "SCRUM")
                        {
                            scrum++;
                        }
                        if (dtTypeByMonth.Rows[j]["Type"].ToString() == "Presentation")
                        {
                            presentation++;
                        }
                        if (dtTypeByMonth.Rows[j]["Type"].ToString() == "Consultation")
                        {
                            consultation++;
                        }
                    }
                    txtReports.Text = txtReports.Text + $"\r\n\t Scrum Appointments: {scrum} \r\n\t Presentation Appointments:" +
                       $" {presentation} \r\n\t Consultation Appointments: {consultation} \r\n\r\n\t";
                }
            }
        }

        private void cbSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Schedule> schedule = Appointment.FillSchedule();

            foreach (var appt in schedule)
            {
                Console.WriteLine($"{appt.schedUserId}, {appt.schedDate}, {appt.schedStart}, {appt.schedEnd}, " +
                    $"{appt.schedCust}, {appt.schedType}");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Schedule> schedule = Appointment.FillSchedule();

            foreach (var appt in schedule)
            {
                Console.WriteLine($"{appt.schedUserId}, {appt.schedDate}, {appt.schedStart}, {appt.schedEnd}, " +
                    $"{appt.schedCust}, {appt.schedType}");
            }
        }
    }
}
