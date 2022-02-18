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
    public partial class AddAppt : Form
    {
        //AddAppt Form variables
        DataTable customerSearch;
        bool validCustomer;
        bool foundCustomer;
        
        public AddAppt()
        {
            InitializeComponent();
        }

        private void AddAppt_Load(object sender, EventArgs e)
        {
            //reset current dgv Index and CurrentAppt object
            DB.currentIndex = -1;
            Appointment.CurrentApptObj = null;
            
            //create customer search table with all existing customers and related ID's and display results in dgv
            DB.OpenConnection();
            string query = "Select customerId as 'Customer Id', customerName as 'Customer Name' from customer";
            DB.Query(query);
            customerSearch = new DataTable();
            DB.adp.Fill(customerSearch);
            DB.CloseConnection();
            displayControls();
        }

        //dgv Cust Search Cell Click Events
        private void dgvCustSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //update selected appointment
            DB.currentIndex = e.RowIndex;
        }
        
        //Button Click Events
        private void btnSelectCust_Click(object sender, EventArgs e)
        {
            //set customerName text to currently selected dgv row Customer Name
            txtName.Text = dgvCustSearch.Rows[DB.currentIndex].Cells["Customer Name"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //store user selected date, start time, and end time from date time picker
            DateTime date = dtpDate.Value.Date;
            TimeSpan startTime = dtpStart.Value.TimeOfDay;
            TimeSpan endTime = dtpEnd.Value.TimeOfDay;

            //add user selected date to user selected start and end times with 00 seconds
            DateTime startAppt = date.Add(startTime).AddSeconds(-date.Add(startTime).Second);
            DateTime endAppt = date.Add(endTime).AddSeconds(-date.Add(endTime).Second);

            //get current user Id from DB.cs
            string userId = DB.currentUserID.ToString();

            //call Appointment.cs methods to check for overlapping appointments and appointments outside of 
            //business hours
            Appointment.IsOverlap(startAppt, endAppt, userId);
            Appointment.IsBusinessHours(dtpDate.Value, dtpStart.Value, dtpEnd.Value);

            //traverse dtCustomer DataTable for rows with names and IDs matching user textbox input
            foreach(DataRow row in Customer.dtCustomer.Rows)
            {
                
                if (row["Customer Name"].ToString().ToUpper() == txtName.Text.ToUpper())
                {
                    MessageBox.Show(row["Customer Name"].ToString().ToUpper() + ", " + txtName.Text.ToUpper());
                    //Update validCustomer to true if current datatable row's customer name matches user textbox
                    //input customer name
                    validCustomer = true;
                    Customer.currentCustId = row["Customer ID"].ToString();
                }
                //else
                //{
                //    validCustomer = false;
                //}
            }
            if (!validCustomer)
            {
                //show message box exception if no valid customer is found in user input
                DialogResult result = MessageBox.Show("There is no existing customer by this name,\r\n " +
                    "Would you like to add this customer?", "Invalid Customer Name", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //close AddAppt form and open AddCustomer form 
                    this.Hide();
                    AddCustomer form = new AddCustomer();
                    form.ShowDialog();
                }
            }
            //Check if user created appointement is within business hours 
            else if (!Appointment.isBusinessHours)
            {
                MessageBox.Show("Appointment on " + dtpDate.Value.ToLongDateString() + " from " +
                        dtpStart.Value.ToShortTimeString() + " to " + dtpEnd.Value.ToShortTimeString() +
                        "\nis outside of business hours and can not be set." +
                        "\n\nBusiness Hours are 8:00 AM to 5:00 PM Monday through Friday.",
                        "Appointment Outside of Business Hours");
            }
            //validate that user selected appointment times do not overlap current user appointment times
            else if (Appointment.isOverlap)
            {
                MessageBox.Show($"There is an overlapping appointment for " +
                    $"{Appointment.CurrentApptObj["User Name"]} with " +
                        $"{Appointment.CurrentApptObj["Customer Name"]} from \n " +
                        $"{Appointment.CurrentApptObj["Start Time"]} to " +
                        $"{Appointment.CurrentApptObj["End Time"]}", "Overlapping Appointment");
            }
            //validate that user selected end time is not after user selected start time for appointment
            else if (startAppt > endAppt)
            {
                MessageBox.Show("The appointment start time cannot be later than the appointment end time");
            }
            else if (startAppt == endAppt)
            {
                MessageBox.Show("The appointment start time cannot be the same as the appointment end time");
            }
            //validate that there are no empty textboxes
            else if  (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please select a Customer for this appointment",
                   "Missing Field Information");
            }
            //validate that combobox appointment type is selected
            else if (cbType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select an Appointment Type for this Appointment",
                    "Missing Field Infromation");
            }
            else
            {
                //all validations pass and new Appointment can be added to database
                DB.OpenConnection();

                string query =
                    "INSERT INTO appointment (customerId, userId, title, description, location, contact, " +
                    "type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "VALUES (@custID, @userID, @title, @description, @location, @contact, @type, @url, @start, " +
                    "@end, CURDATE(), @user, CURDATE(), @user)";
                DB.NonQuery(query);
                DB.cmd.Parameters.AddWithValue("@custID", Customer.currentCustId);
                DB.cmd.Parameters.AddWithValue("@userID", DB.currentUserID);
                DB.cmd.Parameters.AddWithValue("@title", "none");
                DB.cmd.Parameters.AddWithValue("@description", "none");
                DB.cmd.Parameters.AddWithValue("@location", "none");
                DB.cmd.Parameters.AddWithValue("@contact", "none");
                DB.cmd.Parameters.AddWithValue("@type", cbType.Text.ToString());
                DB.cmd.Parameters.AddWithValue("@url", "none");
                DB.cmd.Parameters.AddWithValue("@start", Appointment.UniversalTime(date, startTime));
                DB.cmd.Parameters.AddWithValue("@end", Appointment.UniversalTime(date, endTime));
                DB.cmd.Parameters.AddWithValue("@user", DB.currentUser.ToString());
                DB.cmd.ExecuteNonQuery();
                DB.CloseConnection();

                //close AddAppt form and open Appointments form
                this.Hide();
                Appointments form = new Appointments();
                form.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close AddAppt form and open Appointments form
            this.Hide();
            Appointments form = new Appointments();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close AddAppt form and exit program
            Application.Exit();
        }

        //search customerSearch datatable for customers by name and ID
        private void btnSearch_Click(object sender, EventArgs e)
        {
            foundCustomer = false;

            //create new datatable to store and display search results
            DataTable dtSearch = new DataTable();
            foreach (DataRow row in customerSearch.Rows)
            {
                //Traverse customerSearch datatable for customer names that contain user search textbox input
                //and assign results to dtSearch datable
                if (row["Customer Name"].ToString().ToUpper().Contains(txtSearch.Text.ToUpper()))
                {
                    dtSearch =
                        customerSearch.AsEnumerable().Where(x => x["Customer Name"].ToString().ToUpper().Contains(txtSearch.Text.ToUpper())).CopyToDataTable();
                        //lambda used to store rows from customerSearch datatable with customer names that contain user search textbox input
                    dgvCustSearch.DataSource = dtSearch;
                    foundCustomer = true;
                }
                //Traverse customerSearch datatavle for customer IDs that match user serch textbox imput and
                //assign results to dtSearch datatable
                else if (row["Customer ID"].ToString() == (txtSearch.Text))
                {
                    dtSearch =
                        customerSearch.AsEnumerable().Where(x => x["Customer ID"].ToString() == txtSearch.Text).CopyToDataTable();
                        //lambda used to store rows from customerSearch datatvle with customer IDs that match user search textbox input
                    dgvCustSearch.DataSource = dtSearch;
                    foundCustomer = true;
                }
            }
            if (!foundCustomer) 
            { 
                //display message box exception to user if user search textbox finds no matching customer 
                DialogResult result = MessageBox.Show("There is no customer matching that Name or ID. \n " +
                    "Would you like to add a new customer", "Search Found No Results", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //directs user to AddCustomer form if they need to add a new customer
                    this.Hide();
                    AddCustomer form = new AddCustomer();
                    form.ShowDialog();
                }
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            //update dgvCustSearch to display all customer names and id's in the database
            dgvCustSearch.DataSource = customerSearch;
        }
        
        //Display formatting for AddAppt Form Controls
        private void displayControls()
        {
            //dgvCustSearch formatting
            dgvCustSearch.DataSource = customerSearch;
            dgvCustSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustSearch.ReadOnly = true;
            dgvCustSearch.MultiSelect = false;
            dgvCustSearch.AllowUserToAddRows = false;
            dgvCustSearch.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            dgvCustSearch.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCustSearch.RowHeadersVisible = false;

            //cbType formatting
            cbType.Items.Add("--select Appointment Type--");
            cbType.Items.Add("Presentation");
            cbType.Items.Add("SCRUM");
            cbType.Items.Add("Consultation");
            cbType.SelectedIndex = 0;
        }
    }  
}
