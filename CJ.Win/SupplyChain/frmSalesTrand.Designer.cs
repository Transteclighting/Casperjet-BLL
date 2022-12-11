namespace CJ.Win.SupplyChain
{
    partial class frmSalesTrand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesTrand));
            this.btnGetdata = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dtSalesYear = new System.Windows.Forms.DateTimePicker();
            this.dgvSalesTrand = new System.Windows.Forms.DataGridView();
            this.txtMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtB2B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesTrand)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetdata
            // 
            this.btnGetdata.Location = new System.Drawing.Point(152, 4);
            this.btnGetdata.Name = "btnGetdata";
            this.btnGetdata.Size = new System.Drawing.Size(90, 28);
            this.btnGetdata.TabIndex = 2;
            this.btnGetdata.Text = "Gata Data";
            this.btnGetdata.UseVisualStyleBackColor = true;
            this.btnGetdata.Click += new System.EventHandler(this.btnGetdata_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Year";
            // 
            // dtSalesYear
            // 
            this.dtSalesYear.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalesYear.CustomFormat = "yyyy";
            this.dtSalesYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalesYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalesYear.Location = new System.Drawing.Point(45, 6);
            this.dtSalesYear.Name = "dtSalesYear";
            this.dtSalesYear.ShowUpDown = true;
            this.dtSalesYear.Size = new System.Drawing.Size(102, 21);
            this.dtSalesYear.TabIndex = 1;
            // 
            // dgvSalesTrand
            // 
            this.dgvSalesTrand.AllowUserToAddRows = false;
            this.dgvSalesTrand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesTrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesTrand.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtMonth,
            this.txtRetail,
            this.txtB2B,
            this.txtDealer,
            this.txtTotal});
            this.dgvSalesTrand.Location = new System.Drawing.Point(10, 38);
            this.dgvSalesTrand.Name = "dgvSalesTrand";
            this.dgvSalesTrand.Size = new System.Drawing.Size(405, 328);
            this.dgvSalesTrand.TabIndex = 6;
            // 
            // txtMonth
            // 
            this.txtMonth.HeaderText = "Month";
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.Width = 120;
            // 
            // txtRetail
            // 
            this.txtRetail.HeaderText = "Retail";
            this.txtRetail.Name = "txtRetail";
            this.txtRetail.ReadOnly = true;
            this.txtRetail.Width = 60;
            // 
            // txtB2B
            // 
            this.txtB2B.HeaderText = "B2B";
            this.txtB2B.Name = "txtB2B";
            this.txtB2B.ReadOnly = true;
            this.txtB2B.Width = 60;
            // 
            // txtDealer
            // 
            this.txtDealer.HeaderText = "Dealer";
            this.txtDealer.Name = "txtDealer";
            this.txtDealer.ReadOnly = true;
            this.txtDealer.Width = 60;
            // 
            // txtTotal
            // 
            this.txtTotal.HeaderText = "Total";
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Month";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Retail";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "B2B";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Dealer";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Total";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // frmSalesTrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 378);
            this.Controls.Add(this.dgvSalesTrand);
            this.Controls.Add(this.btnGetdata);
            this.Controls.Add(this.dtSalesYear);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSalesTrand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Trand";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesTrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGetdata;
        private System.Windows.Forms.DateTimePicker dtSalesYear;
        private System.Windows.Forms.DataGridView dgvSalesTrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtB2B;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}