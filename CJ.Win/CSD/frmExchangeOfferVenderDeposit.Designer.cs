namespace CJ.Win.CSD
{
    partial class frmExchangeOfferVenderDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExchangeOfferVenderDeposit));
            this.txtCurrentBalance = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInsNo = new System.Windows.Forms.TextBox();
            this.txtComfirmAmount = new System.Windows.Forms.TextBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.txtReceiveAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblInsNo = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.cmbInstrumentType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInsDate = new System.Windows.Forms.Label();
            this.lblInsType = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblTakaInWord = new System.Windows.Forms.Label();
            this.cmbVenderName = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            this.PaymentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.Location = new System.Drawing.Point(357, 36);
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.ReadOnly = true;
            this.txtCurrentBalance.Size = new System.Drawing.Size(139, 20);
            this.txtCurrentBalance.TabIndex = 18;
            this.txtCurrentBalance.Text = "0.00";
            this.txtCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(268, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Branch Name: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(267, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Vender Balance: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Vender Name: ";
            // 
            // txtInsNo
            // 
            this.txtInsNo.Location = new System.Drawing.Point(82, 46);
            this.txtInsNo.Name = "txtInsNo";
            this.txtInsNo.Size = new System.Drawing.Size(171, 20);
            this.txtInsNo.TabIndex = 7;
            // 
            // txtComfirmAmount
            // 
            this.txtComfirmAmount.Location = new System.Drawing.Point(104, 62);
            this.txtComfirmAmount.Name = "txtComfirmAmount";
            this.txtComfirmAmount.Size = new System.Drawing.Size(158, 20);
            this.txtComfirmAmount.TabIndex = 20;
            this.txtComfirmAmount.Text = "0.00";
            this.txtComfirmAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComfirmAmount.TextChanged += new System.EventHandler(this.txtComfirmAmount_TextChanged);
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(349, 46);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(196, 20);
            this.txtBranch.TabIndex = 11;
            // 
            // txtReceiveAmount
            // 
            this.txtReceiveAmount.Location = new System.Drawing.Point(104, 36);
            this.txtReceiveAmount.Name = "txtReceiveAmount";
            this.txtReceiveAmount.Size = new System.Drawing.Size(158, 20);
            this.txtReceiveAmount.TabIndex = 16;
            this.txtReceiveAmount.Text = "0.00";
            this.txtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Amount: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Confirm Amount: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtDate);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtBranch);
            this.groupBox3.Controls.Add(this.txtInsNo);
            this.groupBox3.Controls.Add(this.lblInsNo);
            this.groupBox3.Controls.Add(this.cmbBank);
            this.groupBox3.Controls.Add(this.cmbInstrumentType);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblInsDate);
            this.groupBox3.Controls.Add(this.lblInsType);
            this.groupBox3.Location = new System.Drawing.Point(15, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(556, 104);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instrument";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(82, 70);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(171, 20);
            this.dtDate.TabIndex = 25;
            // 
            // lblInsNo
            // 
            this.lblInsNo.AutoSize = true;
            this.lblInsNo.Location = new System.Drawing.Point(3, 49);
            this.lblInsNo.Name = "lblInsNo";
            this.lblInsNo.Size = new System.Drawing.Size(76, 13);
            this.lblInsNo.TabIndex = 6;
            this.lblInsNo.Text = "Instrument No.";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(349, 19);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(196, 21);
            this.cmbBank.TabIndex = 3;
            // 
            // cmbInstrumentType
            // 
            this.cmbInstrumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrumentType.FormattingEnabled = true;
            this.cmbInstrumentType.Location = new System.Drawing.Point(82, 19);
            this.cmbInstrumentType.Name = "cmbInstrumentType";
            this.cmbInstrumentType.Size = new System.Drawing.Size(171, 21);
            this.cmbInstrumentType.TabIndex = 1;
            this.cmbInstrumentType.SelectedIndexChanged += new System.EventHandler(this.cmbInstrumentType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Bank: ";
            // 
            // lblInsDate
            // 
            this.lblInsDate.AutoSize = true;
            this.lblInsDate.Location = new System.Drawing.Point(43, 73);
            this.lblInsDate.Name = "lblInsDate";
            this.lblInsDate.Size = new System.Drawing.Size(36, 13);
            this.lblInsDate.TabIndex = 4;
            this.lblInsDate.Text = "Date: ";
            // 
            // lblInsType
            // 
            this.lblInsType.AutoSize = true;
            this.lblInsType.Location = new System.Drawing.Point(42, 23);
            this.lblInsType.Name = "lblInsType";
            this.lblInsType.Size = new System.Drawing.Size(37, 13);
            this.lblInsType.TabIndex = 0;
            this.lblInsType.Text = "Type: ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(70, 232);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(501, 20);
            this.txtRemarks.TabIndex = 24;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(15, 235);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 23;
            this.lblRemarks.Text = "Remarks";
            // 
            // lblTakaInWord
            // 
            this.lblTakaInWord.AutoSize = true;
            this.lblTakaInWord.Location = new System.Drawing.Point(29, 93);
            this.lblTakaInWord.Name = "lblTakaInWord";
            this.lblTakaInWord.Size = new System.Drawing.Size(0, 13);
            this.lblTakaInWord.TabIndex = 21;
            // 
            // cmbVenderName
            // 
            this.cmbVenderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenderName.FormattingEnabled = true;
            this.cmbVenderName.Location = new System.Drawing.Point(104, 9);
            this.cmbVenderName.Name = "cmbVenderName";
            this.cmbVenderName.Size = new System.Drawing.Size(392, 21);
            this.cmbVenderName.TabIndex = 13;
            this.cmbVenderName.SelectedIndexChanged += new System.EventHandler(this.cmbVenderName_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(496, 258);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(415, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Amount (In Word) :";
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.AutoSize = true;
            this.lblAmountInWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWord.ForeColor = System.Drawing.Color.Red;
            this.lblAmountInWord.Location = new System.Drawing.Point(106, 93);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(13, 13);
            this.lblAmountInWord.TabIndex = 28;
            this.lblAmountInWord.Text = "?";
            // 
            // PaymentDue
            // 
            this.PaymentDue.HeaderText = "Payment Due";
            this.PaymentDue.Name = "PaymentDue";
            this.PaymentDue.ReadOnly = true;
            // 
            // ReceivedAmount
            // 
            this.ReceivedAmount.HeaderText = "Received Amount";
            this.ReceivedAmount.Name = "ReceivedAmount";
            this.ReceivedAmount.ReadOnly = true;
            // 
            // InvoiceAmount
            // 
            this.InvoiceAmount.HeaderText = "Invoice Amount";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.ReadOnly = true;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "InvoiceID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.ReadOnly = true;
            this.InvoiceID.Visible = false;
            // 
            // CurrentDue
            // 
            this.CurrentDue.HeaderText = "Current Due";
            this.CurrentDue.Name = "CurrentDue";
            this.CurrentDue.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Invoice No";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // frmExchangeOfferVenderDeposit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 292);
            this.Controls.Add(this.lblAmountInWord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbVenderName);
            this.Controls.Add(this.txtCurrentBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComfirmAmount);
            this.Controls.Add(this.txtReceiveAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblTakaInWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmExchangeOfferVenderDeposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExchangeOfferVenderDeposit";
            this.Load += new System.EventHandler(this.frmExchangeOfferVenderDeposit_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCurrentBalance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInsNo;
        private System.Windows.Forms.TextBox txtComfirmAmount;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.TextBox txtReceiveAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblInsNo;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.ComboBox cmbInstrumentType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblInsDate;
        private System.Windows.Forms.Label lblInsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentDue;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblTakaInWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.ComboBox cmbVenderName;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAmountInWord;
    }
}