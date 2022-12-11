namespace CJ.Win.Security
{
    partial class frmUserRegistration
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
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.cmbPermittedApp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAuthenticateMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserFullName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRequestDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSIMSerial = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIMEI = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblVersionNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rdoEmployee = new System.Windows.Forms.RadioButton();
            this.rdoNonEmployee = new System.Windows.Forms.RadioButton();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(12, 112);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(84, 13);
            this.lblEmployeeName.TabIndex = 61;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // cmbPermittedApp
            // 
            this.cmbPermittedApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPermittedApp.FormattingEnabled = true;
            this.cmbPermittedApp.Location = new System.Drawing.Point(102, 143);
            this.cmbPermittedApp.Name = "cmbPermittedApp";
            this.cmbPermittedApp.Size = new System.Drawing.Size(201, 21);
            this.cmbPermittedApp.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Permitted App";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Authenticate Mode";
            // 
            // cmbAuthenticateMode
            // 
            this.cmbAuthenticateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthenticateMode.FormattingEnabled = true;
            this.cmbAuthenticateMode.Location = new System.Drawing.Point(102, 178);
            this.cmbAuthenticateMode.Name = "cmbAuthenticateMode";
            this.cmbAuthenticateMode.Size = new System.Drawing.Size(201, 21);
            this.cmbAuthenticateMode.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(364, 178);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(163, 21);
            this.cmbStatus.TabIndex = 68;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(452, 209);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(364, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 71;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "User Full Name:";
            // 
            // lblUserFullName
            // 
            this.lblUserFullName.AutoSize = true;
            this.lblUserFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserFullName.Location = new System.Drawing.Point(96, 10);
            this.lblUserFullName.Name = "lblUserFullName";
            this.lblUserFullName.Size = new System.Drawing.Size(13, 13);
            this.lblUserFullName.TabIndex = 74;
            this.lblUserFullName.Text = "?";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(411, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(13, 13);
            this.lblUserName.TabIndex = 76;
            this.lblUserName.Text = "?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(347, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "User Name:";
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.Location = new System.Drawing.Point(96, 34);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(13, 13);
            this.lblMobile.TabIndex = 78;
            this.lblMobile.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "Mobile No:";
            // 
            // lblRequestDate
            // 
            this.lblRequestDate.AutoSize = true;
            this.lblRequestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestDate.Location = new System.Drawing.Point(411, 33);
            this.lblRequestDate.Name = "lblRequestDate";
            this.lblRequestDate.Size = new System.Drawing.Size(13, 13);
            this.lblRequestDate.TabIndex = 80;
            this.lblRequestDate.Text = "?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(334, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 79;
            this.label8.Text = "Request Date:";
            // 
            // lblSIMSerial
            // 
            this.lblSIMSerial.AutoSize = true;
            this.lblSIMSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSIMSerial.Location = new System.Drawing.Point(96, 57);
            this.lblSIMSerial.Name = "lblSIMSerial";
            this.lblSIMSerial.Size = new System.Drawing.Size(13, 13);
            this.lblSIMSerial.TabIndex = 84;
            this.lblSIMSerial.Text = "?";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 83;
            this.label9.Text = "SIM Serial:";
            // 
            // lblIMEI
            // 
            this.lblIMEI.AutoSize = true;
            this.lblIMEI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIMEI.Location = new System.Drawing.Point(412, 56);
            this.lblIMEI.Name = "lblIMEI";
            this.lblIMEI.Size = new System.Drawing.Size(13, 13);
            this.lblIMEI.TabIndex = 82;
            this.lblIMEI.Text = "?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(363, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "IMEI No:";
            // 
            // lblVersionNo
            // 
            this.lblVersionNo.AutoSize = true;
            this.lblVersionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionNo.ForeColor = System.Drawing.Color.Red;
            this.lblVersionNo.Location = new System.Drawing.Point(96, 81);
            this.lblVersionNo.Name = "lblVersionNo";
            this.lblVersionNo.Size = new System.Drawing.Size(13, 13);
            this.lblVersionNo.TabIndex = 86;
            this.lblVersionNo.Text = "?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 85;
            this.label10.Text = "Version No:";
            // 
            // rdoEmployee
            // 
            this.rdoEmployee.AutoSize = true;
            this.rdoEmployee.Checked = true;
            this.rdoEmployee.Location = new System.Drawing.Point(337, 144);
            this.rdoEmployee.Name = "rdoEmployee";
            this.rdoEmployee.Size = new System.Drawing.Size(71, 17);
            this.rdoEmployee.TabIndex = 87;
            this.rdoEmployee.TabStop = true;
            this.rdoEmployee.Text = "Employee";
            this.rdoEmployee.UseVisualStyleBackColor = true;
            this.rdoEmployee.CheckedChanged += new System.EventHandler(this.rdoEmployee_CheckedChanged);
            // 
            // rdoNonEmployee
            // 
            this.rdoNonEmployee.AutoSize = true;
            this.rdoNonEmployee.Location = new System.Drawing.Point(433, 144);
            this.rdoNonEmployee.Name = "rdoNonEmployee";
            this.rdoNonEmployee.Size = new System.Drawing.Size(94, 17);
            this.rdoNonEmployee.TabIndex = 88;
            this.rdoNonEmployee.Text = "Non Employee";
            this.rdoNonEmployee.UseVisualStyleBackColor = true;
            this.rdoNonEmployee.CheckedChanged += new System.EventHandler(this.rdoNonEmployee_CheckedChanged);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(102, 110);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(425, 25);
            this.ctlEmployee1.TabIndex = 60;
            // 
            // frmUserRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 243);
            this.Controls.Add(this.rdoNonEmployee);
            this.Controls.Add(this.rdoEmployee);
            this.Controls.Add(this.lblVersionNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblSIMSerial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblIMEI);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblRequestDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblUserFullName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAuthenticateMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPermittedApp);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.ctlEmployee1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmUserRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserRegistration";
            this.Load += new System.EventHandler(this.frmUserRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.ComboBox cmbPermittedApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAuthenticateMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserFullName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRequestDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSIMSerial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIMEI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblVersionNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoEmployee;
        private System.Windows.Forms.RadioButton rdoNonEmployee;
    }
}