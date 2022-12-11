namespace CJ.Win.Accounts
{
    partial class frmCompanyLoans
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
            this.gbReceiveDate = new System.Windows.Forms.GroupBox();
            this.lblReceiveDate = new System.Windows.Forms.Label();
            this.chkReceiveDateRangeChecked = new System.Windows.Forms.CheckBox();
            this.dtReceiveToDate = new System.Windows.Forms.DateTimePicker();
            this.dtReceiveFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblReceiveDateTo = new System.Windows.Forms.Label();
            this.gbCreateDate = new System.Windows.Forms.GroupBox();
            this.chkCreateDateRangeChecked = new System.Windows.Forms.CheckBox();
            this.dtCreateToDate = new System.Windows.Forms.DateTimePicker();
            this.dtCreateFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblCreateDateTo = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.txtLoanNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLoanType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lvwCompanyLoans = new System.Windows.Forms.ListView();
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLoanNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLoanType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLCNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReceiveDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExpireDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBankName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtLCNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbExpireDate = new System.Windows.Forms.GroupBox();
            this.lblExpireDate = new System.Windows.Forms.Label();
            this.chkExpireDateRangeChecked = new System.Windows.Forms.CheckBox();
            this.dtExpireToDate = new System.Windows.Forms.DateTimePicker();
            this.dtExpireFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpireDateTo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDateExtend = new System.Windows.Forms.Button();
            this.btnInterestRate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLoanNumber = new System.Windows.Forms.Button();
            this.btnRunning = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnQuarterEnd = new System.Windows.Forms.Button();
            this.btnLoanHistory = new System.Windows.Forms.Button();
            this.gbReceiveDate.SuspendLayout();
            this.gbCreateDate.SuspendLayout();
            this.gbExpireDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReceiveDate
            // 
            this.gbReceiveDate.Controls.Add(this.lblReceiveDate);
            this.gbReceiveDate.Controls.Add(this.chkReceiveDateRangeChecked);
            this.gbReceiveDate.Controls.Add(this.dtReceiveToDate);
            this.gbReceiveDate.Controls.Add(this.dtReceiveFromDate);
            this.gbReceiveDate.Controls.Add(this.lblReceiveDateTo);
            this.gbReceiveDate.Location = new System.Drawing.Point(20, 8);
            this.gbReceiveDate.Name = "gbReceiveDate";
            this.gbReceiveDate.Size = new System.Drawing.Size(314, 49);
            this.gbReceiveDate.TabIndex = 3;
            this.gbReceiveDate.TabStop = false;
            // 
            // lblReceiveDate
            // 
            this.lblReceiveDate.AutoSize = true;
            this.lblReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveDate.Location = new System.Drawing.Point(4, 23);
            this.lblReceiveDate.Name = "lblReceiveDate";
            this.lblReceiveDate.Size = new System.Drawing.Size(85, 13);
            this.lblReceiveDate.TabIndex = 1;
            this.lblReceiveDate.Text = "Receive Date";
            // 
            // chkReceiveDateRangeChecked
            // 
            this.chkReceiveDateRangeChecked.AutoSize = true;
            this.chkReceiveDateRangeChecked.Location = new System.Drawing.Point(14, -1);
            this.chkReceiveDateRangeChecked.Name = "chkReceiveDateRangeChecked";
            this.chkReceiveDateRangeChecked.Size = new System.Drawing.Size(160, 17);
            this.chkReceiveDateRangeChecked.TabIndex = 0;
            this.chkReceiveDateRangeChecked.Text = "Enable/Disable Date Range";
            this.chkReceiveDateRangeChecked.UseVisualStyleBackColor = true;
            this.chkReceiveDateRangeChecked.CheckedChanged += new System.EventHandler(this.chkReceiveDateRangeChecked_CheckedChanged);
            // 
            // dtReceiveToDate
            // 
            this.dtReceiveToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtReceiveToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceiveToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceiveToDate.Location = new System.Drawing.Point(212, 20);
            this.dtReceiveToDate.Name = "dtReceiveToDate";
            this.dtReceiveToDate.Size = new System.Drawing.Size(97, 20);
            this.dtReceiveToDate.TabIndex = 4;
            // 
            // dtReceiveFromDate
            // 
            this.dtReceiveFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtReceiveFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceiveFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceiveFromDate.Location = new System.Drawing.Point(88, 20);
            this.dtReceiveFromDate.Name = "dtReceiveFromDate";
            this.dtReceiveFromDate.Size = new System.Drawing.Size(98, 20);
            this.dtReceiveFromDate.TabIndex = 2;
            // 
            // lblReceiveDateTo
            // 
            this.lblReceiveDateTo.AutoSize = true;
            this.lblReceiveDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveDateTo.Location = new System.Drawing.Point(189, 23);
            this.lblReceiveDateTo.Name = "lblReceiveDateTo";
            this.lblReceiveDateTo.Size = new System.Drawing.Size(22, 13);
            this.lblReceiveDateTo.TabIndex = 3;
            this.lblReceiveDateTo.Text = "To";
            // 
            // gbCreateDate
            // 
            this.gbCreateDate.Controls.Add(this.chkCreateDateRangeChecked);
            this.gbCreateDate.Controls.Add(this.dtCreateToDate);
            this.gbCreateDate.Controls.Add(this.dtCreateFromDate);
            this.gbCreateDate.Controls.Add(this.lblCreateDateTo);
            this.gbCreateDate.Controls.Add(this.lblCreateDate);
            this.gbCreateDate.Location = new System.Drawing.Point(654, 9);
            this.gbCreateDate.Name = "gbCreateDate";
            this.gbCreateDate.Size = new System.Drawing.Size(314, 49);
            this.gbCreateDate.TabIndex = 2;
            this.gbCreateDate.TabStop = false;
            // 
            // chkCreateDateRangeChecked
            // 
            this.chkCreateDateRangeChecked.AutoSize = true;
            this.chkCreateDateRangeChecked.Location = new System.Drawing.Point(14, -1);
            this.chkCreateDateRangeChecked.Name = "chkCreateDateRangeChecked";
            this.chkCreateDateRangeChecked.Size = new System.Drawing.Size(160, 17);
            this.chkCreateDateRangeChecked.TabIndex = 0;
            this.chkCreateDateRangeChecked.Text = "Enable/Disable Date Range";
            this.chkCreateDateRangeChecked.UseVisualStyleBackColor = true;
            this.chkCreateDateRangeChecked.CheckedChanged += new System.EventHandler(this.chkCreateDateRangeChecked_CheckedChanged);
            // 
            // dtCreateToDate
            // 
            this.dtCreateToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtCreateToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCreateToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCreateToDate.Location = new System.Drawing.Point(208, 20);
            this.dtCreateToDate.Name = "dtCreateToDate";
            this.dtCreateToDate.Size = new System.Drawing.Size(97, 20);
            this.dtCreateToDate.TabIndex = 4;
            // 
            // dtCreateFromDate
            // 
            this.dtCreateFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtCreateFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCreateFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCreateFromDate.Location = new System.Drawing.Point(83, 20);
            this.dtCreateFromDate.Name = "dtCreateFromDate";
            this.dtCreateFromDate.Size = new System.Drawing.Size(98, 20);
            this.dtCreateFromDate.TabIndex = 2;
            // 
            // lblCreateDateTo
            // 
            this.lblCreateDateTo.AutoSize = true;
            this.lblCreateDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDateTo.Location = new System.Drawing.Point(184, 23);
            this.lblCreateDateTo.Name = "lblCreateDateTo";
            this.lblCreateDateTo.Size = new System.Drawing.Size(22, 13);
            this.lblCreateDateTo.TabIndex = 3;
            this.lblCreateDateTo.Text = "To";
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.Location = new System.Drawing.Point(3, 22);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(77, 13);
            this.lblCreateDate.TabIndex = 1;
            this.lblCreateDate.Text = "Create Date";
            this.lblCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLoanNumber
            // 
            this.txtLoanNumber.AcceptsReturn = true;
            this.txtLoanNumber.AcceptsTab = true;
            this.txtLoanNumber.Location = new System.Drawing.Point(58, 67);
            this.txtLoanNumber.Name = "txtLoanNumber";
            this.txtLoanNumber.Size = new System.Drawing.Size(104, 20);
            this.txtLoanNumber.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(636, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Loan Type";
            // 
            // cmbLoanType
            // 
            this.cmbLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoanType.FormattingEnabled = true;
            this.cmbLoanType.Location = new System.Drawing.Point(694, 66);
            this.cmbLoanType.Name = "cmbLoanType";
            this.cmbLoanType.Size = new System.Drawing.Size(99, 21);
            this.cmbLoanType.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Loan#";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(801, 62);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(79, 28);
            this.btnGo.TabIndex = 29;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lvwCompanyLoans
            // 
            this.lvwCompanyLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCompanyLoans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCompany,
            this.colLoanNo,
            this.colLoanType,
            this.colStatus,
            this.colLCNo,
            this.colReceiveDate,
            this.colAmount,
            this.colDuration,
            this.colExpireDate,
            this.colBankName,
            this.colCreatedBy,
            this.colCreateDate,
            this.colRemarks});
            this.lvwCompanyLoans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCompanyLoans.FullRowSelect = true;
            this.lvwCompanyLoans.GridLines = true;
            this.lvwCompanyLoans.HideSelection = false;
            this.lvwCompanyLoans.Location = new System.Drawing.Point(12, 95);
            this.lvwCompanyLoans.MultiSelect = false;
            this.lvwCompanyLoans.Name = "lvwCompanyLoans";
            this.lvwCompanyLoans.Size = new System.Drawing.Size(872, 408);
            this.lvwCompanyLoans.TabIndex = 30;
            this.lvwCompanyLoans.UseCompatibleStateImageBehavior = false;
            this.lvwCompanyLoans.View = System.Windows.Forms.View.Details;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 70;
            // 
            // colLoanNo
            // 
            this.colLoanNo.Text = "Loan#";
            this.colLoanNo.Width = 92;
            // 
            // colLoanType
            // 
            this.colLoanType.Text = "Loan Type";
            this.colLoanType.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 70;
            // 
            // colLCNo
            // 
            this.colLCNo.Text = "LC#";
            this.colLCNo.Width = 80;
            // 
            // colReceiveDate
            // 
            this.colReceiveDate.Text = "Receive Date";
            this.colReceiveDate.Width = 90;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount DBT";
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAmount.Width = 85;
            // 
            // colDuration
            // 
            this.colDuration.Text = "Duration";
            this.colDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDuration.Width = 70;
            // 
            // colExpireDate
            // 
            this.colExpireDate.Text = "ExpireDate";
            this.colExpireDate.Width = 90;
            // 
            // colBankName
            // 
            this.colBankName.Text = "Bank Name";
            this.colBankName.Width = 250;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            this.colCreatedBy.Width = 100;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 90;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 150;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(890, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 27);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtLCNumber
            // 
            this.txtLCNumber.AcceptsReturn = true;
            this.txtLCNumber.AcceptsTab = true;
            this.txtLCNumber.Location = new System.Drawing.Point(196, 68);
            this.txtLCNumber.Name = "txtLCNumber";
            this.txtLCNumber.Size = new System.Drawing.Size(97, 20);
            this.txtLCNumber.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "LC#";
            // 
            // gbExpireDate
            // 
            this.gbExpireDate.Controls.Add(this.lblExpireDate);
            this.gbExpireDate.Controls.Add(this.chkExpireDateRangeChecked);
            this.gbExpireDate.Controls.Add(this.dtExpireToDate);
            this.gbExpireDate.Controls.Add(this.dtExpireFromDate);
            this.gbExpireDate.Controls.Add(this.lblExpireDateTo);
            this.gbExpireDate.Location = new System.Drawing.Point(343, 9);
            this.gbExpireDate.Name = "gbExpireDate";
            this.gbExpireDate.Size = new System.Drawing.Size(304, 49);
            this.gbExpireDate.TabIndex = 5;
            this.gbExpireDate.TabStop = false;
            // 
            // lblExpireDate
            // 
            this.lblExpireDate.AutoSize = true;
            this.lblExpireDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpireDate.Location = new System.Drawing.Point(4, 23);
            this.lblExpireDate.Name = "lblExpireDate";
            this.lblExpireDate.Size = new System.Drawing.Size(73, 13);
            this.lblExpireDate.TabIndex = 1;
            this.lblExpireDate.Text = "Expire Date";
            // 
            // chkExpireDateRangeChecked
            // 
            this.chkExpireDateRangeChecked.AutoSize = true;
            this.chkExpireDateRangeChecked.Location = new System.Drawing.Point(14, -1);
            this.chkExpireDateRangeChecked.Name = "chkExpireDateRangeChecked";
            this.chkExpireDateRangeChecked.Size = new System.Drawing.Size(160, 17);
            this.chkExpireDateRangeChecked.TabIndex = 0;
            this.chkExpireDateRangeChecked.Text = "Enable/Disable Date Range";
            this.chkExpireDateRangeChecked.UseVisualStyleBackColor = true;
            this.chkExpireDateRangeChecked.CheckedChanged += new System.EventHandler(this.chkExpireDateRangeChecked_CheckedChanged);
            // 
            // dtExpireToDate
            // 
            this.dtExpireToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtExpireToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpireToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpireToDate.Location = new System.Drawing.Point(201, 20);
            this.dtExpireToDate.Name = "dtExpireToDate";
            this.dtExpireToDate.Size = new System.Drawing.Size(97, 20);
            this.dtExpireToDate.TabIndex = 4;
            // 
            // dtExpireFromDate
            // 
            this.dtExpireFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtExpireFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpireFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpireFromDate.Location = new System.Drawing.Point(77, 20);
            this.dtExpireFromDate.Name = "dtExpireFromDate";
            this.dtExpireFromDate.Size = new System.Drawing.Size(98, 20);
            this.dtExpireFromDate.TabIndex = 2;
            // 
            // lblExpireDateTo
            // 
            this.lblExpireDateTo.AutoSize = true;
            this.lblExpireDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpireDateTo.Location = new System.Drawing.Point(178, 23);
            this.lblExpireDateTo.Name = "lblExpireDateTo";
            this.lblExpireDateTo.Size = new System.Drawing.Size(22, 13);
            this.lblExpireDateTo.TabIndex = 3;
            this.lblExpireDateTo.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Bank";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(332, 67);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(169, 21);
            this.cmbBank.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(546, 67);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(83, 21);
            this.cmbStatus.TabIndex = 37;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(890, 126);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 27);
            this.btnEdit.TabIndex = 38;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDateExtend
            // 
            this.btnDateExtend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDateExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDateExtend.Location = new System.Drawing.Point(890, 272);
            this.btnDateExtend.Name = "btnDateExtend";
            this.btnDateExtend.Size = new System.Drawing.Size(92, 27);
            this.btnDateExtend.TabIndex = 39;
            this.btnDateExtend.Text = "Date Extend";
            this.btnDateExtend.UseVisualStyleBackColor = true;
            // 
            // btnInterestRate
            // 
            this.btnInterestRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInterestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInterestRate.Location = new System.Drawing.Point(890, 378);
            this.btnInterestRate.Name = "btnInterestRate";
            this.btnInterestRate.Size = new System.Drawing.Size(92, 27);
            this.btnInterestRate.TabIndex = 40;
            this.btnInterestRate.Text = "Interest Rate";
            this.btnInterestRate.UseVisualStyleBackColor = true;
            this.btnInterestRate.Click += new System.EventHandler(this.btnInterestRate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(890, 425);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 27);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(890, 477);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 27);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoanNumber
            // 
            this.btnLoanNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoanNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoanNumber.Location = new System.Drawing.Point(890, 239);
            this.btnLoanNumber.Name = "btnLoanNumber";
            this.btnLoanNumber.Size = new System.Drawing.Size(92, 27);
            this.btnLoanNumber.TabIndex = 43;
            this.btnLoanNumber.Text = "Loan Number";
            this.btnLoanNumber.UseVisualStyleBackColor = true;
            this.btnLoanNumber.Click += new System.EventHandler(this.btnLoanNumber_Click);
            // 
            // btnRunning
            // 
            this.btnRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunning.Location = new System.Drawing.Point(890, 178);
            this.btnRunning.Name = "btnRunning";
            this.btnRunning.Size = new System.Drawing.Size(92, 27);
            this.btnRunning.TabIndex = 44;
            this.btnRunning.Text = "POST";
            this.btnRunning.UseVisualStyleBackColor = true;
            this.btnRunning.Click += new System.EventHandler(this.btnRunning_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSalmon;
            this.label2.Location = new System.Drawing.Point(12, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Create";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Wheat;
            this.label3.Location = new System.Drawing.Point(55, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Running";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(107, 507);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Settled";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(155, 507);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Overdue";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.Location = new System.Drawing.Point(209, 507);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Cancel";
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Location = new System.Drawing.Point(890, 209);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(92, 27);
            this.btnPayment.TabIndex = 50;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnQuarterEnd
            // 
            this.btnQuarterEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuarterEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuarterEnd.Location = new System.Drawing.Point(890, 305);
            this.btnQuarterEnd.Name = "btnQuarterEnd";
            this.btnQuarterEnd.Size = new System.Drawing.Size(92, 27);
            this.btnQuarterEnd.TabIndex = 51;
            this.btnQuarterEnd.Text = "Quarter End";
            this.btnQuarterEnd.UseVisualStyleBackColor = true;
            this.btnQuarterEnd.Click += new System.EventHandler(this.btnQuarterEnd_Click);
            // 
            // btnLoanHistory
            // 
            this.btnLoanHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoanHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoanHistory.Location = new System.Drawing.Point(890, 338);
            this.btnLoanHistory.Name = "btnLoanHistory";
            this.btnLoanHistory.Size = new System.Drawing.Size(92, 27);
            this.btnLoanHistory.TabIndex = 52;
            this.btnLoanHistory.Text = "Loan History";
            this.btnLoanHistory.UseVisualStyleBackColor = true;
            this.btnLoanHistory.Click += new System.EventHandler(this.btnLoanHistory_Click);
            // 
            // frmCompanyLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 527);
            this.Controls.Add(this.btnLoanHistory);
            this.Controls.Add(this.btnQuarterEnd);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRunning);
            this.Controls.Add(this.btnLoanNumber);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInterestRate);
            this.Controls.Add(this.btnDateExtend);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.gbExpireDate);
            this.Controls.Add(this.txtLCNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwCompanyLoans);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtLoanNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbLoanType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbReceiveDate);
            this.Controls.Add(this.gbCreateDate);
            this.Name = "frmCompanyLoans";
            this.Text = "Company Loans";
            this.Load += new System.EventHandler(this.frmCompanyLoans_Load);
            this.gbReceiveDate.ResumeLayout(false);
            this.gbReceiveDate.PerformLayout();
            this.gbCreateDate.ResumeLayout(false);
            this.gbCreateDate.PerformLayout();
            this.gbExpireDate.ResumeLayout(false);
            this.gbExpireDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReceiveDate;
        private System.Windows.Forms.Label lblReceiveDate;
        private System.Windows.Forms.CheckBox chkReceiveDateRangeChecked;
        private System.Windows.Forms.DateTimePicker dtReceiveToDate;
        private System.Windows.Forms.DateTimePicker dtReceiveFromDate;
        private System.Windows.Forms.Label lblReceiveDateTo;
        private System.Windows.Forms.GroupBox gbCreateDate;
        private System.Windows.Forms.CheckBox chkCreateDateRangeChecked;
        private System.Windows.Forms.DateTimePicker dtCreateToDate;
        private System.Windows.Forms.DateTimePicker dtCreateFromDate;
        private System.Windows.Forms.Label lblCreateDateTo;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.TextBox txtLoanNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLoanType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListView lvwCompanyLoans;
        private System.Windows.Forms.ColumnHeader colLoanNo;
        private System.Windows.Forms.ColumnHeader colLoanType;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colLCNo;
        private System.Windows.Forms.ColumnHeader colBankName;
        private System.Windows.Forms.ColumnHeader colReceiveDate;
        private System.Windows.Forms.ColumnHeader colDuration;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colExpireDate;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtLCNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbExpireDate;
        private System.Windows.Forms.Label lblExpireDate;
        private System.Windows.Forms.CheckBox chkExpireDateRangeChecked;
        private System.Windows.Forms.DateTimePicker dtExpireToDate;
        private System.Windows.Forms.DateTimePicker dtExpireFromDate;
        private System.Windows.Forms.Label lblExpireDateTo;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDateExtend;
        private System.Windows.Forms.Button btnInterestRate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLoanNumber;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.Button btnRunning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnQuarterEnd;
        private System.Windows.Forms.Button btnLoanHistory;
    }
}