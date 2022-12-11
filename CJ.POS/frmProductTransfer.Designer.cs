namespace CJ.POS
{
    partial class frmProductTransfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductTransfer));
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.lblToWH = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequisitionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBarcode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtIsBarcodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSupplyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVATType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVATApplicable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVATCP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLineItem
            // 
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
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.colCurrentStock,
            this.RequisitionQty,
            this.colBarcode,
            this.ProductID,
            this.btnBarcode,
            this.txtIsBarcodeItem,
            this.txtTP,
            this.txtNSP,
            this.txtRSP,
            this.txtVAT,
            this.txtSupplyType,
            this.txtVATType,
            this.txtVATApplicable,
            this.txtVATCP});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLineItem.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLineItem.Location = new System.Drawing.Point(12, 41);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(783, 266);
            this.dgvLineItem.TabIndex = 2;
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLineItem_RowsRemoved);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(705, 366);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(606, 366);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(73, 339);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(722, 21);
            this.txtRemarks.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Remarks";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(507, 313);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(80, 20);
            this.txtTotalQty.TabIndex = 3;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblToWH
            // 
            this.lblToWH.AutoSize = true;
            this.lblToWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToWH.Location = new System.Drawing.Point(9, 15);
            this.lblToWH.Name = "lblToWH";
            this.lblToWH.Size = new System.Drawing.Size(62, 15);
            this.lblToWH.TabIndex = 0;
            this.lblToWH.Text = "To Outlet: ";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(77, 12);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(231, 23);
            this.cmbWarehouse.TabIndex = 1;
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Location = new System.Drawing.Point(382, 14);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(144, 20);
            this.txtVehicleNo.TabIndex = 67;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label51.Location = new System.Drawing.Point(322, 15);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(54, 15);
            this.label51.TabIndex = 66;
            this.label51.Text = "Vehicle#";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 110;
            // 
            // btnFindProduct
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            this.btnFindProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnFindProduct.Frozen = true;
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Text = "...";
            this.btnFindProduct.Width = 35;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 230;
            // 
            // colCurrentStock
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.colCurrentStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.colCurrentStock.Frozen = true;
            this.colCurrentStock.HeaderText = "Stock Qty";
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.ReadOnly = true;
            this.colCurrentStock.Width = 80;
            // 
            // RequisitionQty
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.RequisitionQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.RequisitionQty.Frozen = true;
            this.RequisitionQty.HeaderText = "Qty";
            this.RequisitionQty.Name = "RequisitionQty";
            this.RequisitionQty.ReadOnly = true;
            this.RequisitionQty.Width = 70;
            // 
            // colBarcode
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.colBarcode.DefaultCellStyle = dataGridViewCellStyle6;
            this.colBarcode.Frozen = true;
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            this.colBarcode.Width = 180;
            // 
            // ProductID
            // 
            this.ProductID.Frozen = true;
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // btnBarcode
            // 
            this.btnBarcode.Frozen = true;
            this.btnBarcode.HeaderText = "?";
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Text = "...";
            this.btnBarcode.Width = 35;
            // 
            // txtIsBarcodeItem
            // 
            this.txtIsBarcodeItem.Frozen = true;
            this.txtIsBarcodeItem.HeaderText = "IsBarcodeItem";
            this.txtIsBarcodeItem.Name = "txtIsBarcodeItem";
            this.txtIsBarcodeItem.ReadOnly = true;
            this.txtIsBarcodeItem.Visible = false;
            // 
            // txtTP
            // 
            this.txtTP.HeaderText = "TP";
            this.txtTP.Name = "txtTP";
            // 
            // txtNSP
            // 
            this.txtNSP.HeaderText = "NSP";
            this.txtNSP.Name = "txtNSP";
            // 
            // txtRSP
            // 
            this.txtRSP.HeaderText = "RSP";
            this.txtRSP.Name = "txtRSP";
            // 
            // txtVAT
            // 
            this.txtVAT.HeaderText = "VAT";
            this.txtVAT.Name = "txtVAT";
            // 
            // txtSupplyType
            // 
            this.txtSupplyType.HeaderText = "SupplyType";
            this.txtSupplyType.Name = "txtSupplyType";
            // 
            // txtVATType
            // 
            this.txtVATType.HeaderText = "VATType";
            this.txtVATType.Name = "txtVATType";
            // 
            // txtVATApplicable
            // 
            this.txtVATApplicable.HeaderText = "IsVATApplicable";
            this.txtVATApplicable.Name = "txtVATApplicable";
            // 
            // txtVATCP
            // 
            this.txtVATCP.HeaderText = "VATCP";
            this.txtVATCP.Name = "txtVATCP";
            this.txtVATCP.ReadOnly = true;
            this.txtVATCP.Visible = false;
            // 
            // frmProductTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 402);
            this.Controls.Add(this.txtVehicleNo);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.lblToWH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Transfer";
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
        private System.Windows.Forms.Label lblToWH;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewButtonColumn btnBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIsBarcodeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSupplyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVATType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVATApplicable;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVATCP;
    }
}