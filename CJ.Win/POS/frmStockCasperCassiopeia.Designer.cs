namespace CJ.Win.POS
{
    partial class frmStockCasperCassiopeia
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
            this.label14 = new System.Windows.Forms.Label();
            this.cmbShowroom = new System.Windows.Forms.ComboBox();
            this.lblMAG = new System.Windows.Forms.Label();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.lblASG = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbStockInfo = new System.Windows.Forms.GroupBox();
            this.lvwStockList = new System.Windows.Forms.ListView();
            this.SKUCode = new System.Windows.Forms.ColumnHeader();
            this.SKUName = new System.Windows.Forms.ColumnHeader();
            this.CasperStock = new System.Windows.Forms.ColumnHeader();
            this.CassiopeiaStock = new System.Windows.Forms.ColumnHeader();
            this.StockDiffer = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbStockInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(35, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Showroom";
            // 
            // cmbShowroom
            // 
            this.cmbShowroom.FormattingEnabled = true;
            this.cmbShowroom.Location = new System.Drawing.Point(108, 31);
            this.cmbShowroom.Name = "cmbShowroom";
            this.cmbShowroom.Size = new System.Drawing.Size(221, 21);
            this.cmbShowroom.TabIndex = 14;
            // 
            // lblMAG
            // 
            this.lblMAG.AutoSize = true;
            this.lblMAG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAG.Location = new System.Drawing.Point(404, 34);
            this.lblMAG.Name = "lblMAG";
            this.lblMAG.Size = new System.Drawing.Size(34, 13);
            this.lblMAG.TabIndex = 15;
            this.lblMAG.Text = "MAG";
            // 
            // cmbMAG
            // 
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(447, 31);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(172, 21);
            this.cmbMAG.TabIndex = 16;
            // 
            // cmbASG
            // 
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(447, 60);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(172, 21);
            this.cmbASG.TabIndex = 18;
            // 
            // lblASG
            // 
            this.lblASG.AutoSize = true;
            this.lblASG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblASG.Location = new System.Drawing.Point(404, 63);
            this.lblASG.Name = "lblASG";
            this.lblASG.Size = new System.Drawing.Size(32, 13);
            this.lblASG.TabIndex = 17;
            this.lblASG.Text = "ASG";
            // 
            // cmbBrand
            // 
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(447, 89);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(172, 21);
            this.cmbBrand.TabIndex = 20;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(404, 92);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(40, 13);
            this.lblBrand.TabIndex = 19;
            this.lblBrand.Text = "Brand";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(108, 92);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 23);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbStockInfo
            // 
            this.gbStockInfo.Controls.Add(this.lvwStockList);
            this.gbStockInfo.Location = new System.Drawing.Point(38, 130);
            this.gbStockInfo.Name = "gbStockInfo";
            this.gbStockInfo.Size = new System.Drawing.Size(644, 371);
            this.gbStockInfo.TabIndex = 22;
            this.gbStockInfo.TabStop = false;
            this.gbStockInfo.Text = "Stock Information";
            // 
            // lvwStockList
            // 
            this.lvwStockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwStockList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SKUCode,
            this.SKUName,
            this.CasperStock,
            this.CassiopeiaStock,
            this.StockDiffer});
            this.lvwStockList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwStockList.FullRowSelect = true;
            this.lvwStockList.GridLines = true;
            this.lvwStockList.HideSelection = false;
            this.lvwStockList.Location = new System.Drawing.Point(6, 13);
            this.lvwStockList.MultiSelect = false;
            this.lvwStockList.Name = "lvwStockList";
            this.lvwStockList.Size = new System.Drawing.Size(632, 352);
            this.lvwStockList.TabIndex = 55;
            this.lvwStockList.UseCompatibleStateImageBehavior = false;
            this.lvwStockList.View = System.Windows.Forms.View.Details;
            // 
            // SKUCode
            // 
            this.SKUCode.Text = "SKU Code";
            this.SKUCode.Width = 80;
            // 
            // SKUName
            // 
            this.SKUName.Text = "SKU Name";
            this.SKUName.Width = 215;
            // 
            // CasperStock
            // 
            this.CasperStock.Text = "Casper Stock";
            this.CasperStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CasperStock.Width = 110;
            // 
            // CassiopeiaStock
            // 
            this.CassiopeiaStock.Text = "Cassiopeia Stock";
            this.CassiopeiaStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CassiopeiaStock.Width = 110;
            // 
            // StockDiffer
            // 
            this.StockDiffer.Text = "Difference";
            this.StockDiffer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StockDiffer.Width = 80;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(595, 507);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStockCasperCassiopeia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 607);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbStockInfo);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.lblASG);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.lblMAG);
            this.Controls.Add(this.cmbShowroom);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmStockCasperCassiopeia";
            this.Text = "frmStockCasperCassiopeia";
            this.Load += new System.EventHandler(this.frmStockCasperCassiopeia_Load);
            this.gbStockInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbShowroom;
        private System.Windows.Forms.Label lblMAG;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.Label lblASG;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbStockInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwStockList;
        private System.Windows.Forms.ColumnHeader SKUCode;
        private System.Windows.Forms.ColumnHeader SKUName;
        private System.Windows.Forms.ColumnHeader CasperStock;
        private System.Windows.Forms.ColumnHeader CassiopeiaStock;
        private System.Windows.Forms.ColumnHeader StockDiffer;
    }
}