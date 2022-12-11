namespace CJ.Win.Process
{
    partial class frmSalesDataSync
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lvwData = new System.Windows.Forms.ListView();
            this.colInvoiceID = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.colInvoiceDate = new System.Windows.Forms.ColumnHeader();
            this.colCustomer = new System.Windows.Forms.ColumnHeader();
            this.colWarehouse = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colError = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnViewProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(646, 21);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(95, 31);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 21);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(95, 31);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lvwData
            // 
            this.lvwData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceID,
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colCustomer,
            this.colWarehouse,
            this.colAmount,
            this.colError});
            this.lvwData.FullRowSelect = true;
            this.lvwData.GridLines = true;
            this.lvwData.Location = new System.Drawing.Point(12, 78);
            this.lvwData.MultiSelect = false;
            this.lvwData.Name = "lvwData";
            this.lvwData.Size = new System.Drawing.Size(760, 298);
            this.lvwData.TabIndex = 3;
            this.lvwData.UseCompatibleStateImageBehavior = false;
            this.lvwData.View = System.Windows.Forms.View.Details;
            this.lvwData.DoubleClick += new System.EventHandler(this.lvwData_DoubleClick);
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.Text = "Invoice ID";
            this.colInvoiceID.Width = 69;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 76;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 86;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer";
            this.colCustomer.Width = 148;
            // 
            // colWarehouse
            // 
            this.colWarehouse.Text = "Warehouse";
            this.colWarehouse.Width = 166;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAmount.Width = 71;
            // 
            // colError
            // 
            this.colError.Text = "Upload Status";
            this.colError.Width = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Amount: ";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(545, 380);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(91, 20);
            this.txtTotalAmount.TabIndex = 5;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(692, 379);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnViewProduct
            // 
            this.btnViewProduct.Location = new System.Drawing.Point(157, 21);
            this.btnViewProduct.Name = "btnViewProduct";
            this.btnViewProduct.Size = new System.Drawing.Size(85, 31);
            this.btnViewProduct.TabIndex = 1;
            this.btnViewProduct.Text = "View Product";
            this.btnViewProduct.UseVisualStyleBackColor = true;
            this.btnViewProduct.Click += new System.EventHandler(this.btnViewProduct_Click);
            // 
            // frmSalesDataSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 416);
            this.Controls.Add(this.btnViewProduct);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwData);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnUpload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSalesDataSync";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesDataSync";
            this.Load += new System.EventHandler(this.frmSalesDataSync_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ListView lvwData;
        private System.Windows.Forms.ColumnHeader colInvoiceID;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colWarehouse;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnViewProduct;
    }
}