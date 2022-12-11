namespace CJ.Win
{
    partial class frmOutletCommissionProcessNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutletCommissionProcessNew));
            this.dtCommitionDate = new System.Windows.Forms.DateTimePicker();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtCommitionDate
            // 
            this.dtCommitionDate.CustomFormat = "MMM-yyyy";
            this.dtCommitionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCommitionDate.Location = new System.Drawing.Point(66, 12);
            this.dtCommitionDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtCommitionDate.Name = "dtCommitionDate";
            this.dtCommitionDate.ShowUpDown = true;
            this.dtCommitionDate.Size = new System.Drawing.Size(114, 23);
            this.dtCommitionDate.TabIndex = 14;
            this.dtCommitionDate.Value = new System.DateTime(2016, 10, 17, 10, 56, 6, 0);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.lblRemarks.Location = new System.Drawing.Point(2, 48);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 16);
            this.lblRemarks.TabIndex = 13;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(64, 41);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(532, 23);
            this.txtRemarks.TabIndex = 12;
            // 
            // pbProcess
            // 
            this.pbProcess.Location = new System.Drawing.Point(64, 70);
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(332, 40);
            this.pbProcess.TabIndex = 11;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(426, 70);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(170, 40);
            this.btnProcess.TabIndex = 10;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.lblYear.Location = new System.Drawing.Point(27, 14);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(33, 16);
            this.lblYear.TabIndex = 9;
            this.lblYear.Text = "Year";
            // 
            // frmOutletCommissionProcessNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 123);
            this.Controls.Add(this.dtCommitionDate);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.pbProcess);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblYear);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOutletCommissionProcessNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOutletCommissionProcessNew";
            this.Load += new System.EventHandler(this.frmOutletCommissionProcessNew_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtCommitionDate;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ProgressBar pbProcess;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblYear;
    }
}