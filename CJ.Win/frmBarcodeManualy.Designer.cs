namespace CJ.Win
{
    partial class frmBarcodeManualy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btGenaretBarcode = new System.Windows.Forms.Button();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.btClose = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTimeControl1 = new CJ.Win.Control.GridTimeControl();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInvoiceDate = new RSMS.BaseItems.DateTimePickerColumn();
            this.txtBENo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtBEDate = new RSMS.BaseItems.DateTimePickerColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btGenaretBarcode
            // 
            this.btGenaretBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGenaretBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btGenaretBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btGenaretBarcode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGenaretBarcode.Location = new System.Drawing.Point(879, 26);
            this.btGenaretBarcode.Name = "btGenaretBarcode";
            this.btGenaretBarcode.Size = new System.Drawing.Size(142, 39);
            this.btGenaretBarcode.TabIndex = 7;
            this.btGenaretBarcode.Text = "Generate Barcode";
            this.btGenaretBarcode.UseVisualStyleBackColor = false;
            this.btGenaretBarcode.Click += new System.EventHandler(this.btGenaretBarcode_Click);
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.ProductQty,
            this.ColProductId,
            this.txtInvoiceNo,
            this.txtInvoiceDate,
            this.txtBENo,
            this.dtBEDate});
            this.dgvLineItem.Location = new System.Drawing.Point(7, 26);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(866, 391);
            this.dgvLineItem.TabIndex = 11;
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick_1);
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged_1);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(879, 71);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(142, 39);
            this.btClose.TabIndex = 12;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ProductId";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Invoice No";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "BE/VAT Challan#";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // gridTimeControl1
            // 
            this.gridTimeControl1.HeaderText = "InvoiceDate";
            this.gridTimeControl1.Name = "gridTimeControl1";
            this.gridTimeControl1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTimeControl1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            // 
            // btnFindProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            this.btnFindProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnFindProduct.Frozen = true;
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Text = "...";
            this.btnFindProduct.Width = 35;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.HeaderText = "Product Name";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 250;
            // 
            // ProductQty
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.ProductQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProductQty.HeaderText = "Quantity";
            this.ProductQty.Name = "ProductQty";
            // 
            // ColProductId
            // 
            this.ColProductId.HeaderText = "ProductId";
            this.ColProductId.Name = "ColProductId";
            this.ColProductId.ReadOnly = true;
            this.ColProductId.Visible = false;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.HeaderText = "Invoice No";
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.HeaderText = "InvoiceDate";
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtInvoiceDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtBENo
            // 
            this.txtBENo.HeaderText = "BE/VAT Challan#";
            this.txtBENo.Name = "txtBENo";
            // 
            // dtBEDate
            // 
            this.dtBEDate.HeaderText = "BE/Vat Challan Date";
            this.dtBEDate.Name = "dtBEDate";
            this.dtBEDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtBEDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmBarcodeManualy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 429);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.btGenaretBarcode);
            this.Name = "frmBarcodeManualy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Manualy Product Barcode";
            this.Load += new System.EventHandler(this.frmManualBarcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btGenaretBarcode;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private CJ.Win.Control.GridTimeControl gridTimeControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInvoiceNo;
        private RSMS.BaseItems.DateTimePickerColumn txtInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBENo;
        private RSMS.BaseItems.DateTimePickerColumn dtBEDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}