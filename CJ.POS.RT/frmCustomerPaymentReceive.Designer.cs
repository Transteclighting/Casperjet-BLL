namespace CJ.POS.RT
{
    partial class frmCustomerPaymentReceive
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerPaymentReceive));
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTakaInWord = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkInsStatus = new System.Windows.Forms.CheckBox();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.txtInsNo = new System.Windows.Forms.TextBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblInsNo = new System.Windows.Forms.Label();
            this.dtInstrudate = new System.Windows.Forms.DateTimePicker();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.cmbInstrumentType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInsDate = new System.Windows.Forms.Label();
            this.lblInsType = new System.Windows.Forms.Label();
            this.txtComfirmAmount = new System.Windows.Forms.TextBox();
            this.txtReceiveAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPaymentDueTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReceiveAmtTotal = new System.Windows.Forms.TextBox();
            this.txtCurrentDueTotal = new System.Windows.Forms.TextBox();
            this.txtInvoiceAmtTotal = new System.Windows.Forms.TextBox();
            this.txtAdvance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLineItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNo,
            this.InvoiceDate,
            this.InvoiceAmount,
            this.PaymentDue,
            this.ReceivedAmount,
            this.InvoiceID,
            this.CurrentDue});
            this.dgvLineItem.Location = new System.Drawing.Point(12, 229);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.ReadOnly = true;
            this.dgvLineItem.Size = new System.Drawing.Size(654, 198);
            this.dgvLineItem.TabIndex = 11;
            this.dgvLineItem.TabStop = false;
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
            this.ReceivedAmount.ReadOnly = true;
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
            // lblTakaInWord
            // 
            this.lblTakaInWord.AutoSize = true;
            this.lblTakaInWord.Location = new System.Drawing.Point(19, 92);
            this.lblTakaInWord.Name = "lblTakaInWord";
            this.lblTakaInWord.Size = new System.Drawing.Size(0, 13);
            this.lblTakaInWord.TabIndex = 9;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(71, 203);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(595, 20);
            this.txtRemarks.TabIndex = 10;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(9, 206);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(57, 15);
            this.lblRemarks.TabIndex = 9;
            this.lblRemarks.Text = "Remarks";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.chkInsStatus);
            this.groupBox3.Controls.Add(this.txtBranch);
            this.groupBox3.Controls.Add(this.txtInsNo);
            this.groupBox3.Controls.Add(this.cmbBranch);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.lblInsNo);
            this.groupBox3.Controls.Add(this.dtInstrudate);
            this.groupBox3.Controls.Add(this.cmbBank);
            this.groupBox3.Controls.Add(this.cmbInstrumentType);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblInsDate);
            this.groupBox3.Controls.Add(this.lblInsType);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(654, 107);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instrument";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(319, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Branch Name: ";
            // 
            // chkInsStatus
            // 
            this.chkInsStatus.AutoSize = true;
            this.chkInsStatus.Location = new System.Drawing.Point(242, 75);
            this.chkInsStatus.Name = "chkInsStatus";
            this.chkInsStatus.Size = new System.Drawing.Size(77, 19);
            this.chkInsStatus.TabIndex = 10;
            this.chkInsStatus.Text = "Approved";
            this.chkInsStatus.UseVisualStyleBackColor = true;
            this.chkInsStatus.Visible = false;
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(412, 47);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(159, 21);
            this.txtBranch.TabIndex = 9;
            // 
            // txtInsNo
            // 
            this.txtInsNo.Location = new System.Drawing.Point(412, 21);
            this.txtInsNo.Name = "txtInsNo";
            this.txtInsNo.Size = new System.Drawing.Size(159, 21);
            this.txtInsNo.TabIndex = 7;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(412, 74);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(159, 23);
            this.cmbBranch.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(357, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Branch: ";
            // 
            // lblInsNo
            // 
            this.lblInsNo.AutoSize = true;
            this.lblInsNo.Location = new System.Drawing.Point(321, 21);
            this.lblInsNo.Name = "lblInsNo";
            this.lblInsNo.Size = new System.Drawing.Size(87, 15);
            this.lblInsNo.TabIndex = 6;
            this.lblInsNo.Text = "Instrument No.";
            // 
            // dtInstrudate
            // 
            this.dtInstrudate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInstrudate.Location = new System.Drawing.Point(65, 75);
            this.dtInstrudate.Name = "dtInstrudate";
            this.dtInstrudate.Size = new System.Drawing.Size(171, 21);
            this.dtInstrudate.TabIndex = 5;
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(65, 46);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(171, 23);
            this.cmbBank.TabIndex = 3;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            // 
            // cmbInstrumentType
            // 
            this.cmbInstrumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrumentType.FormattingEnabled = true;
            this.cmbInstrumentType.Location = new System.Drawing.Point(65, 17);
            this.cmbInstrumentType.Name = "cmbInstrumentType";
            this.cmbInstrumentType.Size = new System.Drawing.Size(171, 23);
            this.cmbInstrumentType.TabIndex = 1;
            this.cmbInstrumentType.SelectedIndexChanged += new System.EventHandler(this.cmbInstrumentType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Bank: ";
            // 
            // lblInsDate
            // 
            this.lblInsDate.AutoSize = true;
            this.lblInsDate.Location = new System.Drawing.Point(23, 78);
            this.lblInsDate.Name = "lblInsDate";
            this.lblInsDate.Size = new System.Drawing.Size(39, 15);
            this.lblInsDate.TabIndex = 4;
            this.lblInsDate.Text = "Date: ";
            // 
            // lblInsType
            // 
            this.lblInsType.AutoSize = true;
            this.lblInsType.Location = new System.Drawing.Point(23, 20);
            this.lblInsType.Name = "lblInsType";
            this.lblInsType.Size = new System.Drawing.Size(39, 15);
            this.lblInsType.TabIndex = 0;
            this.lblInsType.Text = "Type: ";
            // 
            // txtComfirmAmount
            // 
            this.txtComfirmAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComfirmAmount.Location = new System.Drawing.Point(109, 63);
            this.txtComfirmAmount.Name = "txtComfirmAmount";
            this.txtComfirmAmount.Size = new System.Drawing.Size(139, 21);
            this.txtComfirmAmount.TabIndex = 7;
            this.txtComfirmAmount.Text = "0.00";
            this.txtComfirmAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReceiveAmount
            // 
            this.txtReceiveAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveAmount.Location = new System.Drawing.Point(109, 38);
            this.txtReceiveAmount.Name = "txtReceiveAmount";
            this.txtReceiveAmount.Size = new System.Drawing.Size(139, 21);
            this.txtReceiveAmount.TabIndex = 3;
            this.txtReceiveAmount.Text = "0.00";
            this.txtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReceiveAmount.TextChanged += new System.EventHandler(this.txtReceiveAmount_TextChanged);
            this.txtReceiveAmount.Leave += new System.EventHandler(this.txtReceiveAmount_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Confirm Amount: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Amount: ";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(591, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(510, 465);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Customer: ";
            // 
            // txtCurrentBalance
            // 
            this.txtCurrentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentBalance.Location = new System.Drawing.Point(502, 37);
            this.txtCurrentBalance.Name = "txtCurrentBalance";
            this.txtCurrentBalance.ReadOnly = true;
            this.txtCurrentBalance.Size = new System.Drawing.Size(139, 21);
            this.txtCurrentBalance.TabIndex = 5;
            this.txtCurrentBalance.Text = "0.00";
            this.txtCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(384, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Customer Balance: ";
            // 
            // txtPaymentDueTotal
            // 
            this.txtPaymentDueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentDueTotal.Location = new System.Drawing.Point(378, 436);
            this.txtPaymentDueTotal.Name = "txtPaymentDueTotal";
            this.txtPaymentDueTotal.ReadOnly = true;
            this.txtPaymentDueTotal.Size = new System.Drawing.Size(95, 21);
            this.txtPaymentDueTotal.TabIndex = 14;
            this.txtPaymentDueTotal.Text = "0.00";
            this.txtPaymentDueTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(214, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Total : >> ";
            // 
            // txtReceiveAmtTotal
            // 
            this.txtReceiveAmtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveAmtTotal.Location = new System.Drawing.Point(475, 436);
            this.txtReceiveAmtTotal.Name = "txtReceiveAmtTotal";
            this.txtReceiveAmtTotal.ReadOnly = true;
            this.txtReceiveAmtTotal.Size = new System.Drawing.Size(95, 21);
            this.txtReceiveAmtTotal.TabIndex = 15;
            this.txtReceiveAmtTotal.Text = "0.00";
            this.txtReceiveAmtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurrentDueTotal
            // 
            this.txtCurrentDueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentDueTotal.Location = new System.Drawing.Point(572, 436);
            this.txtCurrentDueTotal.Name = "txtCurrentDueTotal";
            this.txtCurrentDueTotal.ReadOnly = true;
            this.txtCurrentDueTotal.Size = new System.Drawing.Size(95, 21);
            this.txtCurrentDueTotal.TabIndex = 16;
            this.txtCurrentDueTotal.Text = "0.00";
            this.txtCurrentDueTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInvoiceAmtTotal
            // 
            this.txtInvoiceAmtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceAmtTotal.Location = new System.Drawing.Point(281, 436);
            this.txtInvoiceAmtTotal.Name = "txtInvoiceAmtTotal";
            this.txtInvoiceAmtTotal.ReadOnly = true;
            this.txtInvoiceAmtTotal.Size = new System.Drawing.Size(95, 21);
            this.txtInvoiceAmtTotal.TabIndex = 13;
            this.txtInvoiceAmtTotal.Text = "0.00";
            this.txtInvoiceAmtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAdvance
            // 
            this.txtAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvance.Location = new System.Drawing.Point(281, 462);
            this.txtAdvance.Name = "txtAdvance";
            this.txtAdvance.ReadOnly = true;
            this.txtAdvance.Size = new System.Drawing.Size(95, 21);
            this.txtAdvance.TabIndex = 18;
            this.txtAdvance.Text = "0.00";
            this.txtAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(192, 465);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Advance : >> ";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Invoice No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Invoice Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Invoice Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Payment Due";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Received Amount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "InvoiceID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Current Due";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(109, 11);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(538, 25);
            this.ctlCustomer1.TabIndex = 1;
            this.ctlCustomer1.Leave += new System.EventHandler(this.ctlCustomer1_Leave);
            // 
            // frmCustomerPaymentReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 499);
            this.Controls.Add(this.txtAdvance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInvoiceAmtTotal);
            this.Controls.Add(this.txtCurrentDueTotal);
            this.Controls.Add(this.txtReceiveAmtTotal);
            this.Controls.Add(this.txtPaymentDueTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCurrentBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtComfirmAmount);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtReceiveAmount);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblTakaInWord);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerPaymentReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Payment Receive";
            this.Load += new System.EventHandler(this.frmCustomerPaymentReceive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLineItem;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label lblTakaInWord;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkInsStatus;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.TextBox txtInsNo;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblInsNo;
        private System.Windows.Forms.DateTimePicker dtInstrudate;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.ComboBox cmbInstrumentType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblInsDate;
        private System.Windows.Forms.Label lblInsType;
        private System.Windows.Forms.TextBox txtComfirmAmount;
        private System.Windows.Forms.TextBox txtReceiveAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaymentDueTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentDue;
        private System.Windows.Forms.TextBox txtReceiveAmtTotal;
        private System.Windows.Forms.TextBox txtCurrentDueTotal;
        private System.Windows.Forms.TextBox txtInvoiceAmtTotal;
        private System.Windows.Forms.TextBox txtAdvance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}