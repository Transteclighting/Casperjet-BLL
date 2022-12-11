namespace CJ.POS.RT
{
    partial class frmSmartWarrantyPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmartWarrantyPayment));
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAnount = new System.Windows.Forms.TextBox();
            this.grpBankPart = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblInstrumentNo = new System.Windows.Forms.Label();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.dtInstrumentDate = new System.Windows.Forms.DateTimePicker();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCreditCardType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPOSMachine = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtApprovalNo = new System.Windows.Forms.TextBox();
            this.cmbTenure = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblWarrantyExpiryDate = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.grpBankPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(327, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(43, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Payment Mode";
            // 
            // txtAnount
            // 
            this.txtAnount.Enabled = false;
            this.txtAnount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnount.ForeColor = System.Drawing.Color.Navy;
            this.txtAnount.Location = new System.Drawing.Point(380, 137);
            this.txtAnount.Name = "txtAnount";
            this.txtAnount.Size = new System.Drawing.Size(140, 21);
            this.txtAnount.TabIndex = 9;
            this.txtAnount.Text = "0.00";
            this.txtAnount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAnount.TextChanged += new System.EventHandler(this.txtAnount_TextChanged);
            // 
            // grpBankPart
            // 
            this.grpBankPart.Controls.Add(this.label10);
            this.grpBankPart.Controls.Add(this.lblInstrumentNo);
            this.grpBankPart.Controls.Add(this.txtInstrumentNo);
            this.grpBankPart.Controls.Add(this.dtInstrumentDate);
            this.grpBankPart.Controls.Add(this.cmbBank);
            this.grpBankPart.Controls.Add(this.label2);
            this.grpBankPart.Controls.Add(this.cmbCreditCardType);
            this.grpBankPart.Controls.Add(this.label3);
            this.grpBankPart.Controls.Add(this.cmbPOSMachine);
            this.grpBankPart.Controls.Add(this.label4);
            this.grpBankPart.Controls.Add(this.cmbCategory);
            this.grpBankPart.Controls.Add(this.label6);
            this.grpBankPart.Controls.Add(this.label5);
            this.grpBankPart.Controls.Add(this.txtApprovalNo);
            this.grpBankPart.Enabled = false;
            this.grpBankPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpBankPart.Location = new System.Drawing.Point(52, 164);
            this.grpBankPart.Name = "grpBankPart";
            this.grpBankPart.Size = new System.Drawing.Size(478, 131);
            this.grpBankPart.TabIndex = 10;
            this.grpBankPart.TabStop = false;
            this.grpBankPart.Text = "Bank Part";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.Location = new System.Drawing.Point(228, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Instrument Date";
            // 
            // lblInstrumentNo
            // 
            this.lblInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblInstrumentNo.Location = new System.Drawing.Point(3, 48);
            this.lblInstrumentNo.Name = "lblInstrumentNo";
            this.lblInstrumentNo.Size = new System.Drawing.Size(75, 15);
            this.lblInstrumentNo.TabIndex = 2;
            this.lblInstrumentNo.Text = "Instrument #";
            this.lblInstrumentNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtInstrumentNo.Location = new System.Drawing.Point(84, 46);
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            this.txtInstrumentNo.Size = new System.Drawing.Size(140, 21);
            this.txtInstrumentNo.TabIndex = 3;
            // 
            // dtInstrumentDate
            // 
            this.dtInstrumentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtInstrumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtInstrumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInstrumentDate.Location = new System.Drawing.Point(328, 46);
            this.dtInstrumentDate.Name = "dtInstrumentDate";
            this.dtInstrumentDate.Size = new System.Drawing.Size(140, 21);
            this.dtInstrumentDate.TabIndex = 5;
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(84, 17);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(384, 23);
            this.cmbBank.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bank Name";
            // 
            // cmbCreditCardType
            // 
            this.cmbCreditCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreditCardType.FormattingEnabled = true;
            this.cmbCreditCardType.Location = new System.Drawing.Point(84, 73);
            this.cmbCreditCardType.Name = "cmbCreditCardType";
            this.cmbCreditCardType.Size = new System.Drawing.Size(141, 23);
            this.cmbCreditCardType.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Card Type";
            // 
            // cmbPOSMachine
            // 
            this.cmbPOSMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOSMachine.FormattingEnabled = true;
            this.cmbPOSMachine.Location = new System.Drawing.Point(328, 71);
            this.cmbPOSMachine.Name = "cmbPOSMachine";
            this.cmbPOSMachine.Size = new System.Drawing.Size(140, 23);
            this.cmbPOSMachine.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "POS Machine";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(84, 102);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(141, 23);
            this.cmbCategory.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Approval #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Category";
            // 
            // txtApprovalNo
            // 
            this.txtApprovalNo.Location = new System.Drawing.Point(328, 100);
            this.txtApprovalNo.Name = "txtApprovalNo";
            this.txtApprovalNo.Size = new System.Drawing.Size(140, 21);
            this.txtApprovalNo.TabIndex = 13;
            // 
            // cmbTenure
            // 
            this.cmbTenure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbTenure.FormattingEnabled = true;
            this.cmbTenure.Location = new System.Drawing.Point(136, 79);
            this.cmbTenure.Name = "cmbTenure";
            this.cmbTenure.Size = new System.Drawing.Size(140, 23);
            this.cmbTenure.TabIndex = 1;
            this.cmbTenure.SelectedIndexChanged += new System.EventHandler(this.cmbTenure_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(0, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Smart Warranty Tenure";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(72, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(136, 108);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(140, 21);
            this.dtpStartDate.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label11.Location = new System.Drawing.Point(318, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "End Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(380, 109);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(140, 21);
            this.dtpEndDate.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(443, 301);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 31);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOk.Location = new System.Drawing.Point(348, 300);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 31);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Add";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Navy;
            this.lblProductName.Location = new System.Drawing.Point(192, 9);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(15, 15);
            this.lblProductName.TabIndex = 14;
            this.lblProductName.Text = "?";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(90, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "Product Detail:";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Items.AddRange(new object[] {
            "<Select Payment Mode>",
            "Cash",
            "Card"});
            this.cmbPaymentMode.Location = new System.Drawing.Point(136, 135);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(140, 23);
            this.cmbPaymentMode.TabIndex = 7;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.Navy;
            this.lblBarcode.Location = new System.Drawing.Point(192, 32);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(15, 15);
            this.lblBarcode.TabIndex = 16;
            this.lblBarcode.Text = "?";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(124, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 15);
            this.label14.TabIndex = 15;
            this.label14.Text = "Barcode:";
            // 
            // lblWarrantyExpiryDate
            // 
            this.lblWarrantyExpiryDate.AutoSize = true;
            this.lblWarrantyExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarrantyExpiryDate.ForeColor = System.Drawing.Color.Navy;
            this.lblWarrantyExpiryDate.Location = new System.Drawing.Point(192, 56);
            this.lblWarrantyExpiryDate.Name = "lblWarrantyExpiryDate";
            this.lblWarrantyExpiryDate.Size = new System.Drawing.Size(15, 15);
            this.lblWarrantyExpiryDate.TabIndex = 18;
            this.lblWarrantyExpiryDate.Text = "?";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(180, 15);
            this.label16.TabIndex = 17;
            this.label16.Text = "Main Warranty Expiry Date:";
            // 
            // frmSmartWarrantyPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 338);
            this.Controls.Add(this.lblWarrantyExpiryDate);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbTenure);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpBankPart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPaymentMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAnount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSmartWarrantyPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Warranty Payment";
            this.Load += new System.EventHandler(this.frmSmartWarrantyPayment_Load);
            this.grpBankPart.ResumeLayout(false);
            this.grpBankPart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnount;
        private System.Windows.Forms.GroupBox grpBankPart;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCreditCardType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPOSMachine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApprovalNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblInstrumentNo;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private System.Windows.Forms.DateTimePicker dtInstrumentDate;
        private System.Windows.Forms.ComboBox cmbTenure;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblWarrantyExpiryDate;
        private System.Windows.Forms.Label label16;
    }
}