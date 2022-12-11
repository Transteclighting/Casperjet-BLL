namespace CJ.Win.HR
{
    partial class frmMobileBillDeductionApproval
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtBillMonth = new System.Windows.Forms.TextBox();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.txtTotalLimit = new System.Windows.Forms.TextBox();
            this.txtDeductAmount = new System.Windows.Forms.TextBox();
            this.txtApproveAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkFullApprove = new System.Windows.Forms.CheckBox();
            this.txtDeductAfterApproval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mobile Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bill Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bill Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Limit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Deduct Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Approve Amount";
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(327, 107);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(81, 26);
            this.btnApprove.TabIndex = 14;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(414, 107);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 26);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(94, 9);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.ReadOnly = true;
            this.txtMobileNo.Size = new System.Drawing.Size(156, 20);
            this.txtMobileNo.TabIndex = 1;
            // 
            // txtBillMonth
            // 
            this.txtBillMonth.Location = new System.Drawing.Point(339, 9);
            this.txtBillMonth.Name = "txtBillMonth";
            this.txtBillMonth.ReadOnly = true;
            this.txtBillMonth.Size = new System.Drawing.Size(156, 20);
            this.txtBillMonth.TabIndex = 3;
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Location = new System.Drawing.Point(94, 33);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.ReadOnly = true;
            this.txtBillAmount.Size = new System.Drawing.Size(156, 20);
            this.txtBillAmount.TabIndex = 5;
            // 
            // txtTotalLimit
            // 
            this.txtTotalLimit.Location = new System.Drawing.Point(339, 33);
            this.txtTotalLimit.Name = "txtTotalLimit";
            this.txtTotalLimit.ReadOnly = true;
            this.txtTotalLimit.Size = new System.Drawing.Size(156, 20);
            this.txtTotalLimit.TabIndex = 7;
            // 
            // txtDeductAmount
            // 
            this.txtDeductAmount.Location = new System.Drawing.Point(94, 56);
            this.txtDeductAmount.Name = "txtDeductAmount";
            this.txtDeductAmount.ReadOnly = true;
            this.txtDeductAmount.Size = new System.Drawing.Size(156, 20);
            this.txtDeductAmount.TabIndex = 9;
            // 
            // txtApproveAmount
            // 
            this.txtApproveAmount.Location = new System.Drawing.Point(339, 56);
            this.txtApproveAmount.Name = "txtApproveAmount";
            this.txtApproveAmount.Size = new System.Drawing.Size(156, 20);
            this.txtApproveAmount.TabIndex = 11;
            this.txtApproveAmount.TextChanged += new System.EventHandler(this.txtApproveAmount_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Full Approve";
            // 
            // chkFullApprove
            // 
            this.chkFullApprove.AutoSize = true;
            this.chkFullApprove.Location = new System.Drawing.Point(94, 81);
            this.chkFullApprove.Name = "chkFullApprove";
            this.chkFullApprove.Size = new System.Drawing.Size(15, 14);
            this.chkFullApprove.TabIndex = 13;
            this.chkFullApprove.UseVisualStyleBackColor = true;
            this.chkFullApprove.CheckedChanged += new System.EventHandler(this.chkFullApprove_CheckedChanged);
            // 
            // txtDeductAfterApproval
            // 
            this.txtDeductAfterApproval.Location = new System.Drawing.Point(339, 81);
            this.txtDeductAfterApproval.Name = "txtDeductAfterApproval";
            this.txtDeductAfterApproval.ReadOnly = true;
            this.txtDeductAfterApproval.Size = new System.Drawing.Size(156, 20);
            this.txtDeductAfterApproval.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Deduct after Approval";
            // 
            // frmMobileBillDeductionApproval
            // 
            this.AcceptButton = this.btnApprove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 145);
            this.Controls.Add(this.txtDeductAfterApproval);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkFullApprove);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtApproveAmount);
            this.Controls.Add(this.txtDeductAmount);
            this.Controls.Add(this.txtTotalLimit);
            this.Controls.Add(this.txtBillAmount);
            this.Controls.Add(this.txtBillMonth);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmMobileBillDeductionApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Bill Deduction Approval";
            this.Load += new System.EventHandler(this.frmMobileBillDeductionApproval_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtBillMonth;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.TextBox txtTotalLimit;
        private System.Windows.Forms.TextBox txtDeductAmount;
        private System.Windows.Forms.TextBox txtApproveAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkFullApprove;
        private System.Windows.Forms.TextBox txtDeductAfterApproval;
        private System.Windows.Forms.Label label8;
    }
}