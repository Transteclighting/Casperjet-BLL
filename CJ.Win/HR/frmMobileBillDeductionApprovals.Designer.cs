namespace CJ.Win.HR
{
    partial class frmMobileBillDeductionApprovals
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
            this.lvwDeductBills = new System.Windows.Forms.ListView();
            this.colMobileNumber = new System.Windows.Forms.ColumnHeader();
            this.colUserType = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colEmployeeCode = new System.Windows.Forms.ColumnHeader();
            this.colDesignationName = new System.Windows.Forms.ColumnHeader();
            this.colCompanyCode = new System.Windows.Forms.ColumnHeader();
            this.colDepartmentName = new System.Windows.Forms.ColumnHeader();
            this.colLimitType = new System.Windows.Forms.ColumnHeader();
            this.colCreditLimit = new System.Windows.Forms.ColumnHeader();
            this.coldatapac = new System.Windows.Forms.ColumnHeader();
            this.colPackageAmount = new System.Windows.Forms.ColumnHeader();
            this.colTotalLimit = new System.Windows.Forms.ColumnHeader();
            this.colTMonth = new System.Windows.Forms.ColumnHeader();
            this.colTYear = new System.Windows.Forms.ColumnHeader();
            this.colBillAmount = new System.Windows.Forms.ColumnHeader();
            this.colDeduct = new System.Windows.Forms.ColumnHeader();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.dtBillMonth = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblApproved = new System.Windows.Forms.Label();
            this.lblReject = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbApproveStatus = new System.Windows.Forms.ComboBox();
            this.ctlEmployee2 = new CJ.Win.ctlEmployee();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.lblPartialApproved = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwDeductBills
            // 
            this.lvwDeductBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDeductBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMobileNumber,
            this.colUserType,
            this.colUserName,
            this.colEmployeeCode,
            this.colDesignationName,
            this.colCompanyCode,
            this.colDepartmentName,
            this.colLimitType,
            this.colCreditLimit,
            this.coldatapac,
            this.colPackageAmount,
            this.colTotalLimit,
            this.colTMonth,
            this.colTYear,
            this.colBillAmount,
            this.colDeduct});
            this.lvwDeductBills.FullRowSelect = true;
            this.lvwDeductBills.GridLines = true;
            this.lvwDeductBills.Location = new System.Drawing.Point(13, 95);
            this.lvwDeductBills.MultiSelect = false;
            this.lvwDeductBills.Name = "lvwDeductBills";
            this.lvwDeductBills.Size = new System.Drawing.Size(887, 370);
            this.lvwDeductBills.TabIndex = 0;
            this.lvwDeductBills.UseCompatibleStateImageBehavior = false;
            this.lvwDeductBills.View = System.Windows.Forms.View.Details;
            // 
            // colMobileNumber
            // 
            this.colMobileNumber.Text = "Mobile Number";
            this.colMobileNumber.Width = 88;
            // 
            // colUserType
            // 
            this.colUserType.Text = "UserType";
            // 
            // colUserName
            // 
            this.colUserName.Text = "User Name";
            this.colUserName.Width = 153;
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Text = "Emp. Code";
            this.colEmployeeCode.Width = 42;
            // 
            // colDesignationName
            // 
            this.colDesignationName.Text = "Designation";
            this.colDesignationName.Width = 86;
            // 
            // colCompanyCode
            // 
            this.colCompanyCode.Text = "Company Code";
            this.colCompanyCode.Width = 45;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Text = "Dept.";
            this.colDepartmentName.Width = 90;
            // 
            // colLimitType
            // 
            this.colLimitType.Text = "Limit Type";
            // 
            // colCreditLimit
            // 
            this.colCreditLimit.Text = "Credit Limit";
            // 
            // coldatapac
            // 
            this.coldatapac.Text = "Datapac";
            // 
            // colPackageAmount
            // 
            this.colPackageAmount.Text = "Pack. Amount";
            this.colPackageAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colTotalLimit
            // 
            this.colTotalLimit.Text = "Total Limit";
            this.colTotalLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalLimit.Width = 41;
            // 
            // colTMonth
            // 
            this.colTMonth.Text = "Month";
            this.colTMonth.Width = 39;
            // 
            // colTYear
            // 
            this.colTYear.Text = "Year";
            this.colTYear.Width = 37;
            // 
            // colBillAmount
            // 
            this.colBillAmount.Text = "Bill Amount";
            this.colBillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colDeduct
            // 
            this.colDeduct.Text = "Deduct";
            this.colDeduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.Location = new System.Drawing.Point(904, 94);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(79, 28);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "&Approved";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Location = new System.Drawing.Point(904, 123);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(79, 28);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(904, 439);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(9, 67);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(53, 13);
            this.lblEmployeeName.TabIndex = 43;
            this.lblEmployeeName.Text = "Employee";
            // 
            // dtBillMonth
            // 
            this.dtBillMonth.CustomFormat = "MMM-yyyy";
            this.dtBillMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBillMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBillMonth.Location = new System.Drawing.Point(67, 38);
            this.dtBillMonth.Name = "dtBillMonth";
            this.dtBillMonth.ShowUpDown = true;
            this.dtBillMonth.Size = new System.Drawing.Size(101, 21);
            this.dtBillMonth.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Bill Month";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(275, 37);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(232, 21);
            this.cmbDepartment.TabIndex = 40;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(210, 41);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 39;
            this.lblDepartment.Text = "Department";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(275, 12);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(232, 21);
            this.cmbCompany.TabIndex = 38;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(221, 16);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 37;
            this.lblCompany.Text = "Company";
            // 
            // lblPending
            // 
            this.lblPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPending.AutoSize = true;
            this.lblPending.Location = new System.Drawing.Point(10, 471);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(46, 13);
            this.lblPending.TabIndex = 45;
            this.lblPending.Text = "Pending";
            // 
            // lblApproved
            // 
            this.lblApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblApproved.AutoSize = true;
            this.lblApproved.Location = new System.Drawing.Point(142, 472);
            this.lblApproved.Name = "lblApproved";
            this.lblApproved.Size = new System.Drawing.Size(53, 13);
            this.lblApproved.TabIndex = 46;
            this.lblApproved.Text = "Approved";
            // 
            // lblReject
            // 
            this.lblReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReject.AutoSize = true;
            this.lblReject.Location = new System.Drawing.Point(195, 472);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(38, 13);
            this.lblReject.TabIndex = 47;
            this.lblReject.Text = "Reject";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(759, 40);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(90, 27);
            this.btnGet.TabIndex = 48;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Approve Status";
            // 
            // cmbApproveStatus
            // 
            this.cmbApproveStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApproveStatus.FormattingEnabled = true;
            this.cmbApproveStatus.Location = new System.Drawing.Point(587, 13);
            this.cmbApproveStatus.Name = "cmbApproveStatus";
            this.cmbApproveStatus.Size = new System.Drawing.Size(92, 21);
            this.cmbApproveStatus.TabIndex = 51;
            // 
            // ctlEmployee2
            // 
            this.ctlEmployee2.Location = new System.Drawing.Point(67, 64);
            this.ctlEmployee2.Name = "ctlEmployee2";
            this.ctlEmployee2.Size = new System.Drawing.Size(447, 25);
            this.ctlEmployee2.TabIndex = 49;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(67, 14);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(148, 20);
            this.txtMobileNo.TabIndex = 53;
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Location = new System.Drawing.Point(9, 16);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(55, 13);
            this.lblMobileNo.TabIndex = 52;
            this.lblMobileNo.Text = "Mobile No";
            // 
            // lblPartialApproved
            // 
            this.lblPartialApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPartialApproved.AutoSize = true;
            this.lblPartialApproved.Location = new System.Drawing.Point(56, 472);
            this.lblPartialApproved.Name = "lblPartialApproved";
            this.lblPartialApproved.Size = new System.Drawing.Size(85, 13);
            this.lblPartialApproved.TabIndex = 54;
            this.lblPartialApproved.Text = "Partial Approved";
            // 
            // frmMobileBillDeductionApprovals
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 492);
            this.Controls.Add(this.lblPartialApproved);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.lblMobileNo);
            this.Controls.Add(this.cmbApproveStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlEmployee2);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblReject);
            this.Controls.Add(this.lblApproved);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.dtBillMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lvwDeductBills);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMobileBillDeductionApprovals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deduction Approvals";
            this.Load += new System.EventHandler(this.frmMobileBillDeductionApprovals_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDeductBills;
        private System.Windows.Forms.ColumnHeader colEmployeeCode;
        private System.Windows.Forms.ColumnHeader colMobileNumber;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colDesignationName;
        private System.Windows.Forms.ColumnHeader colCompanyCode;
        private System.Windows.Forms.ColumnHeader colDepartmentName;
        private System.Windows.Forms.ColumnHeader colLimitType;
        private System.Windows.Forms.ColumnHeader colCreditLimit;
        private System.Windows.Forms.ColumnHeader coldatapac;
        private System.Windows.Forms.ColumnHeader colPackageAmount;
        private System.Windows.Forms.ColumnHeader colTotalLimit;
        private System.Windows.Forms.ColumnHeader colTMonth;
        private System.Windows.Forms.ColumnHeader colTYear;
        private System.Windows.Forms.ColumnHeader colBillAmount;
        private System.Windows.Forms.ColumnHeader colDeduct;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colUserType;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.DateTimePicker dtBillMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblApproved;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.Button btnGet;
        private ctlEmployee ctlEmployee2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbApproveStatus;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Label lblPartialApproved;
    }
}