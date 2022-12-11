namespace CJ.POS.RT
{
    partial class frmPOSCustomerHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOSCustomerHistory));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelephoneNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtConsumerName = new System.Windows.Forms.TextBox();
            this.txtConsumerCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdoCompanyAll = new System.Windows.Forms.RadioButton();
            this.rdoElectronics = new System.Windows.Forms.RadioButton();
            this.rdoMobile = new System.Windows.Forms.RadioButton();
            this.rdoService = new System.Windows.Forms.RadioButton();
            this.rdoSales = new System.Windows.Forms.RadioButton();
            this.rdoTypeAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.txtTranType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(421, 192);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 30);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Set";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtTranType,
            this.txtWarehouse,
            this.txtTranNo,
            this.txtTranDate,
            this.txtProductName,
            this.txtQty,
            this.txtAmount,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvLineItem.Location = new System.Drawing.Point(14, 230);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.ReadOnly = true;
            this.dgvLineItem.Size = new System.Drawing.Size(744, 188);
            this.dgvLineItem.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Telephone";
            // 
            // txtTelephoneNo
            // 
            this.txtTelephoneNo.BackColor = System.Drawing.SystemColors.Info;
            this.txtTelephoneNo.Location = new System.Drawing.Point(317, 103);
            this.txtTelephoneNo.Name = "txtTelephoneNo";
            this.txtTelephoneNo.ReadOnly = true;
            this.txtTelephoneNo.Size = new System.Drawing.Size(163, 21);
            this.txtTelephoneNo.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Info;
            this.txtEmail.Location = new System.Drawing.Point(66, 103);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(168, 21);
            this.txtEmail.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mobile No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Address";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(80, 18);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(195, 21);
            this.txtMobileNo.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.Info;
            this.txtAddress.Location = new System.Drawing.Point(66, 76);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(413, 21);
            this.txtAddress.TabIndex = 27;
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.BackColor = System.Drawing.SystemColors.Info;
            this.txtConsumerName.Location = new System.Drawing.Point(66, 49);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.ReadOnly = true;
            this.txtConsumerName.Size = new System.Drawing.Size(413, 21);
            this.txtConsumerName.TabIndex = 25;
            // 
            // txtConsumerCode
            // 
            this.txtConsumerCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtConsumerCode.Location = new System.Drawing.Point(66, 22);
            this.txtConsumerCode.Name = "txtConsumerCode";
            this.txtConsumerCode.ReadOnly = true;
            this.txtConsumerCode.Size = new System.Drawing.Size(168, 21);
            this.txtConsumerCode.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Code";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(673, 424);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get History";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConsumerCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtConsumerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtTelephoneNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consumer Info";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Outlet";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tran #";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Product Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Tran #";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Date";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Product Description";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 60;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 60;
            // 
            // rdoCompanyAll
            // 
            this.rdoCompanyAll.AutoSize = true;
            this.rdoCompanyAll.Checked = true;
            this.rdoCompanyAll.Location = new System.Drawing.Point(7, 18);
            this.rdoCompanyAll.Name = "rdoCompanyAll";
            this.rdoCompanyAll.Size = new System.Drawing.Size(38, 19);
            this.rdoCompanyAll.TabIndex = 7;
            this.rdoCompanyAll.TabStop = true;
            this.rdoCompanyAll.Text = "All";
            this.rdoCompanyAll.UseVisualStyleBackColor = true;
            this.rdoCompanyAll.CheckedChanged += new System.EventHandler(this.rdoCompanyAll_CheckedChanged);
            // 
            // rdoElectronics
            // 
            this.rdoElectronics.AutoSize = true;
            this.rdoElectronics.Location = new System.Drawing.Point(51, 18);
            this.rdoElectronics.Name = "rdoElectronics";
            this.rdoElectronics.Size = new System.Drawing.Size(85, 19);
            this.rdoElectronics.TabIndex = 8;
            this.rdoElectronics.Text = "Electronics";
            this.rdoElectronics.UseVisualStyleBackColor = true;
            this.rdoElectronics.CheckedChanged += new System.EventHandler(this.rdoElectronics_CheckedChanged);
            // 
            // rdoMobile
            // 
            this.rdoMobile.AutoSize = true;
            this.rdoMobile.Location = new System.Drawing.Point(142, 18);
            this.rdoMobile.Name = "rdoMobile";
            this.rdoMobile.Size = new System.Drawing.Size(63, 19);
            this.rdoMobile.TabIndex = 9;
            this.rdoMobile.Text = "Mobile";
            this.rdoMobile.UseVisualStyleBackColor = true;
            this.rdoMobile.CheckedChanged += new System.EventHandler(this.rdoMobile_CheckedChanged);
            // 
            // rdoService
            // 
            this.rdoService.AutoSize = true;
            this.rdoService.Location = new System.Drawing.Point(112, 16);
            this.rdoService.Name = "rdoService";
            this.rdoService.Size = new System.Drawing.Size(65, 19);
            this.rdoService.TabIndex = 12;
            this.rdoService.Text = "Service";
            this.rdoService.UseVisualStyleBackColor = true;
            this.rdoService.CheckedChanged += new System.EventHandler(this.rdoService_CheckedChanged);
            // 
            // rdoSales
            // 
            this.rdoSales.AutoSize = true;
            this.rdoSales.Location = new System.Drawing.Point(50, 16);
            this.rdoSales.Name = "rdoSales";
            this.rdoSales.Size = new System.Drawing.Size(56, 19);
            this.rdoSales.TabIndex = 11;
            this.rdoSales.Text = "Sales";
            this.rdoSales.UseVisualStyleBackColor = true;
            this.rdoSales.CheckedChanged += new System.EventHandler(this.rdoSales_CheckedChanged);
            // 
            // rdoTypeAll
            // 
            this.rdoTypeAll.AutoSize = true;
            this.rdoTypeAll.Checked = true;
            this.rdoTypeAll.Location = new System.Drawing.Point(6, 16);
            this.rdoTypeAll.Name = "rdoTypeAll";
            this.rdoTypeAll.Size = new System.Drawing.Size(38, 19);
            this.rdoTypeAll.TabIndex = 10;
            this.rdoTypeAll.TabStop = true;
            this.rdoTypeAll.Text = "All";
            this.rdoTypeAll.UseVisualStyleBackColor = true;
            this.rdoTypeAll.CheckedChanged += new System.EventHandler(this.rdoTypeAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoCompanyAll);
            this.groupBox2.Controls.Add(this.rdoElectronics);
            this.groupBox2.Controls.Add(this.rdoMobile);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(204, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 41);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoTypeAll);
            this.groupBox3.Controls.Add(this.rdoSales);
            this.groupBox3.Controls.Add(this.rdoService);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(14, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 41);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Type";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(12, 427);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(84, 17);
            this.lblGrandTotal.TabIndex = 32;
            this.lblGrandTotal.Text = "Grand Total:";
            // 
            // txtTranType
            // 
            this.txtTranType.Frozen = true;
            this.txtTranType.HeaderText = "Type";
            this.txtTranType.Name = "txtTranType";
            this.txtTranType.ReadOnly = true;
            this.txtTranType.Width = 60;
            // 
            // txtWarehouse
            // 
            this.txtWarehouse.Frozen = true;
            this.txtWarehouse.HeaderText = "Outlet";
            this.txtWarehouse.Name = "txtWarehouse";
            this.txtWarehouse.ReadOnly = true;
            this.txtWarehouse.Width = 70;
            // 
            // txtTranNo
            // 
            this.txtTranNo.HeaderText = "Tran #";
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.ReadOnly = true;
            this.txtTranNo.Width = 110;
            // 
            // txtTranDate
            // 
            this.txtTranDate.HeaderText = "Date";
            this.txtTranDate.Name = "txtTranDate";
            this.txtTranDate.ReadOnly = true;
            // 
            // txtProductName
            // 
            this.txtProductName.HeaderText = "Product Description";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Width = 240;
            // 
            // txtQty
            // 
            this.txtQty.HeaderText = "Qty";
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Width = 45;
            // 
            // txtAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.txtAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtAmount.HeaderText = "Amount";
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Consumer Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Address";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 160;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mobile#";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Telephone#";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Email";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // frmPOSCustomerHistory
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 457);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPOSCustomerHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer History";
            this.Load += new System.EventHandler(this.frmPOSCustomerHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
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
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelephoneNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtConsumerName;
        private System.Windows.Forms.TextBox txtConsumerCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.RadioButton rdoCompanyAll;
        private System.Windows.Forms.RadioButton rdoElectronics;
        private System.Windows.Forms.RadioButton rdoMobile;
        private System.Windows.Forms.RadioButton rdoService;
        private System.Windows.Forms.RadioButton rdoSales;
        private System.Windows.Forms.RadioButton rdoTypeAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}