namespace CJ.Win.EPS
{
    partial class frmEMICalculation
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
            this.label7 = new System.Windows.Forms.Label();
            this.txtInstallmentNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btShowEMI = new System.Windows.Forms.Button();
            this.dgvEMI = new System.Windows.Forms.DataGridView();
            this.InstallNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalancePrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrincipalPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthlyPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.btPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMI)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInteresrRate
            // 
            this.txtInteresrRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtInteresrRate.Location = new System.Drawing.Point(121, 57);
            this.txtInteresrRate.Name = "txtInteresrRate";
            this.txtInteresrRate.Size = new System.Drawing.Size(117, 20);
            this.txtInteresrRate.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Interest Rate";
            // 
            // txtInstallmentNo
            // 
            this.txtInstallmentNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtInstallmentNo.Location = new System.Drawing.Point(121, 31);
            this.txtInstallmentNo.Name = "txtInstallmentNo";
            this.txtInstallmentNo.Size = new System.Drawing.Size(117, 20);
            this.txtInstallmentNo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = " Number of Installment";
            // 
            // txtPV
            // 
            this.txtPV.BackColor = System.Drawing.SystemColors.Window;
            this.txtPV.Location = new System.Drawing.Point(121, 6);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(117, 20);
            this.txtPV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PV Amount";
            // 
            // btShowEMI
            // 
            this.btShowEMI.Location = new System.Drawing.Point(121, 85);
            this.btShowEMI.Name = "btShowEMI";
            this.btShowEMI.Size = new System.Drawing.Size(75, 23);
            this.btShowEMI.TabIndex = 6;
            this.btShowEMI.Text = "Show Detail";
            this.btShowEMI.UseVisualStyleBackColor = true;
            this.btShowEMI.Click += new System.EventHandler(this.btShowEMI_Click);
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
            this.dgvEMI.Location = new System.Drawing.Point(6, 114);
            this.dgvEMI.Name = "dgvEMI";
            this.dgvEMI.Size = new System.Drawing.Size(643, 377);
            this.dgvEMI.TabIndex = 7;
            // 
            // InstallNo
            // 
            this.InstallNo.HeaderText = "Install No";
            this.InstallNo.Name = "InstallNo";
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
            // 
            // InterestPay
            // 
            this.InterestPay.HeaderText = "Interest Payable";
            this.InterestPay.Name = "InterestPay";
            // 
            // MonthlyPay
            // 
            this.MonthlyPay.HeaderText = "Monthly Instalment";
            this.MonthlyPay.Name = "MonthlyPay";
            // 
            // Month
            // 
            this.Month.HeaderText = "Payment Month";
            this.Month.Name = "Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Strating Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStartDate.Location = new System.Drawing.Point(346, 5);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(92, 20);
            this.dtStartDate.TabIndex = 9;
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(202, 85);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 23);
            this.btPrint.TabIndex = 10;
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // frmEMICalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 491);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvEMI);
            this.Controls.Add(this.btShowEMI);
            this.Controls.Add(this.txtPV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInteresrRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtInstallmentNo);
            this.Controls.Add(this.label6);
            this.Name = "frmEMICalculation";
            this.Text = "EMI Calculation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInteresrRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInstallmentNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btShowEMI;
        private System.Windows.Forms.DataGridView dgvEMI;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstallNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalancePrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrincipalPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthlyPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Button btPrint;
    }
}