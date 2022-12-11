namespace CJ.Win.HR
{
    partial class frmMobileNumberAssign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMobileNumberAssign));
            this.label1 = new System.Windows.Forms.Label();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.rdoEmployee = new System.Windows.Forms.RadioButton();
            this.rdoNonEmployee = new System.Windows.Forms.RadioButton();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLimitType = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtCreaditLimit = new System.Windows.Forms.TextBox();
            this.lblCreaditLimit = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.cmbLimitType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDatapac = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSpecialUserCategory = new System.Windows.Forms.ComboBox();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.cmbAssignFor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mobile No";
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.ForeColor = System.Drawing.Color.Blue;
            this.lblMobileNo.Location = new System.Drawing.Point(89, 19);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(91, 13);
            this.lblMobileNo.TabIndex = 1;
            this.lblMobileNo.Text = "Mobile Number";
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(32, 50);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(56, 13);
            this.lblUserType.TabIndex = 2;
            this.lblUserType.Text = "User Type";
            // 
            // rdoEmployee
            // 
            this.rdoEmployee.AutoSize = true;
            this.rdoEmployee.Location = new System.Drawing.Point(92, 48);
            this.rdoEmployee.Name = "rdoEmployee";
            this.rdoEmployee.Size = new System.Drawing.Size(71, 17);
            this.rdoEmployee.TabIndex = 3;
            this.rdoEmployee.TabStop = true;
            this.rdoEmployee.Text = "Employee";
            this.rdoEmployee.UseVisualStyleBackColor = true;
            this.rdoEmployee.CheckedChanged += new System.EventHandler(this.rdoEmployee_CheckedChanged);
            // 
            // rdoNonEmployee
            // 
            this.rdoNonEmployee.AutoSize = true;
            this.rdoNonEmployee.Location = new System.Drawing.Point(174, 47);
            this.rdoNonEmployee.Name = "rdoNonEmployee";
            this.rdoNonEmployee.Size = new System.Drawing.Size(94, 17);
            this.rdoNonEmployee.TabIndex = 4;
            this.rdoNonEmployee.TabStop = true;
            this.rdoNonEmployee.Text = "Non Employee";
            this.rdoNonEmployee.UseVisualStyleBackColor = true;
            this.rdoNonEmployee.CheckedChanged += new System.EventHandler(this.rdoNonEmployee_CheckedChanged);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(35, 80);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(53, 13);
            this.lblEmployee.TabIndex = 5;
            this.lblEmployee.Text = "Employee";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(4, 105);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(84, 13);
            this.lblEmployeeName.TabIndex = 7;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(88, 102);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(310, 20);
            this.txtEmployeeName.TabIndex = 8;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(26, 156);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "Department";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(37, 130);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 9;
            this.lblCompany.Text = "Company";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(88, 153);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(310, 21);
            this.cmbDepartment.TabIndex = 12;
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(88, 127);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(310, 21);
            this.cmbCompany.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(339, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(430, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 28);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLimitType
            // 
            this.lblLimitType.AutoSize = true;
            this.lblLimitType.Location = new System.Drawing.Point(33, 181);
            this.lblLimitType.Name = "lblLimitType";
            this.lblLimitType.Size = new System.Drawing.Size(55, 13);
            this.lblLimitType.TabIndex = 13;
            this.lblLimitType.Text = "Limit Type";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(35, 256);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 19;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtCreaditLimit
            // 
            this.txtCreaditLimit.Location = new System.Drawing.Point(297, 180);
            this.txtCreaditLimit.Name = "txtCreaditLimit";
            this.txtCreaditLimit.Size = new System.Drawing.Size(100, 20);
            this.txtCreaditLimit.TabIndex = 16;
            // 
            // lblCreaditLimit
            // 
            this.lblCreaditLimit.AutoSize = true;
            this.lblCreaditLimit.Location = new System.Drawing.Point(233, 181);
            this.lblCreaditLimit.Name = "lblCreaditLimit";
            this.lblCreaditLimit.Size = new System.Drawing.Size(61, 13);
            this.lblCreaditLimit.TabIndex = 15;
            this.lblCreaditLimit.Text = "CreaditLimit";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(88, 253);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(424, 20);
            this.txtRemarks.TabIndex = 20;
            // 
            // cmbLimitType
            // 
            this.cmbLimitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLimitType.FormattingEnabled = true;
            this.cmbLimitType.Location = new System.Drawing.Point(88, 178);
            this.cmbLimitType.Name = "cmbLimitType";
            this.cmbLimitType.Size = new System.Drawing.Size(143, 21);
            this.cmbLimitType.TabIndex = 14;
            this.cmbLimitType.SelectedIndexChanged += new System.EventHandler(this.cmbLimitType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Datapac";
            // 
            // cmbDatapac
            // 
            this.cmbDatapac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatapac.FormattingEnabled = true;
            this.cmbDatapac.Location = new System.Drawing.Point(88, 202);
            this.cmbDatapac.Name = "cmbDatapac";
            this.cmbDatapac.Size = new System.Drawing.Size(143, 21);
            this.cmbDatapac.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Special Cat.";
            // 
            // cmbSpecialUserCategory
            // 
            this.cmbSpecialUserCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialUserCategory.FormattingEnabled = true;
            this.cmbSpecialUserCategory.Location = new System.Drawing.Point(298, 203);
            this.cmbSpecialUserCategory.Name = "cmbSpecialUserCategory";
            this.cmbSpecialUserCategory.Size = new System.Drawing.Size(100, 21);
            this.cmbSpecialUserCategory.TabIndex = 23;
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(88, 78);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(427, 25);
            this.ctlEmployee1.TabIndex = 6;
            this.ctlEmployee1.ChangeSelection += new System.EventHandler(this.ctlEmployee1_ChangeSelection);
            this.ctlEmployee1.Load += new System.EventHandler(this.ctlEmployee1_Load);
            this.ctlEmployee1.MouseLeave += new System.EventHandler(this.ctlEmployee1_MouseLeave);
            // 
            // cmbAssignFor
            // 
            this.cmbAssignFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignFor.FormattingEnabled = true;
            this.cmbAssignFor.Location = new System.Drawing.Point(88, 227);
            this.cmbAssignFor.Name = "cmbAssignFor";
            this.cmbAssignFor.Size = new System.Drawing.Size(310, 21);
            this.cmbAssignFor.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Datapac";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Assign For";
            // 
            // frmMobileNumberAssign
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 324);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAssignFor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSpecialUserCategory);
            this.Controls.Add(this.cmbDatapac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLimitType);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblCreaditLimit);
            this.Controls.Add(this.txtCreaditLimit);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblLimitType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.rdoNonEmployee);
            this.Controls.Add(this.rdoEmployee);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.lblMobileNo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMobileNumberAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Number Assign";
            this.Load += new System.EventHandler(this.frmMobileNumberAssign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.RadioButton rdoEmployee;
        private System.Windows.Forms.RadioButton rdoNonEmployee;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLimitType;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtCreaditLimit;
        private System.Windows.Forms.Label lblCreaditLimit;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ComboBox cmbLimitType;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDatapac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSpecialUserCategory;
        private System.Windows.Forms.ComboBox cmbAssignFor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}