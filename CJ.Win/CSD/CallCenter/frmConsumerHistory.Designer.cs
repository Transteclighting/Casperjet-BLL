namespace CJ.Win.CSD.CallCenter
{
    partial class frmConsumerHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumerHistory));
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelephoneNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlternativeCellNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtConsumerName = new System.Windows.Forms.TextBox();
            this.txtConsumerCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSalesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chkVerified = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(701, 372);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Telephone No";
            // 
            // txtTelephoneNo
            // 
            this.txtTelephoneNo.Location = new System.Drawing.Point(502, 88);
            this.txtTelephoneNo.Name = "txtTelephoneNo";
            this.txtTelephoneNo.Size = new System.Drawing.Size(274, 20);
            this.txtTelephoneNo.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(68, 88);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(273, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Alternative Cell No";
            // 
            // txtAlternativeCellNo
            // 
            this.txtAlternativeCellNo.Location = new System.Drawing.Point(502, 10);
            this.txtAlternativeCellNo.Name = "txtAlternativeCellNo";
            this.txtAlternativeCellNo.Size = new System.Drawing.Size(274, 20);
            this.txtAlternativeCellNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mobile No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Enabled = false;
            this.txtMobileNo.Location = new System.Drawing.Point(68, 10);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(273, 20);
            this.txtMobileNo.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(68, 62);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(708, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.Location = new System.Drawing.Point(502, 36);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(274, 20);
            this.txtConsumerName.TabIndex = 7;
            // 
            // txtConsumerCode
            // 
            this.txtConsumerCode.Location = new System.Drawing.Point(68, 36);
            this.txtConsumerCode.Name = "txtConsumerCode";
            this.txtConsumerCode.Size = new System.Drawing.Size(273, 20);
            this.txtConsumerCode.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Consumer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Code";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCompany,
            this.txtTranType,
            this.txtWarehouse,
            this.txtSalesType,
            this.txtTranNo,
            this.txtTranDate,
            this.txtProductCode,
            this.txtProductName,
            this.txtQty,
            this.txtAmount});
            this.dgvLineItem.Location = new System.Drawing.Point(12, 143);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.ReadOnly = true;
            this.dgvLineItem.Size = new System.Drawing.Size(764, 223);
            this.dgvLineItem.TabIndex = 14;
            // 
            // txtCompany
            // 
            this.txtCompany.HeaderText = "Company";
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Width = 60;
            // 
            // txtTranType
            // 
            this.txtTranType.HeaderText = "Tran Type";
            this.txtTranType.Name = "txtTranType";
            this.txtTranType.ReadOnly = true;
            this.txtTranType.Width = 60;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.HeaderText = "Warehouse";
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.ReadOnly = true;
            this.txtWarehouse.Width = 70;
            // 
            // txtSalesType
            // 
            this.txtSalesType.HeaderText = "SalesType";
            this.txtSalesType.Name = "txtSalesType";
            this.txtSalesType.ReadOnly = true;
            this.txtSalesType.Width = 60;
            // 
            // txtTranNo
            // 
            this.txtTranNo.HeaderText = "Tran No";
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.ReadOnly = true;
            this.txtTranNo.Width = 70;
            // 
            // txtTranDate
            // 
            this.txtTranDate.HeaderText = "Tran Date";
            this.txtTranDate.Name = "txtTranDate";
            this.txtTranDate.ReadOnly = true;
            this.txtTranDate.Width = 70;
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Width = 60;
            // 
            // txtProductName
            // 
            this.txtProductName.HeaderText = "Product Name";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Width = 150;
            // 
            // txtQty
            // 
            this.txtQty.HeaderText = "Qty";
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Width = 60;
            // 
            // txtAmount
            // 
            this.txtAmount.HeaderText = "Amount";
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Width = 60;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(701, 114);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chkVerified
            // 
            this.chkVerified.AutoSize = true;
            this.chkVerified.Location = new System.Drawing.Point(68, 118);
            this.chkVerified.Name = "chkVerified";
            this.chkVerified.Size = new System.Drawing.Size(61, 17);
            this.chkVerified.TabIndex = 17;
            this.chkVerified.Text = "Verified";
            this.chkVerified.UseVisualStyleBackColor = true;
            // 
            // frmConsumerHistory
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 399);
            this.Controls.Add(this.chkVerified);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTelephoneNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAlternativeCellNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.txtConsumerCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsumerHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConsumerHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelephoneNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlternativeCellNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtConsumerName;
        private System.Windows.Forms.TextBox txtConsumerCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSalesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAmount;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkVerified;
    }
}