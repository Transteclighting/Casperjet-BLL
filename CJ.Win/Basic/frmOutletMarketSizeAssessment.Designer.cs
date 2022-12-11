namespace CJ.Win.Basic
{
    partial class frmOutletMarketSizeAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutletMarketSizeAssessment));
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMarketType = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.MarketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShopSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 65;
            this.label4.Text = "Market Type";
            // 
            // cmbMarketType
            // 
            this.cmbMarketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarketType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarketType.FormattingEnabled = true;
            this.cmbMarketType.Location = new System.Drawing.Point(107, 14);
            this.cmbMarketType.Name = "cmbMarketType";
            this.cmbMarketType.Size = new System.Drawing.Size(221, 23);
            this.cmbMarketType.TabIndex = 64;
            this.cmbMarketType.SelectedIndexChanged += new System.EventHandler(this.cmbMarketType_SelectedIndexChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MarketType,
            this.Desc,
            this.ShopSize,
            this.AvgSale,
            this.Qty,
            this.REFQty,
            this.ACQty});
            this.dgvData.Location = new System.Drawing.Point(14, 50);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(726, 233);
            this.dgvData.TabIndex = 66;
            // 
            // MarketType
            // 
            this.MarketType.HeaderText = "Market Type";
            this.MarketType.Name = "MarketType";
            this.MarketType.ReadOnly = true;
            this.MarketType.Visible = false;
            this.MarketType.Width = 60;
            // 
            // Desc
            // 
            this.Desc.HeaderText = "Desc";
            this.Desc.Name = "Desc";
            this.Desc.Width = 200;
            // 
            // ShopSize
            // 
            this.ShopSize.HeaderText = "Shop Size";
            this.ShopSize.Name = "ShopSize";
            // 
            // AvgSale
            // 
            this.AvgSale.HeaderText = "Avg Sale";
            this.AvgSale.Name = "AvgSale";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "LED Qty";
            this.Qty.Name = "Qty";
            // 
            // REFQty
            // 
            this.REFQty.HeaderText = "REF Qty";
            this.REFQty.Name = "REFQty";
            // 
            // ACQty
            // 
            this.ACQty.HeaderText = "AC Qty";
            this.ACQty.Name = "ACQty";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(556, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(652, 298);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmOutletMarketSizeAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 338);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMarketType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOutletMarketSizeAssessment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outlet Market Size Assessment";
            this.Load += new System.EventHandler(this.frmOutletMarketSizeAssessment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMarketType;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShopSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACQty;
    }
}