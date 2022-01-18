
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblAppointments = new System.Windows.Forms.Label();
            this.btnUpdateAppt = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGreeting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditCust
            // 
            this.btnEditCust.Location = new System.Drawing.Point(18, 303);
            this.btnEditCust.Name = "btnEditCust";
            this.btnEditCust.Size = new System.Drawing.Size(227, 23);
            this.btnEditCust.TabIndex = 2;
            this.btnEditCust.Text = "View/Edit Customers";
            this.btnEditCust.UseVisualStyleBackColor = true;
            this.btnEditCust.Click += new System.EventHandler(this.btnEditCust_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(18, 366);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(227, 23);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Generate Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(277, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(588, 306);
            this.dataGridView1.TabIndex = 4;
            // 
            // lblAppointments
            // 
            this.lblAppointments.AutoSize = true;
            this.lblAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAppointments.Location = new System.Drawing.Point(275, 63);
            this.lblAppointments.Name = "lblAppointments";
            this.lblAppointments.Size = new System.Drawing.Size(73, 20);
            this.lblAppointments.TabIndex = 7;
            this.lblAppointments.Text = "Calendar";
            // 
            // btnUpdateAppt
            // 
            this.btnUpdateAppt.Location = new System.Drawing.Point(18, 335);
            this.btnUpdateAppt.Name = "btnUpdateAppt";
            this.btnUpdateAppt.Size = new System.Drawing.Size(227, 23);
            this.btnUpdateAppt.TabIndex = 11;
            this.btnUpdateAppt.Text = "Veiw/Edit Appointments";
            this.btnUpdateAppt.UseVisualStyleBackColor = true;
            this.btnUpdateAppt.Click += new System.EventHandler(this.btnUpdateAppt_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(791, 412);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(17, 119);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 14;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(21, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "View Calendar by:";
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGreeting.Location = new System.Drawing.Point(275, 19);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(359, 20);
            this.lblGreeting.TabIndex = 17;
            this.lblGreeting.Text = "Welcome User. What Can I Help You with Today?";
            this.lblGreeting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdateAppt);
            this.Controls.Add(this.lblAppointments);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnEditCust);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditCust;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAppointments;
        private System.Windows.Forms.Button btnUpdateAppt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGreeting;
    }
}