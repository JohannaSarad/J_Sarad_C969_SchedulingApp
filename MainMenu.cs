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
    public partial class MainMenu : Form
    {
        DateTime currentDate = DateTime.Now;
        bool isMonth;
        bool isWeek;
        
        DataTable calendar = new DataTable();
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            DB.currentIndex = -1;
            isWeek = false;
            isMonth = false;
            
            ShowAll();
            displayControls();
        }

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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            currentDate = this.monthCal.SelectionStart;
            if (isWeek)
            {
                ShowWeek();
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

        private void displayControls()
        {
            dgvCalendar.DataSource = calendar;
            dgvCalendar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalendar.ReadOnly = true;
            dgvCalendar.MultiSelect = false;
            dgvCalendar.AllowUserToAddRows = false;
            dgvCalendar.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCalendar.DefaultCellStyle.SelectionForeColor = Color.Black;
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

        private void ShowAll()
        {
            calendar.Clear();
            monthCal.RemoveAllBoldedDates();
            monthCal.AddBoldedDate(currentDate);
            monthCal.UpdateBoldedDates();
            DB.OpenConnection();
            string query =
                "select type as 'Appointment Type', userId as 'User ID', customerId as 'Customer ID', " +
                "customerName as 'Name',  start as 'Date', start as 'Time' from customer join appointment " +
                "using (customerId)";
            DB.Query(query);
            //calendar = new DataTable();
           
            DB.adp.Fill(calendar);
            displayLocalTime();
            dgvCalendar.DataSource = calendar;
        }

        private void ShowWeek()
        {
            monthCal.RemoveAllBoldedDates();
            calendar.Clear();
            int day = (int)currentDate.DayOfWeek;
            string start = currentDate.AddDays(-day).ToString();
            string end = currentDate.AddDays(-day + 7).ToString();
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            
            for (int i = 0; i < 7; i++)
            {
                monthCal.AddBoldedDate(startDate.AddDays(i));
            }
            monthCal.UpdateBoldedDates();
            
            DB.OpenConnection();
            string query =
                "select type as 'Appointment Type', userId as 'User ID', customerId as 'Customer ID', " +
                "customerName as 'Name', start as 'Date', start as 'Time' " +
                "from customer join appointment using (customerId) " +
                "where start BETWEEN @start AND @end";
            DB.Query(query);
            DB.cmd.Parameters.AddWithValue("@start", startDate);
            DB.cmd.Parameters.AddWithValue("@end", endDate);
            calendar = new DataTable();
            DB.adp.Fill(calendar);
            DB.CloseConnection();
            displayLocalTime();
            dgvCalendar.DataSource = calendar;
        }

        private void cbMonthWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int day = (int)currentDate.DayOfWeek;
            //monthCal.AddBoldedDate(currentDate);
            if (cbMonthWeek.Text == "All Appointments")
            {
                //displayLocalTime();
                ShowAll();
                isMonth = false;
                isWeek = false;
            }
            else if (cbMonthWeek.Text == "Month")
            {
                //Appointments.ShowMonth();
                isMonth = true;
                isWeek = false;
                int Month = (int)currentDate.Month;
                MessageBox.Show($"{Month}");
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
