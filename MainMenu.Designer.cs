
namespace J_Sarad_C969_SchedulingApp
{
    partial class MainMenu
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
            this.btnEditCust = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.lblAppointments = new System.Windows.Forms.Label();
            this.btnUpdateAppt = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.monthCal = new System.Windows.Forms.MonthCalendar();
            this.cbMonthWeek = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGreeting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditCust
            // 
            this.btnEditCust.Location = new System.Drawing.Point(25, 323);
            this.btnEditCust.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditCust.Name = "btnEditCust";
            this.btnEditCust.Size = new System.Drawing.Size(225, 28);
            this.btnEditCust.TabIndex = 2;
            this.btnEditCust.Text = "View/Edit Customers";
            this.btnEditCust.UseVisualStyleBackColor = true;
            this.btnEditCust.Click += new System.EventHandler(this.btnEditCust_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(25, 395);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(225, 28);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Generate Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendar.Location = new System.Drawing.Point(300, 106);
            this.dgvCalendar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCalendar.MultiSelect = false;
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.ReadOnly = true;
            this.dgvCalendar.Size = new System.Drawing.Size(643, 317);
            this.dgvCalendar.TabIndex = 4;
            // 
            // lblAppointments
            // 
            this.lblAppointments.AutoSize = true;
            this.lblAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAppointments.Location = new System.Drawing.Point(296, 79);
            this.lblAppointments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppointments.Name = "lblAppointments";
            this.lblAppointments.Size = new System.Drawing.Size(73, 20);
            this.lblAppointments.TabIndex = 7;
            this.lblAppointments.Text = "Calendar";
            // 
            // btnUpdateAppt
            // 
            this.btnUpdateAppt.Location = new System.Drawing.Point(25, 359);
            this.btnUpdateAppt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateAppt.Name = "btnUpdateAppt";
            this.btnUpdateAppt.Size = new System.Drawing.Size(225, 28);
            this.btnUpdateAppt.TabIndex = 11;
            this.btnUpdateAppt.Text = "Veiw/Edit Appointments";
            this.btnUpdateAppt.UseVisualStyleBackColor = true;
            this.btnUpdateAppt.Click += new System.EventHandler(this.btnUpdateAppt_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(843, 456);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // monthCal
            // 
            this.monthCal.Location = new System.Drawing.Point(23, 146);
            this.monthCal.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCal.MaxDate = new System.DateTime(2040, 12, 31, 0, 0, 0, 0);
            this.monthCal.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.monthCal.Name = "monthCal";
            this.monthCal.ShowTodayCircle = false;
            this.monthCal.TabIndex = 14;
            this.monthCal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // cbMonthWeek
            // 
            this.cbMonthWeek.FormattingEnabled = true;
            this.cbMonthWeek.Location = new System.Drawing.Point(25, 106);
            this.cbMonthWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMonthWeek.Name = "cbMonthWeek";
            this.cbMonthWeek.Size = new System.Drawing.Size(160, 24);
            this.cbMonthWeek.TabIndex = 15;
            this.cbMonthWeek.SelectedIndexChanged += new System.EventHandler(this.cbMonthWeek_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(28, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "View Calendar by:";
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGreeting.Location = new System.Drawing.Point(21, 19);
            this.lblGreeting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(359, 20);
            this.lblGreeting.TabIndex = 17;
            this.lblGreeting.Text = "Welcome User. What Can I Help You with Today?";
            this.lblGreeting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 567);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMonthWeek);
            this.Controls.Add(this.monthCal);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdateAppt);
            this.Controls.Add(this.lblAppointments);
            this.Controls.Add(this.dgvCalendar);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnEditCust);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditCust;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.Label lblAppointments;
        private System.Windows.Forms.Button btnUpdateAppt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbMonthWeek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGreeting;
        public System.Windows.Forms.MonthCalendar monthCal;
    }
}