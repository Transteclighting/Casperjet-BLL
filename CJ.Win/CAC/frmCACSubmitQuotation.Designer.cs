namespace CJ.Win.CAC
{
    partial class frmCACSubmitQuotation
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
            this.lblDate = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtFollowUpDate = new System.Windows.Forms.DateTimePicker();
            this.dtTenderDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsTender = new System.Windows.Forms.CheckBox();
            this.chkIsFollowUp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(7, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(65, 13);
            this.lblDate.TabIndex = 13;
            this.lblDate.Text = "Submit Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(76, 4);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(92, 20);
            this.dtDate.TabIndex = 14;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(78, 55);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(298, 20);
            this.txtRemarks.TabIndex = 71;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(7, 58);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 70;
            this.lblRemarks.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(317, 81);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 25);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtFollowUpDate
            // 
            this.dtFollowUpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFollowUpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFollowUpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFollowUpDate.Location = new System.Drawing.Point(279, 29);
            this.dtFollowUpDate.Name = "dtFollowUpDate";
            this.dtFollowUpDate.Size = new System.Drawing.Size(97, 20);
            this.dtFollowUpDate.TabIndex = 74;
            // 
            // dtTenderDate
            // 
            this.dtTenderDate.CustomFormat = "dd-MMM-yyyy";
            this.dtTenderDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTenderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTenderDate.Location = new System.Drawing.Point(76, 29);
            this.dtTenderDate.Name = "dtTenderDate";
            this.dtTenderDate.Size = new System.Drawing.Size(92, 20);
            this.dtTenderDate.TabIndex = 76;
            // 
            // chkIsTender
            // 
            this.chkIsTender.AutoSize = true;
            this.chkIsTender.Location = new System.Drawing.Point(5, 32);
            this.chkIsTender.Name = "chkIsTender";
            this.chkIsTender.Size = new System.Drawing.Size(68, 17);
            this.chkIsTender.TabIndex = 78;
            this.chkIsTender.Text = "IsTender";
            this.chkIsTender.UseVisualStyleBackColor = true;
            // 
            // chkIsFollowUp
            // 
            this.chkIsFollowUp.AutoSize = true;
            this.chkIsFollowUp.Location = new System.Drawing.Point(174, 31);
            this.chkIsFollowUp.Name = "chkIsFollowUp";
            this.chkIsFollowUp.Size = new System.Drawing.Size(101, 17);
            this.chkIsFollowUp.TabIndex = 79;
            this.chkIsFollowUp.Text = "IsFollowUpDate";
            this.chkIsFollowUp.UseVisualStyleBackColor = true;
            // 
            // frmCACSubmitQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 113);
            this.Controls.Add(this.chkIsFollowUp);
            this.Controls.Add(this.chkIsTender);
            this.Controls.Add(this.dtTenderDate);
            this.Controls.Add(this.dtFollowUpDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtDate);
            this.Name = "frmCACSubmitQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Submit Quotation";
            this.Load += new System.EventHandler(this.frmCACSubmitQuotation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtFollowUpDate;
        private System.Windows.Forms.DateTimePicker dtTenderDate;
        private System.Windows.Forms.CheckBox chkIsTender;
        private System.Windows.Forms.CheckBox chkIsFollowUp;
    }
}