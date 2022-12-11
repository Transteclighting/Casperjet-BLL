namespace CJ.Win.HR
{
    partial class frmLoan
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
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInstallmentNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEMI = new System.Windows.Forms.DataGridView();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblComplainNo = new System.Windows.Forms.Label();
            this.lblArticleType = new System.Windows.Forms.Label();
            this.cmbArticleType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoanType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDownPayment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.InstallNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalancePrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrincipalPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthlyPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMI)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInteresrRate
            // 
            this.txtInteresrRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtInteresrRate.Location = new System.Drawing.Point(345, 44);
            this.txtInteresrRate.Name = "txtInteresrRate";
            this.txtInteresrRate.Size = new System.Drawing.Size(117, 20);
            this.txtInteresrRate.TabIndex = 7;
            this.txtInteresrRate.Text = "0.00";
            this.txtInteresrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(108, 124);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(117, 20);
            this.dtStartDate.TabIndex = 15;
            // 
            // txtPV
            // 
            this.txtPV.BackColor = System.Drawing.SystemColors.Window;
            this.txtPV.Location = new System.Drawing.Point(108, 17);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(117, 20);
            this.txtPV.TabIndex = 1;
            this.txtPV.Text = "0.00";
            this.txtPV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(274, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Interest Rate";
            // 
            // txtInstallmentNo
            // 
            this.txtInstallmentNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtInstallmentNo.Location = new System.Drawing.Point(108, 45);
            this.txtInstallmentNo.Name = "txtInstallmentNo";
            this.txtInstallmentNo.Size = new System.Drawing.Size(117, 20);
            this.txtInstallmentNo.TabIndex = 5;
            this.txtInstallmentNo.Text = "0";
            this.txtInstallmentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "# of Installment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Disburse Date";
            // 
            // dgvEMI
            // 
            this.dgvEMI.AllowUserToAddRows = false;
            this.dgvEMI.AllowUserToDeleteRows = false;
            this.dgvEMI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEMI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InstallNo,
            this.BalancePrincipal,
            this.PrincipalPay,
            this.InterestPay,
            this.MonthlyPay,
            this.Month});
            this.dgvEMI.Location = new System.Drawing.Point(12, 150);
            this.dgvEMI.Name = "dgvEMI";
            this.dgvEMI.ReadOnly = true;
            this.dgvEMI.Size = new System.Drawing.Size(505, 286);
            this.dgvEMI.TabIndex = 19;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(453, 123);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(65, 23);
            this.btnProcess.TabIndex = 16;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Allocated Amount";
            // 
            // lblComplainNo
            // 
            this.lblComplainNo.AutoSize = true;
            this.lblComplainNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainNo.Location = new System.Drawing.Point(34, 102);
            this.lblComplainNo.Name = "lblComplainNo";
            this.lblComplainNo.Size = new System.Drawing.Size(70, 13);
            this.lblComplainNo.TabIndex = 12;
            this.lblComplainNo.Text = "Employee No";
            // 
            // lblArticleType
            // 
            this.lblArticleType.AutoSize = true;
            this.lblArticleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticleType.Location = new System.Drawing.Point(279, 74);
            this.lblArticleType.Name = "lblArticleType";
            this.lblArticleType.Size = new System.Drawing.Size(63, 13);
            this.lblArticleType.TabIndex = 10;
            this.lblArticleType.Text = "Article Type";
            // 
            // cmbArticleType
            // 
            this.cmbArticleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArticleType.FormattingEnabled = true;
            this.cmbArticleType.Location = new System.Drawing.Point(345, 70);
            this.cmbArticleType.Name = "cmbArticleType";
            this.cmbArticleType.Size = new System.Drawing.Size(117, 21);
            this.cmbArticleType.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Loan Type";
            // 
            // cmbLoanType
            // 
            this.cmbLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoanType.FormattingEnabled = true;
            this.cmbLoanType.Location = new System.Drawing.Point(108, 70);
            this.cmbLoanType.Name = "cmbLoanType";
            this.cmbLoanType.Size = new System.Drawing.Size(147, 21);
            this.cmbLoanType.TabIndex = 9;
            this.cmbLoanType.SelectedIndexChanged += new System.EventHandler(this.cmbLoanType_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(454, 443);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDownPayment
            // 
            this.txtDownPayment.BackColor = System.Drawing.SystemColors.Window;
            this.txtDownPayment.Location = new System.Drawing.Point(345, 17);
            this.txtDownPayment.Name = "txtDownPayment";
            this.txtDownPayment.Size = new System.Drawing.Size(117, 20);
            this.txtDownPayment.TabIndex = 3;
            this.txtDownPayment.Text = "0.00";
            this.txtDownPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Down Payment";
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
            this.dataGridViewTextBoxColumn2.Width = 90;
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
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(108, 98);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(415, 25);
            this.ctlEmployee1.TabIndex = 13;
            // 
            // InstallNo
            // 
            this.InstallNo.HeaderText = "Installment No";
            this.InstallNo.Name = "InstallNo";
            this.InstallNo.ReadOnly = true;
            this.InstallNo.Width = 60;
            // 
            // BalancePrincipal
            // 
            this.BalancePrincipal.HeaderText = "Balance Principal";
            this.BalancePrincipal.Name = "BalancePrincipal";
            this.BalancePrincipal.ReadOnly = true;
            this.BalancePrincipal.Width = 85;
            // 
            // PrincipalPay
            // 
            this.PrincipalPay.HeaderText = "Principal Payable";
            this.PrincipalPay.Name = "PrincipalPay";
            this.PrincipalPay.ReadOnly = true;
            this.PrincipalPay.Width = 75;
            // 
            // InterestPay
            // 
            this.InterestPay.HeaderText = "Interest Payable";
            this.InterestPay.Name = "InterestPay";
            this.InterestPay.ReadOnly = true;
            this.InterestPay.Width = 80;
            // 
            // MonthlyPay
            // 
            this.MonthlyPay.HeaderText = "Monthly Instalment";
            this.MonthlyPay.Name = "MonthlyPay";
            this.MonthlyPay.ReadOnly = true;
            this.MonthlyPay.Width = 80;
            // 
            // Month
            // 
            this.Month.HeaderText = "Payment Month";
            this.Month.Name = "Month";
            this.Month.ReadOnly = true;
            this.Month.Width = 80;
            // 
            // frmLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 470);
            this.Controls.Add(this.txtDownPayment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblArticleType);
            this.Controls.Add(this.cmbArticleType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLoanType);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.lblComplainNo);
            this.Controls.Add(this.txtInteresrRate);
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
            this.Name = "frmLoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan";
            this.Load += new System.EventHandler(this.frmLoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox txtInteresrRate;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInstallmentNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEMI;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label lblComplainNo;
        private System.Windows.Forms.Label lblArticleType;
        private System.Windows.Forms.ComboBox cmbArticleType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLoanType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDownPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstallNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalancePrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrincipalPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthlyPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
    }
}