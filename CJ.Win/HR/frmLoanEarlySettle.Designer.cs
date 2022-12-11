namespace CJ.Win.HR
{
    partial class frmLoanEarlySettle
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
            this.lvwItems = new System.Windows.Forms.ListView();
            this.colInstallNo = new System.Windows.Forms.ColumnHeader();
            this.colBalancePrincipal = new System.Windows.Forms.ColumnHeader();
            this.colPrincipalPayable = new System.Windows.Forms.ColumnHeader();
            this.colInterestPayable = new System.Windows.Forms.ColumnHeader();
            this.colTotalPayable = new System.Windows.Forms.ColumnHeader();
            this.colPaymentDate = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLoanNo = new System.Windows.Forms.Label();
            this.lblLoanType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLoanAmount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDisburseDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNoOfInstallment = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblEmployeeNo = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPrincipalPayable = new System.Windows.Forms.Label();
            this.lblInterestPayable = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalPayable = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrincipalAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtInterestAmount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            this.lblTotalReceive = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInstallNo,
            this.colBalancePrincipal,
            this.colPrincipalPayable,
            this.colInterestPayable,
            this.colTotalPayable,
            this.colPaymentDate});
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.GridLines = true;
            this.lvwItems.Location = new System.Drawing.Point(12, 152);
            this.lvwItems.MultiSelect = false;
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(595, 153);
            this.lvwItems.TabIndex = 174;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            // 
            // colInstallNo
            // 
            this.colInstallNo.Text = "Installment No";
            this.colInstallNo.Width = 80;
            // 
            // colBalancePrincipal
            // 
            this.colBalancePrincipal.Text = "Balance Principal";
            this.colBalancePrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBalancePrincipal.Width = 100;
            // 
            // colPrincipalPayable
            // 
            this.colPrincipalPayable.Text = "Principal Payable";
            this.colPrincipalPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPrincipalPayable.Width = 100;
            // 
            // colInterestPayable
            // 
            this.colInterestPayable.Text = "Interest Payable";
            this.colInterestPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInterestPayable.Width = 100;
            // 
            // colTotalPayable
            // 
            this.colTotalPayable.Text = "Total Payable";
            this.colTotalPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalPayable.Width = 100;
            // 
            // colPaymentDate
            // 
            this.colPaymentDate.Text = "Payment Month";
            this.colPaymentDate.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 175;
            this.label1.Text = "Loan Number:";
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Location = new System.Drawing.Point(98, 18);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(13, 13);
            this.lblLoanNo.TabIndex = 176;
            this.lblLoanNo.Text = "?";
            // 
            // lblLoanType
            // 
            this.lblLoanType.AutoSize = true;
            this.lblLoanType.Location = new System.Drawing.Point(98, 36);
            this.lblLoanType.Name = "lblLoanType";
            this.lblLoanType.Size = new System.Drawing.Size(13, 13);
            this.lblLoanType.TabIndex = 178;
            this.lblLoanType.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 177;
            this.label3.Text = "Loan Type:";
            // 
            // lblLoanAmount
            // 
            this.lblLoanAmount.AutoSize = true;
            this.lblLoanAmount.Location = new System.Drawing.Point(98, 56);
            this.lblLoanAmount.Name = "lblLoanAmount";
            this.lblLoanAmount.Size = new System.Drawing.Size(13, 13);
            this.lblLoanAmount.TabIndex = 180;
            this.lblLoanAmount.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 179;
            this.label5.Text = "Loan Amount:";
            // 
            // lblDisburseDate
            // 
            this.lblDisburseDate.AutoSize = true;
            this.lblDisburseDate.Location = new System.Drawing.Point(98, 76);
            this.lblDisburseDate.Name = "lblDisburseDate";
            this.lblDisburseDate.Size = new System.Drawing.Size(13, 13);
            this.lblDisburseDate.TabIndex = 182;
            this.lblDisburseDate.Text = "?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 181;
            this.label7.Text = "Disburse Date:";
            // 
            // lblNoOfInstallment
            // 
            this.lblNoOfInstallment.AutoSize = true;
            this.lblNoOfInstallment.Location = new System.Drawing.Point(98, 94);
            this.lblNoOfInstallment.Name = "lblNoOfInstallment";
            this.lblNoOfInstallment.Size = new System.Drawing.Size(13, 13);
            this.lblNoOfInstallment.TabIndex = 184;
            this.lblNoOfInstallment.Text = "?";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 183;
            this.label9.Text = "# of Installment:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(96, 92);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(13, 13);
            this.lblCompany.TabIndex = 194;
            this.lblCompany.Text = "?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 193;
            this.label11.Text = "Company:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(96, 73);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(13, 13);
            this.lblDepartment.TabIndex = 192;
            this.lblDepartment.Text = "?";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 191;
            this.label13.Text = "Department:";
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Location = new System.Drawing.Point(96, 54);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(13, 13);
            this.lblDesignation.TabIndex = 190;
            this.lblDesignation.Text = "?";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 189;
            this.label15.Text = "Designation:";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(96, 36);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(13, 13);
            this.lblEmployeeName.TabIndex = 188;
            this.lblEmployeeName.Text = "?";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 13);
            this.label17.TabIndex = 187;
            this.label17.Text = "Employee Name:";
            // 
            // lblEmployeeNo
            // 
            this.lblEmployeeNo.AutoSize = true;
            this.lblEmployeeNo.Location = new System.Drawing.Point(96, 17);
            this.lblEmployeeNo.Name = "lblEmployeeNo";
            this.lblEmployeeNo.Size = new System.Drawing.Size(13, 13);
            this.lblEmployeeNo.TabIndex = 186;
            this.lblEmployeeNo.Text = "?";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 13);
            this.label19.TabIndex = 185;
            this.label19.Text = "Employee No:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 136);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 13);
            this.label20.TabIndex = 195;
            this.label20.Text = "Due Installment";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNoOfInstallment);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblDisburseDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblLoanAmount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblLoanType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblLoanNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.groupBox1.Location = new System.Drawing.Point(322, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 116);
            this.groupBox1.TabIndex = 196;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loan Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCompany);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblDepartment);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblDesignation);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblEmployeeName);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.lblEmployeeNo);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Location = new System.Drawing.Point(12, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 116);
            this.groupBox2.TabIndex = 197;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Info";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(453, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 26);
            this.btnSave.TabIndex = 198;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(532, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 26);
            this.btnClose.TabIndex = 199;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(95, 314);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(122, 20);
            this.dtFromDate.TabIndex = 201;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 200;
            this.label2.Text = "Settlement Date:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(40, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 202;
            this.label6.Text = "Remarks: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(95, 423);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(509, 20);
            this.txtRemarks.TabIndex = 203;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(420, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 204;
            this.label4.Text = "Principal Payable:";
            // 
            // lblPrincipalPayable
            // 
            this.lblPrincipalPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrincipalPayable.Location = new System.Drawing.Point(514, 311);
            this.lblPrincipalPayable.Name = "lblPrincipalPayable";
            this.lblPrincipalPayable.Size = new System.Drawing.Size(90, 14);
            this.lblPrincipalPayable.TabIndex = 205;
            this.lblPrincipalPayable.Text = "?";
            this.lblPrincipalPayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInterestPayable
            // 
            this.lblInterestPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterestPayable.Location = new System.Drawing.Point(514, 327);
            this.lblInterestPayable.Name = "lblInterestPayable";
            this.lblInterestPayable.Size = new System.Drawing.Size(90, 14);
            this.lblInterestPayable.TabIndex = 207;
            this.lblInterestPayable.Text = "?";
            this.lblInterestPayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(425, 327);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 206;
            this.label10.Text = "Interest Payable:";
            // 
            // lblTotalPayable
            // 
            this.lblTotalPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayable.Location = new System.Drawing.Point(514, 344);
            this.lblTotalPayable.Name = "lblTotalPayable";
            this.lblTotalPayable.Size = new System.Drawing.Size(90, 14);
            this.lblTotalPayable.TabIndex = 209;
            this.lblTotalPayable.Text = "?";
            this.lblTotalPayable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(436, 344);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 208;
            this.label12.Text = "Total Payable:";
            // 
            // txtPrincipalAmount
            // 
            this.txtPrincipalAmount.Location = new System.Drawing.Point(95, 340);
            this.txtPrincipalAmount.Name = "txtPrincipalAmount";
            this.txtPrincipalAmount.Size = new System.Drawing.Size(122, 20);
            this.txtPrincipalAmount.TabIndex = 210;
            this.txtPrincipalAmount.Text = "0";
            this.txtPrincipalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrincipalAmount.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Principal Amount:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 369);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 213;
            this.label14.Text = "Interest Amount:";
            // 
            // txtInterestAmount
            // 
            this.txtInterestAmount.Location = new System.Drawing.Point(95, 366);
            this.txtInterestAmount.Name = "txtInterestAmount";
            this.txtInterestAmount.Size = new System.Drawing.Size(122, 20);
            this.txtInterestAmount.TabIndex = 212;
            this.txtInterestAmount.Text = "0";
            this.txtInterestAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestAmount.TextChanged += new System.EventHandler(this.txtInterestAmount_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 397);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 214;
            this.label16.Text = "Amount (in word):";
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.AutoSize = true;
            this.lblAmountInWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWord.Location = new System.Drawing.Point(98, 398);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(19, 13);
            this.lblAmountInWord.TabIndex = 215;
            this.lblAmountInWord.Text = "??";
            // 
            // lblTotalReceive
            // 
            this.lblTotalReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReceive.Location = new System.Drawing.Point(303, 372);
            this.lblTotalReceive.Name = "lblTotalReceive";
            this.lblTotalReceive.Size = new System.Drawing.Size(95, 14);
            this.lblTotalReceive.TabIndex = 217;
            this.lblTotalReceive.Text = "0.00";
            this.lblTotalReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(228, 372);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 13);
            this.label21.TabIndex = 216;
            this.label21.Text = "Total Receive:";
            // 
            // frmLoanEarlySettle
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 480);
            this.Controls.Add(this.lblTotalReceive);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblAmountInWord);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtInterestAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrincipalAmount);
            this.Controls.Add(this.lblTotalPayable);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblInterestPayable);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPrincipalPayable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lvwItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoanEarlySettle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan Early Settle";
            this.Load += new System.EventHandler(this.frmLoanEarlySettle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.ColumnHeader colInstallNo;
        private System.Windows.Forms.ColumnHeader colBalancePrincipal;
        private System.Windows.Forms.ColumnHeader colPrincipalPayable;
        private System.Windows.Forms.ColumnHeader colInterestPayable;
        private System.Windows.Forms.ColumnHeader colTotalPayable;
        private System.Windows.Forms.ColumnHeader colPaymentDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoanNo;
        private System.Windows.Forms.Label lblLoanType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLoanAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDisburseDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNoOfInstallment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblEmployeeNo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrincipalPayable;
        private System.Windows.Forms.Label lblInterestPayable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalPayable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrincipalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtInterestAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblAmountInWord;
        private System.Windows.Forms.Label lblTotalReceive;
        private System.Windows.Forms.Label label21;
    }
}