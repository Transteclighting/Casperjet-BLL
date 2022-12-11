namespace CJ.Win.POS
{
    partial class frmStockTransfer
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
            this.lblReqNo = new System.Windows.Forms.Label();
            this.txtIMEIList = new System.Windows.Forms.TextBox();
            this.btIMEIValid = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequisitionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRequisitionNo = new System.Windows.Forms.Label();
            this.lblFromWH = new System.Windows.Forms.Label();
            this.lblToWH = new System.Windows.Forms.Label();
            this.lblRequisitionDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReqNo
            // 
            this.lblReqNo.AutoSize = true;
            this.lblReqNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReqNo.Location = new System.Drawing.Point(12, 12);
            this.lblReqNo.Name = "lblReqNo";
            this.lblReqNo.Size = new System.Drawing.Size(98, 13);
            this.lblReqNo.TabIndex = 42;
            this.lblReqNo.Text = "Requisition No: ";
            // 
            // txtIMEIList
            // 
            this.txtIMEIList.Location = new System.Drawing.Point(619, 70);
            this.txtIMEIList.Multiline = true;
            this.txtIMEIList.Name = "txtIMEIList";
            this.txtIMEIList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIMEIList.Size = new System.Drawing.Size(173, 274);
            this.txtIMEIList.TabIndex = 33;
            // 
            // btIMEIValid
            // 
            this.btIMEIValid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIMEIValid.Location = new System.Drawing.Point(577, 202);
            this.btIMEIValid.Name = "btIMEIValid";
            this.btIMEIValid.Size = new System.Drawing.Size(32, 31);
            this.btIMEIValid.TabIndex = 41;
            this.btIMEIValid.Text = "<<";
            this.btIMEIValid.UseVisualStyleBackColor = true;
            this.btIMEIValid.Click += new System.EventHandler(this.btIMEIValid_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(614, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 296);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(431, 344);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(75, 20);
            this.txtTotalQty.TabIndex = 39;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(63, 370);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(729, 20);
            this.txtRemarks.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(613, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 26);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(707, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDescription,
            this.colCurrentStock,
            this.RequisitionQty,
            this.colBarcode,
            this.ProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(8, 68);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.ReadOnly = true;
            this.dgvLineItem.Size = new System.Drawing.Size(564, 274);
            this.dgvLineItem.TabIndex = 34;
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 200;
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.HeaderText = "Stock Qty";
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.ReadOnly = true;
            this.colCurrentStock.Width = 70;
            // 
            // RequisitionQty
            // 
            this.RequisitionQty.HeaderText = "Authorized Qty";
            this.RequisitionQty.Name = "RequisitionQty";
            this.RequisitionQty.ReadOnly = true;
            this.RequisitionQty.Width = 70;
            // 
            // colBarcode
            // 
            this.colBarcode.HeaderText = "BarcodeQty";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            this.colBarcode.Width = 80;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Total: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "From Warehouse: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(334, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "To Warehouse: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(334, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Requisition Date: ";
            // 
            // lblRequisitionNo
            // 
            this.lblRequisitionNo.AutoSize = true;
            this.lblRequisitionNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequisitionNo.Location = new System.Drawing.Point(106, 13);
            this.lblRequisitionNo.Name = "lblRequisitionNo";
            this.lblRequisitionNo.Size = new System.Drawing.Size(18, 13);
            this.lblRequisitionNo.TabIndex = 47;
            this.lblRequisitionNo.Text = "? ";
            // 
            // lblFromWH
            // 
            this.lblFromWH.AutoSize = true;
            this.lblFromWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromWH.Location = new System.Drawing.Point(118, 38);
            this.lblFromWH.Name = "lblFromWH";
            this.lblFromWH.Size = new System.Drawing.Size(18, 13);
            this.lblFromWH.TabIndex = 48;
            this.lblFromWH.Text = "? ";
            // 
            // lblToWH
            // 
            this.lblToWH.AutoSize = true;
            this.lblToWH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToWH.Location = new System.Drawing.Point(428, 37);
            this.lblToWH.Name = "lblToWH";
            this.lblToWH.Size = new System.Drawing.Size(18, 13);
            this.lblToWH.TabIndex = 49;
            this.lblToWH.Text = "? ";
            // 
            // lblRequisitionDate
            // 
            this.lblRequisitionDate.AutoSize = true;
            this.lblRequisitionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequisitionDate.Location = new System.Drawing.Point(439, 13);
            this.lblRequisitionDate.Name = "lblRequisitionDate";
            this.lblRequisitionDate.Size = new System.Drawing.Size(18, 13);
            this.lblRequisitionDate.TabIndex = 50;
            this.lblRequisitionDate.Text = "? ";
            // 
            // frmStockTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 428);
            this.Controls.Add(this.lblRequisitionDate);
            this.Controls.Add(this.lblToWH);
            this.Controls.Add(this.lblFromWH);
            this.Controls.Add(this.lblRequisitionNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReqNo);
            this.Controls.Add(this.txtIMEIList);
            this.Controls.Add(this.btIMEIValid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvLineItem);
            this.Name = "frmStockTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Transfer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReqNo;
        private System.Windows.Forms.TextBox txtIMEIList;
        private System.Windows.Forms.Button btIMEIValid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRequisitionNo;
        private System.Windows.Forms.Label lblFromWH;
        private System.Windows.Forms.Label lblToWH;
        private System.Windows.Forms.Label lblRequisitionDate;
    }
}