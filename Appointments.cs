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
    //FIX ME!!! clear dgv before no type or id found alerts
    //FIX ME!!! Appointments should only show appointments for the current user.
    //You're probably going to have to make another table for this.
    
    public partial class Appointments : Form
    {
        //
        DataTable dtUserAppts;
        
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
            Appointment.CurrentApptID = dgvAppointments.Rows[DB.currentIndex].Cells["Appointment ID"].Value.ToString();
            
            //update current appointment object in UpdateAppointments method based on Appt ID
            appointment.UpdateAppointment(Appointment.CurrentApptID);
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
                DialogResult result = MessageBox.Show("Are you sure you would like to delete this appointment?", " ",
                    MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
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
                DB.currentIndex = -1;
                dgvAppointments.ClearSelection();
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
                cbCustId.SelectedIndex = 0;
                bool typeFound = false;
                DataTable dtFiltered = new DataTable();

                //fill dtFiltered with all Appointments
                //
                dtFiltered = dtUserAppts.AsEnumerable().CopyToDataTable();
                //dtFiltered = Appointment.dtAppointments.AsEnumerable().CopyToDataTable();

                foreach (DataRow row in Appointment.dtAppointments.Rows)
                {
                    if (row["Appointment Type"].ToString() == cbApptType.Text)
                    {
                        //type found, fill dtFiltered with appointments matching selected type
                        typeFound = true;
                        
                        dtFiltered = dtUserAppts.AsEnumerable().Where(x => x["Appointment Type"].ToString() == cbApptType.Text).CopyToDataTable();
                        //dtFiltered = Appointment.dtAppointments.AsEnumerable().Where(x => x["Appointment Type"].ToString() == cbApptType.Text).CopyToDataTable();
                        //lambda used to store rows from dtCurrentUserAppt datatable with appointment types that match the selected value of Type combobox
                    }
                }
                if (!typeFound)
                {
                    //no matching appointment was found, display nothing
                    dtFiltered.Clear();
                    MessageBox.Show("There were no appointments of this type");
                }
                dgvAppointments.DataSource = dtFiltered;
                displayDGV();
                DB.currentIndex = -1;
                dgvAppointments.ClearSelection();
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
                cbApptType.SelectedIndex = 0;
                bool custIDFound = false;
                DataTable dtFiltered = new DataTable();

                //fill dtFiltered with all appointments
                //
                dtFiltered = dtUserAppts.AsEnumerable().CopyToDataTable();
                //dtFiltered = Appointment.dtAppointments.AsEnumerable().CopyToDataTable();

                foreach (DataRow row in Appointment.dtAppointments.Rows)
                {
                    if (row["Customer ID"].ToString() == cbCustId.Text)
                    {
                        //id found, fill dtFiltered with appointments matching selected id
                        custIDFound = true;
                        //
                        dtFiltered = dtUserAppts.AsEnumerable().Where(x => x["Customer ID"].ToString() == cbCustId.Text).CopyToDataTable();
                        //dtFiltered = Appointment.dtAppointments.AsEnumerable().Where(x => x["Customer ID"].ToString() == cbCustId.Text).CopyToDataTable();
                        //lambda used to store rows from dtCurrentUserAppt datatable with appointment types that match the selected value of Type combobox
                    }
                }
                if(!custIDFound) 
                {
                    //no matching id was found, display nothing
                    dtFiltered.Clear();
                    MessageBox.Show("There are no appointments for this customer");
                }
                dgvAppointments.DataSource = dtFiltered;
                displayDGV();
                DB.currentIndex = -1;
                dgvAppointments.ClearSelection();
            }
            else
            {
                //show all appointments
                displayControls();
            }
        }

        // display formatting
        private void displayControls()
        {
            //Filling Appointmnents may not be necessary here after change
            if (Appointment.dtAppointments != null)
            {
                Appointment.dtAppointments.Clear();
            }
            Appointment.FillAppointments();

            dtUserAppts = new DataTable();
            dtUserAppts = Appointment.dtAppointments.Clone();
            foreach (DataRow row in Appointment.dtAppointments.Rows)
            {
                if (row["User ID"].ToString() == DB.currentUserID.ToString())
                {
                    dtUserAppts.ImportRow(row);
                }
            }

            dgvAppointments.DataSource = dtUserAppts;
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
            dgvAppointments.Columns["User ID"].Visible = false;
            dgvAppointments.Columns["User Name"].Visible = false;
            dgvAppointments.Columns["Date"].DisplayIndex = 0;
            dgvAppointments.Columns["Start Time"].DisplayIndex = 1;
            dgvAppointments.Columns["End Time"].DisplayIndex = 2;
            dgvAppointments.Columns["Appointment Type"].DisplayIndex = 3;
            dgvAppointments.Columns["Customer Name"].DisplayIndex = 4;
            dgvAppointments.Columns["Customer Id"].DisplayIndex = 5;
            dgvAppointments.Columns["Appointment ID"].DisplayIndex = 6;
            
            dgvAppointments.ClearSelection();

            lblApptGreeting.Text = ($"Appointments for User {DB.currentUser}");

            //cbApptType formatting
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

        private void displayDGV ()
        {
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
            dgvAppointments.Columns["User ID"].Visible = false;
            dgvAppointments.Columns["User Name"].Visible = false;
            dgvAppointments.Columns["Date"].DisplayIndex = 0;
            dgvAppointments.Columns["Start Time"].DisplayIndex = 1;
            dgvAppointments.Columns["End Time"].DisplayIndex = 2;
            dgvAppointments.Columns["Appointment Type"].DisplayIndex = 3;
            dgvAppointments.Columns["Customer Name"].DisplayIndex = 4;
            dgvAppointments.Columns["Customer Id"].DisplayIndex = 5;
            dgvAppointments.Columns["Appointment ID"].DisplayIndex = 6;
        }
    }

}
