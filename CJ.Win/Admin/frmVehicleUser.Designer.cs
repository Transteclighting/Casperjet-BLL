namespace CJ.Win
{
    partial class frmVehicleUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicleUser));
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxFuelLimit = new System.Windows.Forms.TextBox();
            this.txtMaxMaintenanceLimit = new System.Windows.Forms.TextBox();
            this.dateTimePiJoiningDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(149, 43);
            this.txtDesignation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(299, 23);
            this.txtDesignation.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(149, 12);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(299, 23);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Designation";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(272, 137);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 25);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(363, 137);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 25);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // txtMaxFuelLimit
            // 
            this.txtMaxFuelLimit.Location = new System.Drawing.Point(149, 74);
            this.txtMaxFuelLimit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaxFuelLimit.Name = "txtMaxFuelLimit";
            this.txtMaxFuelLimit.Size = new System.Drawing.Size(299, 23);
            this.txtMaxFuelLimit.TabIndex = 5;
            // 
            // txtMaxMaintenanceLimit
            // 
            this.txtMaxMaintenanceLimit.Location = new System.Drawing.Point(149, 105);
            this.txtMaxMaintenanceLimit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaxMaintenanceLimit.Name = "txtMaxMaintenanceLimit";
            this.txtMaxMaintenanceLimit.Size = new System.Drawing.Size(299, 23);
            this.txtMaxMaintenanceLimit.TabIndex = 7;
            // 
            // dateTimePiJoiningDate
            // 
            this.dateTimePiJoiningDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePiJoiningDate.Location = new System.Drawing.Point(149, 136);
            this.dateTimePiJoiningDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePiJoiningDate.Name = "dateTimePiJoiningDate";
            this.dateTimePiJoiningDate.Size = new System.Drawing.Size(117, 23);
            this.dateTimePiJoiningDate.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Max Fuel Limit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max MainTenance Limit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Joining Date";
            // 
            // frmVehicleUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 205);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePiJoiningDate);
            this.Controls.Add(this.txtMaxMaintenanceLimit);
            this.Controls.Add(this.txtMaxFuelLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVehicleUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVehicleUser";
            this.Load += new System.EventHandler(this.frmVehicleUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxFuelLimit;
        private System.Windows.Forms.TextBox txtMaxMaintenanceLimit;
        private System.Windows.Forms.DateTimePicker dateTimePiJoiningDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}