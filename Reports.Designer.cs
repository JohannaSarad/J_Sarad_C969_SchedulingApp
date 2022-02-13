
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbApptByMonth = new System.Windows.Forms.ComboBox();
            this.cbSchedules = new System.Windows.Forms.ComboBox();
            this.txtReports = new System.Windows.Forms.TextBox();
            this.btnTypeByMonth = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTypeByMonth
            // 
            this.lblTypeByMonth.AutoSize = true;
            this.lblTypeByMonth.Location = new System.Drawing.Point(35, 36);
            this.lblTypeByMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeByMonth.Name = "lblTypeByMonth";
            this.lblTypeByMonth.Size = new System.Drawing.Size(193, 17);
            this.lblTypeByMonth.TabIndex = 0;
            this.lblTypeByMonth.Text = "Appointment Types By Month";
            // 
            // lblApptsByUser
            // 
            this.lblApptsByUser.AutoSize = true;
            this.lblApptsByUser.Location = new System.Drawing.Point(35, 149);
            this.lblApptsByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApptsByUser.Name = "lblApptsByUser";
            this.lblApptsByUser.Size = new System.Drawing.Size(138, 17);
            this.lblApptsByUser.TabIndex = 1;
            this.lblApptsByUser.Text = "Consultant Schedule";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 377);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // cbApptByMonth
            // 
            this.cbApptByMonth.FormattingEnabled = true;
            this.cbApptByMonth.Location = new System.Drawing.Point(38, 318);
            this.cbApptByMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cbApptByMonth.Name = "cbApptByMonth";
            this.cbApptByMonth.Size = new System.Drawing.Size(160, 24);
            this.cbApptByMonth.TabIndex = 3;
            this.cbApptByMonth.SelectedIndexChanged += new System.EventHandler(this.cbApptByMonth_SelectedIndexChanged);
            // 
            // cbSchedules
            // 
            this.cbSchedules.FormattingEnabled = true;
            this.cbSchedules.Location = new System.Drawing.Point(38, 182);
            this.cbSchedules.Margin = new System.Windows.Forms.Padding(4);
            this.cbSchedules.Name = "cbSchedules";
            this.cbSchedules.Size = new System.Drawing.Size(160, 24);
            this.cbSchedules.TabIndex = 4;
            this.cbSchedules.SelectedIndexChanged += new System.EventHandler(this.cbSchedules_SelectedIndexChanged);
            // 
            // txtReports
            // 
            this.txtReports.Location = new System.Drawing.Point(363, 72);
            this.txtReports.Margin = new System.Windows.Forms.Padding(4);
            this.txtReports.Multiline = true;
            this.txtReports.Name = "txtReports";
            this.txtReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReports.Size = new System.Drawing.Size(520, 270);
            this.txtReports.TabIndex = 5;
            // 
            // btnTypeByMonth
            // 
            this.btnTypeByMonth.Location = new System.Drawing.Point(38, 72);
            this.btnTypeByMonth.Name = "btnTypeByMonth";
            this.btnTypeByMonth.Size = new System.Drawing.Size(209, 33);
            this.btnTypeByMonth.TabIndex = 6;
            this.btnTypeByMonth.Text = "Appointment Types By Month";
            this.btnTypeByMonth.UseVisualStyleBackColor = true;
            this.btnTypeByMonth.Click += new System.EventHandler(this.btnTypeByMonth_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTypeByMonth);
            this.Controls.Add(this.txtReports);
            this.Controls.Add(this.cbSchedules);
            this.Controls.Add(this.cbApptByMonth);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbApptByMonth;
        private System.Windows.Forms.ComboBox cbSchedules;
        private System.Windows.Forms.TextBox txtReports;
        private System.Windows.Forms.Button btnTypeByMonth;
        private System.Windows.Forms.Button button1;
    }
}