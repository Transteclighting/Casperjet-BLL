namespace CJ.Win.Accounts
{
    partial class frmCompanyLoan
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLoanType = new System.Windows.Forms.ComboBox();
            this.txtLC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoanNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.lbReceiveDate = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtExpireDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPurposeOfLoan = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbSupplyType = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.lblConvRate = new System.Windows.Forms.Label();
            this.txtConversionRate = new System.Windows.Forms.TextBox();
            this.txtConversionAmount = new System.Windows.Forms.TextBox();
            this.lblConvAmount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Bank";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(99, 71);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(169, 21);
            this.cmbBank.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Loan Type";
            // 
            // cmbLoanType
            // 
            this.cmbLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoanType.FormattingEnabled = true;
            this.cmbLoanType.Location = new System.Drawing.Point(99, 44);
            this.cmbLoanType.Name = "cmbLoanType";
            this.cmbLoanType.Size = new System.Drawing.Size(168, 21);
            this.cmbLoanType.TabIndex = 37;
            // 
            // txtLC
            // 
            this.txtLC.AcceptsReturn = true;
            this.txtLC.AcceptsTab = true;
            this.txtLC.Location = new System.Drawing.Point(99, 124);
            this.txtLC.Name = "txtLC";
            this.txtLC.Size = new System.Drawing.Size(168, 20);
            this.txtLC.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "LC#";
            // 
            // txtLoanNumber
            // 
            this.txtLoanNumber.AcceptsReturn = true;
            this.txtLoanNumber.AcceptsTab = true;
            this.txtLoanNumber.Location = new System.Drawing.Point(99, 98);
            this.txtLoanNumber.Name = "txtLoanNumber";
            this.txtLoanNumber.Size = new System.Drawing.Size(168, 20);
            this.txtLoanNumber.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Loan#";
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceiveDate.Location = new System.Drawing.Point(98, 150);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(98, 20);
            this.dtReceiveDate.TabIndex = 45;
            // 
            // lbReceiveDate
            // 
            this.lbReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReceiveDate.Location = new System.Drawing.Point(8, 152);
            this.lbReceiveDate.Name = "lbReceiveDate";
            this.lbReceiveDate.Size = new System.Drawing.Size(87, 13);
            this.lbReceiveDate.TabIndex = 44;
            this.lbReceiveDate.Text = "Receive Date";
            this.lbReceiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.AcceptsReturn = true;
            this.txtAmount.AcceptsTab = true;
            this.txtAmount.Location = new System.Drawing.Point(157, 176);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(111, 20);
            this.txtAmount.TabIndex = 47;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Amount";
            // 
            // txtDuration
            // 
            this.txtDuration.AcceptsReturn = true;
            this.txtDuration.AcceptsTab = true;
            this.txtDuration.Location = new System.Drawing.Point(98, 202);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(97, 20);
            this.txtDuration.TabIndex = 49;
            this.txtDuration.TextChanged += new System.EventHandler(this.txtDuration_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Duration";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.AcceptsReturn = true;
            this.txtInterestRate.AcceptsTab = true;
            this.txtInterestRate.Location = new System.Drawing.Point(98, 228);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(97, 20);
            this.txtInterestRate.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Interest Rate";
            // 
            // dtExpireDate
            // 
            this.dtExpireDate.CustomFormat = "dd-MMM-yyyy";
            this.dtExpireDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpireDate.Location = new System.Drawing.Point(98, 254);
            this.dtExpireDate.Name = "dtExpireDate";
            this.dtExpireDate.Size = new System.Drawing.Size(98, 20);
            this.dtExpireDate.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Expire Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPurposeOfLoan
            // 
            this.txtPurposeOfLoan.AcceptsReturn = true;
            this.txtPurposeOfLoan.AcceptsTab = true;
            this.txtPurposeOfLoan.Location = new System.Drawing.Point(98, 280);
            this.txtPurposeOfLoan.Multiline = true;
            this.txtPurposeOfLoan.Name = "txtPurposeOfLoan";
            this.txtPurposeOfLoan.Size = new System.Drawing.Size(375, 50);
            this.txtPurposeOfLoan.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "Purpose of Loan";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 340);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Supply Type";
            // 
            // cmbSupplyType
            // 
            this.cmbSupplyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplyType.FormattingEnabled = true;
            this.cmbSupplyType.Location = new System.Drawing.Point(98, 336);
            this.cmbSupplyType.Name = "cmbSupplyType";
            this.cmbSupplyType.Size = new System.Drawing.Size(169, 21);
            this.cmbSupplyType.TabIndex = 57;
            // 
            // txtRemarks
            // 
            this.txtRemarks.AcceptsReturn = true;
            this.txtRemarks.AcceptsTab = true;
            this.txtRemarks.Location = new System.Drawing.Point(99, 363);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(375, 25);
            this.txtRemarks.TabIndex = 59;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 364);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Remarks";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(403, 399);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 27);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(324, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 27);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(98, 175);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(52, 21);
            this.cmbCurrency.TabIndex = 62;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            // 
            // lblConvRate
            // 
            this.lblConvRate.AutoSize = true;
            this.lblConvRate.Location = new System.Drawing.Point(277, 160);
            this.lblConvRate.Name = "lblConvRate";
            this.lblConvRate.Size = new System.Drawing.Size(61, 13);
            this.lblConvRate.TabIndex = 63;
            this.lblConvRate.Text = "Conv. Rate";
            // 
            // txtConversionRate
            // 
            this.txtConversionRate.AcceptsReturn = true;
            this.txtConversionRate.AcceptsTab = true;
            this.txtConversionRate.Location = new System.Drawing.Point(277, 175);
            this.txtConversionRate.Name = "txtConversionRate";
            this.txtConversionRate.Size = new System.Drawing.Size(58, 20);
            this.txtConversionRate.TabIndex = 64;
            this.txtConversionRate.TextChanged += new System.EventHandler(this.txtConversionRate_TextChanged);
            // 
            // txtConversionAmount
            // 
            this.txtConversionAmount.AcceptsReturn = true;
            this.txtConversionAmount.AcceptsTab = true;
            this.txtConversionAmount.Location = new System.Drawing.Point(344, 175);
            this.txtConversionAmount.Name = "txtConversionAmount";
            this.txtConversionAmount.Size = new System.Drawing.Size(87, 20);
            this.txtConversionAmount.TabIndex = 66;
            // 
            // lblConvAmount
            // 
            this.lblConvAmount.AutoSize = true;
            this.lblConvAmount.Location = new System.Drawing.Point(346, 160);
            this.lblConvAmount.Name = "lblConvAmount";
            this.lblConvAmount.Size = new System.Drawing.Size(74, 13);
            this.lblConvAmount.TabIndex = 65;
            this.lblConvAmount.Text = "Conv. Amount";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(98, 17);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(270, 21);
            this.cmbCompany.TabIndex = 68;
            // 
            // frmCompanyLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 438);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.txtConversionAmount);
            this.Controls.Add(this.lblConvAmount);
            this.Controls.Add(this.txtConversionRate);
            this.Controls.Add(this.lblConvRate);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbSupplyType);
            this.Controls.Add(this.txtPurposeOfLoan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtExpireDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtReceiveDate);
            this.Controls.Add(this.lbReceiveDate);
            this.Controls.Add(this.txtLC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLoanNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbLoanType);
            this.Name = "frmCompanyLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Loan";
            this.Load += new System.EventHandler(this.frmCompanyLoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLoanType;
        private System.Windows.Forms.TextBox txtLC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoanNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
        private System.Windows.Forms.Label lbReceiveDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtExpireDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPurposeOfLoan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbSupplyType;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label lblConvRate;
        private System.Windows.Forms.TextBox txtConversionRate;
        private System.Windows.Forms.TextBox txtConversionAmount;
        private System.Windows.Forms.Label lblConvAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbCompany;
    }
}