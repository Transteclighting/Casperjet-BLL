namespace CJ.Factory
{
    partial class frmProductSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductSearch));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMAG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btOk = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.lblAG = new System.Windows.Forms.Label();
            this.cboAG = new System.Windows.Forms.ComboBox();
            this.lblASG = new System.Windows.Forms.Label();
            this.cboASG = new System.Windows.Forms.ComboBox();
            this.lblMAG = new System.Windows.Forms.Label();
            this.lblPG = new System.Windows.Forms.Label();
            this.cboMAG = new System.Windows.Forms.ComboBox();
            this.cboPG = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lvwProduct = new System.Windows.Forms.ListView();
            this.colBrand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 200;
            // 
            // colMAG
            // 
            this.colMAG.Text = "MAG";
            this.colMAG.Width = 119;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(419, 411);
            this.btOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 28);
            this.btOk.TabIndex = 16;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.lvwProductSearch_DoubleClick);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(10, 81);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(41, 16);
            this.lblBrand.TabIndex = 8;
            this.lblBrand.Text = "Brand";
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 109;
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(55, 76);
            this.cboBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(200, 24);
            this.cboBrand.TabIndex = 9;
            // 
            // lblAG
            // 
            this.lblAG.AutoSize = true;
            this.lblAG.Location = new System.Drawing.Point(276, 49);
            this.lblAG.Name = "lblAG";
            this.lblAG.Size = new System.Drawing.Size(25, 16);
            this.lblAG.TabIndex = 6;
            this.lblAG.Text = "AG";
            // 
            // cboAG
            // 
            this.cboAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAG.FormattingEnabled = true;
            this.cboAG.Location = new System.Drawing.Point(306, 44);
            this.cboAG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboAG.Name = "cboAG";
            this.cboAG.Size = new System.Drawing.Size(200, 24);
            this.cboAG.TabIndex = 7;
            // 
            // lblASG
            // 
            this.lblASG.AutoSize = true;
            this.lblASG.Location = new System.Drawing.Point(17, 50);
            this.lblASG.Name = "lblASG";
            this.lblASG.Size = new System.Drawing.Size(32, 16);
            this.lblASG.TabIndex = 4;
            this.lblASG.Text = "ASG";
            // 
            // cboASG
            // 
            this.cboASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboASG.FormattingEnabled = true;
            this.cboASG.Location = new System.Drawing.Point(55, 46);
            this.cboASG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboASG.Name = "cboASG";
            this.cboASG.Size = new System.Drawing.Size(200, 24);
            this.cboASG.TabIndex = 5;
            // 
            // lblMAG
            // 
            this.lblMAG.AutoSize = true;
            this.lblMAG.Location = new System.Drawing.Point(266, 18);
            this.lblMAG.Name = "lblMAG";
            this.lblMAG.Size = new System.Drawing.Size(37, 16);
            this.lblMAG.TabIndex = 2;
            this.lblMAG.Text = "MAG";
            // 
            // lblPG
            // 
            this.lblPG.AutoSize = true;
            this.lblPG.Location = new System.Drawing.Point(26, 18);
            this.lblPG.Name = "lblPG";
            this.lblPG.Size = new System.Drawing.Size(24, 16);
            this.lblPG.TabIndex = 0;
            this.lblPG.Text = "PG";
            // 
            // cboMAG
            // 
            this.cboMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMAG.FormattingEnabled = true;
            this.cboMAG.Location = new System.Drawing.Point(306, 15);
            this.cboMAG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMAG.Name = "cboMAG";
            this.cboMAG.Size = new System.Drawing.Size(200, 24);
            this.cboMAG.TabIndex = 3;
            // 
            // cboPG
            // 
            this.cboPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPG.FormattingEnabled = true;
            this.cboPG.Location = new System.Drawing.Point(55, 15);
            this.cboPG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboPG.Name = "cboPG";
            this.cboPG.Size = new System.Drawing.Size(200, 24);
            this.cboPG.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 143);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 16);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Name";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(14, 112);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(39, 16);
            this.lblCode.TabIndex = 10;
            this.lblCode.Text = "Code";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(55, 108);
            this.txtProductCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(143, 23);
            this.txtProductCode.TabIndex = 11;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(55, 139);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(451, 23);
            this.txtProductName.TabIndex = 13;
            // 
            // lvwProduct
            // 
            this.lvwProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode,
            this.colProductName,
            this.colMAG,
            this.colBrand});
            this.lvwProduct.FullRowSelect = true;
            this.lvwProduct.GridLines = true;
            this.lvwProduct.HideSelection = false;
            this.lvwProduct.Location = new System.Drawing.Point(13, 170);
            this.lvwProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwProduct.Name = "lvwProduct";
            this.lvwProduct.Size = new System.Drawing.Size(493, 233);
            this.lvwProduct.TabIndex = 15;
            this.lvwProduct.UseCompatibleStateImageBehavior = false;
            this.lvwProduct.View = System.Windows.Forms.View.Details;
            this.lvwProduct.DoubleClick += new System.EventHandler(this.lvwProductSearch_DoubleClick);
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 98;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(419, 100);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 28);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(532, 553);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProductSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 443);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cboBrand);
            this.Controls.Add(this.lblAG);
            this.Controls.Add(this.cboAG);
            this.Controls.Add(this.lblASG);
            this.Controls.Add(this.cboASG);
            this.Controls.Add(this.lblMAG);
            this.Controls.Add(this.lblPG);
            this.Controls.Add(this.cboMAG);
            this.Controls.Add(this.cboPG);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lvwProduct);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Product";
            this.Load += new System.EventHandler(this.frmProductSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colMAG;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label lblAG;
        private System.Windows.Forms.ComboBox cboAG;
        private System.Windows.Forms.Label lblASG;
        private System.Windows.Forms.ComboBox cboASG;
        private System.Windows.Forms.Label lblMAG;
        private System.Windows.Forms.Label lblPG;
        private System.Windows.Forms.ComboBox cboMAG;
        private System.Windows.Forms.ComboBox cboPG;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ListView lvwProduct;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colBrand;
    }
}