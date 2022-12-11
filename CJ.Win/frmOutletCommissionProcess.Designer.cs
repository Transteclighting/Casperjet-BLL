namespace CJ.Win
{
    partial class frmOutletCommissionProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutletCommissionProcess));
            this.lblYear = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.dtCommitionDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(32, 14);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(33, 13);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Year";
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(433, 77);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(170, 40);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pbProcess
            // 
            this.pbProcess.Location = new System.Drawing.Point(71, 77);
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(332, 40);
            this.pbProcess.TabIndex = 5;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(71, 41);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(532, 20);
            this.txtRemarks.TabIndex = 6;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(9, 48);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(56, 13);
            this.lblRemarks.TabIndex = 7;
            this.lblRemarks.Text = "Remarks";
            // 
            // dtCommitionDate
            // 
            this.dtCommitionDate.CustomFormat = "MMM-yyyy";
            this.dtCommitionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCommitionDate.Location = new System.Drawing.Point(71, 12);
            this.dtCommitionDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtCommitionDate.Name = "dtCommitionDate";
            this.dtCommitionDate.ShowUpDown = true;
            this.dtCommitionDate.Size = new System.Drawing.Size(114, 20);
            this.dtCommitionDate.TabIndex = 8;
            this.dtCommitionDate.Value = new System.DateTime(2016, 10, 17, 10, 56, 6, 0);
            // 
            // frmOutletCommissionProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(615, 126);
            this.Controls.Add(this.dtCommitionDate);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.pbProcess);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblYear);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOutletCommissionProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommissionProcess";
            this.Load += new System.EventHandler(this.frmOutletCommissionProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ProgressBar pbProcess;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.DateTimePicker dtCommitionDate;
    }
}