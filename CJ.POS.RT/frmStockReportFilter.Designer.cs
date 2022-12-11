namespace CJ.POS.RT
{
    partial class frmStockReportFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockReportFilter));
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.lblAG = new System.Windows.Forms.Label();
            this.cboAG = new System.Windows.Forms.ComboBox();
            this.lblASG = new System.Windows.Forms.Label();
            this.cboASG = new System.Windows.Forms.ComboBox();
            this.lblMAG = new System.Windows.Forms.Label();
            this.cboMAG = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.rdoProductWise = new System.Windows.Forms.RadioButton();
            this.rdoASGWise = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoSold = new System.Windows.Forms.RadioButton();
            this.rdoTransit = new System.Windows.Forms.RadioButton();
            this.rdoUnsold = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoOtherOutletsStock = new System.Windows.Forms.RadioButton();
            this.rdoCentralStock = new System.Windows.Forms.RadioButton();
            this.rdoOwnStock = new System.Windows.Forms.RadioButton();
            this.lblQty = new System.Windows.Forms.Label();
            this.cmbQuantity = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.Location = new System.Drawing.Point(519, 155);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 32);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Preview....";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(49, 13);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(46, 15);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Brand: ";
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(97, 9);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(171, 23);
            this.cboBrand.TabIndex = 1;
            // 
            // lblAG
            // 
            this.lblAG.AutoSize = true;
            this.lblAG.Location = new System.Drawing.Point(323, 45);
            this.lblAG.Name = "lblAG";
            this.lblAG.Size = new System.Drawing.Size(29, 15);
            this.lblAG.TabIndex = 6;
            this.lblAG.Text = "AG: ";
            // 
            // cboAG
            // 
            this.cboAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAG.FormattingEnabled = true;
            this.cboAG.Location = new System.Drawing.Point(356, 38);
            this.cboAG.Name = "cboAG";
            this.cboAG.Size = new System.Drawing.Size(171, 23);
            this.cboAG.TabIndex = 7;
            // 
            // lblASG
            // 
            this.lblASG.AutoSize = true;
            this.lblASG.Location = new System.Drawing.Point(56, 43);
            this.lblASG.Name = "lblASG";
            this.lblASG.Size = new System.Drawing.Size(37, 15);
            this.lblASG.TabIndex = 4;
            this.lblASG.Text = "ASG: ";
            // 
            // cboASG
            // 
            this.cboASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboASG.FormattingEnabled = true;
            this.cboASG.Location = new System.Drawing.Point(97, 39);
            this.cboASG.Name = "cboASG";
            this.cboASG.Size = new System.Drawing.Size(171, 23);
            this.cboASG.TabIndex = 5;
            // 
            // lblMAG
            // 
            this.lblMAG.AutoSize = true;
            this.lblMAG.Location = new System.Drawing.Point(313, 12);
            this.lblMAG.Name = "lblMAG";
            this.lblMAG.Size = new System.Drawing.Size(40, 15);
            this.lblMAG.TabIndex = 2;
            this.lblMAG.Text = "MAG: ";
            // 
            // cboMAG
            // 
            this.cboMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMAG.FormattingEnabled = true;
            this.cboMAG.Location = new System.Drawing.Point(356, 8);
            this.cboMAG.Name = "cboMAG";
            this.cboMAG.Size = new System.Drawing.Size(171, 23);
            this.cboMAG.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(261, 75);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 15);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Product Name: ";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(5, 74);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(87, 15);
            this.lblCode.TabIndex = 8;
            this.lblCode.Text = "Product Code: ";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(97, 72);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(129, 21);
            this.txtProductCode.TabIndex = 9;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(356, 70);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(257, 21);
            this.txtProductName.TabIndex = 11;
            // 
            // rdoProductWise
            // 
            this.rdoProductWise.AutoSize = true;
            this.rdoProductWise.Location = new System.Drawing.Point(9, 16);
            this.rdoProductWise.Name = "rdoProductWise";
            this.rdoProductWise.Size = new System.Drawing.Size(97, 19);
            this.rdoProductWise.TabIndex = 0;
            this.rdoProductWise.Text = "Product Wise";
            this.rdoProductWise.UseVisualStyleBackColor = true;
            this.rdoProductWise.CheckedChanged += new System.EventHandler(this.rdoProductWise_CheckedChanged);
            // 
            // rdoASGWise
            // 
            this.rdoASGWise.AutoSize = true;
            this.rdoASGWise.Location = new System.Drawing.Point(127, 16);
            this.rdoASGWise.Name = "rdoASGWise";
            this.rdoASGWise.Size = new System.Drawing.Size(79, 19);
            this.rdoASGWise.TabIndex = 1;
            this.rdoASGWise.Text = "ASG Wise";
            this.rdoASGWise.UseVisualStyleBackColor = true;
            this.rdoASGWise.CheckedChanged += new System.EventHandler(this.rdoASGWise_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoASGWise);
            this.groupBox1.Controls.Add(this.rdoProductWise);
            this.groupBox1.Location = new System.Drawing.Point(96, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 47);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoSold);
            this.groupBox2.Controls.Add(this.rdoTransit);
            this.groupBox2.Controls.Add(this.rdoUnsold);
            this.groupBox2.Controls.Add(this.rdoAll);
            this.groupBox2.Location = new System.Drawing.Point(93, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 47);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // rdoSold
            // 
            this.rdoSold.AutoSize = true;
            this.rdoSold.Location = new System.Drawing.Point(248, 18);
            this.rdoSold.Name = "rdoSold";
            this.rdoSold.Size = new System.Drawing.Size(50, 19);
            this.rdoSold.TabIndex = 3;
            this.rdoSold.Text = "Sold";
            this.rdoSold.UseVisualStyleBackColor = true;
            // 
            // rdoTransit
            // 
            this.rdoTransit.AutoSize = true;
            this.rdoTransit.Location = new System.Drawing.Point(163, 17);
            this.rdoTransit.Name = "rdoTransit";
            this.rdoTransit.Size = new System.Drawing.Size(62, 19);
            this.rdoTransit.TabIndex = 2;
            this.rdoTransit.Text = "Transit";
            this.rdoTransit.UseVisualStyleBackColor = true;
            // 
            // rdoUnsold
            // 
            this.rdoUnsold.AutoSize = true;
            this.rdoUnsold.Location = new System.Drawing.Point(70, 16);
            this.rdoUnsold.Name = "rdoUnsold";
            this.rdoUnsold.Size = new System.Drawing.Size(64, 19);
            this.rdoUnsold.TabIndex = 1;
            this.rdoUnsold.Text = "Unsold";
            this.rdoUnsold.UseVisualStyleBackColor = true;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(9, 16);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(38, 19);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(33, 105);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(59, 15);
            this.lblBarcode.TabIndex = 12;
            this.lblBarcode.Text = "Barcode: ";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(97, 102);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(516, 21);
            this.txtBarcode.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoOtherOutletsStock);
            this.groupBox3.Controls.Add(this.rdoCentralStock);
            this.groupBox3.Controls.Add(this.rdoOwnStock);
            this.groupBox3.Location = new System.Drawing.Point(94, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 47);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // rdoOtherOutletsStock
            // 
            this.rdoOtherOutletsStock.AutoSize = true;
            this.rdoOtherOutletsStock.Location = new System.Drawing.Point(210, 16);
            this.rdoOtherOutletsStock.Name = "rdoOtherOutletsStock";
            this.rdoOtherOutletsStock.Size = new System.Drawing.Size(129, 19);
            this.rdoOtherOutletsStock.TabIndex = 2;
            this.rdoOtherOutletsStock.Text = "Other Outlets Stock";
            this.rdoOtherOutletsStock.UseVisualStyleBackColor = true;
            this.rdoOtherOutletsStock.CheckedChanged += new System.EventHandler(this.rdoOtherOutletsStock_CheckedChanged);
            // 
            // rdoCentralStock
            // 
            this.rdoCentralStock.AutoSize = true;
            this.rdoCentralStock.Location = new System.Drawing.Point(104, 16);
            this.rdoCentralStock.Name = "rdoCentralStock";
            this.rdoCentralStock.Size = new System.Drawing.Size(97, 19);
            this.rdoCentralStock.TabIndex = 1;
            this.rdoCentralStock.Text = "Central Stock";
            this.rdoCentralStock.UseVisualStyleBackColor = true;
            this.rdoCentralStock.CheckedChanged += new System.EventHandler(this.rdoCentralStock_CheckedChanged);
            // 
            // rdoOwnStock
            // 
            this.rdoOwnStock.AutoSize = true;
            this.rdoOwnStock.Location = new System.Drawing.Point(9, 16);
            this.rdoOwnStock.Name = "rdoOwnStock";
            this.rdoOwnStock.Size = new System.Drawing.Size(83, 19);
            this.rdoOwnStock.TabIndex = 0;
            this.rdoOwnStock.Text = "Own Stock";
            this.rdoOwnStock.UseVisualStyleBackColor = true;
            this.rdoOwnStock.CheckedChanged += new System.EventHandler(this.rdoOwnStock_CheckedChanged);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(481, 107);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(57, 15);
            this.lblQty.TabIndex = 16;
            this.lblQty.Text = "Quantity: ";
            // 
            // cmbQuantity
            // 
            this.cmbQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuantity.FormattingEnabled = true;
            this.cmbQuantity.Items.AddRange(new object[] {
            "All",
            "0",
            ">0"});
            this.cmbQuantity.Location = new System.Drawing.Point(545, 103);
            this.cmbQuantity.Name = "cmbQuantity";
            this.cmbQuantity.Size = new System.Drawing.Size(68, 23);
            this.cmbQuantity.TabIndex = 17;
            // 
            // frmStockReportFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 207);
            this.Controls.Add(this.cmbQuantity);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cboBrand);
            this.Controls.Add(this.lblAG);
            this.Controls.Add(this.cboAG);
            this.Controls.Add(this.lblASG);
            this.Controls.Add(this.cboASG);
            this.Controls.Add(this.lblMAG);
            this.Controls.Add(this.cboMAG);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtProductName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockReportFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Report Filter";
            this.Load += new System.EventHandler(this.frmStockReportFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label lblAG;
        private System.Windows.Forms.ComboBox cboAG;
        private System.Windows.Forms.Label lblASG;
        private System.Windows.Forms.ComboBox cboASG;
        private System.Windows.Forms.Label lblMAG;
        private System.Windows.Forms.ComboBox cboMAG;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.RadioButton rdoProductWise;
        private System.Windows.Forms.RadioButton rdoASGWise;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoTransit;
        private System.Windows.Forms.RadioButton rdoUnsold;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoSold;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoOtherOutletsStock;
        private System.Windows.Forms.RadioButton rdoCentralStock;
        private System.Windows.Forms.RadioButton rdoOwnStock;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.ComboBox cmbQuantity;
    }
}