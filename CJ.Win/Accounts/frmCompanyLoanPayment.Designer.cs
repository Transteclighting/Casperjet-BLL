namespace CJ.Win.Accounts
{
    partial class frmCompanyLoanPayment
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
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckhIsCloseLoan = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoanNumber = new System.Windows.Forms.Label();
            this.lblLoanAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPrincipalPayable = new System.Windows.Forms.Label();
            this.lblInterestPayable = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(117, 116);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(115, 20);
            this.txtPayment.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Payment (DBT):";
            // 
            // ckhIsCloseLoan
            // 
            this.ckhIsCloseLoan.AutoSize = true;
            this.ckhIsCloseLoan.Location = new System.Drawing.Point(257, 116);
            this.ckhIsCloseLoan.Name = "ckhIsCloseLoan";
            this.ckhIsCloseLoan.Size = new System.Drawing.Size(96, 17);
            this.ckhIsCloseLoan.TabIndex = 4;
            this.ckhIsCloseLoan.Text = "Is Close Loan?";
            this.ckhIsCloseLoan.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(117, 142);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(374, 20);
            this.txtRemarks.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(328, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 26);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(414, 180);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 26);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPaymentDate.Location = new System.Drawing.Point(117, 90);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(115, 20);
            this.dtPaymentDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Payment Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Loan Number:";
            // 
            // lblLoanNumber
            // 
            this.lblLoanNumber.AutoSize = true;
            this.lblLoanNumber.Location = new System.Drawing.Point(124, 26);
            this.lblLoanNumber.Name = "lblLoanNumber";
            this.lblLoanNumber.Size = new System.Drawing.Size(13, 13);
            this.lblLoanNumber.TabIndex = 12;
            this.lblLoanNumber.Text = "?";
            // 
            // lblLoanAmount
            // 
            this.lblLoanAmount.AutoSize = true;
            this.lblLoanAmount.Location = new System.Drawing.Point(383, 27);
            this.lblLoanAmount.Name = "lblLoanAmount";
            this.lblLoanAmount.Size = new System.Drawing.Size(13, 13);
            this.lblLoanAmount.TabIndex = 14;
            this.lblLoanAmount.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Loan Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Principal Payable:";
            // 
            // lblPrincipalPayable
            // 
            this.lblPrincipalPayable.AutoSize = true;
            this.lblPrincipalPayable.Location = new System.Drawing.Point(123, 49);
            this.lblPrincipalPayable.Name = "lblPrincipalPayable";
            this.lblPrincipalPayable.Size = new System.Drawing.Size(13, 13);
            this.lblPrincipalPayable.TabIndex = 16;
            this.lblPrincipalPayable.Text = "?";
            // 
            // lblInterestPayable
            // 
            this.lblInterestPayable.AutoSize = true;
            this.lblInterestPayable.Location = new System.Drawing.Point(383, 49);
            this.lblInterestPayable.Name = "lblInterestPayable";
            this.lblInterestPayable.Size = new System.Drawing.Size(13, 13);
            this.lblInterestPayable.TabIndex = 18;
            this.lblInterestPayable.Text = "?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Interest Payable:";
            // 
            // frmCompanyLoanPayment
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 219);
            this.Controls.Add(this.lblInterestPayable);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPrincipalPayable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLoanAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLoanNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtPaymentDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.ckhIsCloseLoan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPayment);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompanyLoanPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Loan Payment";
            this.Load += new System.EventHandler(this.frmCompanyLoanPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckhIsCloseLoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtPaymentDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLoanNumber;
        private System.Windows.Forms.Label lblLoanAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPrincipalPayable;
        private System.Windows.Forms.Label lblInterestPayable;
        private System.Windows.Forms.Label label8;
    }
}