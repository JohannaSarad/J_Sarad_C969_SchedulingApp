using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using J_Sarad_C969_SchedulingApp.model;


namespace J_Sarad_C969_SchedulingApp
{
   
    public partial class MainMenu : Form
    {
        //global instances and variables
        DateTime currentDate = DateTime.Now;
        
        public bool isMonth;
        public bool isWeek;
        
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

            //Fill global data tables
            Appointment.FillAppointments();
            Customer.FillCustomer();
            
            //call to show all appointments in dgvCalendar and display for all form controls
            ShowAll();
            //DB.OverrideCulture();
            displayControls();
        }

        //Button Click Events
        private void btnEditCust_Click(object sender, EventArgs e)
        {
            //close MainMenu form and open Customers form
            this.Hide();
            Customers form = new Customers();
            form.ShowDialog();
        }

        private void btnUpdateAppt_Click(object sender, EventArgs e)
        {
            //close MainMenu form and open UpdateAppt form
            this.Hide();
            Appointments form = new Appointments();
            form.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //close MainMenu form and open Reports form
            this.Hide();
            Reports form = new Reports();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close MainMenu form and exit program
            Application.Exit();
        }



        /*bolds dates in monthCalendar based on cbMonth selection and displays corresponding appointments
         * (All, by month, by week) in dgvCalender */

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            currentDate = this.monthCal.SelectionStart;
            if (isWeek)
            {
                //get all appointments for week of selected monthCalender date and display in dgv calendar
                ShowWeek();
            }
            else if (isMonth)
            {
                //get all appoinments for month of selected monthCalendar date and display in dgv calendar
                ShowMonth();
            }
            else
            {
                //show all appointments in dgv calendar
                ShowAll();
            }
        }
        
        //dgv and month Calendar event updates

        //select and bolds date from month calendar, and shows all appointments in dgvCalender
        private void ShowAll()
        {
            //clears dataTable and monthCalendar data
            Appointment.dtAppointments.Clear();
            monthCal.RemoveAllBoldedDates();
            
            //bolds the currently selected date in month calendar
            monthCal.AddBoldedDate(currentDate);
            monthCal.UpdateBoldedDates();

            //Fill Appointment.dtAppointments with all appointments
            Appointment.FillAppointments();

            //display updated controls
            displayControls();
        }

        /*Selects week from month calendar, bolds all dates of week that selected day is in and displays any
         * appointments in that date range in dgvCalendar*/

        private void ShowWeek()
        {
            //clears dataTable calendar and monthCalendar data
            monthCal.RemoveAllBoldedDates();
            //calendar.Clear();
            Appointment.dtAppointments.Clear();

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

            //Fill Appointment.dtAppointments with dates between start and end date
            Appointment.FillAppointmentsByDate(startDate, endDate);

            //display updated controls
            displayControls();
        }

        /*Selects month from month calendar, bolds all dates of month that selected day is in and displays any
         * appointments in that date range in dgvCalendar*/
        private void ShowMonth()
        {
            //clears dataTable and monthCalendar data
            monthCal.RemoveAllBoldedDates();
            Appointment.dtAppointments.Clear();

            //start and end dates of month from monthCalender click currentDate and converts them from
            // string to DateTime 
           
            int month = (int)currentDate.Month;
            int year = (int)currentDate.Year;
            int nextMonth;
            int nextYear;
            string start;
            string end;
            if (month == 12)
            {
                nextMonth = 1;
                nextYear = year + 1;
                start = (year.ToString() + "-" + month.ToString() + "-" + "01");
                end = (nextYear.ToString() + "-" + nextMonth.ToString() + "-" + "01");
            }
            else
            {
                nextMonth = month + 1;
                start = (year.ToString() + "-" + month.ToString() + "-" + "01");
                end = (year.ToString() + "-" + nextMonth.ToString() + "-" + "01");
            }
            
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            var daysInMonth = (endDate - startDate).TotalDays;
            //MessageBox.Show($"{startDate}, {endDate}");

            //bolds days of selected month in MonthCalendar
            for (var i = 0; i <= daysInMonth; i++)
            {
                monthCal.AddBoldedDate(startDate.AddDays(i));
            }
            monthCal.UpdateBoldedDates();

            //Fill Appointment.dtAppointments with appointments between start and end dates
            Appointment.FillAppointmentsByDate(startDate, endDate);
            
            //display updated controls
            displayControls();
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
                //calendar.Clear();
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



        //display formatting
        private void displayControls()
        {
            
            //dgvCalendar formatting
            dgvCalendar.DataSource = Appointment.dtAppointments;
            dgvCalendar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalendar.ReadOnly = true;
            dgvCalendar.MultiSelect = false;
            dgvCalendar.AllowUserToAddRows = false;
            dgvCalendar.DefaultCellStyle.SelectionBackColor = this.dgvCalendar.DefaultCellStyle.BackColor;
            dgvCalendar.DefaultCellStyle.SelectionForeColor = this.dgvCalendar.DefaultCellStyle.ForeColor;
            dgvCalendar.RowHeadersVisible = false;
            dgvCalendar.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvCalendar.Columns["Start Time"].DefaultCellStyle.Format = "hh:mm tt";
            dgvCalendar.Columns["End Time"].DefaultCellStyle.Format = "hh:mm tt";
            dgvCalendar.Columns["Appointment ID"].Visible = false;
            dgvCalendar.Columns["User ID"].Visible = false;
            dgvCalendar.Columns["Customer ID"].Visible = false;
            dgvCalendar.Columns["Date"].DisplayIndex = 0;
            dgvCalendar.Columns["Start Time"].DisplayIndex = 1;
            dgvCalendar.Columns["End Time"].DisplayIndex = 2;
            dgvCalendar.Columns["Customer Name"].DisplayIndex = 3;
            dgvCalendar.Columns["User Name"].DisplayIndex = 4;
            dgvCalendar.Columns["Appointment Type"].DisplayIndex = 5;

            //cbMonthWeek formatting
            if (string.IsNullOrEmpty(cbMonthWeek.Text))
            {
                cbMonthWeek.Items.Add("All Appointments");
                cbMonthWeek.Items.Add("Month");
                cbMonthWeek.Items.Add("Week");
                cbMonthWeek.SelectedIndex = 0;
            }

            //bolded dates update for monthCalendat
            monthCal.AddBoldedDate(currentDate);
            monthCal.UpdateBoldedDates();

            //greeting with name of current user
            lblGreeting.Text = ($"Welcome {DB.currentUser}. What can I help you with today?");
        }
    }
}


