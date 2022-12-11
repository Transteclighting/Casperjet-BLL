namespace CJ.Win.HR
{
    partial class frmMobileNumbers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMobileNumbers));
            this.lvwMobileNumbers = new System.Windows.Forms.ListView();
            this.colEmployeeCode = new System.Windows.Forms.ColumnHeader();
            this.colMobileNumber = new System.Windows.Forms.ColumnHeader();
            this.colSIMStatus = new System.Windows.Forms.ColumnHeader();
            this.colUserType = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colDepartment = new System.Windows.Forms.ColumnHeader();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.colLimitType = new System.Windows.Forms.ColumnHeader();
            this.colCreditLimit = new System.Windows.Forms.ColumnHeader();
            this.colDatapacLimit = new System.Windows.Forms.ColumnHeader();
            this.colDatapac = new System.Windows.Forms.ColumnHeader();
            this.colBill = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSingleBillEntry = new System.Windows.Forms.Button();
            this.btnAddNumber = new System.Windows.Forms.Button();
            this.btnEditNumber = new System.Windows.Forms.Button();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.lblSimStatus = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.cmbSimStatus = new System.Windows.Forms.ComboBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.btnUnassign = new System.Windows.Forms.Button();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblLimitType = new System.Windows.Forms.Label();
            this.cmbLimitType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkUnassign = new System.Windows.Forms.CheckBox();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.btnBulkBillEntry = new System.Windows.Forms.Button();
            this.btnExelUploader = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtBillMonth = new System.Windows.Forms.DateTimePicker();
            this.txtTotalBill = new System.Windows.Forms.TextBox();
            this.btnEditBill = new System.Windows.Forms.Button();
            this.btnBillReport = new System.Windows.Forms.Button();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.btnEditCreditLimit = new System.Windows.Forms.Button();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // lvwMobileNumbers
            // 
            this.lvwMobileNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMobileNumbers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmployeeCode,
            this.colMobileNumber,
            this.colSIMStatus,
            this.colUserType,
            this.colUserName,
            this.colDepartment,
            this.colCompany,
            this.colLimitType,
            this.colCreditLimit,
            this.colDatapacLimit,
            this.colDatapac,
            this.colBill,
            this.colRemarks});
            this.lvwMobileNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwMobileNumbers.FullRowSelect = true;
            this.lvwMobileNumbers.GridLines = true;
            this.lvwMobileNumbers.HideSelection = false;
            this.lvwMobileNumbers.Location = new System.Drawing.Point(12, 111);
            this.lvwMobileNumbers.MultiSelect = false;
            this.lvwMobileNumbers.Name = "lvwMobileNumbers";
            this.lvwMobileNumbers.Size = new System.Drawing.Size(837, 340);
            this.lvwMobileNumbers.TabIndex = 1;
            this.lvwMobileNumbers.UseCompatibleStateImageBehavior = false;
            this.lvwMobileNumbers.View = System.Windows.Forms.View.Details;
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Text = "Emp. Code";
            this.colEmployeeCode.Width = 50;
            // 
            // colMobileNumber
            // 
            this.colMobileNumber.Text = "Mobile Number";
            this.colMobileNumber.Width = 100;
            // 
            // colSIMStatus
            // 
            this.colSIMStatus.Text = "SIM Status";
            this.colSIMStatus.Width = 70;
            // 
            // colUserType
            // 
            this.colUserType.Text = "User Type";
            this.colUserType.Width = 70;
            // 
            // colUserName
            // 
            this.colUserName.Text = "User Name";
            this.colUserName.Width = 140;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 80;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 80;
            // 
            // colLimitType
            // 
            this.colLimitType.Text = "Limit Type";
            // 
            // colCreditLimit
            // 
            this.colCreditLimit.Text = "Credit Limit";
            this.colCreditLimit.Width = 67;
            // 
            // colDatapacLimit
            // 
            this.colDatapacLimit.Text = "Datapac Limit";
            // 
            // colDatapac
            // 
            this.colDatapac.Text = "Datapac";
            // 
            // colBill
            // 
            this.colBill.Text = "Bill";
            this.colBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(774, 79);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 27);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssign.Location = new System.Drawing.Point(858, 169);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(89, 27);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Tag = "";
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(858, 452);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSingleBillEntry
            // 
            this.btnSingleBillEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSingleBillEntry.Location = new System.Drawing.Point(858, 272);
            this.btnSingleBillEntry.Name = "btnSingleBillEntry";
            this.btnSingleBillEntry.Size = new System.Drawing.Size(90, 28);
            this.btnSingleBillEntry.TabIndex = 5;
            this.btnSingleBillEntry.Tag = "";
            this.btnSingleBillEntry.Text = "Single Bill Entry";
            this.btnSingleBillEntry.UseVisualStyleBackColor = true;
            this.btnSingleBillEntry.Click += new System.EventHandler(this.btnSingleBillEntry_Click_1);
            // 
            // btnAddNumber
            // 
            this.btnAddNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNumber.Location = new System.Drawing.Point(857, 111);
            this.btnAddNumber.Name = "btnAddNumber";
            this.btnAddNumber.Size = new System.Drawing.Size(90, 28);
            this.btnAddNumber.TabIndex = 6;
            this.btnAddNumber.Tag = "";
            this.btnAddNumber.Text = "Add Number";
            this.btnAddNumber.UseVisualStyleBackColor = true;
            this.btnAddNumber.Click += new System.EventHandler(this.btnAddNumber_Click);
            // 
            // btnEditNumber
            // 
            this.btnEditNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditNumber.Location = new System.Drawing.Point(857, 140);
            this.btnEditNumber.Name = "btnEditNumber";
            this.btnEditNumber.Size = new System.Drawing.Size(90, 28);
            this.btnEditNumber.TabIndex = 7;
            this.btnEditNumber.Tag = "";
            this.btnEditNumber.Text = "Edit Number";
            this.btnEditNumber.UseVisualStyleBackColor = true;
            this.btnEditNumber.Click += new System.EventHandler(this.btnEditNumber_Click);
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Location = new System.Drawing.Point(38, 23);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(55, 13);
            this.lblMobileNo.TabIndex = 8;
            this.lblMobileNo.Text = "Mobile No";
            // 
            // lblSimStatus
            // 
            this.lblSimStatus.AutoSize = true;
            this.lblSimStatus.Location = new System.Drawing.Point(270, 24);
            this.lblSimStatus.Name = "lblSimStatus";
            this.lblSimStatus.Size = new System.Drawing.Size(57, 13);
            this.lblSimStatus.TabIndex = 9;
            this.lblSimStatus.Text = "Sim Status";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(96, 21);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(148, 20);
            this.txtMobileNo.TabIndex = 10;
            this.txtMobileNo.TextChanged += new System.EventHandler(this.txtMobileNo_TextChanged);
            // 
            // cmbSimStatus
            // 
            this.cmbSimStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSimStatus.FormattingEnabled = true;
            this.cmbSimStatus.Location = new System.Drawing.Point(330, 20);
            this.cmbSimStatus.Name = "cmbSimStatus";
            this.cmbSimStatus.Size = new System.Drawing.Size(134, 21);
            this.cmbSimStatus.TabIndex = 11;
            this.cmbSimStatus.SelectedIndexChanged += new System.EventHandler(this.cmbSimStatus_SelectedIndexChanged);
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(271, 51);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(56, 13);
            this.lblUserType.TabIndex = 14;
            this.lblUserType.Text = "User Type";
            // 
            // cmbUserType
            // 
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Location = new System.Drawing.Point(330, 47);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(134, 21);
            this.cmbUserType.TabIndex = 15;
            this.cmbUserType.SelectedIndexChanged += new System.EventHandler(this.cmbUserType_SelectedIndexChanged);
            // 
            // btnUnassign
            // 
            this.btnUnassign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnassign.Location = new System.Drawing.Point(858, 197);
            this.btnUnassign.Name = "btnUnassign";
            this.btnUnassign.Size = new System.Drawing.Size(90, 27);
            this.btnUnassign.TabIndex = 16;
            this.btnUnassign.Text = "Unassign";
            this.btnUnassign.UseVisualStyleBackColor = true;
            this.btnUnassign.Click += new System.EventHandler(this.btnUnassign_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(505, 23);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 17;
            this.lblCompany.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(559, 18);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(183, 21);
            this.cmbCompany.TabIndex = 18;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(494, 47);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 19;
            this.lblDepartment.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(559, 44);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(183, 21);
            this.cmbDepartment.TabIndex = 20;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // lblLimitType
            // 
            this.lblLimitType.AutoSize = true;
            this.lblLimitType.Location = new System.Drawing.Point(38, 54);
            this.lblLimitType.Name = "lblLimitType";
            this.lblLimitType.Size = new System.Drawing.Size(55, 13);
            this.lblLimitType.TabIndex = 21;
            this.lblLimitType.Text = "Limit Type";
            // 
            // cmbLimitType
            // 
            this.cmbLimitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLimitType.FormattingEnabled = true;
            this.cmbLimitType.Location = new System.Drawing.Point(96, 51);
            this.cmbLimitType.Name = "cmbLimitType";
            this.cmbLimitType.Size = new System.Drawing.Size(148, 21);
            this.cmbLimitType.TabIndex = 22;
            this.cmbLimitType.SelectedIndexChanged += new System.EventHandler(this.cmbLimitType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Assigned";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 461);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Unassigned";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chkUnassign
            // 
            this.chkUnassign.AutoSize = true;
            this.chkUnassign.Location = new System.Drawing.Point(661, 74);
            this.chkUnassign.Name = "chkUnassign";
            this.chkUnassign.Size = new System.Drawing.Size(92, 17);
            this.chkUnassign.TabIndex = 25;
            this.chkUnassign.Text = "Unassign SIM";
            this.chkUnassign.UseVisualStyleBackColor = true;
            this.chkUnassign.CheckedChanged += new System.EventHandler(this.chkUnassign_CheckedChanged);
            // 
            // btnViewBill
            // 
            this.btnViewBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewBill.Location = new System.Drawing.Point(859, 386);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(90, 28);
            this.btnViewBill.TabIndex = 26;
            this.btnViewBill.Text = "View Bill";
            this.btnViewBill.UseVisualStyleBackColor = true;
            this.btnViewBill.Click += new System.EventHandler(this.btnViewBill_Click);
            // 
            // btnBulkBillEntry
            // 
            this.btnBulkBillEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBulkBillEntry.Location = new System.Drawing.Point(859, 300);
            this.btnBulkBillEntry.Name = "btnBulkBillEntry";
            this.btnBulkBillEntry.Size = new System.Drawing.Size(90, 28);
            this.btnBulkBillEntry.TabIndex = 27;
            this.btnBulkBillEntry.Text = "Bulk Bill Entry";
            this.btnBulkBillEntry.UseVisualStyleBackColor = true;
            this.btnBulkBillEntry.Click += new System.EventHandler(this.btnBulkBillEntry_Click);
            // 
            // btnExelUploader
            // 
            this.btnExelUploader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExelUploader.Location = new System.Drawing.Point(859, 328);
            this.btnExelUploader.Name = "btnExelUploader";
            this.btnExelUploader.Size = new System.Drawing.Size(90, 28);
            this.btnExelUploader.TabIndex = 28;
            this.btnExelUploader.Text = "Excel Uploader";
            this.btnExelUploader.UseVisualStyleBackColor = true;
            this.btnExelUploader.Click += new System.EventHandler(this.btnExelUploader_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Bill Month";
            // 
            // dtBillMonth
            // 
            this.dtBillMonth.CustomFormat = "MMM-yyyy";
            this.dtBillMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBillMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBillMonth.Location = new System.Drawing.Point(561, 71);
            this.dtBillMonth.Name = "dtBillMonth";
            this.dtBillMonth.ShowUpDown = true;
            this.dtBillMonth.Size = new System.Drawing.Size(83, 21);
            this.dtBillMonth.TabIndex = 30;
            // 
            // txtTotalBill
            // 
            this.txtTotalBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBill.Location = new System.Drawing.Point(211, 457);
            this.txtTotalBill.Name = "txtTotalBill";
            this.txtTotalBill.ReadOnly = true;
            this.txtTotalBill.Size = new System.Drawing.Size(150, 22);
            this.txtTotalBill.TabIndex = 31;
            // 
            // btnEditBill
            // 
            this.btnEditBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditBill.Location = new System.Drawing.Point(859, 357);
            this.btnEditBill.Name = "btnEditBill";
            this.btnEditBill.Size = new System.Drawing.Size(90, 28);
            this.btnEditBill.TabIndex = 32;
            this.btnEditBill.Text = "Edit Bill";
            this.btnEditBill.UseVisualStyleBackColor = true;
            this.btnEditBill.Click += new System.EventHandler(this.btnEditBill_Click);
            // 
            // btnBillReport
            // 
            this.btnBillReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBillReport.Location = new System.Drawing.Point(859, 415);
            this.btnBillReport.Name = "btnBillReport";
            this.btnBillReport.Size = new System.Drawing.Size(90, 28);
            this.btnBillReport.TabIndex = 33;
            this.btnBillReport.Text = "Bill Report";
            this.btnBillReport.UseVisualStyleBackColor = true;
            this.btnBillReport.Click += new System.EventHandler(this.btnBillReport_Click);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(11, 82);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(84, 13);
            this.lblEmployeeName.TabIndex = 34;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // btnEditCreditLimit
            // 
            this.btnEditCreditLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCreditLimit.Location = new System.Drawing.Point(859, 225);
            this.btnEditCreditLimit.Name = "btnEditCreditLimit";
            this.btnEditCreditLimit.Size = new System.Drawing.Size(90, 28);
            this.btnEditCreditLimit.TabIndex = 37;
            this.btnEditCreditLimit.Text = "Update Limit";
            this.btnEditCreditLimit.UseVisualStyleBackColor = true;
            this.btnEditCreditLimit.Click += new System.EventHandler(this.btnEditCreditLimit_Click);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(96, 78);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(400, 25);
            this.ctlEmployee1.TabIndex = 36;
            // 
            // frmMobileNumbers
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 486);
            this.Controls.Add(this.btnEditCreditLimit);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.btnBillReport);
            this.Controls.Add(this.btnEditBill);
            this.Controls.Add(this.txtTotalBill);
            this.Controls.Add(this.dtBillMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExelUploader);
            this.Controls.Add(this.btnBulkBillEntry);
            this.Controls.Add(this.btnViewBill);
            this.Controls.Add(this.chkUnassign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLimitType);
            this.Controls.Add(this.lblLimitType);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnUnassign);
            this.Controls.Add(this.cmbUserType);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.cmbSimStatus);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.lblSimStatus);
            this.Controls.Add(this.lblMobileNo);
            this.Controls.Add(this.btnEditNumber);
            this.Controls.Add(this.btnAddNumber);
            this.Controls.Add(this.btnSingleBillEntry);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lvwMobileNumbers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMobileNumbers";
            this.Text = "Mobile Numbers";
            this.Load += new System.EventHandler(this.frmMobileNumbers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwMobileNumbers;
        private System.Windows.Forms.ColumnHeader colMobileNumber;
        private System.Windows.Forms.ColumnHeader colSIMStatus;
        private System.Windows.Forms.ColumnHeader colUserType;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colLimitType;
        private System.Windows.Forms.ColumnHeader colCreditLimit;
        private System.Windows.Forms.ColumnHeader colDatapacLimit;
        private System.Windows.Forms.ColumnHeader colDatapac;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSingleBillEntry;
        private System.Windows.Forms.Button btnAddNumber;
        private System.Windows.Forms.Button btnEditNumber;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.Label lblSimStatus;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.ComboBox cmbSimStatus;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Button btnUnassign;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblLimitType;
        private System.Windows.Forms.ComboBox cmbLimitType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkUnassign;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.Button btnBulkBillEntry;
        private System.Windows.Forms.Button btnExelUploader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtBillMonth;
        private System.Windows.Forms.ColumnHeader colBill;
        private System.Windows.Forms.TextBox txtTotalBill;
        private System.Windows.Forms.Button btnEditBill;
        private System.Windows.Forms.Button btnBillReport;
        private System.Windows.Forms.Label lblEmployeeName;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.ColumnHeader colEmployeeCode;
        private System.Windows.Forms.Button btnEditCreditLimit;
    }
}