namespace CJ.Win.HR
{
    partial class frmOutStationDutyList
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwEmployeeOutDuty = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colStartDate = new System.Windows.Forms.ColumnHeader();
            this.colEndDate = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEnableDisableStartDateRange = new System.Windows.Forms.CheckBox();
            this.dtStartDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtStartDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtEndDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtEndDateFrom = new System.Windows.Forms.DateTimePicker();
            this.chkEnableDisableEndDateRange = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(603, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(603, 182);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(105, 27);
            this.btndelete.TabIndex = 9;
            this.btndelete.Tag = "M1.20";
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(603, 153);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 27);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Tag = "M1.18";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(603, 124);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 27);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwEmployeeOutDuty
            // 
            this.lvwEmployeeOutDuty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEmployeeOutDuty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colName,
            this.colStartDate,
            this.colEndDate,
            this.colAddress,
            this.colRemarks});
            this.lvwEmployeeOutDuty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwEmployeeOutDuty.FullRowSelect = true;
            this.lvwEmployeeOutDuty.GridLines = true;
            this.lvwEmployeeOutDuty.HideSelection = false;
            this.lvwEmployeeOutDuty.Location = new System.Drawing.Point(2, 124);
            this.lvwEmployeeOutDuty.MultiSelect = false;
            this.lvwEmployeeOutDuty.Name = "lvwEmployeeOutDuty";
            this.lvwEmployeeOutDuty.Size = new System.Drawing.Size(595, 358);
            this.lvwEmployeeOutDuty.TabIndex = 6;
            this.lvwEmployeeOutDuty.UseCompatibleStateImageBehavior = false;
            this.lvwEmployeeOutDuty.View = System.Windows.Forms.View.Details;
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 87;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 194;
            // 
            // colStartDate
            // 
            this.colStartDate.Text = "Start Date";
            this.colStartDate.Width = 100;
            // 
            // colEndDate
            // 
            this.colEndDate.Text = "End Date";
            this.colEndDate.Width = 100;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 255;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 255;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(8, 69);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 12;
            this.lblCompany.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(65, 66);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(217, 21);
            this.cmbCompany.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnableDisableStartDateRange);
            this.groupBox1.Controls.Add(this.dtStartDateFrom);
            this.groupBox1.Controls.Add(this.dtStartDateTo);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblFrom);
            this.groupBox1.Location = new System.Drawing.Point(8, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 47);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // chkEnableDisableStartDateRange
            // 
            this.chkEnableDisableStartDateRange.AutoSize = true;
            this.chkEnableDisableStartDateRange.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkEnableDisableStartDateRange.Location = new System.Drawing.Point(8, -1);
            this.chkEnableDisableStartDateRange.Name = "chkEnableDisableStartDateRange";
            this.chkEnableDisableStartDateRange.Size = new System.Drawing.Size(185, 17);
            this.chkEnableDisableStartDateRange.TabIndex = 5;
            this.chkEnableDisableStartDateRange.Text = "Enable/Disable Start Date Range";
            this.chkEnableDisableStartDateRange.UseVisualStyleBackColor = true;
            this.chkEnableDisableStartDateRange.CheckedChanged += new System.EventHandler(this.chkEnableDisableFromDateRanf_CheckedChanged);
            // 
            // dtStartDateFrom
            // 
            this.dtStartDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtStartDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDateFrom.Location = new System.Drawing.Point(52, 19);
            this.dtStartDateFrom.Name = "dtStartDateFrom";
            this.dtStartDateFrom.Size = new System.Drawing.Size(104, 20);
            this.dtStartDateFrom.TabIndex = 7;
            // 
            // dtStartDateTo
            // 
            this.dtStartDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtStartDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDateTo.Location = new System.Drawing.Point(184, 19);
            this.dtStartDateTo.Name = "dtStartDateTo";
            this.dtStartDateTo.Size = new System.Drawing.Size(104, 20);
            this.dtStartDateTo.TabIndex = 9;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(158, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(12, 22);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(34, 13);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtEndDateTo);
            this.groupBox2.Controls.Add(this.dtEndDateFrom);
            this.groupBox2.Controls.Add(this.chkEnableDisableEndDateRange);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(307, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 47);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // dtEndDateTo
            // 
            this.dtEndDateTo.CustomFormat = "dd-MMM-yyyy";
            this.dtEndDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDateTo.Location = new System.Drawing.Point(189, 17);
            this.dtEndDateTo.Name = "dtEndDateTo";
            this.dtEndDateTo.Size = new System.Drawing.Size(104, 20);
            this.dtEndDateTo.TabIndex = 10;
            // 
            // dtEndDateFrom
            // 
            this.dtEndDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtEndDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEndDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDateFrom.Location = new System.Drawing.Point(55, 16);
            this.dtEndDateFrom.Name = "dtEndDateFrom";
            this.dtEndDateFrom.Size = new System.Drawing.Size(104, 20);
            this.dtEndDateFrom.TabIndex = 9;
            // 
            // chkEnableDisableEndDateRange
            // 
            this.chkEnableDisableEndDateRange.AutoSize = true;
            this.chkEnableDisableEndDateRange.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkEnableDisableEndDateRange.Location = new System.Drawing.Point(2, 0);
            this.chkEnableDisableEndDateRange.Name = "chkEnableDisableEndDateRange";
            this.chkEnableDisableEndDateRange.Size = new System.Drawing.Size(182, 17);
            this.chkEnableDisableEndDateRange.TabIndex = 5;
            this.chkEnableDisableEndDateRange.Text = "Enable/Disable End Date Range";
            this.chkEnableDisableEndDateRange.UseVisualStyleBackColor = true;
            this.chkEnableDisableEndDateRange.CheckedChanged += new System.EventHandler(this.chkEnableDisableToDateRange_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "From";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(7, 95);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(53, 13);
            this.lblEmployee.TabIndex = 12;
            this.lblEmployee.Text = "Employee";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(614, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 27);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(65, 93);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(510, 25);
            this.ctlEmployee1.TabIndex = 14;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(351, 66);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(217, 21);
            this.cmbDepartment.TabIndex = 22;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(286, 69);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 21;
            this.lblDepartment.Text = "Department";
            // 
            // frmOutStationDutyList
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 483);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwEmployeeOutDuty);
            this.Name = "frmOutStationDutyList";
            this.Text = "Out Station Duty List";
            this.Load += new System.EventHandler(this.frmOutStationDutyList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwEmployeeOutDuty;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStartDate;
        private System.Windows.Forms.ColumnHeader colEndDate;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEnableDisableStartDateRange;
        private System.Windows.Forms.DateTimePicker dtStartDateFrom;
        private System.Windows.Forms.DateTimePicker dtStartDateTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkEnableDisableEndDateRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtEndDateTo;
        private System.Windows.Forms.DateTimePicker dtEndDateFrom;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
    }
}