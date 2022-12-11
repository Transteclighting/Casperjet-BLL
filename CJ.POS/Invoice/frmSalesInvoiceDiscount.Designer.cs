namespace CJ.POS.Invoice
{
    partial class frmSalesInvoiceDiscount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesInvoiceDiscount));
            this.dgvSalesInvoiceDiscount = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDiscountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInstrumentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFreeProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFreeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIsBarcodeItemFreeProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChargeType = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChargeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalCharge = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvScratchCardQty = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBarcode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGetBarcode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtScratchCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtScratchCardDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIsBarcodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesInvoiceDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChargeType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScratchCardQty)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalesInvoiceDiscount
            // 
            this.dgvSalesInvoiceDiscount.AllowUserToAddRows = false;
            this.dgvSalesInvoiceDiscount.AllowUserToDeleteRows = false;
            this.dgvSalesInvoiceDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesInvoiceDiscount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtID,
            this.txtDiscountType,
            this.txtAmount,
            this.txtInstrumentNo,
            this.txtDescription,
            this.colProductID,
            this.colDiscountType,
            this.txtFreeProductID,
            this.txtFreeQty,
            this.txtProductSerial,
            this.txtIsBarcodeItemFreeProduct});
            this.dgvSalesInvoiceDiscount.Location = new System.Drawing.Point(7, 22);
            this.dgvSalesInvoiceDiscount.Name = "dgvSalesInvoiceDiscount";
            this.dgvSalesInvoiceDiscount.Size = new System.Drawing.Size(415, 252);
            this.dgvSalesInvoiceDiscount.TabIndex = 0;
            this.dgvSalesInvoiceDiscount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesInvoiceDiscount_CellContentClick);
            this.dgvSalesInvoiceDiscount.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesInvoiceDiscount_CellValueChanged);
            // 
            // txtID
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtID.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.Visible = false;
            this.txtID.Width = 40;
            // 
            // txtDiscountType
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDiscountType.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtDiscountType.HeaderText = "Discount Type";
            this.txtDiscountType.Name = "txtDiscountType";
            this.txtDiscountType.ReadOnly = true;
            this.txtDiscountType.Width = 120;
            // 
            // txtAmount
            // 
            this.txtAmount.HeaderText = "Amount";
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Width = 60;
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.HeaderText = "Instrument #";
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            // 
            // txtDescription
            // 
            this.txtDescription.HeaderText = "Description";
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Width = 120;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // colDiscountType
            // 
            this.colDiscountType.HeaderText = "Type";
            this.colDiscountType.Name = "colDiscountType";
            this.colDiscountType.ReadOnly = true;
            this.colDiscountType.Visible = false;
            // 
            // txtFreeProductID
            // 
            this.txtFreeProductID.HeaderText = "FreeProductID";
            this.txtFreeProductID.Name = "txtFreeProductID";
            this.txtFreeProductID.ReadOnly = true;
            this.txtFreeProductID.Visible = false;
            // 
            // txtFreeQty
            // 
            this.txtFreeQty.HeaderText = "FreeQty";
            this.txtFreeQty.Name = "txtFreeQty";
            this.txtFreeQty.ReadOnly = true;
            this.txtFreeQty.Visible = false;
            // 
            // txtProductSerial
            // 
            this.txtProductSerial.HeaderText = "ProductSerial";
            this.txtProductSerial.Name = "txtProductSerial";
            this.txtProductSerial.ReadOnly = true;
            this.txtProductSerial.Visible = false;
            // 
            // txtIsBarcodeItemFreeProduct
            // 
            this.txtIsBarcodeItemFreeProduct.HeaderText = "txtIsBarcodeItemFreeProduct";
            this.txtIsBarcodeItemFreeProduct.Name = "txtIsBarcodeItemFreeProduct";
            this.txtIsBarcodeItemFreeProduct.ReadOnly = true;
            this.txtIsBarcodeItemFreeProduct.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOk.Location = new System.Drawing.Point(700, 572);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 27);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Set";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(795, 572);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalAmount.Location = new System.Drawing.Point(104, 331);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(84, 21);
            this.txtTotalAmount.TabIndex = 5;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(10, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Discount:";
            // 
            // dgvChargeType
            // 
            this.dgvChargeType.AllowUserToAddRows = false;
            this.dgvChargeType.AllowUserToDeleteRows = false;
            this.dgvChargeType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChargeType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.colChargeType});
            this.dgvChargeType.Location = new System.Drawing.Point(7, 20);
            this.dgvChargeType.Name = "dgvChargeType";
            this.dgvChargeType.Size = new System.Drawing.Size(415, 254);
            this.dgvChargeType.TabIndex = 0;
            this.dgvChargeType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChargeType_CellContentClick);
            this.dgvChargeType.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChargeType_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Charge Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Instrument #";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // colChargeType
            // 
            this.colChargeType.HeaderText = "Charge Type";
            this.colChargeType.Name = "colChargeType";
            this.colChargeType.ReadOnly = true;
            this.colChargeType.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(449, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Charge:";
            // 
            // txtTotalCharge
            // 
            this.txtTotalCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTotalCharge.Location = new System.Drawing.Point(535, 331);
            this.txtTotalCharge.Name = "txtTotalCharge";
            this.txtTotalCharge.Size = new System.Drawing.Size(84, 21);
            this.txtTotalCharge.TabIndex = 7;
            this.txtTotalCharge.Text = "0.00";
            this.txtTotalCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.Color.Navy;
            this.lblProductName.Location = new System.Drawing.Point(84, 12);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(15, 15);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(18, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Product:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSalesInvoiceDiscount);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 287);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Discounts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvChargeType);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox2.Location = new System.Drawing.Point(453, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 287);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Charges";
            // 
            // dgvScratchCardQty
            // 
            this.dgvScratchCardQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScratchCardQty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.btnBarcode,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.txtBarcode,
            this.btnGetBarcode,
            this.txtScratchCard,
            this.txtScratchCardDescription,
            this.txtProductID,
            this.txtIsBarcodeItem});
            this.dgvScratchCardQty.Enabled = false;
            this.dgvScratchCardQty.Location = new System.Drawing.Point(7, 23);
            this.dgvScratchCardQty.Name = "dgvScratchCardQty";
            this.dgvScratchCardQty.Size = new System.Drawing.Size(854, 167);
            this.dgvScratchCardQty.TabIndex = 0;
            this.dgvScratchCardQty.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScratchCardQty_CellContentClick);
            this.dgvScratchCardQty.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScratchCardQty_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Code";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // btnBarcode
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBarcode.DefaultCellStyle = dataGridViewCellStyle5;
            this.btnBarcode.HeaderText = "...";
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Width = 30;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn8.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 220;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn10.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // txtBarcode
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBarcode.DefaultCellStyle = dataGridViewCellStyle8;
            this.txtBarcode.HeaderText = "Bracode";
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Width = 140;
            // 
            // btnGetBarcode
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetBarcode.DefaultCellStyle = dataGridViewCellStyle9;
            this.btnGetBarcode.HeaderText = "...";
            this.btnGetBarcode.Name = "btnGetBarcode";
            this.btnGetBarcode.Width = 30;
            // 
            // txtScratchCard
            // 
            this.txtScratchCard.HeaderText = "Card#";
            this.txtScratchCard.Name = "txtScratchCard";
            // 
            // txtScratchCardDescription
            // 
            this.txtScratchCardDescription.HeaderText = "Description";
            this.txtScratchCardDescription.Name = "txtScratchCardDescription";
            this.txtScratchCardDescription.Width = 150;
            // 
            // txtProductID
            // 
            this.txtProductID.HeaderText = "Product ID";
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Visible = false;
            // 
            // txtIsBarcodeItem
            // 
            this.txtIsBarcodeItem.HeaderText = "IsBarcodeItem";
            this.txtIsBarcodeItem.Name = "txtIsBarcodeItem";
            this.txtIsBarcodeItem.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvScratchCardQty);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(14, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(868, 204);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scratch Card Product";
            // 
            // frmSalesInvoiceDiscount
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 606);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalCharge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesInvoiceDiscount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Invoice Discount";
            this.Load += new System.EventHandler(this.frmSalesInvoiceDiscount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesInvoiceDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChargeType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScratchCardQty)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesInvoiceDiscount;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChargeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalCharge;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChargeType;
        private System.Windows.Forms.DataGridView dgvScratchCardQty;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewButtonColumn btnBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBarcode;
        private System.Windows.Forms.DataGridViewButtonColumn btnGetBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtScratchCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtScratchCardDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIsBarcodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDiscountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInstrumentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFreeProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFreeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIsBarcodeItemFreeProduct;
    }
}