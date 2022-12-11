namespace CJ.Win.Claim
{
    partial class frmReplaceClaimStockTranReport
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lbfromdate = new System.Windows.Forms.Label();
            this.lbtodate = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 29);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1269, 514);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(209, 3);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(96, 20);
            this.dtToDate.TabIndex = 31;
            this.dtToDate.UseWaitCursor = true;
            this.dtToDate.Value = new System.DateTime(2016, 1, 27, 0, 0, 0, 0);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(67, 3);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(96, 20);
            this.dtFromDate.TabIndex = 30;
            this.dtFromDate.Value = new System.DateTime(2016, 1, 27, 0, 0, 0, 0);
            // 
            // lbfromdate
            // 
            this.lbfromdate.AutoSize = true;
            this.lbfromdate.Location = new System.Drawing.Point(8, 7);
            this.lbfromdate.Name = "lbfromdate";
            this.lbfromdate.Size = new System.Drawing.Size(56, 13);
            this.lbfromdate.TabIndex = 32;
            this.lbfromdate.Text = "From Date";
            // 
            // lbtodate
            // 
            this.lbtodate.AutoSize = true;
            this.lbtodate.Location = new System.Drawing.Point(183, 9);
            this.lbtodate.Name = "lbtodate";
            this.lbtodate.Size = new System.Drawing.Size(20, 13);
            this.lbtodate.TabIndex = 33;
            this.lbtodate.Text = "To";
            // 
            // btnShowReport
            // 
            this.btnShowReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowReport.Location = new System.Drawing.Point(333, 3);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(78, 20);
            this.btnShowReport.TabIndex = 37;
            this.btnShowReport.TabStop = false;
            this.btnShowReport.Text = "Print";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // frmReplaceClaimStockTranReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 543);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lbfromdate);
            this.Controls.Add(this.lbtodate);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmReplaceClaimStockTranReport";
            this.Text = "Replace Claim Stock Tran Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label lbfromdate;
        private System.Windows.Forms.Label lbtodate;
        private System.Windows.Forms.Button btnShowReport;
    }
}