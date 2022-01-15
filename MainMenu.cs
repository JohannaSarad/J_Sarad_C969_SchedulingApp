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
        DataTable calendar = new DataTable();
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnEditCust_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers form = new Customers();
            form.ShowDialog();
        }
    }
}
