namespace CJ.Win.CAC
{
    partial class frmCACProductPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProductPrice));
            this.btnApply = new System.Windows.Forms.Button();
            this.txtRSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.dtpEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.label59 = new System.Windows.Forms.Label();
            this.colCPBDT = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colRSP = new System.Windows.Forms.ColumnHeader();
            this.lvwProductPrice = new System.Windows.Forms.ListView();
            this.colCPUSD = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCPUSD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(363, 208);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(83, 26);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtRSP
            // 
            this.txtRSP.Location = new System.Drawing.Point(443, 112);
            this.txtRSP.Name = "txtRSP";
            this.txtRSP.Size = new System.Drawing.Size(92, 20);
            this.txtRSP.TabIndex = 9;
            this.txtRSP.Text = "0";
            this.txtRSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "RSP";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(380, 89);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "CP (BDT)";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Location = new System.Drawing.Point(443, 86);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(92, 20);
            this.txtCostPrice.TabIndex = 7;
            this.txtCostPrice.Text = "0";
            this.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCode.Location = new System.Drawing.Point(12, 48);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(79, 13);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Price History";
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(443, 138);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(92, 20);
            this.dtpEffectiveDate.TabIndex = 11;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(351, 144);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(89, 13);
            this.label59.TabIndex = 10;
            this.label59.Text = "Effective Date";
            // 
            // colCPBDT
            // 
            this.colCPBDT.Text = "CP (BDT)";
            this.colCPBDT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCPBDT.Width = 81;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 149;
            // 
            // colRSP
            // 
            this.colRSP.Text = "RSP";
            this.colRSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRSP.Width = 67;
            // 
            // lvwProductPrice
            // 
            this.lvwProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductPrice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colCPBDT,
            this.colCPUSD,
            this.colRSP});
            this.lvwProductPrice.FullRowSelect = true;
            this.lvwProductPrice.GridLines = true;
            this.lvwProductPrice.Location = new System.Drawing.Point(11, 64);
            this.lvwProductPrice.Name = "lvwProductPrice";
            this.lvwProductPrice.Size = new System.Drawing.Size(337, 170);
            this.lvwProductPrice.TabIndex = 3;
            this.lvwProductPrice.UseCompatibleStateImageBehavior = false;
            this.lvwProductPrice.View = System.Windows.Forms.View.Details;
            // 
            // colCPUSD
            // 
            this.colCPUSD.Text = "CP (USD)";
            this.colCPUSD.Width = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(452, 208);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 26);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblProduct.Location = new System.Drawing.Point(67, 16);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(14, 13);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(379, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "CP (USD)";
            // 
            // txtCPUSD
            // 
            this.txtCPUSD.Location = new System.Drawing.Point(443, 60);
            this.txtCPUSD.Name = "txtCPUSD";
            this.txtCPUSD.Size = new System.Drawing.Size(92, 20);
            this.txtCPUSD.TabIndex = 5;
            this.txtCPUSD.Text = "0";
            this.txtCPUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmCACProductPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 245);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCPUSD);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtRSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCostPrice);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.dtpEffectiveDate);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.lvwProductPrice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProductPrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCACProductPrice";
            this.Load += new System.EventHandler(this.frmCACProductPrice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtRSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.DateTimePicker dtpEffectiveDate;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.ColumnHeader colCPBDT;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colRSP;
        private System.Windows.Forms.ListView lvwProductPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCPUSD;
        private System.Windows.Forms.ColumnHeader colCPUSD;
    }
}