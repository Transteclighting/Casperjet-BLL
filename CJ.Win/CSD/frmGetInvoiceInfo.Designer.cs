namespace CJ.Win.CSD
{
    partial class frmGetInvoiceInfo
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
            this.lvwInvoiceSearch = new System.Windows.Forms.ListView();
            this.colInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colProduct = new System.Windows.Forms.ColumnHeader();
            this.colProductSL = new System.Windows.Forms.ColumnHeader();
            this.colTelephone = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductSL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwInvoiceSearch
            // 
            this.lvwInvoiceSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colCustomerName,
            this.colContactNo,
            this.colProduct,
            this.colProductSL,
            this.colTelephone,
            this.colAddress});
            this.lvwInvoiceSearch.FullRowSelect = true;
            this.lvwInvoiceSearch.GridLines = true;
            this.lvwInvoiceSearch.Location = new System.Drawing.Point(9, 95);
            this.lvwInvoiceSearch.Name = "lvwInvoiceSearch";
            this.lvwInvoiceSearch.Size = new System.Drawing.Size(538, 292);
            this.lvwInvoiceSearch.TabIndex = 11;
            this.lvwInvoiceSearch.UseCompatibleStateImageBehavior = false;
            this.lvwInvoiceSearch.View = System.Windows.Forms.View.Details;
            this.lvwInvoiceSearch.DoubleClick += new System.EventHandler(this.lvwInvoiceSearch_DoubleClick);
            this.lvwInvoiceSearch.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwInvoiceSearch_ColumnClick);
            this.lvwInvoiceSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwInvoiceSearch_KeyPress);
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 100;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 143;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 99;
            // 
            // colProduct
            // 
            this.colProduct.Text = "Product";
            this.colProduct.Width = 193;
            // 
            // colProductSL
            // 
            this.colProductSL.Text = "ProductSL";
            this.colProductSL.Width = 90;
            // 
            // colTelephone
            // 
            this.colTelephone.Text = "Telephone";
            this.colTelephone.Width = 100;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 275;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(480, 63);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(68, 26);
            this.btnGetData.TabIndex = 10;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(487, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 26);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(284, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Telephone";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(367, 16);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(180, 20);
            this.txtTelephone.TabIndex = 3;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.Location = new System.Drawing.Point(16, 16);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(82, 16);
            this.lblInvoiceNo.TabIndex = 0;
            this.lblInvoiceNo.Text = "Invoice No";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(99, 16);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(180, 20);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Product SL";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProductSL
            // 
            this.txtProductSL.Location = new System.Drawing.Point(99, 39);
            this.txtProductSL.Name = "txtProductSL";
            this.txtProductSL.Size = new System.Drawing.Size(180, 20);
            this.txtProductSL.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mobile#";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(99, 62);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(180, 20);
            this.txtMobileNo.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(284, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "Customer Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(367, 39);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(180, 20);
            this.txtCustomerName.TabIndex = 7;
            // 
            // frmGetInvoiceInfo
            // 
            this.AcceptButton = this.btnGetData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 428);
            this.Controls.Add(this.lvwInvoiceSearch);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProductSL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCustomerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGetInvoiceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get Invoice Info";
            this.Load += new System.EventHandler(this.frmGetInvoiceInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwInvoiceSearch;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colProduct;
        private System.Windows.Forms.ColumnHeader colProductSL;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colTelephone;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCustomerName;
    }
}