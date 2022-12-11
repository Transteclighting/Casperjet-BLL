namespace CJ.Win.Accounts
{
    partial class frmCustomerCreditCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerCreditCollection));
            this.txtPaymentDueTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrentBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.chkInsStatus = new System.Windows.Forms.CheckBox();
            this.txtCurrentDueTotal = new System.Windows.Forms.TextBox();
            this.txtReceiveAmtTotal = new System.Windows.Forms.TextBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.txtInsNo = new System.Windows.Forms.TextBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblInsNo = new System.Windows.Forms.Label();
            this.dtInstrudate = new System.Windows.Forms.DateTimePicker();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInsDate = new System.Windows.Forms.Label();
            this.txtInvoiceAmtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbInstrumentType = new System.Windows.Forms.ComboBox();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.lblInsType = new System.Windows.Forms.Label();
            this.txtComfirmAmount = new System.Windows.Forms.TextBox();
            this.txtReceiveAmount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbInstrument = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rdoAutomatic = new System.Windows.Forms.RadioButton();
            this.rdoManual = new System.Windows.Forms.RadioButton();
            this.lblTakaInWord = new System.Windows.Forms.Label();
            this.cmbTranType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkAdvanceColl = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.dtTranDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.gbInstrument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPaymentDueTotal
            // 
            this.txtPaymentDueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentDueTotal.Location = new System.Drawing.Point(370, 485);
            this.txtPaymentDueTotal.Name = "txtPaymentDueTotal";
            this.txtPaymentDueTotal.ReadOnly = true;
            this.txtPaymentDueTotal.Size = new System.Drawing.Size(95, 21);
            this.txtPaymentDueTotal.TabIndex = 24;
            this.txtPaymentDueTotal.Text = "0.00";
            this.txtPaymentDueTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(227, 488);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Total :";
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentBalance.Location = new System.Drawing.Point(528, 41);
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.ReadOnly = true;
            this.txtCurrentBalance.Size = new System.Drawing.Size(125, 21);
            this.txtCurrentBalance.TabIndex = 6;
            this.txtCurrentBalance.Text = "0.00";
            this.txtCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(464, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Balance: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Customer: ";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(490, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 29);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(386, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Branch Name: ";
            // 
            // chkInsStatus
            // 
            this.chkInsStatus.AutoSize = true;
            this.chkInsStatus.Checked = true;
            this.chkInsStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInsStatus.Location = new System.Drawing.Point(528, 98);
            this.chkInsStatus.Name = "chkInsStatus";
            this.chkInsStatus.Size = new System.Drawing.Size(83, 19);
            this.chkInsStatus.TabIndex = 14;
            this.chkInsStatus.Text = "Approved";
            this.chkInsStatus.UseVisualStyleBackColor = true;
            // 
            // txtCurrentDueTotal
            // 
            this.txtCurrentDueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentDueTotal.Location = new System.Drawing.Point(564, 485);
            this.txtCurrentDueTotal.Name = "txtCurrentDueTotal";
            this.txtCurrentDueTotal.ReadOnly = true;
            this.txtCurrentDueTotal.Size = new System.Drawing.Size(95, 21);
            this.txtCurrentDueTotal.TabIndex = 26;
            this.txtCurrentDueTotal.Text = "0.00";
            this.txtCurrentDueTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReceiveAmtTotal
            // 
            this.txtReceiveAmtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveAmtTotal.Location = new System.Drawing.Point(467, 485);
            this.txtReceiveAmtTotal.Name = "txtReceiveAmtTotal";
            this.txtReceiveAmtTotal.ReadOnly = true;
            this.txtReceiveAmtTotal.Size = new System.Drawing.Size(95, 21);
            this.txtReceiveAmtTotal.TabIndex = 25;
            this.txtReceiveAmtTotal.Text = "0.00";
            this.txtReceiveAmtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(479, 51);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(159, 21);
            this.txtBranch.TabIndex = 9;
            // 
            // txtInsNo
            // 
            this.txtInsNo.Location = new System.Drawing.Point(479, 22);
            this.txtInsNo.Name = "txtInsNo";
            this.txtInsNo.Size = new System.Drawing.Size(159, 21);
            this.txtInsNo.TabIndex = 7;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(479, 78);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(159, 23);
            this.cmbBranch.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(424, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Branch: ";
            // 
            // lblInsNo
            // 
            this.lblInsNo.AutoSize = true;
            this.lblInsNo.Location = new System.Drawing.Point(388, 25);
            this.lblInsNo.Name = "lblInsNo";
            this.lblInsNo.Size = new System.Drawing.Size(87, 15);
            this.lblInsNo.TabIndex = 6;
            this.lblInsNo.Text = "Instrument No.";
            // 
            // dtInstrudate
            // 
            this.dtInstrudate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInstrudate.Location = new System.Drawing.Point(101, 78);
            this.dtInstrudate.Name = "dtInstrudate";
            this.dtInstrudate.Size = new System.Drawing.Size(171, 21);
            this.dtInstrudate.TabIndex = 5;
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(101, 49);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(171, 23);
            this.cmbBank.TabIndex = 3;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Bank: ";
            // 
            // lblInsDate
            // 
            this.lblInsDate.AutoSize = true;
            this.lblInsDate.Location = new System.Drawing.Point(59, 81);
            this.lblInsDate.Name = "lblInsDate";
            this.lblInsDate.Size = new System.Drawing.Size(39, 15);
            this.lblInsDate.TabIndex = 4;
            this.lblInsDate.Text = "Date: ";
            // 
            // txtInvoiceAmtTotal
            // 
            this.txtInvoiceAmtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceAmtTotal.Location = new System.Drawing.Point(273, 485);
            this.txtInvoiceAmtTotal.Name = "txtInvoiceAmtTotal";
            this.txtInvoiceAmtTotal.ReadOnly = true;
            this.txtInvoiceAmtTotal.Size = new System.Drawing.Size(95, 21);
            this.txtInvoiceAmtTotal.TabIndex = 23;
            this.txtInvoiceAmtTotal.Text = "0.00";
            this.txtInvoiceAmtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(205, 514);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Advance : ";
            // 
            // cmbInstrumentType
            // 
            this.cmbInstrumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrumentType.FormattingEnabled = true;
            this.cmbInstrumentType.Location = new System.Drawing.Point(101, 20);
            this.cmbInstrumentType.Name = "cmbInstrumentType";
            this.cmbInstrumentType.Size = new System.Drawing.Size(171, 23);
            this.cmbInstrumentType.TabIndex = 1;
            this.cmbInstrumentType.SelectedIndexChanged += new System.EventHandler(this.cmbInstrumentType_SelectedIndexChanged);
            // 
            // txtAdvance
            // 
            this.txtAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvance.Location = new System.Drawing.Point(273, 511);
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.ReadOnly = true;
            this.txtAdvance.Size = new System.Drawing.Size(95, 21);
            this.txtAdvance.TabIndex = 28;
            this.txtAdvance.Text = "0.00";
            this.txtAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInsType
            // 
            this.lblInsType.AutoSize = true;
            this.lblInsType.Location = new System.Drawing.Point(59, 23);
            this.lblInsType.Name = "lblInsType";
            this.lblInsType.Size = new System.Drawing.Size(39, 15);
            this.lblInsType.TabIndex = 0;
            this.lblInsType.Text = "Type: ";
            // 
            // txtComfirmAmount
            // 
            this.txtComfirmAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComfirmAmount.Location = new System.Drawing.Point(528, 71);
            this.txtComfirmAmount.Name = "txtComfirmAmount";
            this.txtComfirmAmount.Size = new System.Drawing.Size(125, 21);
            this.txtComfirmAmount.TabIndex = 12;
            this.txtComfirmAmount.Text = "0.00";
            this.txtComfirmAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComfirmAmount.Leave += new System.EventHandler(this.txtComfirmAmount_Leave);
            // 
            // txtReceiveAmount
            // 
            this.txtReceiveAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveAmount.Location = new System.Drawing.Point(116, 72);
            this.txtReceiveAmount.Name = "txtReceiveAmount";
            this.txtReceiveAmount.Size = new System.Drawing.Size(122, 21);
            this.txtReceiveAmount.TabIndex = 8;
            this.txtReceiveAmount.Text = "0.00";
            this.txtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReceiveAmount.TextChanged += new System.EventHandler(this.txtReceiveAmount_TextChanged);
            this.txtReceiveAmount.Leave += new System.EventHandler(this.txtReceiveAmount_Leave);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(579, 514);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 29);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbInstrument
            // 
            this.gbInstrument.Controls.Add(this.label12);
            this.gbInstrument.Controls.Add(this.txtBranch);
            this.gbInstrument.Controls.Add(this.txtInsNo);
            this.gbInstrument.Controls.Add(this.cmbBranch);
            this.gbInstrument.Controls.Add(this.label11);
            this.gbInstrument.Controls.Add(this.lblInsNo);
            this.gbInstrument.Controls.Add(this.dtInstrudate);
            this.gbInstrument.Controls.Add(this.cmbBank);
            this.gbInstrument.Controls.Add(this.cmbInstrumentType);
            this.gbInstrument.Controls.Add(this.label7);
            this.gbInstrument.Controls.Add(this.lblInsDate);
            this.gbInstrument.Controls.Add(this.lblInsType);
            this.gbInstrument.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInstrument.Location = new System.Drawing.Point(15, 128);
            this.gbInstrument.Name = "gbInstrument";
            this.gbInstrument.Size = new System.Drawing.Size(644, 110);
            this.gbInstrument.TabIndex = 15;
            this.gbInstrument.TabStop = false;
            this.gbInstrument.Text = "Instrument";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(116, 244);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(543, 23);
            this.txtRemarks.TabIndex = 17;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(53, 249);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(57, 15);
            this.lblRemarks.TabIndex = 16;
            this.lblRemarks.Text = "Remarks";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.AllowUserToOrderColumns = true;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNo,
            this.InvoiceDate,
            this.InvoiceAmount,
            this.PaymentDue,
            this.ReceivedAmount,
            this.InvoiceID,
            this.CurrentDue});
            this.dgvLineItem.Location = new System.Drawing.Point(15, 298);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(644, 181);
            this.dgvLineItem.TabIndex = 21;
            this.dgvLineItem.TabStop = false;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Invoice No";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            // 
            // InvoiceAmount
            // 
            this.InvoiceAmount.HeaderText = "Invoice Amount";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.ReadOnly = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(424, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Confirm Amount: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Amount: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Invoice Selection Mode";
            // 
            // rdoAutomatic
            // 
            this.rdoAutomatic.AutoSize = true;
            this.rdoAutomatic.Checked = true;
            this.rdoAutomatic.Location = new System.Drawing.Point(158, 273);
            this.rdoAutomatic.Name = "rdoAutomatic";
            this.rdoAutomatic.Size = new System.Drawing.Size(83, 19);
            this.rdoAutomatic.TabIndex = 19;
            this.rdoAutomatic.TabStop = true;
            this.rdoAutomatic.Text = "Automatic";
            this.rdoAutomatic.UseVisualStyleBackColor = true;
            this.rdoAutomatic.CheckedChanged += new System.EventHandler(this.rdoAutomatic_CheckedChanged);
            // 
            // rdoManual
            // 
            this.rdoManual.AutoSize = true;
            this.rdoManual.Location = new System.Drawing.Point(247, 273);
            this.rdoManual.Name = "rdoManual";
            this.rdoManual.Size = new System.Drawing.Size(68, 19);
            this.rdoManual.TabIndex = 20;
            this.rdoManual.Text = "Manual";
            this.rdoManual.UseVisualStyleBackColor = true;
            this.rdoManual.CheckedChanged += new System.EventHandler(this.rdoManual_CheckedChanged);
            // 
            // lblTakaInWord
            // 
            this.lblTakaInWord.AutoSize = true;
            this.lblTakaInWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTakaInWord.Location = new System.Drawing.Point(7, 105);
            this.lblTakaInWord.Name = "lblTakaInWord";
            this.lblTakaInWord.Size = new System.Drawing.Size(109, 15);
            this.lblTakaInWord.TabIndex = 13;
            this.lblTakaInWord.Text = "Amount (In word) : ";
            // 
            // cmbTranType
            // 
            this.cmbTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranType.FormattingEnabled = true;
            this.cmbTranType.Location = new System.Drawing.Point(116, 12);
            this.cmbTranType.Name = "cmbTranType";
            this.cmbTranType.Size = new System.Drawing.Size(342, 23);
            this.cmbTranType.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Transaction Type";
            // 
            // chkAdvanceColl
            // 
            this.chkAdvanceColl.AutoSize = true;
            this.chkAdvanceColl.Location = new System.Drawing.Point(528, 14);
            this.chkAdvanceColl.Name = "chkAdvanceColl";
            this.chkAdvanceColl.Size = new System.Drawing.Size(135, 19);
            this.chkAdvanceColl.TabIndex = 2;
            this.chkAdvanceColl.Text = "Advance Collection";
            this.chkAdvanceColl.UseVisualStyleBackColor = true;
            this.chkAdvanceColl.CheckedChanged += new System.EventHandler(this.chkAdvanceColl_CheckedChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Invoice No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Invoice Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Invoice Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Payment Due";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Received Amount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "InvoiceID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Current Due";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(116, 41);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(349, 25);
            this.ctlCustomer1.TabIndex = 4;
            this.ctlCustomer1.ChangeSelection += new System.EventHandler(this.ctlCustomer1_ChangeSelection);
            this.ctlCustomer1.Leave += new System.EventHandler(this.ctlCustomer1_Leave);
            // 
            // dtTranDate
            // 
            this.dtTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTranDate.Location = new System.Drawing.Point(314, 69);
            this.dtTranDate.Name = "dtTranDate";
            this.dtTranDate.Size = new System.Drawing.Size(103, 23);
            this.dtTranDate.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Tran Date: ";
            // 
            // frmCustomerCreditCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 549);
            this.Controls.Add(this.dtTranDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkAdvanceColl);
            this.Controls.Add(this.chkInsStatus);
            this.Controls.Add(this.cmbTranType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rdoManual);
            this.Controls.Add(this.rdoAutomatic);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.txtPaymentDueTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCurrentBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCurrentDueTotal);
            this.Controls.Add(this.txtReceiveAmtTotal);
            this.Controls.Add(this.txtInvoiceAmtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAdvance);
            this.Controls.Add(this.txtComfirmAmount);
            this.Controls.Add(this.txtReceiveAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbInstrument);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.lblTakaInWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerCreditCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Credit Collection";
            this.Load += new System.EventHandler(this.frmCustomerCreditCollection_Load);
            this.gbInstrument.ResumeLayout(false);
            this.gbInstrument.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPaymentDueTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurrentBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkInsStatus;
        private System.Windows.Forms.TextBox txtCurrentDueTotal;
        private System.Windows.Forms.TextBox txtReceiveAmtTotal;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox txtInsNo;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblInsNo;
        private System.Windows.Forms.DateTimePicker dtInstrudate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblInsDate;
        private System.Windows.Forms.TextBox txtInvoiceAmtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbInstrumentType;
        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.Label lblInsType;
        private System.Windows.Forms.TextBox txtComfirmAmount;
        private System.Windows.Forms.TextBox txtReceiveAmount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbInstrument;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdoAutomatic;
        private System.Windows.Forms.RadioButton rdoManual;
        private System.Windows.Forms.Label lblTakaInWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentDue;
        private System.Windows.Forms.ComboBox cmbTranType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkAdvanceColl;
        private System.Windows.Forms.DateTimePicker dtTranDate;
        private System.Windows.Forms.Label label10;
    }
}