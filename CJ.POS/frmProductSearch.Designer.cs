namespace CJ.POS
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.lblAG = new System.Windows.Forms.Label();
            this.cboAG = new System.Windows.Forms.ComboBox();
            this.lblASG = new System.Windows.Forms.Label();
            this.cboASG = new System.Windows.Forms.ComboBox();
            this.lblMAG = new System.Windows.Forms.Label();
            this.cboMAG = new System.Windows.Forms.ComboBox();
            this.lblPG = new System.Windows.Forms.Label();
            this.cboPG = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lvwProduct = new System.Windows.Forms.ListView();
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BranchStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btOk = new System.Windows.Forms.Button();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(325, 116);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(525, 435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(10, 68);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(40, 15);
            this.lblBrand.TabIndex = 8;
            this.lblBrand.Text = "Brand";
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(55, 63);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(200, 23);
            this.cboBrand.TabIndex = 9;
            // 
            // lblAG
            // 
            this.lblAG.AutoSize = true;
            this.lblAG.Location = new System.Drawing.Point(276, 39);
            this.lblAG.Name = "lblAG";
            this.lblAG.Size = new System.Drawing.Size(23, 15);
            this.lblAG.TabIndex = 6;
            this.lblAG.Text = "AG";
            // 
            // cboAG
            // 
            this.cboAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAG.FormattingEnabled = true;
            this.cboAG.Location = new System.Drawing.Point(306, 34);
            this.cboAG.Name = "cboAG";
            this.cboAG.Size = new System.Drawing.Size(200, 23);
            this.cboAG.TabIndex = 7;
            // 
            // lblASG
            // 
            this.lblASG.AutoSize = true;
            this.lblASG.Location = new System.Drawing.Point(17, 39);
            this.lblASG.Name = "lblASG";
            this.lblASG.Size = new System.Drawing.Size(31, 15);
            this.lblASG.TabIndex = 4;
            this.lblASG.Text = "ASG";
            // 
            // cboASG
            // 
            this.cboASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboASG.FormattingEnabled = true;
            this.cboASG.Location = new System.Drawing.Point(55, 34);
            this.cboASG.Name = "cboASG";
            this.cboASG.Size = new System.Drawing.Size(200, 23);
            this.cboASG.TabIndex = 5;
            this.cboASG.SelectedIndexChanged += new System.EventHandler(this.cboASG_SelectedIndexChanged);
            // 
            // lblMAG
            // 
            this.lblMAG.AutoSize = true;
            this.lblMAG.Location = new System.Drawing.Point(266, 8);
            this.lblMAG.Name = "lblMAG";
            this.lblMAG.Size = new System.Drawing.Size(34, 15);
            this.lblMAG.TabIndex = 2;
            this.lblMAG.Text = "MAG";
            // 
            // cboMAG
            // 
            this.cboMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMAG.FormattingEnabled = true;
            this.cboMAG.Location = new System.Drawing.Point(306, 5);
            this.cboMAG.Name = "cboMAG";
            this.cboMAG.Size = new System.Drawing.Size(200, 23);
            this.cboMAG.TabIndex = 3;
            this.cboMAG.SelectedIndexChanged += new System.EventHandler(this.cboMAG_SelectedIndexChanged);
            // 
            // lblPG
            // 
            this.lblPG.AutoSize = true;
            this.lblPG.Location = new System.Drawing.Point(26, 8);
            this.lblPG.Name = "lblPG";
            this.lblPG.Size = new System.Drawing.Size(24, 15);
            this.lblPG.TabIndex = 0;
            this.lblPG.Text = "PG";
            // 
            // cboPG
            // 
            this.cboPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPG.FormattingEnabled = true;
            this.cboPG.Location = new System.Drawing.Point(55, 5);
            this.cboPG.Name = "cboPG";
            this.cboPG.Size = new System.Drawing.Size(200, 23);
            this.cboPG.TabIndex = 1;
            this.cboPG.SelectedIndexChanged += new System.EventHandler(this.cboPG_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 122);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Name";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(14, 96);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(36, 15);
            this.lblCode.TabIndex = 10;
            this.lblCode.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(55, 92);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(143, 21);
            this.txtCode.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(55, 119);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(263, 21);
            this.txtName.TabIndex = 13;
            // 
            // lvwProduct
            // 
            this.lvwProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProduct.CheckBoxes = true;
            this.lvwProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode,
            this.colProductName,
            this.colProductDesc,
            this.BranchStock});
            this.lvwProduct.FullRowSelect = true;
            this.lvwProduct.GridLines = true;
            this.lvwProduct.HideSelection = false;
            this.lvwProduct.Location = new System.Drawing.Point(13, 149);
            this.lvwProduct.Name = "lvwProduct";
            this.lvwProduct.Size = new System.Drawing.Size(599, 280);
            this.lvwProduct.TabIndex = 16;
            this.lvwProduct.UseCompatibleStateImageBehavior = false;
            this.lvwProduct.View = System.Windows.Forms.View.Details;
            this.lvwProduct.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwProduct_ColumnClick);
            this.lvwProduct.DoubleClick += new System.EventHandler(this.lvwProduct_DoubleClick);
            this.lvwProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwProduct_KeyPress);
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 82;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 200;
            // 
            // colProductDesc
            // 
            this.colProductDesc.Text = "Product Description";
            this.colProductDesc.Width = 200;
            // 
            // BranchStock
            // 
            this.BranchStock.Text = "Branch Stock";
            this.BranchStock.Width = 100;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(431, 435);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 17;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(419, 116);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(87, 27);
            this.btSelectAll.TabIndex = 15;
            this.btSelectAll.Text = "Select All ";
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // frmProductSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 466);
            this.Controls.Add(this.btSelectAll);
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
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lvwProduct);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Search";
            this.Load += new System.EventHandler(this.frmSearchProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label lblAG;
        private System.Windows.Forms.ComboBox cboAG;
        private System.Windows.Forms.Label lblASG;
        private System.Windows.Forms.ComboBox cboASG;
        private System.Windows.Forms.Label lblMAG;
        private System.Windows.Forms.ComboBox cboMAG;
        private System.Windows.Forms.Label lblPG;
        private System.Windows.Forms.ComboBox cboPG;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListView lvwProduct;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colProductDesc;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.ColumnHeader BranchStock;
    }
}