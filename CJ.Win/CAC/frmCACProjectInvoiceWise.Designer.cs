namespace CJ.Win.CAC
{
    partial class frmCACProjectInvoiceWise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProjectInvoiceWise));
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvAmount = new System.Windows.Forms.TextBox();
            this.btnAddInvoiceList = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtInvNo = new System.Windows.Forms.TextBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.dtInvDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvCACProjectInvoiceWise = new System.Windows.Forms.DataGridView();
            this.txtInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DtInvoiceDate = new CJ.Win.Control.CalenderControl();
            this.txtInvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInvoiceRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calenderControl1 = new CJ.Win.Control.CalenderControl();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpInvoiceMap = new System.Windows.Forms.GroupBox();
            this.lvwInvoiceMap = new System.Windows.Forms.ListView();
            this.colInvNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label25 = new System.Windows.Forms.Label();
            this.txtTotalSecurityAmount = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACProjectInvoiceWise)).BeginInit();
            this.grpInvoiceMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtTotalAmount.Location = new System.Drawing.Point(396, 231);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(116, 23);
            this.txtTotalAmount.TabIndex = 16;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(351, 419);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 24);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(306, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Total Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(30, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Amount";
            // 
            // txtInvAmount
            // 
            this.txtInvAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtInvAmount.Location = new System.Drawing.Point(84, 59);
            this.txtInvAmount.Name = "txtInvAmount";
            this.txtInvAmount.ReadOnly = true;
            this.txtInvAmount.Size = new System.Drawing.Size(157, 23);
            this.txtInvAmount.TabIndex = 2;
            // 
            // btnAddInvoiceList
            // 
            this.btnAddInvoiceList.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnAddInvoiceList.Location = new System.Drawing.Point(396, 87);
            this.btnAddInvoiceList.Name = "btnAddInvoiceList";
            this.btnAddInvoiceList.Size = new System.Drawing.Size(61, 24);
            this.btnAddInvoiceList.TabIndex = 13;
            this.btnAddInvoiceList.Text = "Add";
            this.btnAddInvoiceList.UseVisualStyleBackColor = true;
            this.btnAddInvoiceList.Click += new System.EventHandler(this.btnAddInvoiceList_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblNumber.Location = new System.Drawing.Point(15, 34);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(61, 15);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "Invoice #:";
            // 
            // txtInvNo
            // 
            this.txtInvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtInvNo.Location = new System.Drawing.Point(84, 30);
            this.txtInvNo.Name = "txtInvNo";
            this.txtInvNo.Size = new System.Drawing.Size(157, 23);
            this.txtInvNo.TabIndex = 3;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lbldate.Location = new System.Drawing.Point(247, 33);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(37, 15);
            this.lbldate.TabIndex = 4;
            this.lbldate.Text = "Date:";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGo.Location = new System.Drawing.Point(396, 30);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(61, 24);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Get";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(435, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 24);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(288, 30);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(84, 23);
            this.dtDate.TabIndex = 11;
            // 
            // dtInvDate
            // 
            this.dtInvDate.CustomFormat = "dd-MMM-yyyy";
            this.dtInvDate.Enabled = false;
            this.dtInvDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtInvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvDate.Location = new System.Drawing.Point(288, 30);
            this.dtInvDate.Name = "dtInvDate";
            this.dtInvDate.Size = new System.Drawing.Size(102, 23);
            this.dtInvDate.TabIndex = 5;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(84, 88);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(306, 23);
            this.txtRemarks.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(25, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Remarks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Project Code:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCode.Location = new System.Drawing.Point(91, 9);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(13, 15);
            this.lblCode.TabIndex = 67;
            this.lblCode.Text = "?";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblName.Location = new System.Drawing.Point(256, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(13, 15);
            this.lblName.TabIndex = 69;
            this.lblName.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(170, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 68;
            this.label6.Text = "Project Name:";
            // 
            // dgvCACProjectInvoiceWise
            // 
            this.dgvCACProjectInvoiceWise.AllowUserToAddRows = false;
            this.dgvCACProjectInvoiceWise.AllowUserToResizeColumns = false;
            this.dgvCACProjectInvoiceWise.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCACProjectInvoiceWise.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCACProjectInvoiceWise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCACProjectInvoiceWise.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtInvoice,
            this.DtInvoiceDate,
            this.txtInvoiceAmount,
            this.txtInvoiceRemarks});
            this.dgvCACProjectInvoiceWise.Location = new System.Drawing.Point(12, 117);
            this.dgvCACProjectInvoiceWise.Name = "dgvCACProjectInvoiceWise";
            this.dgvCACProjectInvoiceWise.Size = new System.Drawing.Size(500, 108);
            this.dgvCACProjectInvoiceWise.TabIndex = 70;
            this.dgvCACProjectInvoiceWise.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCACProjectInvoiceWise_CellValueChanged);
            this.dgvCACProjectInvoiceWise.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCACProjectInvoiceWise_RowsRemoved);
            // 
            // txtInvoice
            // 
            this.txtInvoice.HeaderText = "Invoice #";
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Width = 120;
            // 
            // DtInvoiceDate
            // 
            this.DtInvoiceDate.HeaderText = "Date";
            this.DtInvoiceDate.Name = "DtInvoiceDate";
            this.DtInvoiceDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DtInvoiceDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.HeaderText = "Amount";
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Width = 120;
            // 
            // txtInvoiceRemarks
            // 
            this.txtInvoiceRemarks.HeaderText = "Remarks";
            this.txtInvoiceRemarks.Name = "txtInvoiceRemarks";
            this.txtInvoiceRemarks.Width = 250;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "SupplierID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Invoice #";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 250;
            // 
            // calenderControl1
            // 
            this.calenderControl1.HeaderText = "Date";
            this.calenderControl1.Name = "calenderControl1";
            this.calenderControl1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calenderControl1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calenderControl1.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Date";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 250;
            // 
            // grpInvoiceMap
            // 
            this.grpInvoiceMap.Controls.Add(this.lvwInvoiceMap);
            this.grpInvoiceMap.Controls.Add(this.label25);
            this.grpInvoiceMap.Controls.Add(this.txtTotalSecurityAmount);
            this.grpInvoiceMap.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F);
            this.grpInvoiceMap.Location = new System.Drawing.Point(12, 260);
            this.grpInvoiceMap.Name = "grpInvoiceMap";
            this.grpInvoiceMap.Size = new System.Drawing.Size(500, 124);
            this.grpInvoiceMap.TabIndex = 80;
            this.grpInvoiceMap.TabStop = false;
            this.grpInvoiceMap.Text = "Invoice Map";
            // 
            // lvwInvoiceMap
            // 
            this.lvwInvoiceMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInvoiceMap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvNo,
            this.colDate,
            this.colAmount});
            this.lvwInvoiceMap.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwInvoiceMap.FullRowSelect = true;
            this.lvwInvoiceMap.GridLines = true;
            this.lvwInvoiceMap.Location = new System.Drawing.Point(6, 20);
            this.lvwInvoiceMap.Name = "lvwInvoiceMap";
            this.lvwInvoiceMap.Size = new System.Drawing.Size(488, 98);
            this.lvwInvoiceMap.TabIndex = 12;
            this.lvwInvoiceMap.UseCompatibleStateImageBehavior = false;
            this.lvwInvoiceMap.View = System.Windows.Forms.View.Details;
            this.lvwInvoiceMap.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwInvoiceMap_ColumnWidthChanging);
            // 
            // colInvNo
            // 
            this.colInvNo.Text = "Invoice #";
            this.colInvNo.Width = 120;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 120;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(342, 172);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(36, 14);
            this.label25.TabIndex = 10;
            this.label25.Text = "Total:";
            // 
            // txtTotalSecurityAmount
            // 
            this.txtTotalSecurityAmount.Location = new System.Drawing.Point(386, 169);
            this.txtTotalSecurityAmount.Name = "txtTotalSecurityAmount";
            this.txtTotalSecurityAmount.ReadOnly = true;
            this.txtTotalSecurityAmount.Size = new System.Drawing.Size(90, 21);
            this.txtTotalSecurityAmount.TabIndex = 11;
            this.txtTotalSecurityAmount.Text = "0";
            this.txtTotalSecurityAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtTotal.Location = new System.Drawing.Point(396, 387);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(110, 23);
            this.txtTotal.TabIndex = 82;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(354, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 81;
            this.label5.Text = "Total";
            // 
            // frmCACProjectInvoiceWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 452);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpInvoiceMap);
            this.Controls.Add(this.dgvCACProjectInvoiceWise);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtInvDate);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInvAmount);
            this.Controls.Add(this.btnAddInvoiceList);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.txtInvNo);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProjectInvoiceWise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAC Project Invoice Wise";
            this.Load += new System.EventHandler(this.frmCACProjectInvoiceWise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACProjectInvoiceWise)).EndInit();
            this.grpInvoiceMap.ResumeLayout(false);
            this.grpInvoiceMap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInvAmount;
        private System.Windows.Forms.Button btnAddInvoiceList;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtInvNo;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.DateTimePicker dtInvDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvCACProjectInvoiceWise;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Control.CalenderControl calenderControl1;
        private System.Windows.Forms.GroupBox grpInvoiceMap;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTotalSecurityAmount;
        private System.Windows.Forms.ListView lvwInvoiceMap;
        private System.Windows.Forms.ColumnHeader colInvNo;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInvoice;
        private Control.CalenderControl DtInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtInvoiceRemarks;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
    }
}