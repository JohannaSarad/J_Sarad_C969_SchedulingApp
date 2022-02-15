
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvCustSearch = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSelectCust = new System.Windows.Forms.Button();
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
            this.cbType.Location = new System.Drawing.Point(213, 36);
            this.cbType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(200, 24);
            this.cbType.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(59, 39);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(123, 17);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Appointment Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 6;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(59, 97);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 17);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Customer Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(213, 91);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 10;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MM/dd/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(213, 153);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(119, 23);
            this.dtpDate.TabIndex = 11;
            this.dtpDate.Value = new System.DateTime(2022, 3, 18, 0, 0, 0, 0);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(59, 154);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(121, 17);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Appointment Date";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(213, 352);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(368, 352);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvCustSearch
            // 
            this.dgvCustSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustSearch.Location = new System.Drawing.Point(537, 97);
            this.dgvCustSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCustSearch.Name = "dgvCustSearch";
            this.dgvCustSearch.Size = new System.Drawing.Size(423, 239);
            this.dgvCustSearch.TabIndex = 16;
            this.dgvCustSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustSearch_CellClick);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(533, 11);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(211, 17);
            this.lblSearch.TabIndex = 18;
            this.lblSearch.Text = "Search Customer by Name or ID";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(860, 56);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(659, 59);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 23);
            this.txtSearch.TabIndex = 20;
            // 
            // btnSelectCust
            // 
            this.btnSelectCust.Location = new System.Drawing.Point(732, 352);
            this.btnSelectCust.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectCust.Name = "btnSelectCust";
            this.btnSelectCust.Size = new System.Drawing.Size(228, 28);
            this.btnSelectCust.TabIndex = 21;
            this.btnSelectCust.Text = "Select Customer";
            this.btnSelectCust.UseVisualStyleBackColor = true;
            this.btnSelectCust.Click += new System.EventHandler(this.btnSelectCust_Click);
            // 
            // lblstartTime
            // 
            this.lblstartTime.AutoSize = true;
            this.lblstartTime.Location = new System.Drawing.Point(59, 217);
            this.lblstartTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstartTime.Name = "lblstartTime";
            this.lblstartTime.Size = new System.Drawing.Size(73, 17);
            this.lblstartTime.TabIndex = 23;
            this.lblstartTime.Text = "Start Time";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(59, 277);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(68, 17);
            this.lblEndTime.TabIndex = 24;
            this.lblEndTime.Text = "End Time";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(860, 407);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblHM
            // 
            this.lblHM.AutoSize = true;
            this.lblHM.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHM.Location = new System.Drawing.Point(365, 217);
            this.lblHM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHM.Name = "lblHM";
            this.lblHM.Size = new System.Drawing.Size(113, 17);
            this.lblHM.TabIndex = 40;
            this.lblHM.Text = "Hour:Min AM/PM";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "hh:mm tt";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(213, 211);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(119, 23);
            this.dtpStart.TabIndex = 49;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Checked = false;
            this.dtpEnd.CustomFormat = "hh:mm tt";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(213, 272);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(119, 23);
            this.dtpEnd.TabIndex = 50;
            // 
            // lblMDY
            // 
            this.lblMDY.AutoSize = true;
            this.lblMDY.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMDY.Location = new System.Drawing.Point(365, 158);
            this.lblMDY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMDY.Name = "lblMDY";
            this.lblMDY.Size = new System.Drawing.Size(110, 17);
            this.lblMDY.TabIndex = 51;
            this.lblMDY.Text = "Month/Day/Year";
            // 
            // lblHM2
            // 
            this.lblHM2.AutoSize = true;
            this.lblHM2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHM2.Location = new System.Drawing.Point(365, 278);
            this.lblHM2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHM2.Name = "lblHM2";
            this.lblHM2.Size = new System.Drawing.Size(113, 17);
            this.lblHM2.TabIndex = 52;
            this.lblHM2.Text = "Hour:Min AM/PM";
            // 
            // AddAppt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 479);
            this.Controls.Add(this.lblHM2);
            this.Controls.Add(this.lblMDY);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblHM);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblstartTime);
            this.Controls.Add(this.btnSelectCust);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvCustSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cbType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvCustSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSelectCust;
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