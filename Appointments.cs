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
        DataTable apptTable;
        public int currentIndex;
        public Appointments()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu form = new MainMenu();
            form.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAppt form = new AddAppt();
            form.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0)
            {
                this.Hide();
                UpdateAppt form = new UpdateAppt();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select an Appointment to Update");
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            currentIndex = -1;
            DB.OpenConnection();
            string query = "select type as 'Appointment Type', userId as 'User ID', customerId as 'Customer ID', customerName as 'Name',  start as 'Appointment Time' from customer join appointment using (customerId)";
            DB.Query(query);
            apptTable = new DataTable();
            DB.adp.Fill(apptTable);
            //DB.FillTable(query);
            DB.CloseConnection();
            displayDGV();
        }

        private void displayDGV()
        {
            dgvAppointments.DataSource = apptTable;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.MultiSelect = false;
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAppointments.RowHeadersVisible = false;
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIndex = e.RowIndex;
        }
    }
}
