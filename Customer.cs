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
using MySql.Data.MySqlClient;
using System.Configuration;

namespace J_Sarad_C969_SchedulingApp
{
    public partial class Customer : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MySqlkey"].ConnectionString;
        static MySqlConnection con = new MySqlConnection(connectionString);
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            
            con.Open();
            string query = "select customerId as 'ID', customerName as 'Name', phone as 'Phone', address as 'Address', city as 'City', country as 'Country' from customer t1 inner join address t2 on t1.addressId=t2.addressId inner join city t3 on t2.cityId=t3.cityId inner join country t4 on t3.countryId=t4.countryId";
            MySqlCommand cmd = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            dgvCustomers.DataSource = dt;
            display();

           
        }

        private void display()
        {
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCustomers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCustomers.RowHeadersVisible = false;
        }
    }
}
