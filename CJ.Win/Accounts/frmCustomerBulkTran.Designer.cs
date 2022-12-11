namespace CJ.Win.Accounts
{
    partial class frmCustomerBulkTran
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
            this.lblRemarks = new System.Windows.Forms.Label();
            this.dtInstrudate = new System.Windows.Forms.DateTimePicker();
            this.lblInsDate = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.cmbCustTranType = new System.Windows.Forms.ComboBox();
            this.lblInsType = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtXLFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.pbInvoice = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(12, 48);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 15;
            this.lblRemarks.Text = "Remarks";
            // 
            // dtInstrudate
            // 
            this.dtInstrudate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInstrudate.Location = new System.Drawing.Point(470, 15);
            this.dtInstrudate.Name = "dtInstrudate";
            this.dtInstrudate.Size = new System.Drawing.Size(106, 20);
            this.dtInstrudate.TabIndex = 14;
            // 
            // lblInsDate
            // 
            this.lblInsDate.AutoSize = true;
            this.lblInsDate.Location = new System.Drawing.Point(438, 18);
            this.lblInsDate.Name = "lblInsDate";
            this.lblInsDate.Size = new System.Drawing.Size(30, 13);
            this.lblInsDate.TabIndex = 13;
            this.lblInsDate.Text = "Date";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(63, 46);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(516, 20);
            this.txtRemarks.TabIndex = 16;
            // 
            // cmbCustTranType
            // 
            this.cmbCustTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustTranType.FormattingEnabled = true;
            this.cmbCustTranType.Location = new System.Drawing.Point(63, 14);
            this.cmbCustTranType.Name = "cmbCustTranType";
            this.cmbCustTranType.Size = new System.Drawing.Size(352, 21);
            this.cmbCustTranType.TabIndex = 18;
            // 
            // lblInsType
            // 
            this.lblInsType.AutoSize = true;
            this.lblInsType.Location = new System.Drawing.Point(8, 17);
            this.lblInsType.Name = "lblInsType";
            this.lblInsType.Size = new System.Drawing.Size(56, 13);
            this.lblInsType.TabIndex = 17;
            this.lblInsType.Text = "Tran Type";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(440, 87);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtXLFilePath
            // 
            this.txtXLFilePath.Location = new System.Drawing.Point(80, 89);
            this.txtXLFilePath.Name = "txtXLFilePath";
            this.txtXLFilePath.ReadOnly = true;
            this.txtXLFilePath.Size = new System.Drawing.Size(354, 20);
            this.txtXLFilePath.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "XL File Paht";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(521, 87);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 23;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.AllowUserToOrderColumns = true;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Location = new System.Drawing.Point(12, 116);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.ReadOnly = true;
            this.dgvLineItem.Size = new System.Drawing.Size(585, 236);
            this.dgvLineItem.TabIndex = 24;
            this.dgvLineItem.TabStop = false;
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(441, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(521, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(410, 360);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(83, 20);
            this.txtTotalAmount.TabIndex = 27;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.AutoSize = true;
            this.lblAmountInWord.Location = new System.Drawing.Point(14, 362);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(83, 13);
            this.lblAmountInWord.TabIndex = 28;
            this.lblAmountInWord.Text = "Amount Is Word";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCustTranType);
            this.groupBox1.Controls.Add(this.lblInsType);
            this.groupBox1.Controls.Add(this.lblRemarks);
            this.groupBox1.Controls.Add(this.dtInstrudate);
            this.groupBox1.Controls.Add(this.lblInsDate);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 77);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.FileName = "openFileDialogData";
            // 
            // pbInvoice
            // 
            this.pbInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInvoice.Location = new System.Drawing.Point(12, 393);
            this.pbInvoice.Name = "pbInvoice";
            this.pbInvoice.Size = new System.Drawing.Size(423, 21);
            this.pbInvoice.TabIndex = 30;
            // 
            // frmCustomerBulkTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 424);
            this.Controls.Add(this.pbInvoice);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblAmountInWord);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXLFilePath);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerBulkTran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Bulk Tran";
            this.Load += new System.EventHandler(this.frmCustomerBulkTran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.DateTimePicker dtInstrudate;
        private System.Windows.Forms.Label lblInsDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ComboBox cmbCustTranType;
        private System.Windows.Forms.Label lblInsType;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtXLFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblAmountInWord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.ProgressBar pbInvoice;
    }
}