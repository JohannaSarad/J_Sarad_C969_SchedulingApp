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
    //FIX ME!!! clean up sql statments and make sure names of dgv columns all match throughout
    public partial class MainMenu : Form
    {
        //global instances and variables
        DateTime currentDate = DateTime.Now;
        DataTable calendar = new DataTable();
        bool isMonth;
        bool isWeek;
        
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //variable and property initialization
            DB.currentIndex = -1;
            isWeek = false;
            isMonth = false;
            
            //call to show all appointments in dgvCalendar and display for all form controls
            ShowAll();
            displayControls();
            MessageBox.Show($"{currentDate.DayOfWeek}" + ", " + $"{currentDate.ToShortTimeString()}");
        }

        //Button Click Events
        
        private void btnEditCust_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers form = new Customers();
            form.ShowDialog();
        }

        private void btnUpdateAppt_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appointments form = new Appointments();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*bolds dates in monthCalendar based on cbMonth selection and displays corresponding appointments in 
         * dgvCalender based on whether they are by all appointments, appointments in selected month, or 
         * appointments in selected week */

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            currentDate = this.monthCal.SelectionStart;
            if (isWeek)
            {
                ShowWeek();
            }
            else if (isMonth)
            {
                ShowMonth();
            }
            else
            {
                ShowAll();
            }
        }
        
        private void dgvCalendar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DB.currentIndex = e.RowIndex;
            
        }

        //Form displays

        //display format for Data Grid View dgvCalendar, monthCalendar cbMonthWeek, and combobox cbMonthWeek
        private void displayControls()
        {
            dgvCalendar.DataSource = calendar;
            dgvCalendar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalendar.ReadOnly = true;
            dgvCalendar.MultiSelect = false;
            dgvCalendar.AllowUserToAddRows = false;
            dgvCalendar.DefaultCellStyle.SelectionBackColor = this.dgvCalendar.DefaultCellStyle.BackColor;
            dgvCalendar.DefaultCellStyle.SelectionForeColor = this.dgvCalendar.DefaultCellStyle.ForeColor; 
            dgvCalendar.RowHeadersVisible = false;
            dgvCalendar.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvCalendar.Columns["Time"].DefaultCellStyle.Format = "hh:mm tt";

            cbMonthWeek.Text = "All Appointments";
            cbMonthWeek.Items.Add("All Appointments");
            cbMonthWeek.Items.Add("Month");
            cbMonthWeek.Items.Add("Week");

            monthCal.AddBoldedDate(currentDate);
            monthCal.UpdateBoldedDates();
        }

        //displays time and date in local timezone. May not be necessary in this case. 
        private void displayLocalTime()
        {
            for (int i = 0; i < calendar.Rows.Count; i++)
            {
                calendar.Rows[i]["Date"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)calendar.Rows[i]["Date"],
                    TimeZoneInfo.Local);
                calendar.Rows[i]["Time"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)calendar.Rows[i]["Time"],
                    TimeZoneInfo.Local);
            }
        }

        //dgv and month Calendar event updates

        //Selects and bolds date from month calendar, and shows all appointments in dgvCalender
        private void ShowAll()
        {
            //clears dataTable calendar and monthCalendar data
            calendar.Clear();
            monthCal.RemoveAllBoldedDates();
            
            //bolds the currently selected date in month calendar
            monthCal.AddBoldedDate(currentDate);
            monthCal.UpdateBoldedDates();

            //Selects values from database and displays them in dgvCalendar in Local Time. 
            DB.OpenConnection();
            string query =
                "select appointmentId as 'Appointment ID', type as 'Type', customerId as 'Customer ID', " +
                "customerName as 'Customer Name',  start as 'Date', start as 'Time' " +
                "from customer join appointment using (customerId) order by appointmentId";
            DB.Query(query);
            DB.adp.Fill(calendar);
            displayLocalTime();
            dgvCalendar.DataSource = calendar;
        }

        /*Selects week from month calendar, bolds all dates of week that selected day is in and displays any
         * appointments in that date range in dgvCalendar*/

        private void ShowWeek()
        {
            //clears dataTable calendar and monthCalendar data
            monthCal.RemoveAllBoldedDates();
            calendar.Clear();

            /*creates start and end dates of week from monthCalender click currentDate and converts them from
             * string to DateTime */
            int day = (int)currentDate.DayOfWeek;
            string start = currentDate.AddDays(-day).ToString();
            string end = currentDate.AddDays(-day + 7).ToString();
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            
            //bolds days of selected week in MonthCalendar
            for (int i = 0; i < 7; i++)
            {
                monthCal.AddBoldedDate(startDate.AddDays(i));
            }
            monthCal.UpdateBoldedDates();
            
            //Selects values from database and displays them in dgvCalendar in Local Time. 
            DB.OpenConnection();
            string query =
                "select appointmentId as 'Appointment ID', type as 'Type', customerId as 'Customer ID', " +
                "customerName as 'Customer Name', start as 'Date', start as 'Time' " +
                "from customer join appointment using (customerId) " +
                "where start BETWEEN @start AND @end order by start";
            DB.Query(query);
            DB.cmd.Parameters.AddWithValue("@start", startDate);
            DB.cmd.Parameters.AddWithValue("@end", endDate);
            DB.adp.Fill(calendar);
            DB.CloseConnection();
            displayLocalTime();
            dgvCalendar.DataSource = calendar;
        }

        /*Selects month from month calendar, bolds all dates of month that selected day is in and displays any
         * appointments in that date range in dgvCalendar*/
        private void ShowMonth()
        {
            //clears dataTable calendar and monthCalendar data
            monthCal.RemoveAllBoldedDates();
            calendar.Clear();

            /*creates start and end dates of month from monthCalender click currentDate and converts them from
             * string to DateTime */
            int month = (int)currentDate.Month;
            int year = (int)currentDate.Year;
            int nextMonth = month + 1;
            string start = (year.ToString() + "-" + month.ToString() + "-" + "01");
            string end = (year.ToString() + "-" + nextMonth.ToString() + "-" + "01");
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            var daysInMonth = (endDate - startDate).TotalDays;

            //bolds days of selected month in MonthCalendar
            for (var i = 0; i <= daysInMonth; i++)
            {
                monthCal.AddBoldedDate(startDate.AddDays(i));
            }
            monthCal.UpdateBoldedDates();

            //Selects values from database and displays them in dgvCalendar in Local Time.
            DB.OpenConnection();
            string query = 
                "select appointmentId as 'Appointment ID', type as 'Appointment Type', userId as 'User ID', " +
                "customerId as 'Customer ID', customerName as 'Name', start as 'Date', start as 'Time' " +
                "from customer join appointment using (customerId) " +
                "where start BETWEEN @start AND @end order by start";
            DB.Query(query);
            DB.cmd.Parameters.AddWithValue("@start", start);
            DB.cmd.Parameters.AddWithValue("@end", endDate);
            //calendar = new DataTable();
            DB.adp.Fill(calendar);
            DB.CloseConnection();
            displayLocalTime();
            dgvCalendar.DataSource = calendar;
        }

        private void cbMonthWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonthWeek.Text == "All Appointments")
            {
                ShowAll();
                isMonth = false;
                isWeek = false;
            }
            else if (cbMonthWeek.Text == "Month")
            {
                calendar.Clear();
                isMonth = true;
                isWeek = false;
                ShowMonth();
            }
            else
            {
                isWeek = true;
                isMonth = false;
                ShowWeek();
            }
        }

       
    }
}


