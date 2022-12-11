namespace CJ.Win.HR
{
    partial class frmLoanCalculator
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
            this.txtInteresrRate = new System.Windows.Forms.TextBox();
            this.btPrint = new System.Windows.Forms.Button();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInstallmentNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEMI = new System.Windows.Forms.DataGridView();
            this.InstallNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalancePrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrincipalPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthlyPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBonusAdjust = new System.Windows.Forms.CheckBox();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkIsPFLoan = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMI)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInteresrRate
            // 
            this.txtInteresrRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtInteresrRate.Location = new System.Drawing.Point(344, 46);
            this.txtInteresrRate.Name = "txtInteresrRate";
            this.txtInteresrRate.Size = new System.Drawing.Size(50, 20);
            this.txtInteresrRate.TabIndex = 7;
            this.txtInteresrRate.Text = "0.00";
            this.txtInteresrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(429, 94);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 26);
            this.btPrint.TabIndex = 12;
            this.btPrint.Text = "View";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(107, 43);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(117, 20);
            this.dtStartDate.TabIndex = 5;
            // 
            // txtPV
            // 
            this.txtPV.BackColor = System.Drawing.SystemColors.Window;
            this.txtPV.Location = new System.Drawing.Point(107, 13);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(117, 20);
            this.txtPV.TabIndex = 1;
            this.txtPV.Text = "0.00";
            this.txtPV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Interest Rate";
            // 
            // txtInstallmentNo
            // 
            this.txtInstallmentNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtInstallmentNo.Location = new System.Drawing.Point(344, 13);
            this.txtInstallmentNo.Name = "txtInstallmentNo";
            this.txtInstallmentNo.Size = new System.Drawing.Size(50, 20);
            this.txtInstallmentNo.TabIndex = 3;
            this.txtInstallmentNo.Text = "0";
            this.txtInstallmentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "# of Installment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Disburse Date";
            // 
            // dgvEMI
            // 
            this.dgvEMI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEMI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEMI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InstallNo,
            this.BalancePrincipal,
            this.PrincipalPay,
            this.InterestPay,
            this.MonthlyPay,
            this.Month});
            this.dgvEMI.Location = new System.Drawing.Point(16, 124);
            this.dgvEMI.Name = "dgvEMI";
            this.dgvEMI.Size = new System.Drawing.Size(488, 330);
            this.dgvEMI.TabIndex = 13;
            // 
            // InstallNo
            // 
            this.InstallNo.HeaderText = "Install No";
            this.InstallNo.Name = "InstallNo";
            this.InstallNo.Width = 60;
            // 
            // BalancePrincipal
            // 
            this.BalancePrincipal.HeaderText = "Balance Principal";
            this.BalancePrincipal.Name = "BalancePrincipal";
            // 
            // PrincipalPay
            // 
            this.PrincipalPay.HeaderText = "Principal Payable";
            this.PrincipalPay.Name = "PrincipalPay";
            this.PrincipalPay.Width = 60;
            // 
            // InterestPay
            // 
            this.InterestPay.HeaderText = "Interest Payable";
            this.InterestPay.Name = "InterestPay";
            this.InterestPay.Width = 60;
            // 
            // MonthlyPay
            // 
            this.MonthlyPay.HeaderText = "Monthly Instalment";
            this.MonthlyPay.Name = "MonthlyPay";
            this.MonthlyPay.Width = 60;
            // 
            // Month
            // 
            this.Month.HeaderText = "Payment Month";
            this.Month.Name = "Month";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(348, 94);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 26);
            this.btnProcess.TabIndex = 11;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Principle Value";
            // 
            // chkBonusAdjust
            // 
            this.chkBonusAdjust.AutoSize = true;
            this.chkBonusAdjust.Location = new System.Drawing.Point(107, 72);
            this.chkBonusAdjust.Name = "chkBonusAdjust";
            this.chkBonusAdjust.Size = new System.Drawing.Size(105, 17);
            this.chkBonusAdjust.TabIndex = 8;
            this.chkBonusAdjust.Text = "Is Bonus Adjust?";
            this.chkBonusAdjust.UseVisualStyleBackColor = true;
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.BackColor = System.Drawing.SystemColors.Window;
            this.txtBasicSalary.Location = new System.Drawing.Point(107, 95);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(101, 20);
            this.txtBasicSalary.TabIndex = 10;
            this.txtBasicSalary.Text = "0.00";
            this.txtBasicSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Basic Salary";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Install No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Balance Principal";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Principal Payable";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Interest Payable";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Monthly Instalment";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Payment Month";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // chkIsPFLoan
            // 
            this.chkIsPFLoan.AutoSize = true;
            this.chkIsPFLoan.Location = new System.Drawing.Point(276, 72);
            this.chkIsPFLoan.Name = "chkIsPFLoan";
            this.chkIsPFLoan.Size = new System.Drawing.Size(83, 17);
            this.chkIsPFLoan.TabIndex = 14;
            this.chkIsPFLoan.Text = "Is PF Loan?";
            this.chkIsPFLoan.UseVisualStyleBackColor = true;
            // 
            // frmLoanCalculator
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 471);
            this.Controls.Add(this.chkIsPFLoan);
            this.Controls.Add(this.txtBasicSalary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkBonusAdjust);
            this.Controls.Add(this.txtInteresrRate);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.txtPV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInstallmentNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvEMI);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoanCalculator";
            this.Text = "Loan Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TextBox txtInteresrRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInstallmentNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEMI;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstallNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalancePrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrincipalPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthlyPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.CheckBox chkBonusAdjust;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsPFLoan;
    }
}