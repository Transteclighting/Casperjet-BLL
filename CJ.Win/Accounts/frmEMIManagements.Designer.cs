namespace CJ.Win.Accounts
{
    partial class frmEMIManagements
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
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.label19 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colPaymentMode = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.colInvoiceDate = new System.Windows.Forms.ColumnHeader();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.colInvoiceNo = new System.Windows.Forms.ColumnHeader();
            this.lvwEMIInfo = new System.Windows.Forms.ListView();
            this.colShowroom = new System.Windows.Forms.ColumnHeader();
            this.colAmount = new System.Windows.Forms.ColumnHeader();
            this.colBankName = new System.Windows.Forms.ColumnHeader();
            this.colCardType = new System.Windows.Forms.ColumnHeader();
            this.colPosMachineName = new System.Windows.Forms.ColumnHeader();
            this.colNoOfInstallment = new System.Windows.Forms.ColumnHeader();
            this.colInstrumentNo = new System.Windows.Forms.ColumnHeader();
            this.colInstrumentDate = new System.Windows.Forms.ColumnHeader();
            this.colCardCategory = new System.Windows.Forms.ColumnHeader();
            this.cmbShowroom = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTranNo = new System.Windows.Forms.Label();
            this.txtTranNo = new System.Windows.Forms.TextBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 178;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 382);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 13);
            this.label19.TabIndex = 87;
            this.label19.Text = "Send_To_Bank";
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnGetData.Location = new System.Drawing.Point(540, 102);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(79, 28);
            this.btnGetData.TabIndex = 78;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(707, 346);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 28);
            this.btnClose.TabIndex = 83;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(707, 136);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 28);
            this.btnAdd.TabIndex = 79;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.Text = "Payment Mode";
            this.colPaymentMode.Width = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "To";
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colInvoiceDate.Width = 76;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(8, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Salmon;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(109, 382);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 86;
            this.label20.Text = "Pending";
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "InvoiceNo";
            this.colInvoiceNo.Width = 87;
            // 
            // lvwEMIInfo
            // 
            this.lvwEMIInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEMIInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShowroom,
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colAmount,
            this.colPaymentMode,
            this.colBankName,
            this.colCardType,
            this.colPosMachineName,
            this.colNoOfInstallment,
            this.colInstrumentNo,
            this.colInstrumentDate,
            this.colCardCategory,
            this.colStatus});
            this.lvwEMIInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwEMIInfo.FullRowSelect = true;
            this.lvwEMIInfo.GridLines = true;
            this.lvwEMIInfo.HideSelection = false;
            this.lvwEMIInfo.Location = new System.Drawing.Point(12, 136);
            this.lvwEMIInfo.MultiSelect = false;
            this.lvwEMIInfo.Name = "lvwEMIInfo";
            this.lvwEMIInfo.Size = new System.Drawing.Size(682, 238);
            this.lvwEMIInfo.TabIndex = 84;
            this.lvwEMIInfo.UseCompatibleStateImageBehavior = false;
            this.lvwEMIInfo.View = System.Windows.Forms.View.Details;
            // 
            // colShowroom
            // 
            this.colShowroom.Text = "Showroom";
            this.colShowroom.Width = 66;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            // 
            // colBankName
            // 
            this.colBankName.Text = "BankName";
            this.colBankName.Width = 86;
            // 
            // colCardType
            // 
            this.colCardType.Text = "Card Type";
            this.colCardType.Width = 62;
            // 
            // colPosMachineName
            // 
            this.colPosMachineName.Text = "PosMachine";
            this.colPosMachineName.Width = 74;
            // 
            // colNoOfInstallment
            // 
            this.colNoOfInstallment.Text = "NoOfInstallment";
            this.colNoOfInstallment.Width = 65;
            // 
            // colInstrumentNo
            // 
            this.colInstrumentNo.Text = "InstrumentNo";
            // 
            // colInstrumentDate
            // 
            this.colInstrumentDate.Text = "InstrumentDate";
            // 
            // colCardCategory
            // 
            this.colCardCategory.Text = "CardCategory";
            // 
            // cmbShowroom
            // 
            this.cmbShowroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShowroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShowroom.FormattingEnabled = true;
            this.cmbShowroom.Location = new System.Drawing.Point(360, 78);
            this.cmbShowroom.Name = "cmbShowroom";
            this.cmbShowroom.Size = new System.Drawing.Size(163, 21);
            this.cmbShowroom.TabIndex = 77;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(297, 81);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 13);
            this.lblStatus.TabIndex = 76;
            this.lblStatus.Text = "Showroom";
            // 
            // lblTranNo
            // 
            this.lblTranNo.AutoSize = true;
            this.lblTranNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranNo.Location = new System.Drawing.Point(20, 82);
            this.lblTranNo.Name = "lblTranNo";
            this.lblTranNo.Size = new System.Drawing.Size(59, 13);
            this.lblTranNo.TabIndex = 74;
            this.lblTranNo.Text = "Invoice No";
            // 
            // txtTranNo
            // 
            this.txtTranNo.Location = new System.Drawing.Point(85, 79);
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.Size = new System.Drawing.Size(196, 20);
            this.txtTranNo.TabIndex = 75;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(294, 37);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(158, 20);
            this.dtToDate.TabIndex = 73;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(65, 37);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(166, 20);
            this.dtFromDate.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Location = new System.Drawing.Point(23, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 60);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(360, 107);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(163, 21);
            this.cmbStatus.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Status";
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(85, 107);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(196, 21);
            this.cmbBank.TabIndex = 93;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "Bank Name";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(707, 170);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 28);
            this.btnDelete.TabIndex = 94;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmEMIManagements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 401);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lvwEMIInfo);
            this.Controls.Add(this.cmbShowroom);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTranNo);
            this.Controls.Add(this.txtTranNo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEMIManagements";
            this.Text = "frmEMIManagements";
            this.Load += new System.EventHandler(this.frmEMIManagements_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colPaymentMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ListView lvwEMIInfo;
        private System.Windows.Forms.ComboBox cmbShowroom;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTranNo;
        private System.Windows.Forms.TextBox txtTranNo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader colShowroom;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colBankName;
        private System.Windows.Forms.ColumnHeader colCardType;
        private System.Windows.Forms.ColumnHeader colPosMachineName;
        private System.Windows.Forms.ColumnHeader colNoOfInstallment;
        private System.Windows.Forms.ColumnHeader colInstrumentNo;
        private System.Windows.Forms.ColumnHeader colInstrumentDate;
        private System.Windows.Forms.ColumnHeader colCardCategory;
        private System.Windows.Forms.Button btnDelete;
    }
}