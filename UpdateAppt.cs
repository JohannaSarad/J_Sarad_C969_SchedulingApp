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
    public partial class UpdateAppt : Form
    {
        public UpdateAppt()
        {
            InitializeComponent();
        }


        private void UpdateAppt_Load(object sender, EventArgs e)
        {

            cbType.Items.Add("Presentation");
            cbType.Items.Add("SCRUM");
            cbType.Items.Add("Consultation");
            using (Appointments apptForm = (Appointments)Application.OpenForms["Appointments"])
            {
                txtUserID.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["User ID"].Value.ToString().Trim();
                txtCustID.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["Customer ID"].Value.ToString().Trim();
                txtName.Text = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells["Name"].Value.ToString();
                //dtpDate.Value = apptForm.dgvAppointments.Rows[DB.currentIndex].Cells[""]
            }
        }

       
    }
}
