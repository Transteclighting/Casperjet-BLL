namespace TEL.SMS.UI.Win
{
    partial class frmRptWarrantyReg
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
            this.rbtSMS = new System.Windows.Forms.RadioButton();
            this.rbtAll = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.rbtManual = new System.Windows.Forms.RadioButton();
            this.rptWarrentyDetail = new System.Windows.Forms.RadioButton();
            this.rptWarrentySummary = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbtSMS
            // 
            this.rbtSMS.AutoSize = true;
            this.rbtSMS.Location = new System.Drawing.Point(268, 35);
            this.rbtSMS.Name = "rbtSMS";
            this.rbtSMS.Size = new System.Drawing.Size(48, 17);
            this.rbtSMS.TabIndex = 13;
            this.rbtSMS.Text = "SMS";
            this.rbtSMS.UseVisualStyleBackColor = true;
            // 
            // rbtAll
            // 
            this.rbtAll.AutoSize = true;
            this.rbtAll.Checked = true;
            this.rbtAll.Location = new System.Drawing.Point(268, 7);
            this.rbtAll.Name = "rbtAll";
            this.rbtAll.Size = new System.Drawing.Size(36, 17);
            this.rbtAll.TabIndex = 12;
            this.rbtAll.TabStop = true;
            this.rbtAll.Text = "All";
            this.rbtAll.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(15, 94);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 36);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "From Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(74, 31);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(122, 20);
            this.dtpToDate.TabIndex = 8;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(74, 5);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(124, 20);
            this.dtpFromDate.TabIndex = 7;
            // 
            // rbtManual
            // 
            this.rbtManual.AutoSize = true;
            this.rbtManual.Location = new System.Drawing.Point(268, 66);
            this.rbtManual.Name = "rbtManual";
            this.rbtManual.Size = new System.Drawing.Size(60, 17);
            this.rbtManual.TabIndex = 14;
            this.rbtManual.Text = "Manual";
            this.rbtManual.UseVisualStyleBackColor = true;
            // 
            // rptWarrentyDetail
            // 
            this.rptWarrentyDetail.AutoSize = true;
            this.rptWarrentyDetail.Location = new System.Drawing.Point(134, 104);
            this.rptWarrentyDetail.Name = "rptWarrentyDetail";
            this.rptWarrentyDetail.Size = new System.Drawing.Size(194, 17);
            this.rptWarrentyDetail.TabIndex = 15;
            this.rptWarrentyDetail.Text = "Warrenty for the ShowRoom Details";
            this.rptWarrentyDetail.UseVisualStyleBackColor = true;
            this.rptWarrentyDetail.CheckedChanged += new System.EventHandler(this.rptWarrentyDetail_CheckedChanged);
            // 
            // rptWarrentySummary
            // 
            this.rptWarrentySummary.AutoSize = true;
            this.rptWarrentySummary.Location = new System.Drawing.Point(134, 127);
            this.rptWarrentySummary.Name = "rptWarrentySummary";
            this.rptWarrentySummary.Size = new System.Drawing.Size(205, 17);
            this.rptWarrentySummary.TabIndex = 16;
            this.rptWarrentySummary.Text = "Warrenty for the ShowRoom Summary";
            this.rptWarrentySummary.UseVisualStyleBackColor = true;
            // 
            // frmRptWarrantyReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 173);
            this.Controls.Add(this.rptWarrentySummary);
            this.Controls.Add(this.rptWarrentyDetail);
            this.Controls.Add(this.rbtManual);
            this.Controls.Add(this.rbtSMS);
            this.Controls.Add(this.rbtAll);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Name = "frmRptWarrantyReg";
            this.Text = "Warranty Register Report";
            this.Load += new System.EventHandler(this.frmRptWarrantyReg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtSMS;
        private System.Windows.Forms.RadioButton rbtAll;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.RadioButton rbtManual;
        private System.Windows.Forms.RadioButton rptWarrentyDetail;
        private System.Windows.Forms.RadioButton rptWarrentySummary;
    }
}