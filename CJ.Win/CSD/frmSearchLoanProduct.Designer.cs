namespace CJ.Win
{
    partial class frmSearchLoanProduct
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
            this.btnGo = new System.Windows.Forms.Button();
            this.lblLoanNo = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtLoanProductNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwLoanProductSearch = new System.Windows.Forms.ListView();
            this.colLoanNo = new System.Windows.Forms.ColumnHeader();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colBarcode = new System.Windows.Forms.ColumnHeader();
            this.colWH = new System.Windows.Forms.ColumnHeader();
            this.txtBarcodeSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(526, 50);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(105, 31);
            this.btnGo.TabIndex = 164;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblLoanNo
            // 
            this.lblLoanNo.AutoSize = true;
            this.lblLoanNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoanNo.Location = new System.Drawing.Point(22, 31);
            this.lblLoanNo.Name = "lblLoanNo";
            this.lblLoanNo.Size = new System.Drawing.Size(95, 13);
            this.lblLoanNo.TabIndex = 163;
            this.lblLoanNo.Text = "Loan Product #";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(393, 28);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(107, 20);
            this.txtProductCode.TabIndex = 162;
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(306, 31);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(84, 13);
            this.lblProductCode.TabIndex = 161;
            this.lblProductCode.Text = "Product Code";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(120, 55);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(152, 20);
            this.txtProductName.TabIndex = 160;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(30, 58);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(87, 13);
            this.lblProductName.TabIndex = 159;
            this.lblProductName.Text = "Product Name";
            // 
            // txtLoanProductNo
            // 
            this.txtLoanProductNo.Location = new System.Drawing.Point(120, 28);
            this.txtLoanProductNo.Name = "txtLoanProductNo";
            this.txtLoanProductNo.Size = new System.Drawing.Size(152, 20);
            this.txtLoanProductNo.TabIndex = 158;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(526, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 157;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwLoanProductSearch
            // 
            this.lvwLoanProductSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLoanNo,
            this.colProductCode,
            this.colProductName,
            this.colBarcode,
            this.colWH});
            this.lvwLoanProductSearch.FullRowSelect = true;
            this.lvwLoanProductSearch.GridLines = true;
            this.lvwLoanProductSearch.Location = new System.Drawing.Point(35, 93);
            this.lvwLoanProductSearch.Name = "lvwLoanProductSearch";
            this.lvwLoanProductSearch.Size = new System.Drawing.Size(604, 223);
            this.lvwLoanProductSearch.TabIndex = 156;
            this.lvwLoanProductSearch.UseCompatibleStateImageBehavior = false;
            this.lvwLoanProductSearch.View = System.Windows.Forms.View.Details;
            this.lvwLoanProductSearch.DoubleClick += new System.EventHandler(this.lvwLoanProductSearch_DoubleClick);
            this.lvwLoanProductSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwLoanProductSearch_KeyPress);
            // 
            // colLoanNo
            // 
            this.colLoanNo.Text = "Loan #";
            this.colLoanNo.Width = 90;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 90;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 230;
            // 
            // colBarcode
            // 
            this.colBarcode.Text = "Barcode SL";
            this.colBarcode.Width = 110;
            // 
            // colWH
            // 
            this.colWH.Text = "WH#";
            // 
            // txtBarcodeSerial
            // 
            this.txtBarcodeSerial.Location = new System.Drawing.Point(393, 57);
            this.txtBarcodeSerial.Name = "txtBarcodeSerial";
            this.txtBarcodeSerial.Size = new System.Drawing.Size(107, 20);
            this.txtBarcodeSerial.TabIndex = 166;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 165;
            this.label1.Text = "Barcode Serial";
            // 
            // frmSearchLoanProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 365);
            this.Controls.Add(this.txtBarcodeSerial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblLoanNo);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtLoanProductNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwLoanProductSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSearchLoanProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Loan Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblLoanNo;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtLoanProductNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwLoanProductSearch;
        private System.Windows.Forms.ColumnHeader colLoanNo;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colBarcode;
        private System.Windows.Forms.TextBox txtBarcodeSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colWH;
    }
}