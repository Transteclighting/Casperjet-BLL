namespace CJ.Win.HR
{
    partial class frmPayrolls
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwList = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.colTMonth = new System.Windows.Forms.ColumnHeader();
            this.colTYear = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colNoOfEmpl = new System.Windows.Forms.ColumnHeader();
            this.colGrossSalary = new System.Windows.Forms.ColumnHeader();
            this.colDeductAmount = new System.Windows.Forms.ColumnHeader();
            this.colNetSalary = new System.Windows.Forms.ColumnHeader();
            this.colExpense = new System.Windows.Forms.ColumnHeader();
            this.colSubsidy = new System.Windows.Forms.ColumnHeader();
            this.colTotalSalary = new System.Windows.Forms.ColumnHeader();
            this.colCreateUser = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colVerifiedBy = new System.Windows.Forms.ColumnHeader();
            this.colVerifiedDate = new System.Windows.Forms.ColumnHeader();
            this.colApprovedBy = new System.Windows.Forms.ColumnHeader();
            this.colApprovedDate = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.dtSalaryMonth = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCompareReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStaffTopSheet = new System.Windows.Forms.Button();
            this.btnSendtoAccpac = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(759, 118);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 27);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwList
            // 
            this.lvwList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colCompany,
            this.colTMonth,
            this.colTYear,
            this.colType,
            this.colDescription,
            this.colStatus,
            this.colNoOfEmpl,
            this.colGrossSalary,
            this.colDeductAmount,
            this.colNetSalary,
            this.colExpense,
            this.colSubsidy,
            this.colTotalSalary,
            this.colCreateUser,
            this.colCreateDate,
            this.colVerifiedBy,
            this.colVerifiedDate,
            this.colApprovedBy,
            this.colApprovedDate});
            this.lvwList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(12, 119);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(736, 333);
            this.lvwList.TabIndex = 18;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.DoubleClick += new System.EventHandler(this.lvwList_DoubleClick);
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 70;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 64;
            // 
            // colTMonth
            // 
            this.colTMonth.Text = "Month";
            // 
            // colTYear
            // 
            this.colTYear.Text = "Year";
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 70;
            // 
            // colNoOfEmpl
            // 
            this.colNoOfEmpl.Text = "#OfEmpl";
            // 
            // colGrossSalary
            // 
            this.colGrossSalary.Text = "Gross Amount";
            this.colGrossSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colGrossSalary.Width = 80;
            // 
            // colDeductAmount
            // 
            this.colDeductAmount.Text = "Deduct Amount";
            this.colDeductAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDeductAmount.Width = 80;
            // 
            // colNetSalary
            // 
            this.colNetSalary.Text = "Net Salary";
            this.colNetSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNetSalary.Width = 80;
            // 
            // colExpense
            // 
            this.colExpense.Text = "Expense";
            this.colExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colExpense.Width = 80;
            // 
            // colSubsidy
            // 
            this.colSubsidy.Text = "Subsidy";
            this.colSubsidy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSubsidy.Width = 80;
            // 
            // colTotalSalary
            // 
            this.colTotalSalary.Text = "Total Salary";
            this.colTotalSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalSalary.Width = 80;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 70;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 70;
            // 
            // colVerifiedBy
            // 
            this.colVerifiedBy.Text = "Verified By";
            this.colVerifiedBy.Width = 70;
            // 
            // colVerifiedDate
            // 
            this.colVerifiedDate.Text = "Verified Date";
            this.colVerifiedDate.Width = 70;
            // 
            // colApprovedBy
            // 
            this.colApprovedBy.Text = "Approved By";
            this.colApprovedBy.Width = 70;
            // 
            // colApprovedDate
            // 
            this.colApprovedDate.Text = "Approved Date";
            this.colApprovedDate.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Month";
            // 
            // dtSalaryMonth
            // 
            this.dtSalaryMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryMonth.CustomFormat = "MMM-yyyy";
            this.dtSalaryMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalaryMonth.Location = new System.Drawing.Point(71, 39);
            this.dtSalaryMonth.Name = "dtSalaryMonth";
            this.dtSalaryMonth.ShowUpDown = true;
            this.dtSalaryMonth.Size = new System.Drawing.Size(115, 23);
            this.dtSalaryMonth.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(71, 13);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(213, 21);
            this.cmbCompany.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(382, 13);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(158, 21);
            this.cmbStatus.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(382, 39);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(158, 21);
            this.cmbType.TabIndex = 7;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(569, 83);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 25);
            this.btnGet.TabIndex = 10;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(759, 148);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 27);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(759, 387);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 27);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(759, 424);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(759, 178);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(92, 27);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(69, 67);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(215, 20);
            this.txtCode.TabIndex = 9;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.Location = new System.Drawing.Point(759, 238);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(92, 27);
            this.btnApprove.TabIndex = 15;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerify.Location = new System.Drawing.Point(759, 208);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(92, 27);
            this.btnVerify.TabIndex = 14;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightCoral;
            this.label6.Location = new System.Drawing.Point(12, 459);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Create";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.SandyBrown;
            this.label7.Location = new System.Drawing.Point(60, 459);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Verify";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label8.Location = new System.Drawing.Point(103, 459);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Approve";
            // 
            // btnCompareReport
            // 
            this.btnCompareReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompareReport.Location = new System.Drawing.Point(759, 267);
            this.btnCompareReport.Name = "btnCompareReport";
            this.btnCompareReport.Size = new System.Drawing.Size(92, 27);
            this.btnCompareReport.TabIndex = 22;
            this.btnCompareReport.Text = "Compare Report";
            this.btnCompareReport.UseVisualStyleBackColor = true;
            this.btnCompareReport.Click += new System.EventHandler(this.btnCompareReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtSalaryMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 93);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnStaffTopSheet
            // 
            this.btnStaffTopSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaffTopSheet.Location = new System.Drawing.Point(759, 298);
            this.btnStaffTopSheet.Name = "btnStaffTopSheet";
            this.btnStaffTopSheet.Size = new System.Drawing.Size(92, 27);
            this.btnStaffTopSheet.TabIndex = 24;
            this.btnStaffTopSheet.Text = "Staff Top Sheet";
            this.btnStaffTopSheet.UseVisualStyleBackColor = true;
            this.btnStaffTopSheet.Click += new System.EventHandler(this.btnStaffTopSheet_Click);
            // 
            // btnSendtoAccpac
            // 
            this.btnSendtoAccpac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendtoAccpac.Location = new System.Drawing.Point(759, 329);
            this.btnSendtoAccpac.Name = "btnSendtoAccpac";
            this.btnSendtoAccpac.Size = new System.Drawing.Size(92, 27);
            this.btnSendtoAccpac.TabIndex = 25;
            this.btnSendtoAccpac.Text = "Send to Accpac";
            this.btnSendtoAccpac.UseVisualStyleBackColor = true;
            this.btnSendtoAccpac.Click += new System.EventHandler(this.btnSendtoAccpac_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Thistle;
            this.label9.Location = new System.Drawing.Point(160, 459);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Send to Accpac";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(253, 459);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Post at Accpac";
            // 
            // frmPayrolls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 481);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSendtoAccpac);
            this.Controls.Add(this.btnStaffTopSheet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCompareReport);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmPayrolls";
            this.Text = "Payrolls";
            this.Load += new System.EventHandler(this.frmPayrolls_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colTMonth;
        private System.Windows.Forms.ColumnHeader colTYear;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colNoOfEmpl;
        private System.Windows.Forms.ColumnHeader colGrossSalary;
        private System.Windows.Forms.ColumnHeader colDeductAmount;
        private System.Windows.Forms.ColumnHeader colNetSalary;
        private System.Windows.Forms.ColumnHeader colExpense;
        private System.Windows.Forms.ColumnHeader colSubsidy;
        private System.Windows.Forms.ColumnHeader colTotalSalary;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtSalaryMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader colVerifiedBy;
        private System.Windows.Forms.ColumnHeader colVerifiedDate;
        private System.Windows.Forms.ColumnHeader colApprovedBy;
        private System.Windows.Forms.ColumnHeader colApprovedDate;
        private System.Windows.Forms.Button btnCompareReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStaffTopSheet;
        private System.Windows.Forms.Button btnSendtoAccpac;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}