namespace CJ.Win.CSD.Reception
{
    partial class frmAdvancePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvancePayment));
            this.grpBankPart = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtApprovalNo = new System.Windows.Forms.TextBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCreditCardType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPOSMachine = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblInstrumentNo = new System.Windows.Forms.Label();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.dtInstrumentDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.lblJob = new System.Windows.Forms.Label();
            this.grpBankPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBankPart
            // 
            this.grpBankPart.Controls.Add(this.label13);
            this.grpBankPart.Controls.Add(this.txtApprovalNo);
            this.grpBankPart.Controls.Add(this.cmbBank);
            this.grpBankPart.Controls.Add(this.label8);
            this.grpBankPart.Controls.Add(this.cmbCreditCardType);
            this.grpBankPart.Controls.Add(this.label9);
            this.grpBankPart.Controls.Add(this.cmbPOSMachine);
            this.grpBankPart.Controls.Add(this.label11);
            this.grpBankPart.Controls.Add(this.cmbCategory);
            this.grpBankPart.Controls.Add(this.label15);
            this.grpBankPart.Enabled = false;
            this.grpBankPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpBankPart.Location = new System.Drawing.Point(12, 164);
            this.grpBankPart.Name = "grpBankPart";
            this.grpBankPart.Size = new System.Drawing.Size(525, 131);
            this.grpBankPart.TabIndex = 2;
            this.grpBankPart.TabStop = false;
            this.grpBankPart.Text = "Bank Part";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(306, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "Approval #";
            // 
            // txtApprovalNo
            // 
            this.txtApprovalNo.Location = new System.Drawing.Point(376, 86);
            this.txtApprovalNo.Name = "txtApprovalNo";
            this.txtApprovalNo.Size = new System.Drawing.Size(140, 21);
            this.txtApprovalNo.TabIndex = 11;
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(99, 28);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(417, 23);
            this.cmbBank.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Bank Name";
            // 
            // cmbCreditCardType
            // 
            this.cmbCreditCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreditCardType.FormattingEnabled = true;
            this.cmbCreditCardType.Location = new System.Drawing.Point(99, 57);
            this.cmbCreditCardType.Name = "cmbCreditCardType";
            this.cmbCreditCardType.Size = new System.Drawing.Size(171, 23);
            this.cmbCreditCardType.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Card Type";
            // 
            // cmbPOSMachine
            // 
            this.cmbPOSMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOSMachine.FormattingEnabled = true;
            this.cmbPOSMachine.Location = new System.Drawing.Point(376, 57);
            this.cmbPOSMachine.Name = "cmbPOSMachine";
            this.cmbPOSMachine.Size = new System.Drawing.Size(140, 23);
            this.cmbPOSMachine.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(287, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "POS Machine";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(99, 86);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(171, 23);
            this.cmbCategory.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.TabIndex = 6;
            this.label15.Text = "Category";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.Location = new System.Drawing.Point(274, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "Instrument Date";
            // 
            // lblInstrumentNo
            // 
            this.lblInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblInstrumentNo.Location = new System.Drawing.Point(11, 138);
            this.lblInstrumentNo.Name = "lblInstrumentNo";
            this.lblInstrumentNo.Size = new System.Drawing.Size(75, 15);
            this.lblInstrumentNo.TabIndex = 12;
            this.lblInstrumentNo.Text = "Instrument #";
            this.lblInstrumentNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtInstrumentNo.Location = new System.Drawing.Point(92, 136);
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            this.txtInstrumentNo.Size = new System.Drawing.Size(170, 21);
            this.txtInstrumentNo.TabIndex = 13;
            // 
            // dtInstrumentDate
            // 
            this.dtInstrumentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtInstrumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtInstrumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInstrumentDate.Location = new System.Drawing.Point(373, 133);
            this.dtInstrumentDate.Name = "dtInstrumentDate";
            this.dtInstrumentDate.Size = new System.Drawing.Size(140, 21);
            this.dtInstrumentDate.TabIndex = 15;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(475, 356);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(384, 356);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 26);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Product Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(102, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(308, 20);
            this.txtName.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(1, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 18);
            this.label12.TabIndex = 17;
            this.label12.Text = "Job No";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Enabled = false;
            this.txtJobNumber.Location = new System.Drawing.Point(102, 12);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(199, 20);
            this.txtJobNumber.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(0, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 18);
            this.label14.TabIndex = 21;
            this.label14.Text = "Consumer Name";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(102, 40);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(199, 20);
            this.txtCustomerName.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(311, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 18);
            this.label16.TabIndex = 19;
            this.label16.Text = "Contact No";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(392, 41);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(150, 20);
            this.txtContactNo.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Payment Mode";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(371, 108);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(166, 21);
            this.cmbPaymentMode.TabIndex = 25;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(71, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Amount";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(142, 108);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(119, 20);
            this.txtAmount.TabIndex = 23;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(71, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(30, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Remarks";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(102, 302);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(395, 43);
            this.txtRemarks.TabIndex = 27;
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(46, 12);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(518, 20);
            this.ctlCSDJob1.TabIndex = 29;
            this.ctlCSDJob1.ChangeSelection += new System.EventHandler(this.ctlCSDJob1_ChangeSelection);
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Location = new System.Drawing.Point(4, 15);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(41, 13);
            this.lblJob.TabIndex = 28;
            this.lblJob.Text = "Job No";
            // 
            // frmAdvancePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 399);
            this.Controls.Add(this.ctlCSDJob1);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblInstrumentNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInstrumentNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtInstrumentDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPaymentMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtJobNumber);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.grpBankPart);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmAdvancePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance Payment";
            this.Load += new System.EventHandler(this.frmAdvancePayment_Load);
            this.grpBankPart.ResumeLayout(false);
            this.grpBankPart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpBankPart;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCreditCardType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPOSMachine;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblInstrumentNo;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private System.Windows.Forms.DateTimePicker dtInstrumentDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtApprovalNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemarks;
        private ctlCSDJob ctlCSDJob1;
        private System.Windows.Forms.Label lblJob;
    }
}