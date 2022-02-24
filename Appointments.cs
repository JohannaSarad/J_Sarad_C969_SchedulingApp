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
        //FiX ME!!! in cbApptType_SelectedIndexChanged and cbCustId_SelectedIndexChanged there needs to be a 
        //working option that clears the dgv if the type or id is not found but leaves the collumns of the dgv
        //intact

        //public DataTable dtCurrentUserAppt;

        //create an instance of Appointment
        Appointment appointment = new Appointment();

        public Appointments()
        {
            InitializeComponent();
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            //reset global variables
            DB.currentIndex = -1;
            //DB.currentApptId = null;

            displayControls();
        }

        //dgvAppointments Cell Click Event
        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //update current Index to selected dgv row index
            DB.currentIndex = e.RowIndex;
            
            //update global appointment ID selected 
            appointment.CurrentApptID = dgvAppointments.Rows[DB.currentIndex].Cells["Appointment ID"].Value.ToString();
            
            //update current appointment object in UpdateAppointments method based on Appt ID
            appointment.UpdateAppointment(appointment.CurrentApptID);
            //updating the static appointmentObj (this should be the same everywhere)
        }

        //Button Click Events
        private void btnMenu_Click(object sender, EventArgs e)
        {
            //close Appointment Form and open MainMenu Form
            this.Hide();
            MainMenu form = new MainMenu();
            form.ShowDialog();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //close Appointment Form and open AddAppt Form
            this.Hide();
            AddAppt form = new AddAppt();
            form.ShowDialog();
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //close Appointment Form and open UpdateAppt Form if a row is selected in dgvAppointments
            if (DB.currentIndex >= 0)
            {
                this.Hide();
                UpdateAppt form = new UpdateAppt();
                form.ShowDialog();
            }
            //show exception if there is no row selected in dgvAppointments to update
            else
            {
                MessageBox.Show("Please Select an Appointment to Update");
            }
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close Appointment form and exit program
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete selected row in dgvAppointments from database if a row is selected. 
            if (DB.currentIndex >= 0)
            {
                try
                {
                    DB.OpenConnection();
                    string query = "DELETE FROM appointment WHERE appointmentId = @appointmentID";
                    DB.NonQuery(query);
                    DB.cmd.Parameters.AddWithValue("@appointmentID", Appointment.CurrentApptObj["Appointment ID"]);
                    DB.cmd.ExecuteNonQuery();
                    displayControls();
                    DB.currentIndex = -1;
                    dgvAppointments.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured!" + ex.Message);
                }
                finally
                {
                    DB.CloseConnection();
                }
                
            }
            else
            {
                //Show error message if no row is selected
                MessageBox.Show("Please Select an Appointment to Delete");
            }
        }

        
        //ComboBox Selected Index Changed Events
        
        private void cbApptType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbApptType.SelectedIndex > 0)
            {
                bool typeFound = false;
                DataTable dtFiltered = new DataTable();
                //dtFiltered = dtCurrentUserAppt.AsEnumerable().CopyToDataTable();
                dtFiltered = Appointment.dtAppointments.AsEnumerable().CopyToDataTable();
                //foreach (DataRow row in dtCurrentUserAppt.Rows)
                foreach (DataRow row in Appointment.dtAppointments.Rows)

                {
                    //Traverse dtCurrentuserAppt datatable for Appointment types that contain type combo box selected value
                    //and assign results to dtFiltered datable
                    if (row["Appointment Type"].ToString() == cbApptType.Text)
                    {
                        cbCustId.SelectedIndex = 0;
                        //dtFiltered = dtCurrentUserAppt.AsEnumerable().Where(x => x["Appointment Type"].ToString() == cbApptType.Text).CopyToDataTable();
                        dtFiltered = Appointment.dtAppointments.AsEnumerable().Where(x => x["Appointment Type"].ToString() == cbApptType.Text).CopyToDataTable();
                        //lambda used to store rows from dtCurrentUserAppt datatable with appointment types that match the selected value of Type combobox

                        DB.currentIndex = -1;
                        dgvAppointments.ClearSelection();
                    }
                }
                if (!typeFound)
                {
                    //no matching appointment was found, display nothing
                    dtFiltered.Clear();
                    //dgvAppointments.Rows.Clear();
                }
                dgvAppointments.DataSource = dtFiltered;
            }
            else
            {
                //show all appointments
                displayControls();
            }
        }
        private void cbCustId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCustId.SelectedIndex > 0)
            {
                bool custIDFound = false;
                DataTable dtFiltered = new DataTable();
                //dtFiltered = dtCurrentUserAppt.AsEnumerable().CopyToDataTable();
                dtFiltered = Appointment.dtAppointments.AsEnumerable().CopyToDataTable();

                //foreach (DataRow row in dtCurrentUserAppt.Rows)
                foreach (DataRow row in Appointment.dtAppointments.Rows)
                    {
                    //    //Traverse dtCurrentuserAppt datatable for Customer IDs that match type combobox selected value
                    //    //and assign results to dtFiltered datable
                    if (row["Customer ID"].ToString() == cbCustId.Text)
                    {
                        cbApptType.SelectedIndex = 0;
                        //fill dtFiltered Data table with dt CurrentUser Appt filtered results
                        //dtFiltered = dtCurrentUserAppt.AsEnumerable().Where(x => x["Customer ID"].ToString() == cbCustId.Text).CopyToDataTable();
                        dtFiltered = Appointment.dtAppointments.AsEnumerable().Where(x => x["Customer ID"].ToString() == cbCustId.Text).CopyToDataTable();
                        //lambda used to store rows from dtCurrentUserAppt datatable with appointment types that match the selected value of Type combobox
                        custIDFound = true;
                        DB.currentIndex = -1;
                        dgvAppointments.ClearSelection();
                    }
                }
                if(!custIDFound) 
                {
                    //no matching appointment was found, display nothing
                    dtFiltered.Clear();
                    //dgvAppointments.DataSource = dtFiltered;
                }
                dgvAppointments.DataSource = dtFiltered;
            }
            else
            {
                //show all appointments
                displayControls();
            }
        }

        //Appointment Form control display formatting
        private void displayControls()
        {
            //Fix me!!! may want to clear Appointment.dtAppointments table before doing this
            if (Appointment.dtAppointments != null)
            {
                Appointment.dtAppointments.Clear();
            }
            Appointment.FillAppointments();
            //dtCurrentUserAppt = new DataTable();
            //dtCurrentUserAppt = Appointment.dtAppointments.Clone();
            //foreach (DataRow row in Appointment.dtAppointments.Rows)
            //{
            //    if (row["User ID"].ToString() == DB.currentUserID.ToString())
            //    {
            //        dtCurrentUserAppt.ImportRow(row);
            //    }
            //}

            //dgvAppointments.DataSource = dtCurrentUserAppt;
            dgvAppointments.DataSource = Appointment.dtAppointments;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.MultiSelect = false;
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvAppointments.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvAppointments.Columns["Start Time"].DefaultCellStyle.Format = "hh:mm tt";
            dgvAppointments.Columns["End Time"].DefaultCellStyle.Format = "hh:mm tt";
            dgvAppointments.ClearSelection();

            //cbAPptType formatting
            if (string.IsNullOrEmpty(cbApptType.Text))
            {
                cbApptType.Items.Add("All Types");
                cbApptType.Items.Add("Presentation");
                cbApptType.Items.Add("SCRUM");
                cbApptType.Items.Add("Consultation");
                cbApptType.SelectedIndex = 0;
            }

            //cbCustId formatting
            if (string.IsNullOrEmpty(cbCustId.Text))
            {
                DataTable dtCustId = new DataTable();
                try
                {
                    DB.OpenConnection();
                    string query = "select customerID as 'Customer ID' from customer";
                    DB.Query(query);
                    //DataTable dtCustId = new DataTable();
                    DB.adp.Fill(dtCustId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occured!" + ex.Message);
                }
                finally
                {
                    DB.CloseConnection();
                }

                cbCustId.Items.Add("All Customers");

                for (int i = 0; i < dtCustId.Rows.Count; i++)
                {
                    cbCustId.Items.Add(dtCustId.Rows[i]["Customer ID"].ToString());
                }
                cbCustId.SelectedIndex = 0;
            }
        }
    }
}
