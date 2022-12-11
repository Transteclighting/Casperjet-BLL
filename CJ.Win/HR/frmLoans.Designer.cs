namespace CJ.Win.HR
{
    partial class frmLoans
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
            this.btnGet = new System.Windows.Forms.Button();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.lblComplainStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblComplainNo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblArticleType = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.cmbArticleType = new System.Windows.Forms.ComboBox();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoanType = new System.Windows.Forms.ComboBox();
            this.txtLoanNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lvwLoans = new System.Windows.Forms.ListView();
            this.colLoanNo = new System.Windows.Forms.ColumnHeader();
            this.colDisburseDate = new System.Windows.Forms.ColumnHeader();
            this.colLoanType = new System.Windows.Forms.ColumnHeader();
            this.colArticleType = new System.Windows.Forms.ColumnHeader();
            this.colAllocatedAmount = new System.Windows.Forms.ColumnHeader();
            this.colNoOfInstallment = new System.Windows.Forms.ColumnHeader();
            this.colInterestRate = new System.Windows.Forms.ColumnHeader();
            this.colPrincipalPayable = new System.Windows.Forms.ColumnHeader();
            this.colInterestPayable = new System.Windows.Forms.ColumnHeader();
            this.colTotalPayable = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colEmployee = new System.Windows.Forms.ColumnHeader();
            this.colCreateUser = new System.Windows.Forms.ColumnHeader();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnEarlySettle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(614, 126);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(68, 28);
            this.btnGet.TabIndex = 170;
            this.btnGet.Text = "&Get Data";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblContactNo
            // 
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(40, 105);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(55, 13);
            this.lblContactNo.TabIndex = 169;
            this.lblContactNo.Text = "Loan No";
            // 
            // lblComplainStatus
            // 
            this.lblComplainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainStatus.Location = new System.Drawing.Point(440, 79);
            this.lblComplainStatus.Name = "lblComplainStatus";
            this.lblComplainStatus.Size = new System.Drawing.Size(43, 13);
            this.lblComplainStatus.TabIndex = 166;
            this.lblComplainStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(489, 75);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(96, 21);
            this.cmbStatus.TabIndex = 165;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(192, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 164;
            this.lblTo.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(215, 19);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 163;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(90, 19);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 162;
            // 
            // lblComplainNo
            // 
            this.lblComplainNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainNo.Location = new System.Drawing.Point(14, 130);
            this.lblComplainNo.Name = "lblComplainNo";
            this.lblComplainNo.Size = new System.Drawing.Size(81, 13);
            this.lblComplainNo.TabIndex = 161;
            this.lblComplainNo.Text = "Employee No";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblArticleType);
            this.groupBox2.Controls.Add(this.cmbCompany);
            this.groupBox2.Controls.Add(this.cmbArticleType);
            this.groupBox2.Controls.Add(this.ctlEmployee1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbLoanType);
            this.groupBox2.Controls.Add(this.txtLoanNo);
            this.groupBox2.Location = new System.Drawing.Point(12, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 92);
            this.groupBox2.TabIndex = 171;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 180;
            this.label3.Text = "Company";
            // 
            // lblArticleType
            // 
            this.lblArticleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticleType.Location = new System.Drawing.Point(399, 41);
            this.lblArticleType.Name = "lblArticleType";
            this.lblArticleType.Size = new System.Drawing.Size(76, 13);
            this.lblArticleType.TabIndex = 177;
            this.lblArticleType.Text = "Article Type";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(84, 11);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(225, 21);
            this.cmbCompany.TabIndex = 179;
            // 
            // cmbArticleType
            // 
            this.cmbArticleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArticleType.FormattingEnabled = true;
            this.cmbArticleType.Location = new System.Drawing.Point(477, 38);
            this.cmbArticleType.Name = "cmbArticleType";
            this.cmbArticleType.Size = new System.Drawing.Size(97, 21);
            this.cmbArticleType.TabIndex = 176;
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(85, 65);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(495, 25);
            this.ctlEmployee1.TabIndex = 175;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Loan Type";
            // 
            // cmbLoanType
            // 
            this.cmbLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoanType.FormattingEnabled = true;
            this.cmbLoanType.Location = new System.Drawing.Point(270, 38);
            this.cmbLoanType.Name = "cmbLoanType";
            this.cmbLoanType.Size = new System.Drawing.Size(120, 21);
            this.cmbLoanType.TabIndex = 173;
            this.cmbLoanType.SelectedIndexChanged += new System.EventHandler(this.cmbLoanType_SelectedIndexChanged);
            // 
            // txtLoanNo
            // 
            this.txtLoanNo.Location = new System.Drawing.Point(85, 38);
            this.txtLoanNo.Name = "txtLoanNo";
            this.txtLoanNo.Size = new System.Drawing.Size(110, 20);
            this.txtLoanNo.TabIndex = 146;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 161;
            this.label10.Text = "Disburse Date";
            // 
            // lvwLoans
            // 
            this.lvwLoans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLoans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLoanNo,
            this.colDisburseDate,
            this.colLoanType,
            this.colArticleType,
            this.colAllocatedAmount,
            this.colNoOfInstallment,
            this.colInterestRate,
            this.colPrincipalPayable,
            this.colInterestPayable,
            this.colTotalPayable,
            this.colStatus,
            this.colEmployee,
            this.colCreateUser});
            this.lvwLoans.FullRowSelect = true;
            this.lvwLoans.GridLines = true;
            this.lvwLoans.Location = new System.Drawing.Point(12, 159);
            this.lvwLoans.MultiSelect = false;
            this.lvwLoans.Name = "lvwLoans";
            this.lvwLoans.Size = new System.Drawing.Size(731, 284);
            this.lvwLoans.TabIndex = 173;
            this.lvwLoans.UseCompatibleStateImageBehavior = false;
            this.lvwLoans.View = System.Windows.Forms.View.Details;
            // 
            // colLoanNo
            // 
            this.colLoanNo.Text = "Loan No";
            this.colLoanNo.Width = 76;
            // 
            // colDisburseDate
            // 
            this.colDisburseDate.Text = "Disburse Date";
            this.colDisburseDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDisburseDate.Width = 86;
            // 
            // colLoanType
            // 
            this.colLoanType.Text = "Loan Type";
            this.colLoanType.Width = 110;
            // 
            // colArticleType
            // 
            this.colArticleType.Text = "Article Type";
            this.colArticleType.Width = 70;
            // 
            // colAllocatedAmount
            // 
            this.colAllocatedAmount.Text = "Loan Amount";
            this.colAllocatedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAllocatedAmount.Width = 80;
            // 
            // colNoOfInstallment
            // 
            this.colNoOfInstallment.Text = "#Of Inst.";
            this.colNoOfInstallment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colInterestRate
            // 
            this.colInterestRate.Text = "IR(%)";
            this.colInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInterestRate.Width = 40;
            // 
            // colPrincipalPayable
            // 
            this.colPrincipalPayable.Text = "Principal Payable";
            this.colPrincipalPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPrincipalPayable.Width = 95;
            // 
            // colInterestPayable
            // 
            this.colInterestPayable.Text = "Interest Payable";
            this.colInterestPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInterestPayable.Width = 90;
            // 
            // colTotalPayable
            // 
            this.colTotalPayable.Text = "Total Payable";
            this.colTotalPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalPayable.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStatus.Width = 66;
            // 
            // colEmployee
            // 
            this.colEmployee.Text = "Employee";
            this.colEmployee.Width = 140;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 100;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(755, 310);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 27);
            this.btnDelete.TabIndex = 177;
            this.btnDelete.Tag = "M34.2.5";
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(755, 186);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 27);
            this.btnPrint.TabIndex = 176;
            this.btnPrint.Tag = "M34.2.4";
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(755, 157);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 27);
            this.btnAdd.TabIndex = 174;
            this.btnAdd.TabStop = false;
            this.btnAdd.Tag = "M34.2.1";
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(755, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 27);
            this.btnClose.TabIndex = 178;
            this.btnClose.Tag = "M34.2.5";
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 48);
            this.groupBox1.TabIndex = 179;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(9, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 172;
            this.chkAll.Text = "Enable/Disable Date Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnEarlySettle
            // 
            this.btnEarlySettle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEarlySettle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEarlySettle.Location = new System.Drawing.Point(755, 215);
            this.btnEarlySettle.Name = "btnEarlySettle";
            this.btnEarlySettle.Size = new System.Drawing.Size(80, 27);
            this.btnEarlySettle.TabIndex = 180;
            this.btnEarlySettle.Tag = "M34.2.4";
            this.btnEarlySettle.Text = "&Early Settle";
            this.btnEarlySettle.UseVisualStyleBackColor = true;
            this.btnEarlySettle.Click += new System.EventHandler(this.btnEarlySettle_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(777, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 233;
            this.label4.Text = "Closed";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Wheat;
            this.label2.Location = new System.Drawing.Point(776, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 232;
            this.label2.Text = "Running";
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(755, 245);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(80, 27);
            this.btnReport.TabIndex = 234;
            this.btnReport.Tag = "M34.2.4";
            this.btnReport.Text = "&Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 455);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEarlySettle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwLoans);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.lblComplainStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblComplainNo);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmLoans";
            this.Text = "Loans";
            this.Load += new System.EventHandler(this.frmLoans_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblComplainStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label lblComplainNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbLoanType;
        private System.Windows.Forms.TextBox txtLoanNo;
        private System.Windows.Forms.ListView lvwLoans;
        private System.Windows.Forms.ColumnHeader colLoanNo;
        private System.Windows.Forms.ColumnHeader colDisburseDate;
        private System.Windows.Forms.ColumnHeader colLoanType;
        private System.Windows.Forms.ColumnHeader colArticleType;
        private System.Windows.Forms.ColumnHeader colAllocatedAmount;
        private System.Windows.Forms.ColumnHeader colNoOfInstallment;
        private System.Windows.Forms.ColumnHeader colInterestRate;
        private System.Windows.Forms.ColumnHeader colPrincipalPayable;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colEmployee;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblArticleType;
        private System.Windows.Forms.ComboBox cmbArticleType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnEarlySettle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colInterestPayable;
        private System.Windows.Forms.ColumnHeader colTotalPayable;
        private System.Windows.Forms.Button btnReport;
    }
}