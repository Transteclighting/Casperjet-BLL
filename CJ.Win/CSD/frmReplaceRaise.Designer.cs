namespace CJ.Win
{
    partial class frmReplaceRaise
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtInvoiceCashMemo = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblDOP = new System.Windows.Forms.Label();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblIssueRemarks = new System.Windows.Forms.Label();
            this.txtRaiseRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFullWarrantyPeriod = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEDD = new System.Windows.Forms.DateTimePicker();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(324, 242);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(444, 242);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtInvoiceCashMemo
            // 
            this.txtInvoiceCashMemo.Location = new System.Drawing.Point(179, 38);
            this.txtInvoiceCashMemo.Name = "txtInvoiceCashMemo";
            this.txtInvoiceCashMemo.Size = new System.Drawing.Size(147, 20);
            this.txtInvoiceCashMemo.TabIndex = 1;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(39, 41);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(140, 13);
            this.lblInvoiceNo.TabIndex = 140;
            this.lblInvoiceNo.Text = "Invoice/Cash Memo No";
            // 
            // lblDOP
            // 
            this.lblDOP.AutoSize = true;
            this.lblDOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOP.Location = new System.Drawing.Point(86, 68);
            this.lblDOP.Name = "lblDOP";
            this.lblDOP.Size = new System.Drawing.Size(91, 13);
            this.lblDOP.TabIndex = 137;
            this.lblDOP.Text = "Purchase Date";
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPurchaseDate.Location = new System.Drawing.Point(179, 64);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(147, 20);
            this.dtPurchaseDate.TabIndex = 2;
            // 
            // lblIssueRemarks
            // 
            this.lblIssueRemarks.AutoSize = true;
            this.lblIssueRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueRemarks.Location = new System.Drawing.Point(14, 143);
            this.lblIssueRemarks.Name = "lblIssueRemarks";
            this.lblIssueRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblIssueRemarks.TabIndex = 136;
            this.lblIssueRemarks.Text = "Remarks";
            // 
            // txtRaiseRemarks
            // 
            this.txtRaiseRemarks.Location = new System.Drawing.Point(17, 164);
            this.txtRaiseRemarks.Multiline = true;
            this.txtRaiseRemarks.Name = "txtRaiseRemarks";
            this.txtRaiseRemarks.Size = new System.Drawing.Size(532, 68);
            this.txtRaiseRemarks.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "Full Warranty Period (Up to)";
            // 
            // dtFullWarrantyPeriod
            // 
            this.dtFullWarrantyPeriod.CustomFormat = "dd-MMM-yyyy";
            this.dtFullWarrantyPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFullWarrantyPeriod.Location = new System.Drawing.Point(179, 90);
            this.dtFullWarrantyPeriod.Name = "dtFullWarrantyPeriod";
            this.dtFullWarrantyPeriod.Size = new System.Drawing.Size(147, 20);
            this.dtFullWarrantyPeriod.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 144;
            this.label3.Text = "Expected Delivery Date";
            // 
            // dtEDD
            // 
            this.dtEDD.CustomFormat = "dd-MMM-yyyy";
            this.dtEDD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEDD.Location = new System.Drawing.Point(179, 116);
            this.dtEDD.Name = "dtEDD";
            this.dtEDD.Size = new System.Drawing.Size(147, 20);
            this.dtEDD.TabIndex = 143;
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.Location = new System.Drawing.Point(10, 15);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(47, 13);
            this.lblJobNo.TabIndex = 145;
            this.lblJobNo.Text = "Job No";
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(60, 12);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(489, 20);
            this.ctlCSDJob1.TabIndex = 146;
            this.ctlCSDJob1.ChangeSelection += new System.EventHandler(this.ctlCSDJob1_ChangeSelection);
            // 
            // frmReplaceRaise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 281);
            this.Controls.Add(this.lblJobNo);
            this.Controls.Add(this.ctlCSDJob1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtEDD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFullWarrantyPeriod);
            this.Controls.Add(this.txtInvoiceCashMemo);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.lblDOP);
            this.Controls.Add(this.dtPurchaseDate);
            this.Controls.Add(this.lblIssueRemarks);
            this.Controls.Add(this.txtRaiseRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplaceRaise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace Raise";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtInvoiceCashMemo;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblDOP;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.Label lblIssueRemarks;
        private System.Windows.Forms.TextBox txtRaiseRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFullWarrantyPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEDD;
        private System.Windows.Forms.Label lblJobNo;
        private ctlCSDJob ctlCSDJob1;
    }
}