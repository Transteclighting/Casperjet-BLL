namespace CJ.Win.POS
{
    partial class frmStockRequisition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockRequisition));
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWarehouseParent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequisitionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtHOStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(777, 425);
            this.txtTotalQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(80, 23);
            this.txtTotalQty.TabIndex = 3;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(71, 453);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(896, 23);
            this.txtRemarks.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(765, 484);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 32);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(870, 484);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 32);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(857, 425);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(112, 23);
            this.txtTotalAmount.TabIndex = 4;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(121, 72);
            this.cmbOutlet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(281, 24);
            this.cmbOutlet.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Outlet:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Parent Warehouse:";
            // 
            // cmbWarehouseParent
            // 
            this.cmbWarehouseParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseParent.FormattingEnabled = true;
            this.cmbWarehouseParent.Location = new System.Drawing.Point(121, 12);
            this.cmbWarehouseParent.Name = "cmbWarehouseParent";
            this.cmbWarehouseParent.Size = new System.Drawing.Size(281, 24);
            this.cmbWarehouseParent.TabIndex = 11;
            this.cmbWarehouseParent.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouseParent_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Warehouse:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(121, 42);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(281, 24);
            this.cmbWarehouse.TabIndex = 13;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // CValue
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.CValue.DefaultCellStyle = dataGridViewCellStyle1;
            this.CValue.HeaderText = "Total Value";
            this.CValue.Name = "CValue";
            this.CValue.Width = 95;
            // 
            // RequisitionQty
            // 
            this.RequisitionQty.HeaderText = "Req Qty";
            this.RequisitionQty.Name = "RequisitionQty";
            this.RequisitionQty.Width = 70;
            // 
            // colCurrentStock
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.colCurrentStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCurrentStock.HeaderText = "Outlet Stock";
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.ReadOnly = true;
            this.colCurrentStock.Width = 70;
            // 
            // txtHOStock
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.txtHOStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtHOStock.HeaderText = "HO Stock";
            this.txtHOStock.Name = "txtHOStock";
            this.txtHOStock.ReadOnly = true;
            this.txtHOStock.Width = 70;
            // 
            // colUnitPrice
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            this.colUnitPrice.Width = 90;
            // 
            // FromWH
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.FromWH.DefaultCellStyle = dataGridViewCellStyle5;
            this.FromWH.HeaderText = "MTD Sale Qty";
            this.FromWH.Name = "FromWH";
            this.FromWH.ReadOnly = true;
            this.FromWH.Width = 90;
            // 
            // ToWH
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.ToWH.DefaultCellStyle = dataGridViewCellStyle6;
            this.ToWH.HeaderText = "YTD Sale Qty";
            this.ToWH.Name = "ToWH";
            this.ToWH.ReadOnly = true;
            this.ToWH.Width = 90;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle7;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 200;
            // 
            // btnFindProduct
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gray;
            this.btnFindProduct.DefaultCellStyle = dataGridViewCellStyle8;
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Text = "...";
            this.btnFindProduct.Width = 35;
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.ToWH,
            this.FromWH,
            this.colUnitPrice,
            this.txtHOStock,
            this.colCurrentStock,
            this.RequisitionQty,
            this.CValue,
            this.ProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(12, 104);
            this.dgvLineItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(957, 313);
            this.dgvLineItem.TabIndex = 2;
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLineItem_RowsRemoved);
            // 
            // frmStockRequisition
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 525);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbWarehouseParent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOutlet);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.txtTotalAmount);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmStockRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Requisition";
            this.Load += new System.EventHandler(this.frmProductRequisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbWarehouseParent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtHOStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridView dgvLineItem;
    }
}