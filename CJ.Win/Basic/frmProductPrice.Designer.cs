namespace CJ.Win.Basic
{
    partial class frmProductPrice
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
            this.lvwProductPrice = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCostPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTradePrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRSP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMRP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVAT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSpecialPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVATCP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.label59 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTradePrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRSP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSpecialPrice = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMC = new System.Windows.Forms.TextBox();
            this.ctlProduct = new CJ.Control.ctlProduct();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVATCP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwProductPrice
            // 
            this.lvwProductPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductPrice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colCostPrice,
            this.colTradePrice,
            this.colNSP,
            this.colRSP,
            this.colMRP,
            this.colVAT,
            this.colSpecialPrice,
            this.colMC,
            this.colVATCP});
            this.lvwProductPrice.FullRowSelect = true;
            this.lvwProductPrice.GridLines = true;
            this.lvwProductPrice.Location = new System.Drawing.Point(203, 43);
            this.lvwProductPrice.Name = "lvwProductPrice";
            this.lvwProductPrice.Size = new System.Drawing.Size(627, 252);
            this.lvwProductPrice.TabIndex = 2;
            this.lvwProductPrice.UseCompatibleStateImageBehavior = false;
            this.lvwProductPrice.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 150;
            // 
            // colCostPrice
            // 
            this.colCostPrice.Text = "Cost Price";
            this.colCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCostPrice.Width = 75;
            // 
            // colTradePrice
            // 
            this.colTradePrice.Text = "Trade Price";
            this.colTradePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTradePrice.Width = 70;
            // 
            // colNSP
            // 
            this.colNSP.Text = "NSP";
            this.colNSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNSP.Width = 64;
            // 
            // colRSP
            // 
            this.colRSP.Text = "RSP";
            this.colRSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colMRP
            // 
            this.colMRP.Text = "MRP";
            this.colMRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMRP.Width = 59;
            // 
            // colVAT
            // 
            this.colVAT.Text = "VAT";
            this.colVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colVAT.Width = 53;
            // 
            // colSpecialPrice
            // 
            this.colSpecialPrice.Text = "Special Price";
            this.colSpecialPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSpecialPrice.Width = 78;
            // 
            // colMC
            // 
            this.colMC.Text = "MC";
            // 
            // colVATCP
            // 
            this.colVATCP.Text = "VAT CP";
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(105, 223);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(92, 20);
            this.dtpEffectiveDate.TabIndex = 15;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(24, 226);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(75, 13);
            this.label59.TabIndex = 14;
            this.label59.Text = "Effective Date";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(56, 16);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(44, 13);
            this.lblCode.TabIndex = 16;
            this.lblCode.Text = "Product";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(44, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "Cost Price";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Location = new System.Drawing.Point(105, 43);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(92, 20);
            this.txtCostPrice.TabIndex = 18;
            this.txtCostPrice.Text = "0";
            this.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostPrice.TextChanged += new System.EventHandler(this.txtCostPrice_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Trade Price";
            // 
            // txtTradePrice
            // 
            this.txtTradePrice.Location = new System.Drawing.Point(105, 69);
            this.txtTradePrice.Name = "txtTradePrice";
            this.txtTradePrice.Size = new System.Drawing.Size(92, 20);
            this.txtTradePrice.TabIndex = 20;
            this.txtTradePrice.Text = "0";
            this.txtTradePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTradePrice.TextChanged += new System.EventHandler(this.txtTradePrice_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "NSP";
            // 
            // txtNSP
            // 
            this.txtNSP.Location = new System.Drawing.Point(105, 95);
            this.txtNSP.Name = "txtNSP";
            this.txtNSP.Size = new System.Drawing.Size(92, 20);
            this.txtNSP.TabIndex = 22;
            this.txtNSP.Text = "0";
            this.txtNSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNSP.TextChanged += new System.EventHandler(this.txtNSP_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "RSP";
            // 
            // txtMRP
            // 
            this.txtMRP.Location = new System.Drawing.Point(105, 145);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(92, 20);
            this.txtMRP.TabIndex = 24;
            this.txtMRP.Text = "0";
            this.txtMRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMRP.TextChanged += new System.EventHandler(this.txtMRP_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "MRP";
            // 
            // txtRSP
            // 
            this.txtRSP.Location = new System.Drawing.Point(105, 119);
            this.txtRSP.Name = "txtRSP";
            this.txtRSP.Size = new System.Drawing.Size(92, 20);
            this.txtRSP.TabIndex = 26;
            this.txtRSP.Text = "0";
            this.txtRSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRSP.TextChanged += new System.EventHandler(this.txtRSP_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "VAT";
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(105, 171);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(92, 20);
            this.txtVAT.TabIndex = 28;
            this.txtVAT.Text = "0";
            this.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVAT.TextChanged += new System.EventHandler(this.txtVAT_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Special Price";
            // 
            // txtSpecialPrice
            // 
            this.txtSpecialPrice.Location = new System.Drawing.Point(105, 197);
            this.txtSpecialPrice.Name = "txtSpecialPrice";
            this.txtSpecialPrice.Size = new System.Drawing.Size(92, 20);
            this.txtSpecialPrice.TabIndex = 30;
            this.txtSpecialPrice.Text = "0";
            this.txtSpecialPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSpecialPrice.TextChanged += new System.EventHandler(this.txtSpecialPrice_TextChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(755, 327);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 31;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(105, 301);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(725, 20);
            this.txtRemarks.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Remarks";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "MC";
            // 
            // txtMC
            // 
            this.txtMC.Location = new System.Drawing.Point(105, 249);
            this.txtMC.Name = "txtMC";
            this.txtMC.Size = new System.Drawing.Size(92, 20);
            this.txtMC.TabIndex = 35;
            this.txtMC.Text = "0";
            this.txtMC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMC.TextChanged += new System.EventHandler(this.txtMC_TextChanged);
            // 
            // ctlProduct
            // 
            this.ctlProduct.Location = new System.Drawing.Point(105, 10);
            this.ctlProduct.Name = "ctlProduct";
            this.ctlProduct.Size = new System.Drawing.Size(424, 24);
            this.ctlProduct.TabIndex = 36;
            this.ctlProduct.ChangeSelection += new System.EventHandler(this.ctlProduct_ChangeSelection);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "VAT Cost Price ";
            // 
            // txtVATCP
            // 
            this.txtVATCP.Location = new System.Drawing.Point(105, 275);
            this.txtVATCP.Name = "txtVATCP";
            this.txtVATCP.Size = new System.Drawing.Size(92, 20);
            this.txtVATCP.TabIndex = 38;
            this.txtVATCP.Text = "0";
            this.txtVATCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVATCP.TextChanged += new System.EventHandler(this.txtVATCP_TextChanged);
            // 
            // frmProductPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 355);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVATCP);
            this.Controls.Add(this.ctlProduct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSpecialPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMRP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTradePrice);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtCostPrice);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.dtpEffectiveDate);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.lvwProductPrice);
            this.Name = "frmProductPrice";
            this.Text = "frmProductPrice";
            this.Load += new System.EventHandler(this.frmProductPrice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProductPrice;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colCostPrice;
        private System.Windows.Forms.ColumnHeader colTradePrice;
        private System.Windows.Forms.ColumnHeader colNSP;
        private System.Windows.Forms.ColumnHeader colRSP;
        private System.Windows.Forms.ColumnHeader colMRP;
        private System.Windows.Forms.ColumnHeader colVAT;
        private ctlProduct ctlProduct1;
        private System.Windows.Forms.DateTimePicker dtpEffectiveDate;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTradePrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMRP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRSP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSpecialPrice;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ColumnHeader colSpecialPrice;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMC;
        private System.Windows.Forms.ColumnHeader colMC;
        private CJ.Control.ctlProduct ctlProduct;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVATCP;
        private System.Windows.Forms.ColumnHeader colVATCP;
    }
}