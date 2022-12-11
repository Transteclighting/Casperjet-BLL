namespace CJ.Win.Inventory
{
    partial class frmStockAdjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockAdjustment));
            this.label9 = new System.Windows.Forms.Label();
            this.cmbAdjustmentType = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbToChannel = new System.Windows.Forms.ComboBox();
            this.dtTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPORef = new System.Windows.Forms.ComboBox();
            this.cmbFromWarehouse = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbToWarehouse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFromChannel = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.txtTransationRef = new System.Windows.Forms.TextBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(355, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Adjustment Type";
            // 
            // cmbAdjustmentType
            // 
            this.cmbAdjustmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdjustmentType.FormattingEnabled = true;
            this.cmbAdjustmentType.Items.AddRange(new object[] {
            "Increase",
            "Decrease"});
            this.cmbAdjustmentType.Location = new System.Drawing.Point(445, 102);
            this.cmbAdjustmentType.Name = "cmbAdjustmentType";
            this.cmbAdjustmentType.Size = new System.Drawing.Size(240, 21);
            this.cmbAdjustmentType.TabIndex = 15;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(619, 560);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(704, 560);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Channel";
            // 
            // cmbToChannel
            // 
            this.cmbToChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToChannel.FormattingEnabled = true;
            this.cmbToChannel.Location = new System.Drawing.Point(108, 73);
            this.cmbToChannel.Name = "cmbToChannel";
            this.cmbToChannel.Size = new System.Drawing.Size(241, 21);
            this.cmbToChannel.TabIndex = 9;
            // 
            // dtTransactionDate
            // 
            this.dtTransactionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtTransactionDate.Enabled = false;
            this.dtTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionDate.Location = new System.Drawing.Point(108, 47);
            this.dtTransactionDate.Name = "dtTransactionDate";
            this.dtTransactionDate.Size = new System.Drawing.Size(122, 20);
            this.dtTransactionDate.TabIndex = 5;
            this.dtTransactionDate.Tag = "M1.21";
            // 
            // cmbPORef
            // 
            this.cmbPORef.FormattingEnabled = true;
            this.cmbPORef.Location = new System.Drawing.Point(445, 12);
            this.cmbPORef.Name = "cmbPORef";
            this.cmbPORef.Size = new System.Drawing.Size(121, 21);
            this.cmbPORef.TabIndex = 3;
            this.cmbPORef.Visible = false;
            // 
            // cmbFromWarehouse
            // 
            this.cmbFromWarehouse.FormattingEnabled = true;
            this.cmbFromWarehouse.Location = new System.Drawing.Point(445, 43);
            this.cmbFromWarehouse.Name = "cmbFromWarehouse";
            this.cmbFromWarehouse.Size = new System.Drawing.Size(240, 21);
            this.cmbFromWarehouse.TabIndex = 7;
            this.cmbFromWarehouse.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Warehouse";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "PO Ref #";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "From Channel";
            this.label5.Visible = false;
            // 
            // txtQuantity
            // 
            this.txtQuantity.HeaderText = "Quantity";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 75;
            // 
            // cmbToWarehouse
            // 
            this.cmbToWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToWarehouse.FormattingEnabled = true;
            this.cmbToWarehouse.Location = new System.Drawing.Point(108, 103);
            this.cmbToWarehouse.Name = "cmbToWarehouse";
            this.cmbToWarehouse.Size = new System.Drawing.Size(241, 21);
            this.cmbToWarehouse.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "From Warehouse";
            this.label4.Visible = false;
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.HeaderText = "Unit Cost Price";
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.ReadOnly = true;
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Text = "...";
            this.btnFindProduct.Width = 35;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Width = 230;
            // 
            // CurrentStock
            // 
            this.CurrentStock.HeaderText = "Current Stock";
            this.CurrentStock.Name = "CurrentStock";
            // 
            // TotalValue
            // 
            this.TotalValue.HeaderText = "Total Value";
            this.TotalValue.Name = "TotalValue";
            this.TotalValue.Width = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Transaction Date";
            // 
            // cmbFromChannel
            // 
            this.cmbFromChannel.FormattingEnabled = true;
            this.cmbFromChannel.Location = new System.Drawing.Point(445, 75);
            this.cmbFromChannel.Name = "cmbFromChannel";
            this.cmbFromChannel.Size = new System.Drawing.Size(240, 21);
            this.cmbFromChannel.TabIndex = 11;
            this.cmbFromChannel.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 560);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(108, 129);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(577, 20);
            this.txtRemarks.TabIndex = 17;
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(13, 21);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(93, 13);
            this.lblTransactionRefNo.TabIndex = 0;
            this.lblTransactionRefNo.Text = "Transaction Ref #";
            // 
            // txtTransationRef
            // 
            this.txtTransationRef.Location = new System.Drawing.Point(108, 21);
            this.txtTransationRef.Name = "txtTransationRef";
            this.txtTransationRef.Size = new System.Drawing.Size(122, 20);
            this.txtTransationRef.TabIndex = 1;
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.CurrentStock,
            this.txtCostPrice,
            this.txtQuantity,
            this.TotalValue});
            this.dgvLineItem.Location = new System.Drawing.Point(12, 166);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(767, 378);
            this.dgvLineItem.TabIndex = 18;
            // 
            // frmStockAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 597);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbAdjustmentType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbToChannel);
            this.Controls.Add(this.dtTransactionDate);
            this.Controls.Add(this.cmbPORef);
            this.Controls.Add(this.cmbFromWarehouse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbToWarehouse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFromChannel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblTransactionRefNo);
            this.Controls.Add(this.txtTransationRef);
            this.Controls.Add(this.dgvLineItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStockAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Adjustment";
            this.Load += new System.EventHandler(this.frmStockAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAdjustmentType;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbToChannel;
        private System.Windows.Forms.DateTimePicker dtTransactionDate;
        private System.Windows.Forms.ComboBox cmbPORef;
        private System.Windows.Forms.ComboBox cmbFromWarehouse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.ComboBox cmbToWarehouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFromChannel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.TextBox txtTransationRef;
        private System.Windows.Forms.DataGridView dgvLineItem;
    }
}