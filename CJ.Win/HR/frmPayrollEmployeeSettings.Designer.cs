namespace CJ.Win.HR
{
    partial class frmPayrollEmployeeSettings
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
            this.btnSetting = new System.Windows.Forms.Button();
            this.lvwEmployeeSettings = new System.Windows.Forms.ListView();
            this.colEmplCode = new System.Windows.Forms.ColumnHeader();
            this.colEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.colDesignation = new System.Windows.Forms.ColumnHeader();
            this.colDepartment = new System.Windows.Forms.ColumnHeader();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.colYear = new System.Windows.Forms.ColumnHeader();
            this.colTakehomeSalary = new System.Windows.Forms.ColumnHeader();
            this.colIsSetSalary = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtSalaryMonth = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.lblComplainStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Location = new System.Drawing.Point(649, 92);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(72, 26);
            this.btnSetting.TabIndex = 22;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // lvwEmployeeSettings
            // 
            this.lvwEmployeeSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEmployeeSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmplCode,
            this.colEmployeeName,
            this.colDesignation,
            this.colDepartment,
            this.colCompany,
            this.colYear,
            this.colTakehomeSalary,
            this.colIsSetSalary});
            this.lvwEmployeeSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwEmployeeSettings.FullRowSelect = true;
            this.lvwEmployeeSettings.GridLines = true;
            this.lvwEmployeeSettings.HideSelection = false;
            this.lvwEmployeeSettings.Location = new System.Drawing.Point(12, 93);
            this.lvwEmployeeSettings.MultiSelect = false;
            this.lvwEmployeeSettings.Name = "lvwEmployeeSettings";
            this.lvwEmployeeSettings.Size = new System.Drawing.Size(629, 309);
            this.lvwEmployeeSettings.TabIndex = 23;
            this.lvwEmployeeSettings.UseCompatibleStateImageBehavior = false;
            this.lvwEmployeeSettings.View = System.Windows.Forms.View.Details;
            this.lvwEmployeeSettings.DoubleClick += new System.EventHandler(this.lvwEmployeeSettings_DoubleClick);
            // 
            // colEmplCode
            // 
            this.colEmplCode.Text = "Empl Code";
            this.colEmplCode.Width = 70;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 156;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 120;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 122;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            // 
            // colYear
            // 
            this.colYear.Text = "Year";
            this.colYear.Width = 40;
            // 
            // colTakehomeSalary
            // 
            this.colTakehomeSalary.Text = "Take-home Salary";
            this.colTakehomeSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTakehomeSalary.Width = 100;
            // 
            // colIsSetSalary
            // 
            this.colIsSetSalary.Text = "Is Set?";
            this.colIsSetSalary.Width = 50;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 182;
            this.label3.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(81, 12);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(237, 21);
            this.cmbCompany.TabIndex = 181;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 186;
            this.label1.Text = "Employee";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 185;
            this.label8.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(81, 37);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(237, 21);
            this.cmbDepartment.TabIndex = 184;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 187;
            this.label2.Text = "Year";
            // 
            // dtSalaryMonth
            // 
            this.dtSalaryMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryMonth.CustomFormat = "yyyy";
            this.dtSalaryMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalaryMonth.Location = new System.Drawing.Point(404, 10);
            this.dtSalaryMonth.Name = "dtSalaryMonth";
            this.dtSalaryMonth.ShowUpDown = true;
            this.dtSalaryMonth.Size = new System.Drawing.Size(75, 23);
            this.dtSalaryMonth.TabIndex = 188;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(649, 377);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 26);
            this.btnClose.TabIndex = 189;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(513, 59);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(72, 26);
            this.btnGet.TabIndex = 190;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblComplainStatus
            // 
            this.lblComplainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainStatus.Location = new System.Drawing.Point(360, 40);
            this.lblComplainStatus.Name = "lblComplainStatus";
            this.lblComplainStatus.Size = new System.Drawing.Size(42, 13);
            this.lblComplainStatus.TabIndex = 192;
            this.lblComplainStatus.Text = "Is Set?";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(403, 37);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(76, 21);
            this.cmbStatus.TabIndex = 191;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(667, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 193;
            this.label4.Text = "Yes";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightPink;
            this.label5.Location = new System.Drawing.Point(667, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 194;
            this.label5.Text = "No";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(649, 123);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(72, 26);
            this.btnCopy.TabIndex = 195;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(649, 154);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 26);
            this.btnDelete.TabIndex = 196;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(82, 63);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(403, 25);
            this.ctlEmployee1.TabIndex = 183;
            // 
            // frmPayrollEmployeeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 414);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblComplainStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtSalaryMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lvwEmployeeSettings);
            this.Controls.Add(this.btnSetting);
            this.Name = "frmPayrollEmployeeSettings";
            this.Text = "Payroll Employee Settings";
            this.Load += new System.EventHandler(this.frmPayrollEmployeeSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.ListView lvwEmployeeSettings;
        private System.Windows.Forms.ColumnHeader colEmplCode;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colIsSetSalary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtSalaryMonth;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblComplainStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ColumnHeader colTakehomeSalary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelete;
    }
}