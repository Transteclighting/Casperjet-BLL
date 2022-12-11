namespace CJ.POS.Invoice
{
    partial class frmRetailInvoiceReverse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetailInvoiceReverse));
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dicscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFreeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDiscounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtReverseReason = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btReverse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRetailSalesAmt = new System.Windows.Forms.Label();
            this.lbChange = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblInvoiceAmount = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblConsumerName = new System.Windows.Forms.Label();
            this.lblConsumerAddress = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.ProductName,
            this.UnitPrice,
            this.Dicscount,
            this.ColQty,
            this.ColFreeQty,
            this.ProductID,
            this.txtCharges,
            this.txtDiscounts,
            this.txtCP,
            this.txtVAT,
            this.txtTP});
            this.dgvLineItem.Location = new System.Drawing.Point(12, 151);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.ReadOnly = true;
            this.dgvLineItem.Size = new System.Drawing.Size(775, 195);
            this.dgvLineItem.TabIndex = 24;
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Width = 80;
            // 
            // ProductName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProductName.Frozen = true;
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 220;
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.UnitPrice.Frozen = true;
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 78;
            // 
            // Dicscount
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Dicscount.DefaultCellStyle = dataGridViewCellStyle4;
            this.Dicscount.Frozen = true;
            this.Dicscount.HeaderText = "Discount";
            this.Dicscount.Name = "Dicscount";
            this.Dicscount.ReadOnly = true;
            this.Dicscount.Width = 70;
            // 
            // ColQty
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColQty.Frozen = true;
            this.ColQty.HeaderText = "Sale Qty";
            this.ColQty.Name = "ColQty";
            this.ColQty.ReadOnly = true;
            this.ColQty.Width = 73;
            // 
            // ColFreeQty
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColFreeQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColFreeQty.Frozen = true;
            this.ColFreeQty.HeaderText = "Free Qty";
            this.ColFreeQty.Name = "ColFreeQty";
            this.ColFreeQty.ReadOnly = true;
            this.ColFreeQty.Width = 73;
            // 
            // ProductID
            // 
            this.ProductID.Frozen = true;
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // txtCharges
            // 
            this.txtCharges.HeaderText = "Charges";
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.ReadOnly = true;
            this.txtCharges.Width = 70;
            // 
            // txtDiscounts
            // 
            this.txtDiscounts.HeaderText = "Discounts";
            this.txtDiscounts.Name = "txtDiscounts";
            this.txtDiscounts.ReadOnly = true;
            this.txtDiscounts.Width = 70;
            // 
            // txtCP
            // 
            this.txtCP.HeaderText = "CP";
            this.txtCP.Name = "txtCP";
            this.txtCP.ReadOnly = true;
            this.txtCP.Visible = false;
            // 
            // txtVAT
            // 
            this.txtVAT.HeaderText = "VAT";
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.ReadOnly = true;
            this.txtVAT.Visible = false;
            // 
            // txtTP
            // 
            this.txtTP.HeaderText = "TP";
            this.txtTP.Name = "txtTP";
            this.txtTP.ReadOnly = true;
            this.txtTP.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Invoice Date :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Consumer Name :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Mobile No :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(72, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Email :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Consumer Address :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(45, 55);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 13);
            this.label22.TabIndex = 20;
            this.label22.Text = "Total Discount :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Total Charge :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(458, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(108, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Retail Sales Amount :";
            // 
            // txtReverseReason
            // 
            this.txtReverseReason.Location = new System.Drawing.Point(97, 352);
            this.txtReverseReason.Name = "txtReverseReason";
            this.txtReverseReason.Size = new System.Drawing.Size(690, 20);
            this.txtReverseReason.TabIndex = 26;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 355);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 13);
            this.label24.TabIndex = 25;
            this.label24.Text = "Reverse Reason:";
            // 
            // btReverse
            // 
            this.btReverse.Location = new System.Drawing.Point(630, 378);
            this.btReverse.Name = "btReverse";
            this.btReverse.Size = new System.Drawing.Size(75, 26);
            this.btReverse.TabIndex = 27;
            this.btReverse.Text = "Reverse";
            this.btReverse.UseVisualStyleBackColor = true;
            this.btReverse.Click += new System.EventHandler(this.btReverse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Invoice Amount :";
            // 
            // lblRetailSalesAmt
            // 
            this.lblRetailSalesAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetailSalesAmt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRetailSalesAmt.Location = new System.Drawing.Point(566, 27);
            this.lblRetailSalesAmt.Name = "lblRetailSalesAmt";
            this.lblRetailSalesAmt.Size = new System.Drawing.Size(207, 13);
            this.lblRetailSalesAmt.TabIndex = 13;
            this.lblRetailSalesAmt.Text = "?";
            this.lblRetailSalesAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbChange
            // 
            this.lbChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChange.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbChange.Location = new System.Drawing.Point(566, 45);
            this.lbChange.Name = "lbChange";
            this.lbChange.Size = new System.Drawing.Size(207, 13);
            this.lbChange.TabIndex = 15;
            this.lbChange.Text = "?";
            this.lbChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDiscount.Location = new System.Drawing.Point(127, 55);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(207, 13);
            this.lblDiscount.TabIndex = 21;
            this.lblDiscount.Text = "?";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceAmount
            // 
            this.lblInvoiceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceAmount.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInvoiceAmount.Location = new System.Drawing.Point(128, 75);
            this.lblInvoiceAmount.Name = "lblInvoiceAmount";
            this.lblInvoiceAmount.Size = new System.Drawing.Size(206, 13);
            this.lblInvoiceAmount.TabIndex = 23;
            this.lblInvoiceAmount.Text = "?";
            this.lblInvoiceAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInvoiceNo.Location = new System.Drawing.Point(115, 15);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(248, 13);
            this.lblInvoiceNo.TabIndex = 1;
            this.lblInvoiceNo.Text = "?";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblInvoiceDate.Location = new System.Drawing.Point(115, 34);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(248, 13);
            this.lblInvoiceDate.TabIndex = 3;
            this.lblInvoiceDate.Text = "?";
            this.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConsumerName
            // 
            this.lblConsumerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumerName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConsumerName.Location = new System.Drawing.Point(115, 55);
            this.lblConsumerName.Name = "lblConsumerName";
            this.lblConsumerName.Size = new System.Drawing.Size(248, 13);
            this.lblConsumerName.TabIndex = 5;
            this.lblConsumerName.Text = "?";
            this.lblConsumerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConsumerAddress
            // 
            this.lblConsumerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumerAddress.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblConsumerAddress.Location = new System.Drawing.Point(115, 74);
            this.lblConsumerAddress.Name = "lblConsumerAddress";
            this.lblConsumerAddress.Size = new System.Drawing.Size(248, 13);
            this.lblConsumerAddress.TabIndex = 7;
            this.lblConsumerAddress.Text = "?";
            this.lblConsumerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblEmail.Location = new System.Drawing.Point(115, 93);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(248, 13);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "?";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMobile
            // 
            this.lblMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMobile.Location = new System.Drawing.Point(115, 113);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(248, 13);
            this.lblMobile.TabIndex = 11;
            this.lblMobile.Text = "?";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(712, 378);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDiscount);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.lblInvoiceAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(439, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 135);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMobile);
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.Controls.Add(this.lblConsumerAddress);
            this.groupBox2.Controls.Add(this.lblConsumerName);
            this.groupBox2.Controls.Add(this.lblInvoiceDate);
            this.groupBox2.Controls.Add(this.lblInvoiceNo);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(11, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 134);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // frmRetailInvoiceReverse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 412);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbChange);
            this.Controls.Add(this.lblRetailSalesAmt);
            this.Controls.Add(this.btReverse);
            this.Controls.Add(this.txtReverseReason);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRetailInvoiceReverse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Reverse";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtReverseReason;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btReverse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRetailSalesAmt;
        private System.Windows.Forms.Label lbChange;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblInvoiceAmount;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblConsumerName;
        private System.Windows.Forms.Label lblConsumerAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dicscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFreeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDiscounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTP;
    }
}