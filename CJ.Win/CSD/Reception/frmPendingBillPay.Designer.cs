namespace CJ.Win.CSD.Reception
{
    partial class frmPendingBillPay
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dtInstrumentDate = new System.Windows.Forms.DateTimePicker();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.cmbInstrumentType = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSparePartsDiscount = new System.Windows.Forms.TextBox();
            this.txtServiceChargeDiscount = new System.Windows.Forms.TextBox();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.lbl99 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.txtJobType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtServiceType = new System.Windows.Forms.TextBox();
            this.txtCurrentPayable = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAfterDiscount = new System.Windows.Forms.TextBox();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.dtInstrumentDate);
            this.groupBox6.Controls.Add(this.txtInstrumentNo);
            this.groupBox6.Controls.Add(this.cmbBank);
            this.groupBox6.Controls.Add(this.cmbInstrumentType);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Location = new System.Drawing.Point(27, 112);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(317, 123);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Instrument";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 95);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(66, 13);
            this.label30.TabIndex = 6;
            this.label30.Text = "Instrument #";
            // 
            // dtInstrumentDate
            // 
            this.dtInstrumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInstrumentDate.Location = new System.Drawing.Point(82, 69);
            this.dtInstrumentDate.Name = "dtInstrumentDate";
            this.dtInstrumentDate.Size = new System.Drawing.Size(226, 20);
            this.dtInstrumentDate.TabIndex = 5;
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Location = new System.Drawing.Point(82, 92);
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            this.txtInstrumentNo.Size = new System.Drawing.Size(226, 20);
            this.txtInstrumentNo.TabIndex = 7;
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(82, 43);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(226, 21);
            this.cmbBank.TabIndex = 3;
            // 
            // cmbInstrumentType
            // 
            this.cmbInstrumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrumentType.FormattingEnabled = true;
            this.cmbInstrumentType.Location = new System.Drawing.Point(82, 17);
            this.cmbInstrumentType.Name = "cmbInstrumentType";
            this.cmbInstrumentType.Size = new System.Drawing.Size(226, 21);
            this.cmbInstrumentType.TabIndex = 1;
            this.cmbInstrumentType.SelectedIndexChanged += new System.EventHandler(this.cmbInstrumentType_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(46, 46);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 13);
            this.label31.TabIndex = 2;
            this.label31.Text = "Bank";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(48, 72);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(30, 13);
            this.label32.TabIndex = 4;
            this.label32.Text = "Date";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(47, 20);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(31, 13);
            this.label33.TabIndex = 0;
            this.label33.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer Name";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(179, 391);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 19;
            this.btnPay.Text = "&Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(258, 391);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSparePartsDiscount
            // 
            this.txtSparePartsDiscount.Location = new System.Drawing.Point(109, 270);
            this.txtSparePartsDiscount.Name = "txtSparePartsDiscount";
            this.txtSparePartsDiscount.Size = new System.Drawing.Size(226, 20);
            this.txtSparePartsDiscount.TabIndex = 12;
            this.txtSparePartsDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSparePartsDiscount.TextChanged += new System.EventHandler(this.txtSparePartsDiscount_TextChanged);
            // 
            // txtServiceChargeDiscount
            // 
            this.txtServiceChargeDiscount.Location = new System.Drawing.Point(109, 293);
            this.txtServiceChargeDiscount.Name = "txtServiceChargeDiscount";
            this.txtServiceChargeDiscount.Size = new System.Drawing.Size(226, 20);
            this.txtServiceChargeDiscount.TabIndex = 14;
            this.txtServiceChargeDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServiceChargeDiscount.TextChanged += new System.EventHandler(this.txtServiceChargeDiscount_TextChanged);
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Location = new System.Drawing.Point(109, 341);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(226, 20);
            this.txtPayAmount.TabIndex = 16;
            this.txtPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl99
            // 
            this.lbl99.AutoSize = true;
            this.lbl99.Location = new System.Drawing.Point(36, 91);
            this.lbl99.Name = "lbl99";
            this.lbl99.Size = new System.Drawing.Size(70, 13);
            this.lbl99.TabIndex = 6;
            this.lbl99.Text = "Service Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Spare Parts Dis.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Service Charge Dis.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Received Amount";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(109, 14);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.ReadOnly = true;
            this.txtJobNo.Size = new System.Drawing.Size(224, 20);
            this.txtJobNo.TabIndex = 1;
            // 
            // txtJobType
            // 
            this.txtJobType.Location = new System.Drawing.Point(109, 62);
            this.txtJobType.Name = "txtJobType";
            this.txtJobType.ReadOnly = true;
            this.txtJobType.Size = new System.Drawing.Size(224, 20);
            this.txtJobType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Job Type";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(109, 39);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(224, 20);
            this.txtCustomerName.TabIndex = 3;
            // 
            // txtServiceType
            // 
            this.txtServiceType.Location = new System.Drawing.Point(109, 88);
            this.txtServiceType.Name = "txtServiceType";
            this.txtServiceType.ReadOnly = true;
            this.txtServiceType.Size = new System.Drawing.Size(224, 20);
            this.txtServiceType.TabIndex = 7;
            // 
            // txtCurrentPayable
            // 
            this.txtCurrentPayable.Location = new System.Drawing.Point(109, 243);
            this.txtCurrentPayable.Name = "txtCurrentPayable";
            this.txtCurrentPayable.ReadOnly = true;
            this.txtCurrentPayable.Size = new System.Drawing.Size(224, 20);
            this.txtCurrentPayable.TabIndex = 9;
            this.txtCurrentPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, -202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Current Payable";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Current Payable";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(109, 364);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(226, 20);
            this.txtRemarks.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Net Receivable";
            // 
            // txtAfterDiscount
            // 
            this.txtAfterDiscount.Location = new System.Drawing.Point(109, 317);
            this.txtAfterDiscount.Name = "txtAfterDiscount";
            this.txtAfterDiscount.ReadOnly = true;
            this.txtAfterDiscount.Size = new System.Drawing.Size(224, 20);
            this.txtAfterDiscount.TabIndex = 51;
            this.txtAfterDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmPendingBillPay
            // 
            this.AcceptButton = this.btnPay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 425);
            this.Controls.Add(this.txtAfterDiscount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCurrentPayable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtServiceType);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJobType);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl99);
            this.Controls.Add(this.txtPayAmount);
            this.Controls.Add(this.txtServiceChargeDiscount);
            this.Controls.Add(this.txtSparePartsDiscount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPendingBillPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pending Bill Pay";
            this.Load += new System.EventHandler(this.frmPendingBillPay_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DateTimePicker dtInstrumentDate;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.ComboBox cmbInstrumentType;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSparePartsDiscount;
        private System.Windows.Forms.TextBox txtServiceChargeDiscount;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.Label lbl99;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.TextBox txtJobType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtServiceType;
        private System.Windows.Forms.TextBox txtCurrentPayable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAfterDiscount;
    }
}