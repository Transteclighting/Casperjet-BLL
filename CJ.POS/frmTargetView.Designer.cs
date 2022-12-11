namespace CJ.POS
{
    partial class frmTargetView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTargetView));
            this.dgvTGT = new System.Windows.Forms.DataGridView();
            this.txtMAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRetailTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRtlSalesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRTLQtyPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRetailTGTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRetailSalesAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRTLValPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDealerTGTQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDealerSalesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDealerQtyPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDealerTGTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDealerSalesAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDealerValPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtB2BTGTQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtB2BSalesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtB2BQtyPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtB2BTGTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtB2BSalesAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtB2BValPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEStoreTGTQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEStoreSalesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txteStoreQtyPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txteStoreTGTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txttxteStoreSalesAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txteStoreValPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalTGTQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalSalesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalTGTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalSalesAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSalesPerson = new System.Windows.Forms.ComboBox();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.dtWeek = new System.Windows.Forms.DateTimePicker();
            this.lblYear = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWeek = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMAGWeekTarget = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTGT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTGT
            // 
            this.dgvTGT.AllowUserToAddRows = false;
            this.dgvTGT.AllowUserToDeleteRows = false;
            this.dgvTGT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTGT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtMAG,
            this.txtRetailTGT,
            this.txtRtlSalesQty,
            this.txtRTLQtyPercentage,
            this.txtRetailTGTAmt,
            this.txtRetailSalesAmt,
            this.txtRTLValPercentage,
            this.txtDealerTGTQty,
            this.txtDealerSalesQty,
            this.txtDealerQtyPercentage,
            this.txtDealerTGTAmt,
            this.txtDealerSalesAmt,
            this.txtDealerValPercentage,
            this.txtB2BTGTQty,
            this.txtB2BSalesQty,
            this.txtB2BQtyPercentage,
            this.txtB2BTGTAmt,
            this.txtB2BSalesAmt,
            this.txtB2BValPercentage,
            this.txtEStoreTGTQty,
            this.txtEStoreSalesQty,
            this.txteStoreQtyPercentage,
            this.txteStoreTGTAmt,
            this.txttxteStoreSalesAmt,
            this.txteStoreValPercentage,
            this.txtTotalTGTQty,
            this.txtTotalSalesQty,
            this.txtTotalTGTAmt,
            this.txtTotalSalesAmt});
            this.dgvTGT.Location = new System.Drawing.Point(12, 72);
            this.dgvTGT.Name = "dgvTGT";
            this.dgvTGT.ReadOnly = true;
            this.dgvTGT.Size = new System.Drawing.Size(906, 395);
            this.dgvTGT.TabIndex = 13;
            // 
            // txtMAG
            // 
            this.txtMAG.Frozen = true;
            this.txtMAG.HeaderText = "MAG";
            this.txtMAG.Name = "txtMAG";
            this.txtMAG.ReadOnly = true;
            this.txtMAG.Width = 60;
            // 
            // txtRetailTGT
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.txtRetailTGT.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtRetailTGT.HeaderText = "Retail TGT Qty";
            this.txtRetailTGT.Name = "txtRetailTGT";
            this.txtRetailTGT.ReadOnly = true;
            this.txtRetailTGT.Width = 45;
            // 
            // txtRtlSalesQty
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRtlSalesQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtRtlSalesQty.HeaderText = "Retail Sales Qty";
            this.txtRtlSalesQty.Name = "txtRtlSalesQty";
            this.txtRtlSalesQty.ReadOnly = true;
            this.txtRtlSalesQty.Width = 45;
            // 
            // txtRTLQtyPercentage
            // 
            this.txtRTLQtyPercentage.HeaderText = "(%)";
            this.txtRTLQtyPercentage.Name = "txtRTLQtyPercentage";
            this.txtRTLQtyPercentage.ReadOnly = true;
            this.txtRTLQtyPercentage.Width = 40;
            // 
            // txtRetailTGTAmt
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRetailTGTAmt.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtRetailTGTAmt.HeaderText = "Retail TGT Amt";
            this.txtRetailTGTAmt.Name = "txtRetailTGTAmt";
            this.txtRetailTGTAmt.ReadOnly = true;
            this.txtRetailTGTAmt.Width = 60;
            // 
            // txtRetailSalesAmt
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRetailSalesAmt.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtRetailSalesAmt.HeaderText = "Retail Sales Amt";
            this.txtRetailSalesAmt.Name = "txtRetailSalesAmt";
            this.txtRetailSalesAmt.ReadOnly = true;
            this.txtRetailSalesAmt.Width = 60;
            // 
            // txtRTLValPercentage
            // 
            this.txtRTLValPercentage.HeaderText = "(%)";
            this.txtRTLValPercentage.Name = "txtRTLValPercentage";
            this.txtRTLValPercentage.ReadOnly = true;
            this.txtRTLValPercentage.Width = 40;
            // 
            // txtDealerTGTQty
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDealerTGTQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtDealerTGTQty.HeaderText = "Dealer TGT Qty";
            this.txtDealerTGTQty.Name = "txtDealerTGTQty";
            this.txtDealerTGTQty.ReadOnly = true;
            this.txtDealerTGTQty.Width = 45;
            // 
            // txtDealerSalesQty
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDealerSalesQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtDealerSalesQty.HeaderText = "Dealer Sales Qty";
            this.txtDealerSalesQty.Name = "txtDealerSalesQty";
            this.txtDealerSalesQty.ReadOnly = true;
            this.txtDealerSalesQty.Width = 45;
            // 
            // txtDealerQtyPercentage
            // 
            this.txtDealerQtyPercentage.HeaderText = "(%)";
            this.txtDealerQtyPercentage.Name = "txtDealerQtyPercentage";
            this.txtDealerQtyPercentage.ReadOnly = true;
            this.txtDealerQtyPercentage.Width = 40;
            // 
            // txtDealerTGTAmt
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDealerTGTAmt.DefaultCellStyle = dataGridViewCellStyle7;
            this.txtDealerTGTAmt.HeaderText = "Dealer TGT Amt";
            this.txtDealerTGTAmt.Name = "txtDealerTGTAmt";
            this.txtDealerTGTAmt.ReadOnly = true;
            this.txtDealerTGTAmt.Width = 60;
            // 
            // txtDealerSalesAmt
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtDealerSalesAmt.DefaultCellStyle = dataGridViewCellStyle8;
            this.txtDealerSalesAmt.HeaderText = "Dealer Sales Amt";
            this.txtDealerSalesAmt.Name = "txtDealerSalesAmt";
            this.txtDealerSalesAmt.ReadOnly = true;
            this.txtDealerSalesAmt.Width = 60;
            // 
            // txtDealerValPercentage
            // 
            this.txtDealerValPercentage.HeaderText = "(%)";
            this.txtDealerValPercentage.Name = "txtDealerValPercentage";
            this.txtDealerValPercentage.ReadOnly = true;
            this.txtDealerValPercentage.Width = 40;
            // 
            // txtB2BTGTQty
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtB2BTGTQty.DefaultCellStyle = dataGridViewCellStyle9;
            this.txtB2BTGTQty.HeaderText = "B2B TGT Qty";
            this.txtB2BTGTQty.Name = "txtB2BTGTQty";
            this.txtB2BTGTQty.ReadOnly = true;
            this.txtB2BTGTQty.Width = 45;
            // 
            // txtB2BSalesQty
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtB2BSalesQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.txtB2BSalesQty.HeaderText = "B2B Sales Qty";
            this.txtB2BSalesQty.Name = "txtB2BSalesQty";
            this.txtB2BSalesQty.ReadOnly = true;
            this.txtB2BSalesQty.Width = 45;
            // 
            // txtB2BQtyPercentage
            // 
            this.txtB2BQtyPercentage.HeaderText = "(%)";
            this.txtB2BQtyPercentage.Name = "txtB2BQtyPercentage";
            this.txtB2BQtyPercentage.ReadOnly = true;
            this.txtB2BQtyPercentage.Width = 40;
            // 
            // txtB2BTGTAmt
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtB2BTGTAmt.DefaultCellStyle = dataGridViewCellStyle11;
            this.txtB2BTGTAmt.HeaderText = "B2B TGT Amt";
            this.txtB2BTGTAmt.Name = "txtB2BTGTAmt";
            this.txtB2BTGTAmt.ReadOnly = true;
            this.txtB2BTGTAmt.Width = 60;
            // 
            // txtB2BSalesAmt
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtB2BSalesAmt.DefaultCellStyle = dataGridViewCellStyle12;
            this.txtB2BSalesAmt.HeaderText = "B2B Sales Amt";
            this.txtB2BSalesAmt.Name = "txtB2BSalesAmt";
            this.txtB2BSalesAmt.ReadOnly = true;
            this.txtB2BSalesAmt.Width = 60;
            // 
            // txtB2BValPercentage
            // 
            this.txtB2BValPercentage.HeaderText = "(%)";
            this.txtB2BValPercentage.Name = "txtB2BValPercentage";
            this.txtB2BValPercentage.ReadOnly = true;
            this.txtB2BValPercentage.Width = 40;
            // 
            // txtEStoreTGTQty
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEStoreTGTQty.DefaultCellStyle = dataGridViewCellStyle13;
            this.txtEStoreTGTQty.HeaderText = "e-Store TGT Qty";
            this.txtEStoreTGTQty.Name = "txtEStoreTGTQty";
            this.txtEStoreTGTQty.ReadOnly = true;
            this.txtEStoreTGTQty.Width = 45;
            // 
            // txtEStoreSalesQty
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEStoreSalesQty.DefaultCellStyle = dataGridViewCellStyle14;
            this.txtEStoreSalesQty.HeaderText = "e-Store Sales Qty";
            this.txtEStoreSalesQty.Name = "txtEStoreSalesQty";
            this.txtEStoreSalesQty.ReadOnly = true;
            this.txtEStoreSalesQty.Width = 45;
            // 
            // txteStoreQtyPercentage
            // 
            this.txteStoreQtyPercentage.HeaderText = "(%)";
            this.txteStoreQtyPercentage.Name = "txteStoreQtyPercentage";
            this.txteStoreQtyPercentage.ReadOnly = true;
            this.txteStoreQtyPercentage.Width = 40;
            // 
            // txteStoreTGTAmt
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txteStoreTGTAmt.DefaultCellStyle = dataGridViewCellStyle15;
            this.txteStoreTGTAmt.HeaderText = "e-Store TGT Amt";
            this.txteStoreTGTAmt.Name = "txteStoreTGTAmt";
            this.txteStoreTGTAmt.ReadOnly = true;
            this.txteStoreTGTAmt.Width = 60;
            // 
            // txttxteStoreSalesAmt
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txttxteStoreSalesAmt.DefaultCellStyle = dataGridViewCellStyle16;
            this.txttxteStoreSalesAmt.HeaderText = "e-Store Sales Amt";
            this.txttxteStoreSalesAmt.Name = "txttxteStoreSalesAmt";
            this.txttxteStoreSalesAmt.ReadOnly = true;
            this.txttxteStoreSalesAmt.Width = 60;
            // 
            // txteStoreValPercentage
            // 
            this.txteStoreValPercentage.HeaderText = "(%)";
            this.txteStoreValPercentage.Name = "txteStoreValPercentage";
            this.txteStoreValPercentage.ReadOnly = true;
            this.txteStoreValPercentage.Width = 40;
            // 
            // txtTotalTGTQty
            // 
            this.txtTotalTGTQty.HeaderText = "Total TGT Qty";
            this.txtTotalTGTQty.Name = "txtTotalTGTQty";
            this.txtTotalTGTQty.ReadOnly = true;
            this.txtTotalTGTQty.Width = 50;
            // 
            // txtTotalSalesQty
            // 
            this.txtTotalSalesQty.HeaderText = "Total Sales Qty";
            this.txtTotalSalesQty.Name = "txtTotalSalesQty";
            this.txtTotalSalesQty.ReadOnly = true;
            this.txtTotalSalesQty.Width = 50;
            // 
            // txtTotalTGTAmt
            // 
            this.txtTotalTGTAmt.HeaderText = "Total TGT Amt";
            this.txtTotalTGTAmt.Name = "txtTotalTGTAmt";
            this.txtTotalTGTAmt.ReadOnly = true;
            this.txtTotalTGTAmt.Width = 60;
            // 
            // txtTotalSalesAmt
            // 
            this.txtTotalSalesAmt.HeaderText = "Total Sales Amt";
            this.txtTotalSalesAmt.Name = "txtTotalSalesAmt";
            this.txtTotalSalesAmt.ReadOnly = true;
            this.txtTotalSalesAmt.Width = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(427, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "PG:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(606, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "MAG:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Sales Person:";
            // 
            // cmbSalesPerson
            // 
            this.cmbSalesPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesPerson.FormattingEnabled = true;
            this.cmbSalesPerson.Location = new System.Drawing.Point(98, 41);
            this.cmbSalesPerson.Name = "cmbSalesPerson";
            this.cmbSalesPerson.Size = new System.Drawing.Size(298, 23);
            this.cmbSalesPerson.TabIndex = 9;
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(463, 10);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(136, 23);
            this.cmbPG.TabIndex = 5;
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(652, 10);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(136, 23);
            this.cmbMAG.TabIndex = 7;
            // 
            // dtWeek
            // 
            this.dtWeek.CustomFormat = "MMM-yyyy";
            this.dtWeek.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWeek.Location = new System.Drawing.Point(98, 11);
            this.dtWeek.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtWeek.Name = "dtWeek";
            this.dtWeek.ShowUpDown = true;
            this.dtWeek.Size = new System.Drawing.Size(132, 21);
            this.dtWeek.TabIndex = 1;
            this.dtWeek.Value = new System.DateTime(2016, 2, 11, 0, 0, 0, 0);
            this.dtWeek.ValueChanged += new System.EventHandler(this.dtWeek_ValueChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(22, 13);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(70, 15);
            this.lblYear.TabIndex = 0;
            this.lblYear.Text = "Month/Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(247, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Week";
            // 
            // cmbWeek
            // 
            this.cmbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeek.FormattingEnabled = true;
            this.cmbWeek.Location = new System.Drawing.Point(291, 12);
            this.cmbWeek.Name = "cmbWeek";
            this.cmbWeek.Size = new System.Drawing.Size(105, 23);
            this.cmbWeek.TabIndex = 3;
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(463, 41);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(325, 23);
            this.cmbBrand.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(408, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Brand:";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(794, 39);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 27);
            this.btnGetData.TabIndex = 12;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(925, 441);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMAGWeekTarget
            // 
            this.btnMAGWeekTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMAGWeekTarget.Location = new System.Drawing.Point(925, 72);
            this.btnMAGWeekTarget.Name = "btnMAGWeekTarget";
            this.btnMAGWeekTarget.Size = new System.Drawing.Size(87, 42);
            this.btnMAGWeekTarget.TabIndex = 14;
            this.btnMAGWeekTarget.Text = "MAG Week Target";
            this.btnMAGWeekTarget.UseVisualStyleBackColor = true;
            this.btnMAGWeekTarget.Click += new System.EventHandler(this.btnMAGWeekTarget_Click);
            // 
            // frmTargetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 481);
            this.Controls.Add(this.btnMAGWeekTarget);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWeek);
            this.Controls.Add(this.dtWeek);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSalesPerson);
            this.Controls.Add(this.cmbPG);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.dgvTGT);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTargetView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTargetView";
            this.Load += new System.EventHandler(this.frmTargetView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTGT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTGT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSalesPerson;
        private System.Windows.Forms.ComboBox cmbPG;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.DateTimePicker dtWeek;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWeek;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMAGWeekTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalSalesAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalTGTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalSalesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalTGTQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txteStoreValPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txttxteStoreSalesAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txteStoreTGTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txteStoreQtyPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEStoreSalesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEStoreTGTQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtB2BValPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtB2BSalesAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtB2BTGTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtB2BQtyPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtB2BSalesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtB2BTGTQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDealerValPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDealerSalesAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDealerTGTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDealerQtyPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDealerSalesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDealerTGTQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRTLValPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRetailSalesAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRetailTGTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRTLQtyPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRtlSalesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRetailTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMAG;
    }
}