
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
            this.lblGreeting = new System.Windows.Forms.Label();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.Location = new System.Drawing.Point(0, 0);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(216, 13);
            this.lblGreeting.TabIndex = 0;
            this.lblGreeting.Text = "Welcome User. What can I help with today?";
            // 
            // btnCustomers
            // 
            this.btnCustomers.Location = new System.Drawing.Point(78, 50);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(178, 23);
            this.btnCustomers.TabIndex = 1;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.Location = new System.Drawing.Point(78, 79);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(178, 23);
            this.btnAppointments.TabIndex = 2;
            this.btnAppointments.Text = "Appointments";
            this.btnAppointments.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(78, 108);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(178, 23);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Generate Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 211);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.lblGreeting);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnReports;
    }
}