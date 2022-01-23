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
        DateTime calDate = DateTime.Now;
        
        
        DataTable calendar = new DataTable();
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            DB.currentIndex = -1;
            
            DB.OpenConnection();
            string query = "select type as 'Appointment Type', userId as 'User ID', customerId as 'Customer ID', customerName as 'Name',  start as 'Appointment Time' from customer join appointment using (customerId)";
            DB.Query(query);
            calendar = new DataTable();
            DB.adp.Fill(calendar);

            DB.CloseConnection();
            display();
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
            calDate = this.monthCal.SelectionStart;
            MessageBox.Show(calDate.ToString());

            int day = (int)currentDate.DayOfWeek;

            //MessageBox.Show(week);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            MessageBox.Show(currentDate.ToString());
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.ToLocalTime();
            MessageBox.Show(currentDate.ToString());
        }

        private void btnUTC_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.UtcNow;
            MessageBox.Show(currentDate.ToString());
        }

        private void dgvCalendar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DB.currentIndex = e.RowIndex;
        }

        private void display()
        {
            dgvCalendar.DataSource = calendar;
            dgvCalendar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalendar.ReadOnly = true;
            dgvCalendar.MultiSelect = false;
            dgvCalendar.AllowUserToAddRows = false;
            dgvCalendar.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCalendar.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCalendar.RowHeadersVisible = false;
            dgvCalendar.Columns["Appointment Time"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
        }
    }
}
