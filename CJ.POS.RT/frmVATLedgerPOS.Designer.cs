namespace CJ.POS.RT
{
    partial class frmVATLedgerPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVATLedgerPOS));
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVAT = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.lblName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbReportNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(72, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "VAT:";
            // 
            // cmbVAT
            // 
            this.cmbVAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVAT.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbVAT.FormattingEnabled = true;
            this.cmbVAT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbVAT.Items.AddRange(new object[] {
            "<ALL>",
            "0.05",
            "0.15"});
            this.cmbVAT.Location = new System.Drawing.Point(109, 111);
            this.cmbVAT.Name = "cmbVAT";
            this.cmbVAT.Size = new System.Drawing.Size(105, 23);
            this.cmbVAT.TabIndex = 7;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnPreview.Location = new System.Drawing.Point(440, 111);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 25);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "Preview...";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(393, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(421, 78);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(106, 23);
            this.dtToDate.TabIndex = 5;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(109, 78);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(105, 23);
            this.dtFromDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(44, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "From Date:";
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.ctlProduct1.Location = new System.Drawing.Point(109, 41);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(418, 25);
            this.ctlProduct1.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(16, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(90, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Product Detail:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(49, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Report#";
            // 
            // cmbReportNo
            // 
            this.cmbReportNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbReportNo.FormattingEnabled = true;
            this.cmbReportNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbReportNo.Items.AddRange(new object[] {
            "<Select Report #>",
            "Mushak - 6.2.1",
            "Form KA"});
            this.cmbReportNo.Location = new System.Drawing.Point(109, 12);
            this.cmbReportNo.Name = "cmbReportNo";
            this.cmbReportNo.Size = new System.Drawing.Size(105, 23);
            this.cmbReportNo.TabIndex = 10;
            // 
            // frmVATLedgerPOS
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 173);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbReportNo);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbVAT);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVATLedgerPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VAT Ledger POS";
            this.Load += new System.EventHandler(this.frmVATLedgerPOS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVAT;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbReportNo;
    }
}