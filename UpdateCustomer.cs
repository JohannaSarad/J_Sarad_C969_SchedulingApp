using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_Sarad_C969_SchedulingApp
{
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            Customers custForm = (Customers)Application.OpenForms["Customers"];
            //txtCustID.Text = dgvCustomers.Rows[currentIndex].Cells["ID"].Value.ToString().Trim();
            txtName.Text = (string)custForm.dgvCustomers.Rows[custForm.currentIndex].Cells["Name"].Value.ToString();
            txtAddress.Text = (string)custForm.dgvCustomers.Rows[custForm.currentIndex].Cells["Address"].Value.ToString().Trim();
            txtPhone.Text = (string)custForm.dgvCustomers.Rows[custForm.currentIndex].Cells["Phone"].Value.ToString();
            txtCity.Text = (string)custForm.dgvCustomers.Rows[custForm.currentIndex].Cells["City"].Value.ToString();
            txtCountry.Text = (string)custForm.dgvCustomers.Rows[custForm.currentIndex].Cells["Country"].Value.ToString();
        }
    }
}
