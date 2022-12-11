namespace CJ.Win.BEIL
{
    partial class frmProductionLotDelivery
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvChallanItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArticleDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQCPassQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChallanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtChallanDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLotType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtChallanQty = new System.Windows.Forms.TextBox();
            this.txtQCPassQty = new System.Windows.Forms.TextBox();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanItem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(633, 253);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(82, 20);
            this.txtAmount.TabIndex = 30;
            this.txtAmount.Text = "0";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(65, 331);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(651, 20);
            this.txtRemarks.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Remarks";
            // 
            // dgvChallanItem
            // 
            this.dgvChallanItem.AllowUserToAddRows = false;
            this.dgvChallanItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChallanItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtArticleDetails,
            this.ColUnitPrice,
            this.ColQCPassQty,
            this.ColChallanQty,
            this.ColAmount,
            this.ColProductID});
            this.dgvChallanItem.Location = new System.Drawing.Point(12, 80);
            this.dgvChallanItem.Name = "dgvChallanItem";
            this.dgvChallanItem.Size = new System.Drawing.Size(703, 167);
            this.dgvChallanItem.TabIndex = 27;
            this.dgvChallanItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChallanItem_CellValueChanged);
            this.dgvChallanItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvChallanItem_RowsRemoved);
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.HeaderText = "ProductCode";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 90;
            // 
            // txtArticleDetails
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtArticleDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtArticleDetails.HeaderText = "Product Details";
            this.txtArticleDetails.Name = "txtArticleDetails";
            this.txtArticleDetails.Width = 270;
            // 
            // ColUnitPrice
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColUnitPrice.HeaderText = "Unit Price";
            this.ColUnitPrice.Name = "ColUnitPrice";
            this.ColUnitPrice.Width = 70;
            // 
            // ColQCPassQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColQCPassQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColQCPassQty.HeaderText = "QC Pass Qty";
            this.ColQCPassQty.Name = "ColQCPassQty";
            this.ColQCPassQty.Width = 70;
            // 
            // ColChallanQty
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.ColChallanQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColChallanQty.HeaderText = "Challan Qty";
            this.ColChallanQty.Name = "ColChallanQty";
            this.ColChallanQty.Width = 70;
            // 
            // ColAmount
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColAmount.HeaderText = "Amount";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.Width = 90;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ProductID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(560, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtChallanDate
            // 
            this.dtChallanDate.CustomFormat = "dd-MMM-yyyy";
            this.dtChallanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChallanDate.Location = new System.Drawing.Point(316, 12);
            this.dtChallanDate.Name = "dtChallanDate";
            this.dtChallanDate.Size = new System.Drawing.Size(133, 20);
            this.dtChallanDate.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Challan Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Type:";
            // 
            // cmbLotType
            // 
            this.cmbLotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLotType.FormattingEnabled = true;
            this.cmbLotType.Location = new System.Drawing.Point(64, 12);
            this.cmbLotType.Name = "cmbLotType";
            this.cmbLotType.Size = new System.Drawing.Size(162, 21);
            this.cmbLotType.TabIndex = 22;
            this.cmbLotType.SelectedIndexChanged += new System.EventHandler(this.cmbLotType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Customer:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(64, 39);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(385, 21);
            this.cmbCustomer.TabIndex = 20;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(641, 357);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtChallanQty
            // 
            this.txtChallanQty.Location = new System.Drawing.Point(560, 253);
            this.txtChallanQty.Name = "txtChallanQty";
            this.txtChallanQty.ReadOnly = true;
            this.txtChallanQty.Size = new System.Drawing.Size(67, 20);
            this.txtChallanQty.TabIndex = 31;
            this.txtChallanQty.Text = "0";
            this.txtChallanQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQCPassQty
            // 
            this.txtQCPassQty.Location = new System.Drawing.Point(487, 253);
            this.txtQCPassQty.Name = "txtQCPassQty";
            this.txtQCPassQty.ReadOnly = true;
            this.txtQCPassQty.Size = new System.Drawing.Size(67, 20);
            this.txtQCPassQty.TabIndex = 32;
            this.txtQCPassQty.Text = "0";
            this.txtQCPassQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Location = new System.Drawing.Point(634, 305);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(82, 20);
            this.txtNetAmount.TabIndex = 33;
            this.txtNetAmount.Text = "0";
            this.txtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(633, 279);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(82, 20);
            this.txtDiscount.TabIndex = 34;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(575, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Discount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(562, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Net Amount:";
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAmountInWord.AutoSize = true;
            this.lblAmountInWord.Location = new System.Drawing.Point(134, 363);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(35, 13);
            this.lblAmountInWord.TabIndex = 175;
            this.lblAmountInWord.Text = "label6";
            this.lblAmountInWord.Visible = false;
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(9, 363);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(119, 13);
            this.label50.TabIndex = 174;
            this.label50.Text = "Net Amount ( In Word) :";
            // 
            // frmProductionLotDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 389);
            this.Controls.Add(this.lblAmountInWord);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtNetAmount);
            this.Controls.Add(this.txtQCPassQty);
            this.Controls.Add(this.txtChallanQty);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvChallanItem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtChallanDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLotType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.btnClose);
            this.Name = "frmProductionLotDelivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductionLotDelivery";
            this.Load += new System.EventHandler(this.frmProductionLotDelivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvChallanItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtChallanDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLotType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtChallanQty;
        private System.Windows.Forms.TextBox txtQCPassQty;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAmountInWord;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArticleDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQCPassQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChallanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
    }
}