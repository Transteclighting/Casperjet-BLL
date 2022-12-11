namespace CJ.Win.CSD.Workshop
{
    partial class frmBackupSetIssue
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
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.btnIssue = new System.Windows.Forms.Button();
            this.lblJob = new System.Windows.Forms.Label();
            this.txtBackupSetID = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblSelectedBackupSet = new System.Windows.Forms.Label();
            this.lbProductCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(86, 59);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(483, 31);
            this.ctlCSDJob1.TabIndex = 0;
            // 
            // btnIssue
            // 
            this.btnIssue.Location = new System.Drawing.Point(482, 96);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(89, 26);
            this.btnIssue.TabIndex = 1;
            this.btnIssue.Text = "&Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Location = new System.Drawing.Point(58, 67);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(24, 13);
            this.lblJob.TabIndex = 3;
            this.lblJob.Text = "Job";
            // 
            // txtBackupSetID
            // 
            this.txtBackupSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupSetID.Location = new System.Drawing.Point(86, 10);
            this.txtBackupSetID.Name = "txtBackupSetID";
            this.txtBackupSetID.ReadOnly = true;
            this.txtBackupSetID.Size = new System.Drawing.Size(157, 20);
            this.txtBackupSetID.TabIndex = 11;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(317, 10);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(254, 20);
            this.txtProductCode.TabIndex = 11;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(86, 37);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(486, 20);
            this.txtProductName.TabIndex = 11;
            // 
            // lblSelectedBackupSet
            // 
            this.lblSelectedBackupSet.AutoSize = true;
            this.lblSelectedBackupSet.Location = new System.Drawing.Point(7, 13);
            this.lblSelectedBackupSet.Name = "lblSelectedBackupSet";
            this.lblSelectedBackupSet.Size = new System.Drawing.Size(77, 13);
            this.lblSelectedBackupSet.TabIndex = 12;
            this.lblSelectedBackupSet.Text = "Backup Set ID";
            // 
            // lbProductCode
            // 
            this.lbProductCode.AutoSize = true;
            this.lbProductCode.Location = new System.Drawing.Point(244, 12);
            this.lbProductCode.Name = "lbProductCode";
            this.lbProductCode.Size = new System.Drawing.Size(72, 13);
            this.lbProductCode.TabIndex = 13;
            this.lbProductCode.Text = "Product Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Product Name";
            // 
            // frmBackupSetIssue
            // 
            this.AcceptButton = this.btnIssue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 131);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbProductCode);
            this.Controls.Add(this.lblSelectedBackupSet);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.txtBackupSetID);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.ctlCSDJob1);
            this.MaximizeBox = false;
            this.Name = "frmBackupSetIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup Set Issue";
            this.Load += new System.EventHandler(this.frmBackupSetTran_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlCSDJob ctlCSDJob1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.TextBox txtBackupSetID;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblSelectedBackupSet;
        private System.Windows.Forms.Label lbProductCode;
        private System.Windows.Forms.Label label1;
    }
}