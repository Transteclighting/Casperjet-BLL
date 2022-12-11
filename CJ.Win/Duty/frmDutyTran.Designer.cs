namespace CJ.Win.Duty
{
    partial class frmDutyTran
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btClose = new System.Windows.Forms.Button();
            this.lbDuty = new System.Windows.Forms.Label();
            this.cmbDutyType = new System.Windows.Forms.ComboBox();
            this.btSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAccountNo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lbDoc = new System.Windows.Forms.Label();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.dtTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.txtTransationNo = new System.Windows.Forms.TextBox();
            this.lbRebate = new System.Windows.Forms.Label();
            this.cmbRebateType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbRebate);
            this.groupBox1.Controls.Add(this.cmbRebateType);
            this.groupBox1.Controls.Add(this.btClose);
            this.groupBox1.Controls.Add(this.lbDuty);
            this.groupBox1.Controls.Add(this.cmbDutyType);
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbAccountNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.lbDoc);
            this.groupBox1.Controls.Add(this.txtDocNo);
            this.groupBox1.Controls.Add(this.dtTransactionDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTransactionRefNo);
            this.groupBox1.Controls.Add(this.txtTransationNo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(477, 149);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 15;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lbDuty
            // 
            this.lbDuty.AutoSize = true;
            this.lbDuty.Location = new System.Drawing.Point(340, 48);
            this.lbDuty.Name = "lbDuty";
            this.lbDuty.Size = new System.Drawing.Size(59, 13);
            this.lbDuty.TabIndex = 12;
            this.lbDuty.Text = "Duty Type:";
            // 
            // cmbDutyType
            // 
            this.cmbDutyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDutyType.FormattingEnabled = true;
            this.cmbDutyType.Location = new System.Drawing.Point(402, 44);
            this.cmbDutyType.Name = "cmbDutyType";
            this.cmbDutyType.Size = new System.Drawing.Size(112, 21);
            this.cmbDutyType.TabIndex = 13;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(399, 149);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 14;
            this.btSave.Text = "&Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Remarks:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(109, 124);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(443, 20);
            this.txtRemarks.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Account No:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAccountNo
            // 
            this.cmbAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountNo.FormattingEnabled = true;
            this.cmbAccountNo.Location = new System.Drawing.Point(109, 70);
            this.cmbAccountNo.Name = "cmbAccountNo";
            this.cmbAccountNo.Size = new System.Drawing.Size(182, 21);
            this.cmbAccountNo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(109, 97);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(122, 20);
            this.txtAmount.TabIndex = 9;
            // 
            // lbDoc
            // 
            this.lbDoc.AutoSize = true;
            this.lbDoc.Location = new System.Drawing.Point(21, 48);
            this.lbDoc.Name = "lbDoc";
            this.lbDoc.Size = new System.Drawing.Size(76, 13);
            this.lbDoc.TabIndex = 4;
            this.lbDoc.Text = "Document No:";
            this.lbDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocNo
            // 
            this.txtDocNo.Location = new System.Drawing.Point(109, 44);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(182, 20);
            this.txtDocNo.TabIndex = 5;
            // 
            // dtTransactionDate
            // 
            this.dtTransactionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionDate.Location = new System.Drawing.Point(403, 18);
            this.dtTransactionDate.Name = "dtTransactionDate";
            this.dtTransactionDate.Size = new System.Drawing.Size(112, 20);
            this.dtTransactionDate.TabIndex = 3;
            this.dtTransactionDate.Tag = "M1.21";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transaction Date:";
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(23, 21);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(83, 13);
            this.lblTransactionRefNo.TabIndex = 0;
            this.lblTransactionRefNo.Text = "Transaction No:";
            this.lblTransactionRefNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTransationNo
            // 
            this.txtTransationNo.Enabled = false;
            this.txtTransationNo.Location = new System.Drawing.Point(109, 18);
            this.txtTransationNo.Name = "txtTransationNo";
            this.txtTransationNo.Size = new System.Drawing.Size(122, 20);
            this.txtTransationNo.TabIndex = 1;
            // 
            // lbRebate
            // 
            this.lbRebate.AutoSize = true;
            this.lbRebate.Location = new System.Drawing.Point(329, 78);
            this.lbRebate.Name = "lbRebate";
            this.lbRebate.Size = new System.Drawing.Size(72, 13);
            this.lbRebate.TabIndex = 16;
            this.lbRebate.Text = "Rebate Type:";
            // 
            // cmbRebateType
            // 
            this.cmbRebateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRebateType.FormattingEnabled = true;
            this.cmbRebateType.Items.AddRange(new object[] {
            "PURCHASE_REBATE",
            "SUPPLY_REBATE",
            "BANK_CHARGER_REBATE",
            "INSURANCE_REBATE",
            "GLOBAL_TASK_REBATE"});
            this.cmbRebateType.Location = new System.Drawing.Point(402, 74);
            this.cmbRebateType.Name = "cmbRebateType";
            this.cmbRebateType.Size = new System.Drawing.Size(149, 21);
            this.cmbRebateType.TabIndex = 17;
            // 
            // frmDutyTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 186);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDutyTran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDutyTran_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTransactionDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.TextBox txtTransationNo;
        private System.Windows.Forms.Label lbDoc;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAccountNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lbDuty;
        private System.Windows.Forms.ComboBox cmbDutyType;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lbRebate;
        private System.Windows.Forms.ComboBox cmbRebateType;
    }
}