namespace CJ.POS.RT.Invoice
{
    partial class frmInvoicePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoicePayment));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDueAmount = new System.Windows.Forms.TextBox();
            this.txtCollectionAmount = new System.Windows.Forms.TextBox();
            this.txtNetPay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtTotalDisount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPromoDisount = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lblpayableAmount = new System.Windows.Forms.Label();
            this.txtAdditionalDiscount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvInvoicePayment = new System.Windows.Forms.DataGridView();
            this.colPaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreditCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPOSMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApprovalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsEMI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoofInstallment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInstrumentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInstrumentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentModeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosMachinID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtendedEMICharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBankDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtBGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCreditApprovalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAdvancePaymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBankDiscountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtExtendedEMIChargeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSDApprovalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalCharge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAddPayment = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDiscountsCharges = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicePayment)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(711, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 31);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOK.Location = new System.Drawing.Point(616, 419);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 31);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(154, 46);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(214, 21);
            this.txtTotal.TabIndex = 3;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(46, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 15);
            this.label21.TabIndex = 2;
            this.label21.Text = "Total Sales Price:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.txtDueAmount);
            this.groupBox7.Controls.Add(this.txtCollectionAmount);
            this.groupBox7.Controls.Add(this.txtNetPay);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(427, 46);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(371, 118);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Due:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Collection:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Payable:";
            // 
            // txtDueAmount
            // 
            this.txtDueAmount.BackColor = System.Drawing.SystemColors.Info;
            this.txtDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueAmount.Location = new System.Drawing.Point(122, 82);
            this.txtDueAmount.Name = "txtDueAmount";
            this.txtDueAmount.ReadOnly = true;
            this.txtDueAmount.Size = new System.Drawing.Size(240, 26);
            this.txtDueAmount.TabIndex = 5;
            this.txtDueAmount.Text = "0.00";
            this.txtDueAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCollectionAmount
            // 
            this.txtCollectionAmount.BackColor = System.Drawing.SystemColors.Info;
            this.txtCollectionAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCollectionAmount.Location = new System.Drawing.Point(122, 50);
            this.txtCollectionAmount.Name = "txtCollectionAmount";
            this.txtCollectionAmount.ReadOnly = true;
            this.txtCollectionAmount.Size = new System.Drawing.Size(240, 26);
            this.txtCollectionAmount.TabIndex = 3;
            this.txtCollectionAmount.Text = "0.00";
            this.txtCollectionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNetPay
            // 
            this.txtNetPay.BackColor = System.Drawing.SystemColors.Info;
            this.txtNetPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetPay.Location = new System.Drawing.Point(122, 18);
            this.txtNetPay.Name = "txtNetPay";
            this.txtNetPay.ReadOnly = true;
            this.txtNetPay.Size = new System.Drawing.Size(240, 26);
            this.txtNetPay.TabIndex = 1;
            this.txtNetPay.Text = "0.00";
            this.txtNetPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.Navy;
            this.lblProductName.Location = new System.Drawing.Point(154, 18);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(15, 15);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "?";
            // 
            // txtTotalDisount
            // 
            this.txtTotalDisount.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalDisount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDisount.Location = new System.Drawing.Point(144, 69);
            this.txtTotalDisount.Name = "txtTotalDisount";
            this.txtTotalDisount.ReadOnly = true;
            this.txtTotalDisount.Size = new System.Drawing.Size(214, 21);
            this.txtTotalDisount.TabIndex = 5;
            this.txtTotalDisount.Text = "0.0";
            this.txtTotalDisount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(50, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Total Discount:";
            // 
            // txtPromoDisount
            // 
            this.txtPromoDisount.BackColor = System.Drawing.SystemColors.Info;
            this.txtPromoDisount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPromoDisount.Location = new System.Drawing.Point(144, 18);
            this.txtPromoDisount.Name = "txtPromoDisount";
            this.txtPromoDisount.ReadOnly = true;
            this.txtPromoDisount.Size = new System.Drawing.Size(214, 21);
            this.txtPromoDisount.TabIndex = 1;
            this.txtPromoDisount.Text = "0.0";
            this.txtPromoDisount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPromoDisount.TextChanged += new System.EventHandler(this.txtPromoDisount_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(128, 15);
            this.label22.TabIndex = 0;
            this.label22.Text = "Promotional Discount:";
            // 
            // lblpayableAmount
            // 
            this.lblpayableAmount.AutoSize = true;
            this.lblpayableAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblpayableAmount.Location = new System.Drawing.Point(7, 421);
            this.lblpayableAmount.Name = "lblpayableAmount";
            this.lblpayableAmount.Size = new System.Drawing.Size(97, 15);
            this.lblpayableAmount.TabIndex = 10;
            this.lblpayableAmount.Text = "Amount In Word:";
            // 
            // txtAdditionalDiscount
            // 
            this.txtAdditionalDiscount.BackColor = System.Drawing.SystemColors.Info;
            this.txtAdditionalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalDiscount.Location = new System.Drawing.Point(144, 45);
            this.txtAdditionalDiscount.Name = "txtAdditionalDiscount";
            this.txtAdditionalDiscount.ReadOnly = true;
            this.txtAdditionalDiscount.Size = new System.Drawing.Size(214, 21);
            this.txtAdditionalDiscount.TabIndex = 3;
            this.txtAdditionalDiscount.Text = "0.0";
            this.txtAdditionalDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Additional Discount:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtTotalDisount);
            this.groupBox1.Controls.Add(this.txtPromoDisount);
            this.groupBox1.Controls.Add(this.txtAdditionalDiscount);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(10, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 101);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Discount";
            // 
            // dgvInvoicePayment
            // 
            this.dgvInvoicePayment.AllowUserToAddRows = false;
            this.dgvInvoicePayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoicePayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPaymentMode,
            this.colAmount,
            this.colBank,
            this.colCreditCardType,
            this.colPOSMachine,
            this.colCategory,
            this.colApprovalNo,
            this.colIsEMI,
            this.colNoofInstallment,
            this.colInstrumentNo,
            this.colInstrumentDate,
            this.colPaymentModeID,
            this.colBankID,
            this.colCardTypeID,
            this.colPosMachinID,
            this.colCardCategory,
            this.colExtendedEMICharge,
            this.colBankDiscount,
            this.colUpdate,
            this.txtBGID,
            this.txtCreditApprovalID,
            this.txtAdvancePaymentID,
            this.txtBankDiscountID,
            this.txtExtendedEMIChargeID,
            this.txtSDApprovalNo});
            this.dgvInvoicePayment.Location = new System.Drawing.Point(10, 213);
            this.dgvInvoicePayment.Name = "dgvInvoicePayment";
            this.dgvInvoicePayment.Size = new System.Drawing.Size(788, 200);
            this.dgvInvoicePayment.TabIndex = 9;
            this.dgvInvoicePayment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoicePayment_CellContentClick);
            this.dgvInvoicePayment.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvInvoicePayment_RowsRemoved);
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.HeaderText = "Payment Mode";
            this.colPaymentMode.Name = "colPaymentMode";
            this.colPaymentMode.ReadOnly = true;
            this.colPaymentMode.Width = 105;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 60;
            // 
            // colBank
            // 
            this.colBank.HeaderText = "Bank";
            this.colBank.Name = "colBank";
            this.colBank.ReadOnly = true;
            // 
            // colCreditCardType
            // 
            this.colCreditCardType.HeaderText = "Card Type";
            this.colCreditCardType.Name = "colCreditCardType";
            this.colCreditCardType.ReadOnly = true;
            this.colCreditCardType.Width = 85;
            // 
            // colPOSMachine
            // 
            this.colPOSMachine.HeaderText = "POS Machine";
            this.colPOSMachine.Name = "colPOSMachine";
            this.colPOSMachine.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 80;
            // 
            // colApprovalNo
            // 
            this.colApprovalNo.HeaderText = "Approval#";
            this.colApprovalNo.Name = "colApprovalNo";
            this.colApprovalNo.ReadOnly = true;
            this.colApprovalNo.Width = 80;
            // 
            // colIsEMI
            // 
            this.colIsEMI.HeaderText = "Is EMI";
            this.colIsEMI.Name = "colIsEMI";
            this.colIsEMI.ReadOnly = true;
            this.colIsEMI.Width = 50;
            // 
            // colNoofInstallment
            // 
            this.colNoofInstallment.HeaderText = "# of Installment";
            this.colNoofInstallment.Name = "colNoofInstallment";
            this.colNoofInstallment.ReadOnly = true;
            this.colNoofInstallment.Width = 50;
            // 
            // colInstrumentNo
            // 
            this.colInstrumentNo.HeaderText = "Instrument #";
            this.colInstrumentNo.Name = "colInstrumentNo";
            this.colInstrumentNo.ReadOnly = true;
            this.colInstrumentNo.Width = 80;
            // 
            // colInstrumentDate
            // 
            this.colInstrumentDate.HeaderText = "Instrument Date";
            this.colInstrumentDate.Name = "colInstrumentDate";
            this.colInstrumentDate.ReadOnly = true;
            this.colInstrumentDate.Width = 80;
            // 
            // colPaymentModeID
            // 
            this.colPaymentModeID.HeaderText = "PaymentModeID";
            this.colPaymentModeID.Name = "colPaymentModeID";
            this.colPaymentModeID.ReadOnly = true;
            this.colPaymentModeID.Visible = false;
            // 
            // colBankID
            // 
            this.colBankID.HeaderText = "BankID";
            this.colBankID.Name = "colBankID";
            this.colBankID.ReadOnly = true;
            this.colBankID.Visible = false;
            // 
            // colCardTypeID
            // 
            this.colCardTypeID.HeaderText = "CardTypeID";
            this.colCardTypeID.Name = "colCardTypeID";
            this.colCardTypeID.ReadOnly = true;
            this.colCardTypeID.Visible = false;
            // 
            // colPosMachinID
            // 
            this.colPosMachinID.HeaderText = "PosMachinID";
            this.colPosMachinID.Name = "colPosMachinID";
            this.colPosMachinID.ReadOnly = true;
            this.colPosMachinID.Visible = false;
            // 
            // colCardCategory
            // 
            this.colCardCategory.HeaderText = "CardCategory";
            this.colCardCategory.Name = "colCardCategory";
            this.colCardCategory.ReadOnly = true;
            this.colCardCategory.Visible = false;
            // 
            // colExtendedEMICharge
            // 
            this.colExtendedEMICharge.HeaderText = "ExtendedEMICharge";
            this.colExtendedEMICharge.Name = "colExtendedEMICharge";
            this.colExtendedEMICharge.ReadOnly = true;
            this.colExtendedEMICharge.Visible = false;
            // 
            // colBankDiscount
            // 
            this.colBankDiscount.HeaderText = "BankDiscount";
            this.colBankDiscount.Name = "colBankDiscount";
            this.colBankDiscount.ReadOnly = true;
            this.colBankDiscount.Visible = false;
            // 
            // colUpdate
            // 
            this.colUpdate.HeaderText = "Edit";
            this.colUpdate.Name = "colUpdate";
            this.colUpdate.Width = 35;
            // 
            // txtBGID
            // 
            this.txtBGID.HeaderText = "BGID";
            this.txtBGID.Name = "txtBGID";
            this.txtBGID.ReadOnly = true;
            this.txtBGID.Visible = false;
            // 
            // txtCreditApprovalID
            // 
            this.txtCreditApprovalID.HeaderText = "CreditApprovalID";
            this.txtCreditApprovalID.Name = "txtCreditApprovalID";
            this.txtCreditApprovalID.Visible = false;
            // 
            // txtAdvancePaymentID
            // 
            this.txtAdvancePaymentID.HeaderText = "AdvancePaymentID";
            this.txtAdvancePaymentID.Name = "txtAdvancePaymentID";
            this.txtAdvancePaymentID.ReadOnly = true;
            this.txtAdvancePaymentID.Visible = false;
            // 
            // txtBankDiscountID
            // 
            this.txtBankDiscountID.HeaderText = "BankDiscountID";
            this.txtBankDiscountID.Name = "txtBankDiscountID";
            this.txtBankDiscountID.ReadOnly = true;
            this.txtBankDiscountID.Visible = false;
            // 
            // txtExtendedEMIChargeID
            // 
            this.txtExtendedEMIChargeID.HeaderText = "ExtendedEMIChargeID";
            this.txtExtendedEMIChargeID.Name = "txtExtendedEMIChargeID";
            this.txtExtendedEMIChargeID.ReadOnly = true;
            this.txtExtendedEMIChargeID.Visible = false;
            // 
            // txtSDApprovalNo
            // 
            this.txtSDApprovalNo.HeaderText = "SDApprovalNo";
            this.txtSDApprovalNo.Name = "txtSDApprovalNo";
            this.txtSDApprovalNo.Visible = false;
            // 
            // txtTotalCharge
            // 
            this.txtTotalCharge.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCharge.Location = new System.Drawing.Point(154, 73);
            this.txtTotalCharge.Name = "txtTotalCharge";
            this.txtTotalCharge.ReadOnly = true;
            this.txtTotalCharge.Size = new System.Drawing.Size(214, 21);
            this.txtTotalCharge.TabIndex = 5;
            this.txtTotalCharge.Text = "0.00";
            this.txtTotalCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Charge:";
            // 
            // lblAddPayment
            // 
            this.lblAddPayment.AutoSize = true;
            this.lblAddPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblAddPayment.Location = new System.Drawing.Point(7, 15);
            this.lblAddPayment.Name = "lblAddPayment";
            this.lblAddPayment.Size = new System.Drawing.Size(100, 16);
            this.lblAddPayment.TabIndex = 0;
            this.lblAddPayment.Text = "Add Payment";
            this.lblAddPayment.Click += new System.EventHandler(this.lblAddPayment_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Payment Mode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 105;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Bank";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Card Type";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 85;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "POS Machine";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Category";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Approval#";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Is EMI";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "# of Installment";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 50;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Instrument #";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Instrument Date";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "PaymentModeID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "BankID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "CardTypeID";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "PosMachinID";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // lblDiscountsCharges
            // 
            this.lblDiscountsCharges.AutoSize = true;
            this.lblDiscountsCharges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDiscountsCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountsCharges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDiscountsCharges.Location = new System.Drawing.Point(138, 15);
            this.lblDiscountsCharges.Name = "lblDiscountsCharges";
            this.lblDiscountsCharges.Size = new System.Drawing.Size(152, 16);
            this.lblDiscountsCharges.TabIndex = 1;
            this.lblDiscountsCharges.Text = "Discounts && Charges";
            this.lblDiscountsCharges.Click += new System.EventHandler(this.lblDiscountsCharges_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAddPayment);
            this.groupBox2.Controls.Add(this.lblDiscountsCharges);
            this.groupBox2.Location = new System.Drawing.Point(427, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 41);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // frmInvoicePayment
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 457);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtTotalCharge);
            this.Controls.Add(this.dgvInvoicePayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblpayableAmount);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInvoicePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmInvoicePayment_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicePayment)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtPromoDisount;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblpayableAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDueAmount;
        private System.Windows.Forms.TextBox txtCollectionAmount;
        private System.Windows.Forms.TextBox txtNetPay;
        private System.Windows.Forms.TextBox txtTotalDisount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAdditionalDiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvInvoicePayment;
        private System.Windows.Forms.TextBox txtTotalCharge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAddPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.Label lblDiscountsCharges;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSDApprovalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtExtendedEMIChargeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBankDiscountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAdvancePaymentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCreditApprovalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBGID;
        private System.Windows.Forms.DataGridViewButtonColumn colUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExtendedEMICharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosMachinID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentModeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstrumentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstrumentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoofInstallment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsEMI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApprovalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPOSMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreditCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentMode;
    }
}