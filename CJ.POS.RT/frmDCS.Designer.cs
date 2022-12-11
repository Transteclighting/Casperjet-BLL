namespace CJ.POS.RT
{
    partial class frmDCS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDCS));
            this.lvwDCSInvoice = new System.Windows.Forms.ListView();
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDeposit = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInvoiceAmount = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCreditCard = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAdvanceReceive = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOthers = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDCSAdditional = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalReceive = new System.Windows.Forms.Label();
            this.lblDepositCreditCard = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalDeposit = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOthers = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblDifferent = new System.Windows.Forms.Label();
            this.lbldiff = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.lblDepositBankGuaranty = new System.Windows.Forms.Label();
            this.lblAdvanceCard = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblAdjustedB2CCredit = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblAdvanceAdjusted = new System.Windows.Forms.Label();
            this.lblReverseAmount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBankGuaranty = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblCreditCollection = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblAdvanceAdjustedIN = new System.Windows.Forms.Label();
            this.lblB2CCredit = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwDCSInvoice
            // 
            this.lvwDCSInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colAmount,
            this.colType});
            this.lvwDCSInvoice.FullRowSelect = true;
            this.lvwDCSInvoice.GridLines = true;
            this.lvwDCSInvoice.Location = new System.Drawing.Point(14, 68);
            this.lvwDCSInvoice.Name = "lvwDCSInvoice";
            this.lvwDCSInvoice.Size = new System.Drawing.Size(263, 172);
            this.lvwDCSInvoice.TabIndex = 11;
            this.lvwDCSInvoice.UseCompatibleStateImageBehavior = false;
            this.lvwDCSInvoice.View = System.Windows.Forms.View.Details;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Ref. Tran#";
            this.colInvoiceNo.Width = 110;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAmount.Width = 84;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 71;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(84, 15);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(145, 21);
            this.dtFromDate.TabIndex = 16;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "DCS Date";
            // 
            // dgvDeposit
            // 
            this.dgvDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeposit.Location = new System.Drawing.Point(7, 22);
            this.dgvDeposit.Name = "dgvDeposit";
            this.dgvDeposit.Size = new System.Drawing.Size(592, 173);
            this.dgvDeposit.TabIndex = 19;
            this.dgvDeposit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeposit_CellContentClick);
            this.dgvDeposit.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeposit_CellValueChanged);
            this.dgvDeposit.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvDeposit_RowsRemoved);
            this.dgvDeposit.Leave += new System.EventHandler(this.dgvDeposit_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Total:";
            // 
            // lblInvoiceAmount
            // 
            this.lblInvoiceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAmount.Location = new System.Drawing.Point(118, 201);
            this.lblInvoiceAmount.Name = "lblInvoiceAmount";
            this.lblInvoiceAmount.Size = new System.Drawing.Size(98, 15);
            this.lblInvoiceAmount.TabIndex = 22;
            this.lblInvoiceAmount.Text = "0.00";
            this.lblInvoiceAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCash
            // 
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(113, 229);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(103, 15);
            this.lblCash.TabIndex = 24;
            this.lblCash.Text = "0.00";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Total Cash:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCreditCard
            // 
            this.lblCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCard.Location = new System.Drawing.Point(113, 290);
            this.lblCreditCard.Name = "lblCreditCard";
            this.lblCreditCard.Size = new System.Drawing.Size(103, 15);
            this.lblCreditCard.TabIndex = 26;
            this.lblCreditCard.Text = "0.00";
            this.lblCreditCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Card:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdvanceReceive
            // 
            this.lblAdvanceReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvanceReceive.Location = new System.Drawing.Point(113, 250);
            this.lblAdvanceReceive.Name = "lblAdvanceReceive";
            this.lblAdvanceReceive.Size = new System.Drawing.Size(103, 15);
            this.lblAdvanceReceive.TabIndex = 28;
            this.lblAdvanceReceive.Text = "0.00";
            this.lblAdvanceReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "Advance:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOthers
            // 
            this.lblOthers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOthers.Location = new System.Drawing.Point(113, 312);
            this.lblOthers.Name = "lblOthers";
            this.lblOthers.Size = new System.Drawing.Size(103, 15);
            this.lblOthers.TabIndex = 30;
            this.lblOthers.Text = "0.00";
            this.lblOthers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "EPS and Others:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDCSAdditional
            // 
            this.txtDCSAdditional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDCSAdditional.Location = new System.Drawing.Point(121, 437);
            this.txtDCSAdditional.Name = "txtDCSAdditional";
            this.txtDCSAdditional.Size = new System.Drawing.Size(98, 21);
            this.txtDCSAdditional.TabIndex = 32;
            this.txtDCSAdditional.Text = "0.00";
            this.txtDCSAdditional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDCSAdditional.TextChanged += new System.EventHandler(this.txtDCSAdditional_TextChanged);
            this.txtDCSAdditional.Leave += new System.EventHandler(this.txtDCSAdditional_Leave);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 33;
            this.label4.Text = "Additional:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(11, 463);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Total Receive:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalReceive
            // 
            this.lblTotalReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReceive.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalReceive.Location = new System.Drawing.Point(118, 463);
            this.lblTotalReceive.Name = "lblTotalReceive";
            this.lblTotalReceive.Size = new System.Drawing.Size(103, 15);
            this.lblTotalReceive.TabIndex = 35;
            this.lblTotalReceive.Text = "0.00";
            this.lblTotalReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepositCreditCard
            // 
            this.lblDepositCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositCreditCard.Location = new System.Drawing.Point(496, 291);
            this.lblDepositCreditCard.Name = "lblDepositCreditCard";
            this.lblDepositCreditCard.Size = new System.Drawing.Size(103, 15);
            this.lblDepositCreditCard.TabIndex = 37;
            this.lblDepositCreditCard.Text = "0.00";
            this.lblDepositCreditCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(396, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 15);
            this.label11.TabIndex = 36;
            this.label11.Text = "Credit Card:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeposit
            // 
            this.lblDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.Location = new System.Drawing.Point(501, 201);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(98, 15);
            this.lblDeposit.TabIndex = 39;
            this.lblDeposit.Text = "0.00";
            this.lblDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(447, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 15);
            this.label13.TabIndex = 38;
            this.label13.Text = "Total:";
            // 
            // lblTotalDeposit
            // 
            this.lblTotalDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDeposit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalDeposit.Location = new System.Drawing.Point(497, 428);
            this.lblTotalDeposit.Name = "lblTotalDeposit";
            this.lblTotalDeposit.Size = new System.Drawing.Size(103, 15);
            this.lblTotalDeposit.TabIndex = 43;
            this.lblTotalDeposit.Text = "0.00";
            this.lblTotalDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(384, 428);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 15);
            this.label15.TabIndex = 42;
            this.label15.Text = "Total Deposit:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(304, 402);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(192, 15);
            this.label16.TabIndex = 41;
            this.label16.Text = "Utility and Others Adjust:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOthers
            // 
            this.txtOthers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOthers.Location = new System.Drawing.Point(502, 398);
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.Size = new System.Drawing.Size(96, 21);
            this.txtOthers.TabIndex = 40;
            this.txtOthers.Text = "0.00";
            this.txtOthers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOthers.TextChanged += new System.EventHandler(this.txtOthers_TextChanged);
            this.txtOthers.Leave += new System.EventHandler(this.txtOthers_Leave);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 527);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 15);
            this.label10.TabIndex = 45;
            this.label10.Text = "Remarks:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(115, 524);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(806, 21);
            this.txtRemarks.TabIndex = 44;
            // 
            // lblDifferent
            // 
            this.lblDifferent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifferent.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDifferent.Location = new System.Drawing.Point(755, 498);
            this.lblDifferent.Name = "lblDifferent";
            this.lblDifferent.Size = new System.Drawing.Size(166, 23);
            this.lblDifferent.TabIndex = 47;
            this.lblDifferent.Text = "0.00";
            this.lblDifferent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbldiff
            // 
            this.lbldiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiff.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbldiff.Location = new System.Drawing.Point(633, 499);
            this.lbldiff.Name = "lbldiff";
            this.lbldiff.Size = new System.Drawing.Size(125, 21);
            this.lbldiff.TabIndex = 46;
            this.lbldiff.Text = "Difference:";
            this.lbldiff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.lblDepositBankGuaranty);
            this.groupBox1.Controls.Add(this.lblAdvanceCard);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.lblAdjustedB2CCredit);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.lblAdvanceAdjusted);
            this.groupBox1.Controls.Add(this.lblReverseAmount);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblTotalDeposit);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtOthers);
            this.groupBox1.Controls.Add(this.lblDeposit);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblDepositCreditCard);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.dgvDeposit);
            this.groupBox1.Location = new System.Drawing.Point(306, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 451);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OUT";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(35, 229);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 15);
            this.label23.TabIndex = 52;
            this.label23.Text = "Advance Card:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label23.Visible = false;
            // 
            // lblDepositBankGuaranty
            // 
            this.lblDepositBankGuaranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepositBankGuaranty.Location = new System.Drawing.Point(496, 380);
            this.lblDepositBankGuaranty.Name = "lblDepositBankGuaranty";
            this.lblDepositBankGuaranty.Size = new System.Drawing.Size(103, 15);
            this.lblDepositBankGuaranty.TabIndex = 61;
            this.lblDepositBankGuaranty.Text = "0.00";
            this.lblDepositBankGuaranty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdvanceCard
            // 
            this.lblAdvanceCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvanceCard.Location = new System.Drawing.Point(134, 229);
            this.lblAdvanceCard.Name = "lblAdvanceCard";
            this.lblAdvanceCard.Size = new System.Drawing.Size(103, 15);
            this.lblAdvanceCard.TabIndex = 60;
            this.lblAdvanceCard.Text = "0.00";
            this.lblAdvanceCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAdvanceCard.Visible = false;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(368, 380);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(127, 15);
            this.label22.TabIndex = 60;
            this.label22.Text = "Bank Guaranty:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdjustedB2CCredit
            // 
            this.lblAdjustedB2CCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjustedB2CCredit.Location = new System.Drawing.Point(497, 357);
            this.lblAdjustedB2CCredit.Name = "lblAdjustedB2CCredit";
            this.lblAdjustedB2CCredit.Size = new System.Drawing.Size(103, 15);
            this.lblAdjustedB2CCredit.TabIndex = 53;
            this.lblAdjustedB2CCredit.Text = "0.00";
            this.lblAdjustedB2CCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(371, 358);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 15);
            this.label17.TabIndex = 53;
            this.label17.Text = "Approve Credit:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdvanceAdjusted
            // 
            this.lblAdvanceAdjusted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvanceAdjusted.Location = new System.Drawing.Point(497, 336);
            this.lblAdvanceAdjusted.Name = "lblAdvanceAdjusted";
            this.lblAdvanceAdjusted.Size = new System.Drawing.Size(103, 15);
            this.lblAdvanceAdjusted.TabIndex = 53;
            this.lblAdvanceAdjusted.Text = "0.00";
            this.lblAdvanceAdjusted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReverseAmount
            // 
            this.lblReverseAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReverseAmount.Location = new System.Drawing.Point(496, 314);
            this.lblReverseAmount.Name = "lblReverseAmount";
            this.lblReverseAmount.Size = new System.Drawing.Size(103, 15);
            this.lblReverseAmount.TabIndex = 45;
            this.lblReverseAmount.Text = "0.00";
            this.lblReverseAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(328, 335);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 15);
            this.label14.TabIndex = 52;
            this.label14.Text = "Advance Adjust:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(368, 313);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 15);
            this.label12.TabIndex = 44;
            this.label12.Text = "Reverse Amount:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblBankGuaranty);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.lblCreditCollection);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.lblAdvanceAdjustedIN);
            this.groupBox2.Controls.Add(this.lblB2CCredit);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblOthers);
            this.groupBox2.Controls.Add(this.lblCreditCard);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblAdvanceReceive);
            this.groupBox2.Controls.Add(this.lblCash);
            this.groupBox2.Controls.Add(this.lblInvoiceAmount);
            this.groupBox2.Location = new System.Drawing.Point(5, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 451);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IN";
            // 
            // lblBankGuaranty
            // 
            this.lblBankGuaranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankGuaranty.Location = new System.Drawing.Point(115, 373);
            this.lblBankGuaranty.Name = "lblBankGuaranty";
            this.lblBankGuaranty.Size = new System.Drawing.Size(103, 15);
            this.lblBankGuaranty.TabIndex = 59;
            this.lblBankGuaranty.Text = "0.00";
            this.lblBankGuaranty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 373);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 15);
            this.label21.TabIndex = 58;
            this.label21.Text = "Bank Guaranty:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCreditCollection
            // 
            this.lblCreditCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditCollection.Location = new System.Drawing.Point(113, 270);
            this.lblCreditCollection.Name = "lblCreditCollection";
            this.lblCreditCollection.Size = new System.Drawing.Size(103, 15);
            this.lblCreditCollection.TabIndex = 57;
            this.lblCreditCollection.Text = "0.00";
            this.lblCreditCollection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(9, 270);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 15);
            this.label20.TabIndex = 56;
            this.label20.Text = "Credit Collection:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAdvanceAdjustedIN
            // 
            this.lblAdvanceAdjustedIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvanceAdjustedIN.Location = new System.Drawing.Point(113, 333);
            this.lblAdvanceAdjustedIN.Name = "lblAdvanceAdjustedIN";
            this.lblAdvanceAdjustedIN.Size = new System.Drawing.Size(103, 15);
            this.lblAdvanceAdjustedIN.TabIndex = 55;
            this.lblAdvanceAdjustedIN.Text = "0.00";
            this.lblAdvanceAdjustedIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblB2CCredit
            // 
            this.lblB2CCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB2CCredit.Location = new System.Drawing.Point(113, 352);
            this.lblB2CCredit.Name = "lblB2CCredit";
            this.lblB2CCredit.Size = new System.Drawing.Size(103, 15);
            this.lblB2CCredit.TabIndex = 52;
            this.lblB2CCredit.Text = "0.00";
            this.lblB2CCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 333);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(102, 15);
            this.label19.TabIndex = 54;
            this.label19.Text = "Advance Adjust:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "Approve Credit:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(834, 551);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(743, 551);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 29);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDCS
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 591);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDifferent);
            this.Controls.Add(this.lbldiff);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblTotalReceive);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDCSAdditional);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwDCSInvoice);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDCS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add DCS";
            this.Load += new System.EventHandler(this.frmDCS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDCSInvoice;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDeposit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInvoiceAmount;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCreditCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAdvanceReceive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOthers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDCSAdditional;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalReceive;
        private System.Windows.Forms.Label lblDepositCreditCard;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotalDeposit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtOthers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblDifferent;
        private System.Windows.Forms.Label lbldiff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblReverseAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAdvanceAdjusted;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblAdjustedB2CCredit;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblB2CCredit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAdvanceAdjustedIN;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblCreditCollection;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblBankGuaranty;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblDepositBankGuaranty;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblAdvanceCard;
    }
}