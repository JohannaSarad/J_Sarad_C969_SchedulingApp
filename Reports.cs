using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using J_Sarad_C969_SchedulingApp.model;
using System.IO;

namespace J_Sarad_C969_SchedulingApp
{
    public partial class Reports : Form
    {
        public string[] Months =
            {"January", "February", "March", "April", "May", "June", "July", "August",
            "September", "October", "November", "December"};

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
            if (string.IsNullOrEmpty(cbApptByMonth.Text))
            {
                cbApptByMonth.Items.Add("--select month--");
                cbApptByMonth.Items.Add("All Months");
                for (int i = 0; i < Months.Length; i++)
                {
                    cbApptByMonth.Items.Add(Months[i]);
                }
                cbApptByMonth.SelectedIndex = 0;
            }

            if (string.IsNullOrEmpty(cbSchedules.Text))
            {
                DataTable dtUsers = new DataTable();
                try
                {
                    DB.OpenConnection();
                    string query = "select userId as 'User' from user";
                    DB.Query(query);
                    DB.adp.Fill(dtUsers);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured" + ex.Message);
                }
                finally
                {
                    DB.CloseConnection();
                }

                cbSchedules.Items.Add("--select user--");

                for (int i = 0; i < dtUsers.Rows.Count; i++)
                {
                    cbSchedules.Items.Add(dtUsers.Rows[i]["User"].ToString());
                }
                cbSchedules.SelectedIndex = 0;
            }

            if (string.IsNullOrEmpty(cbCustByCity.Text))
            {
                cbCustByCity.Items.Add("--select city--");
                var distinctCities = (from row in Customer.dtCustomer.AsEnumerable()
                                      select row["City"]).Distinct();
                foreach (var city in distinctCities)
                {
                    cbCustByCity.Items.Add(city);
                }
                cbCustByCity.SelectedIndex = 0;
            }
            
        }

        private void cbApptByMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtTypeByMonth = new DataTable();
            if (cbApptByMonth.SelectedIndex > 0)
            {
                if (cbSchedules.SelectedIndex > 0)
                {
                    cbSchedules.SelectedIndex = 0;
                }
                try
                {
                    DB.OpenConnection();
                    string query = "Select start as 'Start', type as 'Type' from appointment";
                    DB.Query(query);
                    DB.adp.Fill(dtTypeByMonth);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured" + ex.Message);
                }
                finally
                {
                    DB.CloseConnection();
                }

                for (int i = 0; i < dtTypeByMonth.Rows.Count; i++)
                {
                    dtTypeByMonth.Rows[i]["Start"] =
                            TimeZoneInfo.ConvertTimeFromUtc((DateTime)dtTypeByMonth.Rows[i]["Start"],
                            TimeZoneInfo.Local);
                }

                if (cbApptByMonth.SelectedIndex == 1) 
                {
                    txtReports.Text = "\rNumber of each appointment type by All Months \r\n\r\n\t";
                    for (int i = 0; i < Months.Length; i++)
                    {
                        int scrum = 0;
                        int consultation = 0;
                        int presentation = 0;

                        txtReports.Text = txtReports.Text + Months[i] + "\r\n\t";
                        for (int j = 0; j < dtTypeByMonth.Rows.Count; j++)
                        {
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
                        }
                        txtReports.Text = txtReports.Text + $"\r\n\t Scrum Appointments: {scrum} \r\n\t Presentation Appointments:" +
                              $" {presentation} \r\n\t Consultation Appointments: {consultation} \r\n\r\n\t";
                    }
                }
                else
                {
                    txtReports.Text = "\r\nNumber of each appointment type by Month of ";
                    for (int i = 0; i < Months.Length; i++)
                    {
                        if (Months[i] == cbApptByMonth.Text)
                        {
                            int scrum = 0;
                            int presentation = 0;
                            int consultation = 0;
                            txtReports.Text = txtReports.Text + Months[i].ToString() + "\r\n\r\n\t";
                            foreach (DataRow row in dtTypeByMonth.Rows)
                            {
                                
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
                            }
                            txtReports.Text = txtReports.Text + $"Consulation: {consultation} \r\n\t " +
                                   $"Presentation: {presentation}\r\n\t SCRUM: {scrum}";
                        }   
                    }
                }
            }
        }

        private void cbSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            List<Schedule> schedule = Appointment.FillSchedule();
            string user = cbSchedules.Text;
            schedule = schedule.OrderBy(x => x.schedDate).ToList();
            schedule = schedule.Where(x => x.schedUserId == user).ToList();

            if (cbSchedules.SelectedIndex > 0)
            {
                if (cbApptByMonth.SelectedIndex > 0)
                {
                    cbApptByMonth.SelectedIndex = 0;
                }
                txtReports.Text =
                    $"Consulatant Schedule for User {user} \r\n\r\n Date : Start Time : End Time : " +
                    $"Customer Name : Schedule Type \r\n\r\n";
                foreach (var appt in schedule)
                {
                    txtReports.Text = txtReports.Text + ($"{appt.schedDate}, {appt.schedStart}, {appt.schedEnd}, " +
                        $"{appt.schedCust}, {appt.schedType} \r\n");

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu form = new MainMenu();
            form.ShowDialog();
        }

        private void cbCustByCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCustByCity.SelectedIndex > 0)
            {
                txtReports.Text = $"Customers from {cbCustByCity.Text} \r\n\r\n";
                ArrayList customers = Customer.FillArray();
                //MessageBox.Show($"{customers}");
                foreach (string customer in customers)
                {
                    //string s = customer.ToString();
                    string selected = cbCustByCity.Text;
                    if (customer.ToString().Contains(selected))
                    {
                        txtReports.Text = txtReports.Text + customer.ToString() + "\r\n";
                    }
                }
            }
        }
    }
}
