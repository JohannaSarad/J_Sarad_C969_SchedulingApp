
namespace J_Sarad_C969_SchedulingApp
{
    partial class Appointments
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
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.cbApptType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSelectedCust = new System.Windows.Forms.Label();
            this.cbCustId = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(37, 110);
            this.dgvAppointments.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new System.Drawing.Size(870, 283);
            this.dgvAppointments.TabIndex = 0;
            this.dgvAppointments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellClick);
            //this.dgvAppointments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointments_CellContentClick);
            // 
            // cbApptType
            // 
            this.cbApptType.FormattingEnabled = true;
            this.cbApptType.Location = new System.Drawing.Point(37, 54);
            this.cbApptType.Margin = new System.Windows.Forms.Padding(4);
            this.cbApptType.Name = "cbApptType";
            this.cbApptType.Size = new System.Drawing.Size(160, 24);
            this.cbApptType.TabIndex = 2;
            this.cbApptType.SelectedIndexChanged += new System.EventHandler(this.cbApptType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(33, 22);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(180, 17);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "View By Appointment Type:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(37, 414);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(167, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Appointment";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(257, 414);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(167, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update Appointment";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(472, 414);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(167, 28);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete Appointment";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblSelectedCust
            // 
            this.lblSelectedCust.AutoSize = true;
            this.lblSelectedCust.Location = new System.Drawing.Point(244, 22);
            this.lblSelectedCust.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedCust.Name = "lblSelectedCust";
            this.lblSelectedCust.Size = new System.Drawing.Size(142, 17);
            this.lblSelectedCust.TabIndex = 8;
            this.lblSelectedCust.Text = "View By Customer ID:";
            // 
            // cbCustId
            // 
            this.cbCustId.FormattingEnabled = true;
            this.cbCustId.Location = new System.Drawing.Point(248, 54);
            this.cbCustId.Margin = new System.Windows.Forms.Padding(4);
            this.cbCustId.Name = "cbCustId";
            this.cbCustId.Size = new System.Drawing.Size(160, 24);
            this.cbCustId.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(807, 414);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(723, 50);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(184, 28);
            this.btnMenu.TabIndex = 11;
            this.btnMenu.Text = "Return to Main Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 462);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbCustId);
            this.Controls.Add(this.lblSelectedCust);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cbApptType);
            this.Controls.Add(this.dgvAppointments);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Appointments";
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.Appointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbApptType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSelectedCust;
        private System.Windows.Forms.ComboBox cbCustId;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMenu;
        public System.Windows.Forms.DataGridView dgvAppointments;
    }
}