
namespace J_Sarad_C969_SchedulingApp
{
    partial class AddAppt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCustID = new System.Windows.Forms.Label();
            this.dgvCustSearch = new System.Windows.Forms.DataGridView();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSelectCust = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblstartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblHM = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblMDY = new System.Windows.Forms.Label();
            this.lblHM2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(160, 29);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(200, 21);
            this.cbType.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(44, 32);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(93, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Appointment Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(44, 163);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Customer Name";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(44, 79);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(43, 13);
            this.lblUserId.TabIndex = 8;
            this.lblUserId.Text = "User ID";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(160, 160);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 10;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/dd/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(160, 202);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(90, 20);
            this.dtpDate.TabIndex = 11;
            this.dtpDate.Value = new System.DateTime(2022, 3, 18, 0, 0, 0, 0);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(44, 206);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(92, 13);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Appointment Date";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(265, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblCustID
            // 
            this.lblCustID.AutoSize = true;
            this.lblCustID.Location = new System.Drawing.Point(44, 119);
            this.lblCustID.Name = "lblCustID";
            this.lblCustID.Size = new System.Drawing.Size(65, 13);
            this.lblCustID.TabIndex = 15;
            this.lblCustID.Text = "Customer ID";
            // 
            // dgvCustSearch
            // 
            this.dgvCustSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustSearch.Location = new System.Drawing.Point(403, 79);
            this.dgvCustSearch.Name = "dgvCustSearch";
            this.dgvCustSearch.Size = new System.Drawing.Size(386, 194);
            this.dgvCustSearch.TabIndex = 16;
            this.dgvCustSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustSearch_CellClick);
            // 
            // txtCustID
            // 
            this.txtCustID.Location = new System.Drawing.Point(160, 119);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.ReadOnly = true;
            this.txtCustID.Size = new System.Drawing.Size(200, 20);
            this.txtCustID.TabIndex = 17;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(400, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(159, 13);
            this.lblSearch.TabIndex = 18;
            this.lblSearch.Text = "Search Customer by Name or ID";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(714, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(569, 49);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(139, 20);
            this.txtSearch.TabIndex = 20;
            // 
            // btnSelectCust
            // 
            this.btnSelectCust.Location = new System.Drawing.Point(618, 289);
            this.btnSelectCust.Name = "btnSelectCust";
            this.btnSelectCust.Size = new System.Drawing.Size(171, 23);
            this.btnSelectCust.TabIndex = 21;
            this.btnSelectCust.Text = "Select Customer";
            this.btnSelectCust.UseVisualStyleBackColor = true;
            this.btnSelectCust.Click += new System.EventHandler(this.btnSelectCust_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(160, 72);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(200, 20);
            this.txtUserID.TabIndex = 22;
            // 
            // lblstartTime
            // 
            this.lblstartTime.AutoSize = true;
            this.lblstartTime.Location = new System.Drawing.Point(44, 243);
            this.lblstartTime.Name = "lblstartTime";
            this.lblstartTime.Size = new System.Drawing.Size(55, 13);
            this.lblstartTime.TabIndex = 23;
            this.lblstartTime.Text = "Start Time";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(44, 280);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 13);
            this.lblEndTime.TabIndex = 24;
            this.lblEndTime.Text = "End Time";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(714, 344);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // lblHM
            // 
            this.lblHM.AutoSize = true;
            this.lblHM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHM.Location = new System.Drawing.Point(276, 249);
            this.lblHM.Name = "lblHM";
            this.lblHM.Size = new System.Drawing.Size(90, 13);
            this.lblHM.TabIndex = 40;
            this.lblHM.Text = "Hour:Min AM/PM";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "HH:mm tt";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(160, 243);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(90, 20);
            this.dtpStart.TabIndex = 49;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Checked = false;
            this.dtpEnd.CustomFormat = "HH:mm tt";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(160, 280);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(90, 20);
            this.dtpEnd.TabIndex = 50;
            // 
            // lblMDY
            // 
            this.lblMDY.AutoSize = true;
            this.lblMDY.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMDY.Location = new System.Drawing.Point(276, 208);
            this.lblMDY.Name = "lblMDY";
            this.lblMDY.Size = new System.Drawing.Size(88, 13);
            this.lblMDY.TabIndex = 51;
            this.lblMDY.Text = "Month/Day/Year";
            // 
            // lblHM2
            // 
            this.lblHM2.AutoSize = true;
            this.lblHM2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHM2.Location = new System.Drawing.Point(276, 286);
            this.lblHM2.Name = "lblHM2";
            this.lblHM2.Size = new System.Drawing.Size(90, 13);
            this.lblHM2.TabIndex = 52;
            this.lblHM2.Text = "Hour:Min AM/PM";
            // 
            // AddAppt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 389);
            this.Controls.Add(this.lblHM2);
            this.Controls.Add(this.lblMDY);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblHM);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblstartTime);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.btnSelectCust);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtCustID);
            this.Controls.Add(this.dgvCustSearch);
            this.Controls.Add(this.lblCustID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cbType);
            this.Name = "AddAppt";
            this.Text = "Add Appointment";
            this.Load += new System.EventHandler(this.AddAppt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCustID;
        private System.Windows.Forms.DataGridView dgvCustSearch;
        private System.Windows.Forms.TextBox txtCustID;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSelectCust;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblstartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblHM;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblMDY;
        private System.Windows.Forms.Label lblHM2;
    }
}