namespace CJ.Win.Process
{
    partial class frmTransferFromCassiopia
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
            this.TranType = new System.Windows.Forms.ColumnHeader();
            this.Remarks = new System.Windows.Forms.ColumnHeader();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.TranDate = new System.Windows.Forms.ColumnHeader();
            this.btnGet = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TranNo = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwSRTran = new System.Windows.Forms.ListView();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.pbTransfer = new System.Windows.Forms.ProgressBar();
            this.btnPrintTransaction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TranType
            // 
            this.TranType.Text = "Tran Type";
            this.TranType.Width = 120;
            // 
            // Remarks
            // 
            this.Remarks.Text = "Remarks";
            this.Remarks.Width = 200;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(474, 46);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(120, 27);
            this.btnTransfer.TabIndex = 70;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // TranDate
            // 
            this.TranDate.Text = "Tran Date";
            this.TranDate.Width = 96;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(343, 4);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 69;
            this.btnGet.Text = "Get Data";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(205, 5);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(132, 20);
            this.dtpTo.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "From";
            // 
            // TranNo
            // 
            this.TranNo.Text = "Tran No";
            this.TranNo.Width = 99;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(474, 397);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 27);
            this.btnClose.TabIndex = 62;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwSRTran
            // 
            this.lvwSRTran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSRTran.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TranNo,
            this.TranDate,
            this.TranType,
            this.Remarks});
            this.lvwSRTran.FullRowSelect = true;
            this.lvwSRTran.GridLines = true;
            this.lvwSRTran.HideSelection = false;
            this.lvwSRTran.Location = new System.Drawing.Point(3, 47);
            this.lvwSRTran.Name = "lvwSRTran";
            this.lvwSRTran.Size = new System.Drawing.Size(471, 377);
            this.lvwSRTran.TabIndex = 63;
            this.lvwSRTran.UseCompatibleStateImageBehavior = false;
            this.lvwSRTran.View = System.Windows.Forms.View.Details;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(39, 5);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(132, 20);
            this.dtpFrom.TabIndex = 71;
            // 
            // pbTransfer
            // 
            this.pbTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTransfer.Location = new System.Drawing.Point(3, 29);
            this.pbTransfer.Name = "pbTransfer";
            this.pbTransfer.Size = new System.Drawing.Size(591, 16);
            this.pbTransfer.TabIndex = 73;
            this.pbTransfer.Visible = false;
            // 
            // btnPrintTransaction
            // 
            this.btnPrintTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintTransaction.Location = new System.Drawing.Point(474, 77);
            this.btnPrintTransaction.Name = "btnPrintTransaction";
            this.btnPrintTransaction.Size = new System.Drawing.Size(120, 28);
            this.btnPrintTransaction.TabIndex = 166;
            this.btnPrintTransaction.Text = "Print Transaction";
            this.btnPrintTransaction.UseVisualStyleBackColor = true;
            this.btnPrintTransaction.Click += new System.EventHandler(this.btnPrintTransaction_Click);
            // 
            // frmTransferFromCassiopia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 426);
            this.Controls.Add(this.btnPrintTransaction);
            this.Controls.Add(this.pbTransfer);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwSRTran);
            this.Controls.Add(this.dtpFrom);
            this.Name = "frmTransferFromCassiopia";
            this.Text = "Transfer From Cassiopia to Casper";
            this.Load += new System.EventHandler(this.frmTransferFromCassiopia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader TranType;
        private System.Windows.Forms.ColumnHeader Remarks;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.ColumnHeader TranDate;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader TranNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwSRTran;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ProgressBar pbTransfer;
        private System.Windows.Forms.Button btnPrintTransaction;
    }
}