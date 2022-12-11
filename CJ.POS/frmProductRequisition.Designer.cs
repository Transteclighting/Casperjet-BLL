namespace CJ.POS
{
    partial class frmProductRequisition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductRequisition));
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHOStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequisitionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHOStock = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblLastUpdateDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdateHOStock = new System.Windows.Forms.Button();
            this.lblcmbDMSOrder = new System.Windows.Forms.Label();
            this.cmbDMSOrder = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.colUnitPrice,
            this.ToWH,
            this.FromWH,
            this.colHOStock,
            this.colCurrentStock,
            this.RequisitionQty,
            this.CValue,
            this.ProductID,
            this.btnHOStock});
            this.dgvLineItem.Location = new System.Drawing.Point(12, 43);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(1059, 312);
            this.dgvLineItem.TabIndex = 3;
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLineItem_RowsRemoved);
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 110;
            // 
            // btnFindProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            this.btnFindProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Text = "...";
            this.btnFindProduct.Width = 35;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 200;
            // 
            // colUnitPrice
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // ToWH
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.ToWH.DefaultCellStyle = dataGridViewCellStyle4;
            this.ToWH.HeaderText = "YTD Sale Qty";
            this.ToWH.Name = "ToWH";
            this.ToWH.ReadOnly = true;
            this.ToWH.Width = 108;
            // 
            // FromWH
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.FromWH.DefaultCellStyle = dataGridViewCellStyle5;
            this.FromWH.HeaderText = "MTD Sale Qty";
            this.FromWH.Name = "FromWH";
            this.FromWH.ReadOnly = true;
            this.FromWH.Width = 108;
            // 
            // colHOStock
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.colHOStock.DefaultCellStyle = dataGridViewCellStyle6;
            this.colHOStock.HeaderText = "HO Stock";
            this.colHOStock.Name = "colHOStock";
            this.colHOStock.ReadOnly = true;
            this.colHOStock.Width = 85;
            // 
            // colCurrentStock
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            this.colCurrentStock.DefaultCellStyle = dataGridViewCellStyle7;
            this.colCurrentStock.HeaderText = "Own Stock";
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.ReadOnly = true;
            this.colCurrentStock.Width = 90;
            // 
            // RequisitionQty
            // 
            this.RequisitionQty.HeaderText = "Requ Qty";
            this.RequisitionQty.Name = "RequisitionQty";
            this.RequisitionQty.Width = 85;
            // 
            // CValue
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            this.CValue.DefaultCellStyle = dataGridViewCellStyle8;
            this.CValue.HeaderText = "Total Value";
            this.CValue.Name = "CValue";
            this.CValue.Width = 95;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // btnHOStock
            // 
            this.btnHOStock.HeaderText = "HO Stock";
            this.btnHOStock.Name = "btnHOStock";
            this.btnHOStock.Visible = false;
            this.btnHOStock.Width = 40;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(981, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(885, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(72, 390);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(999, 21);
            this.txtRemarks.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Remarks";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(892, 363);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(82, 21);
            this.txtTotalQty.TabIndex = 4;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(977, 363);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(94, 21);
            this.txtTotalAmount.TabIndex = 5;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLastUpdateDate
            // 
            this.lblLastUpdateDate.AutoSize = true;
            this.lblLastUpdateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdateDate.Location = new System.Drawing.Point(674, 12);
            this.lblLastUpdateDate.Name = "lblLastUpdateDate";
            this.lblLastUpdateDate.Size = new System.Drawing.Size(14, 15);
            this.lblLastUpdateDate.TabIndex = 1;
            this.lblLastUpdateDate.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(538, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "HO Stock Last Update:";
            // 
            // btnUpdateHOStock
            // 
            this.btnUpdateHOStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateHOStock.Location = new System.Drawing.Point(962, 4);
            this.btnUpdateHOStock.Name = "btnUpdateHOStock";
            this.btnUpdateHOStock.Size = new System.Drawing.Size(109, 30);
            this.btnUpdateHOStock.TabIndex = 2;
            this.btnUpdateHOStock.Text = "HO Stock Update";
            this.btnUpdateHOStock.UseVisualStyleBackColor = true;
            this.btnUpdateHOStock.Click += new System.EventHandler(this.btnUpdateHOStock_Click);
            // 
            // lblcmbDMSOrder
            // 
            this.lblcmbDMSOrder.AutoSize = true;
            this.lblcmbDMSOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcmbDMSOrder.Location = new System.Drawing.Point(19, 12);
            this.lblcmbDMSOrder.Name = "lblcmbDMSOrder";
            this.lblcmbDMSOrder.Size = new System.Drawing.Size(94, 15);
            this.lblcmbDMSOrder.TabIndex = 10;
            this.lblcmbDMSOrder.Text = "Ref. DMS Order";
            this.lblcmbDMSOrder.Visible = false;
            // 
            // cmbDMSOrder
            // 
            this.cmbDMSOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDMSOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDMSOrder.FormattingEnabled = true;
            this.cmbDMSOrder.Location = new System.Drawing.Point(116, 9);
            this.cmbDMSOrder.Name = "cmbDMSOrder";
            this.cmbDMSOrder.Size = new System.Drawing.Size(346, 23);
            this.cmbDMSOrder.TabIndex = 11;
            this.cmbDMSOrder.Visible = false;
            this.cmbDMSOrder.SelectedIndexChanged += new System.EventHandler(this.cmbDMSOrder_SelectedIndexChanged);
            // 
            // frmProductRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 451);
            this.Controls.Add(this.lblcmbDMSOrder);
            this.Controls.Add(this.cmbDMSOrder);
            this.Controls.Add(this.btnUpdateHOStock);
            this.Controls.Add(this.lblLastUpdateDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvLineItem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Requisition";
            this.Load += new System.EventHandler(this.frmProductRequisition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblLastUpdateDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateHOStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHOStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewButtonColumn btnHOStock;
        private System.Windows.Forms.Label lblcmbDMSOrder;
        private System.Windows.Forms.ComboBox cmbDMSOrder;
    }
}