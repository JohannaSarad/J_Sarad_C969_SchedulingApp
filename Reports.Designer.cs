
namespace J_Sarad_C969_SchedulingApp
{
    partial class Reports
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
            this.lblTypeByMonth = new System.Windows.Forms.Label();
            this.lblApptsByUser = new System.Windows.Forms.Label();
            this.lblCustByCity = new System.Windows.Forms.Label();
            this.cbApptByMonth = new System.Windows.Forms.ComboBox();
            this.cbSchedules = new System.Windows.Forms.ComboBox();
            this.txtReports = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.cbCustByCity = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTypeByMonth
            // 
            this.lblTypeByMonth.AutoSize = true;
            this.lblTypeByMonth.Location = new System.Drawing.Point(35, 52);
            this.lblTypeByMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeByMonth.Name = "lblTypeByMonth";
            this.lblTypeByMonth.Size = new System.Drawing.Size(193, 17);
            this.lblTypeByMonth.TabIndex = 0;
            this.lblTypeByMonth.Text = "Appointment Types By Month";
            // 
            // lblApptsByUser
            // 
            this.lblApptsByUser.AutoSize = true;
            this.lblApptsByUser.Location = new System.Drawing.Point(35, 173);
            this.lblApptsByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApptsByUser.Name = "lblApptsByUser";
            this.lblApptsByUser.Size = new System.Drawing.Size(138, 17);
            this.lblApptsByUser.TabIndex = 1;
            this.lblApptsByUser.Text = "Consultant Schedule";
            // 
            // lblCustByCity
            // 
            this.lblCustByCity.AutoSize = true;
            this.lblCustByCity.Location = new System.Drawing.Point(35, 300);
            this.lblCustByCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustByCity.Name = "lblCustByCity";
            this.lblCustByCity.Size = new System.Drawing.Size(122, 17);
            this.lblCustByCity.TabIndex = 2;
            this.lblCustByCity.Text = "Customers By City";
            // 
            // cbApptByMonth
            // 
            this.cbApptByMonth.FormattingEnabled = true;
            this.cbApptByMonth.IntegralHeight = false;
            this.cbApptByMonth.Location = new System.Drawing.Point(38, 82);
            this.cbApptByMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cbApptByMonth.MaxDropDownItems = 4;
            this.cbApptByMonth.Name = "cbApptByMonth";
            this.cbApptByMonth.Size = new System.Drawing.Size(160, 24);
            this.cbApptByMonth.TabIndex = 3;
            this.cbApptByMonth.SelectedIndexChanged += new System.EventHandler(this.cbApptByMonth_SelectedIndexChanged);
            // 
            // cbSchedules
            // 
            this.cbSchedules.FormattingEnabled = true;
            this.cbSchedules.IntegralHeight = false;
            this.cbSchedules.Location = new System.Drawing.Point(38, 203);
            this.cbSchedules.Margin = new System.Windows.Forms.Padding(4);
            this.cbSchedules.MaxDropDownItems = 4;
            this.cbSchedules.Name = "cbSchedules";
            this.cbSchedules.Size = new System.Drawing.Size(160, 24);
            this.cbSchedules.TabIndex = 4;
            this.cbSchedules.SelectedIndexChanged += new System.EventHandler(this.cbSchedules_SelectedIndexChanged);
            // 
            // txtReports
            // 
            this.txtReports.Location = new System.Drawing.Point(262, 82);
            this.txtReports.Margin = new System.Windows.Forms.Padding(4);
            this.txtReports.Multiline = true;
            this.txtReports.Name = "txtReports";
            this.txtReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReports.Size = new System.Drawing.Size(571, 260);
            this.txtReports.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(623, 371);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(659, 31);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(174, 23);
            this.btnMainMenu.TabIndex = 7;
            this.btnMainMenu.Text = "Return To Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // cbCustByCity
            // 
            this.cbCustByCity.FormattingEnabled = true;
            this.cbCustByCity.Location = new System.Drawing.Point(38, 333);
            this.cbCustByCity.Name = "cbCustByCity";
            this.cbCustByCity.Size = new System.Drawing.Size(160, 24);
            this.cbCustByCity.TabIndex = 8;
            this.cbCustByCity.SelectedIndexChanged += new System.EventHandler(this.cbCustByCity_SelectedIndexChanged);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 480);
            this.Controls.Add(this.cbCustByCity);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtReports);
            this.Controls.Add(this.cbSchedules);
            this.Controls.Add(this.cbApptByMonth);
            this.Controls.Add(this.lblCustByCity);
            this.Controls.Add(this.lblApptsByUser);
            this.Controls.Add(this.lblTypeByMonth);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTypeByMonth;
        private System.Windows.Forms.Label lblApptsByUser;
        private System.Windows.Forms.Label lblCustByCity;
        private System.Windows.Forms.ComboBox cbApptByMonth;
        private System.Windows.Forms.ComboBox cbSchedules;
        private System.Windows.Forms.TextBox txtReports;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.ComboBox cbCustByCity;
    }
}