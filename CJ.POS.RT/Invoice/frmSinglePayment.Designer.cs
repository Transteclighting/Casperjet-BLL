namespace CJ.POS.RT.Invoice
{
    partial class frmSinglePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSinglePayment));
            this.btnOk = new System.Windows.Forms.Button();
            this.dtInstrumentDate = new System.Windows.Forms.DateTimePicker();
            this.txtAnount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCreditCardType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPOSMachine = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtApprovalNo = new System.Windows.Forms.TextBox();
            this.chkIsEMI = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbNoofInstallment = new System.Windows.Forms.ComboBox();
            this.lblInstrumentNo = new System.Windows.Forms.Label();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grpBankPart = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBankDiscount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtExtendedEMICharge = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDueAmt = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCpopy = new System.Windows.Forms.Label();
            this.lblPaste = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSDApprovalNo = new System.Windows.Forms.TextBox();
            this.grpBankPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOk.Location = new System.Drawing.Point(362, 306);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 31);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Add to list";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dtInstrumentDate
            // 
            this.dtInstrumentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtInstrumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtInstrumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInstrumentDate.Location = new System.Drawing.Point(400, 96);
            this.dtInstrumentDate.Name = "dtInstrumentDate";
            this.dtInstrumentDate.Size = new System.Drawing.Size(140, 21);
            this.dtInstrumentDate.TabIndex = 11;
            // 
            // txtAnount
            // 
            this.txtAnount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtAnount.Location = new System.Drawing.Point(400, 70);
            this.txtAnount.Name = "txtAnount";
            this.txtAnount.Size = new System.Drawing.Size(140, 21);
            this.txtAnount.TabIndex = 7;
            this.txtAnount.Text = "0.00";
            this.txtAnount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAnount.TextChanged += new System.EventHandler(this.txtAnount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(15, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Payment Mode";
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(111, 70);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(170, 23);
            this.cmbPaymentMode.TabIndex = 5;
            this.cmbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMode_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(345, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Amount";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(99, 22);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(429, 23);
            this.cmbBank.TabIndex = 1;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bank Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Card Type";
            // 
            // cmbCreditCardType
            // 
            this.cmbCreditCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreditCardType.FormattingEnabled = true;
            this.cmbCreditCardType.Location = new System.Drawing.Point(99, 51);
            this.cmbCreditCardType.Name = "cmbCreditCardType";
            this.cmbCreditCardType.Size = new System.Drawing.Size(171, 23);
            this.cmbCreditCardType.TabIndex = 3;
            this.cmbCreditCardType.SelectedIndexChanged += new System.EventHandler(this.cmbCreditCardType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "POS Machine";
            // 
            // cmbPOSMachine
            // 
            this.cmbPOSMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOSMachine.FormattingEnabled = true;
            this.cmbPOSMachine.Location = new System.Drawing.Point(388, 51);
            this.cmbPOSMachine.Name = "cmbPOSMachine";
            this.cmbPOSMachine.Size = new System.Drawing.Size(140, 23);
            this.cmbPOSMachine.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(99, 80);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(171, 23);
            this.cmbCategory.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Approval #";
            // 
            // txtApprovalNo
            // 
            this.txtApprovalNo.Location = new System.Drawing.Point(388, 80);
            this.txtApprovalNo.Name = "txtApprovalNo";
            this.txtApprovalNo.Size = new System.Drawing.Size(140, 21);
            this.txtApprovalNo.TabIndex = 9;
            // 
            // chkIsEMI
            // 
            this.chkIsEMI.AutoSize = true;
            this.chkIsEMI.Enabled = false;
            this.chkIsEMI.Location = new System.Drawing.Point(99, 109);
            this.chkIsEMI.Name = "chkIsEMI";
            this.chkIsEMI.Size = new System.Drawing.Size(60, 19);
            this.chkIsEMI.TabIndex = 10;
            this.chkIsEMI.Text = "Is EMI";
            this.chkIsEMI.UseVisualStyleBackColor = true;
            this.chkIsEMI.CheckedChanged += new System.EventHandler(this.chkIsEMI_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "# of Installment";
            // 
            // cmbNoofInstallment
            // 
            this.cmbNoofInstallment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoofInstallment.Enabled = false;
            this.cmbNoofInstallment.FormattingEnabled = true;
            this.cmbNoofInstallment.Location = new System.Drawing.Point(388, 107);
            this.cmbNoofInstallment.Name = "cmbNoofInstallment";
            this.cmbNoofInstallment.Size = new System.Drawing.Size(140, 23);
            this.cmbNoofInstallment.TabIndex = 12;
            this.cmbNoofInstallment.SelectedIndexChanged += new System.EventHandler(this.cmbNoofInstallment_SelectedIndexChanged);
            // 
            // lblInstrumentNo
            // 
            this.lblInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblInstrumentNo.Location = new System.Drawing.Point(30, 101);
            this.lblInstrumentNo.Name = "lblInstrumentNo";
            this.lblInstrumentNo.Size = new System.Drawing.Size(75, 15);
            this.lblInstrumentNo.TabIndex = 8;
            this.lblInstrumentNo.Text = "Instrument #";
            this.lblInstrumentNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtInstrumentNo.Location = new System.Drawing.Point(111, 99);
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            this.txtInstrumentNo.Size = new System.Drawing.Size(170, 21);
            this.txtInstrumentNo.TabIndex = 9;
            this.txtInstrumentNo.TextChanged += new System.EventHandler(this.txtInstrumentNo_TextChanged);
            this.txtInstrumentNo.Leave += new System.EventHandler(this.txtInstrumentNo_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.Location = new System.Drawing.Point(300, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Instrument Date";
            // 
            // grpBankPart
            // 
            this.grpBankPart.Controls.Add(this.label12);
            this.grpBankPart.Controls.Add(this.txtBankDiscount);
            this.grpBankPart.Controls.Add(this.label14);
            this.grpBankPart.Controls.Add(this.txtExtendedEMICharge);
            this.grpBankPart.Controls.Add(this.cmbBank);
            this.grpBankPart.Controls.Add(this.label2);
            this.grpBankPart.Controls.Add(this.cmbCreditCardType);
            this.grpBankPart.Controls.Add(this.label3);
            this.grpBankPart.Controls.Add(this.label7);
            this.grpBankPart.Controls.Add(this.cmbPOSMachine);
            this.grpBankPart.Controls.Add(this.cmbNoofInstallment);
            this.grpBankPart.Controls.Add(this.label4);
            this.grpBankPart.Controls.Add(this.chkIsEMI);
            this.grpBankPart.Controls.Add(this.cmbCategory);
            this.grpBankPart.Controls.Add(this.label6);
            this.grpBankPart.Controls.Add(this.label5);
            this.grpBankPart.Controls.Add(this.txtApprovalNo);
            this.grpBankPart.Enabled = false;
            this.grpBankPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpBankPart.Location = new System.Drawing.Point(12, 126);
            this.grpBankPart.Name = "grpBankPart";
            this.grpBankPart.Size = new System.Drawing.Size(537, 174);
            this.grpBankPart.TabIndex = 12;
            this.grpBankPart.TabStop = false;
            this.grpBankPart.Text = "Bank Part";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "Bank Discount";
            // 
            // txtBankDiscount
            // 
            this.txtBankDiscount.BackColor = System.Drawing.SystemColors.Info;
            this.txtBankDiscount.Location = new System.Drawing.Point(99, 136);
            this.txtBankDiscount.Name = "txtBankDiscount";
            this.txtBankDiscount.ReadOnly = true;
            this.txtBankDiscount.Size = new System.Drawing.Size(128, 21);
            this.txtBankDiscount.TabIndex = 14;
            this.txtBankDiscount.Text = "0.00";
            this.txtBankDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBankDiscount.TextChanged += new System.EventHandler(this.txtBankDiscount_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(255, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 15);
            this.label14.TabIndex = 15;
            this.label14.Text = "Extended EMI Charge";
            // 
            // txtExtendedEMICharge
            // 
            this.txtExtendedEMICharge.BackColor = System.Drawing.SystemColors.Info;
            this.txtExtendedEMICharge.Location = new System.Drawing.Point(388, 136);
            this.txtExtendedEMICharge.Name = "txtExtendedEMICharge";
            this.txtExtendedEMICharge.ReadOnly = true;
            this.txtExtendedEMICharge.Size = new System.Drawing.Size(140, 21);
            this.txtExtendedEMICharge.TabIndex = 16;
            this.txtExtendedEMICharge.Text = "0.00";
            this.txtExtendedEMICharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtendedEMICharge.TextChanged += new System.EventHandler(this.txtExtendedEMICharge_TextChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Navy;
            this.lblProductName.Location = new System.Drawing.Point(92, 9);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(15, 15);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Product:";
            // 
            // lblDueAmt
            // 
            this.lblDueAmt.AutoSize = true;
            this.lblDueAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmt.ForeColor = System.Drawing.Color.Navy;
            this.lblDueAmt.Location = new System.Drawing.Point(91, 37);
            this.lblDueAmt.Name = "lblDueAmt";
            this.lblDueAmt.Size = new System.Drawing.Size(15, 15);
            this.lblDueAmt.TabIndex = 3;
            this.lblDueAmt.Text = "?";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Payable:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(462, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 31);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCpopy
            // 
            this.lblCpopy.AutoSize = true;
            this.lblCpopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCpopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCpopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCpopy.Location = new System.Drawing.Point(462, 9);
            this.lblCpopy.Name = "lblCpopy";
            this.lblCpopy.Size = new System.Drawing.Size(38, 15);
            this.lblCpopy.TabIndex = 15;
            this.lblCpopy.Text = "Copy";
            this.lblCpopy.Click += new System.EventHandler(this.lblCpopy_Click);
            // 
            // lblPaste
            // 
            this.lblPaste.AutoSize = true;
            this.lblPaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPaste.Location = new System.Drawing.Point(506, 9);
            this.lblPaste.Name = "lblPaste";
            this.lblPaste.Size = new System.Drawing.Size(43, 15);
            this.lblPaste.TabIndex = 16;
            this.lblPaste.Text = "Paste";
            this.lblPaste.Click += new System.EventHandler(this.lblPaste_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label15.Location = new System.Drawing.Point(26, 309);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 15);
            this.label15.TabIndex = 17;
            this.label15.Text = "SD Approval#";
            // 
            // txtSDApprovalNo
            // 
            this.txtSDApprovalNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSDApprovalNo.Location = new System.Drawing.Point(111, 306);
            this.txtSDApprovalNo.Name = "txtSDApprovalNo";
            this.txtSDApprovalNo.Size = new System.Drawing.Size(170, 21);
            this.txtSDApprovalNo.TabIndex = 18;
            this.txtSDApprovalNo.TextChanged += new System.EventHandler(this.txtSDApprovalNo_TextChanged);
            // 
            // frmSinglePayment
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 350);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSDApprovalNo);
            this.Controls.Add(this.lblPaste);
            this.Controls.Add(this.lblCpopy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDueAmt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grpBankPart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblInstrumentNo);
            this.Controls.Add(this.txtInstrumentNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPaymentMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAnount);
            this.Controls.Add(this.dtInstrumentDate);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSinglePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Payment";
            this.Load += new System.EventHandler(this.frmSinglePayment_Load);
            this.grpBankPart.ResumeLayout(false);
            this.grpBankPart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DateTimePicker dtInstrumentDate;
        private System.Windows.Forms.TextBox txtAnount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCreditCardType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPOSMachine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApprovalNo;
        private System.Windows.Forms.CheckBox chkIsEMI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbNoofInstallment;
        private System.Windows.Forms.Label lblInstrumentNo;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpBankPart;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDueAmt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtExtendedEMICharge;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBankDiscount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCpopy;
        private System.Windows.Forms.Label lblPaste;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSDApprovalNo;
    }
}