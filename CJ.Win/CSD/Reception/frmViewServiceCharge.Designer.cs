namespace CJ.Win.CSD.Reception
{
    partial class frmViewServiceCharge
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServiceTotalCharge = new System.Windows.Forms.TextBox();
            this.txtInspectionTotalCharge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInstallationTotalCharge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Charge";
            // 
            // txtServiceTotalCharge
            // 
            this.txtServiceTotalCharge.Location = new System.Drawing.Point(108, 9);
            this.txtServiceTotalCharge.Name = "txtServiceTotalCharge";
            this.txtServiceTotalCharge.ReadOnly = true;
            this.txtServiceTotalCharge.Size = new System.Drawing.Size(196, 20);
            this.txtServiceTotalCharge.TabIndex = 1;
            // 
            // txtInspectionTotalCharge
            // 
            this.txtInspectionTotalCharge.Location = new System.Drawing.Point(108, 35);
            this.txtInspectionTotalCharge.Name = "txtInspectionTotalCharge";
            this.txtInspectionTotalCharge.ReadOnly = true;
            this.txtInspectionTotalCharge.Size = new System.Drawing.Size(196, 20);
            this.txtInspectionTotalCharge.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inspection Charge";
            // 
            // txtInstallationTotalCharge
            // 
            this.txtInstallationTotalCharge.Location = new System.Drawing.Point(108, 61);
            this.txtInstallationTotalCharge.Name = "txtInstallationTotalCharge";
            this.txtInstallationTotalCharge.ReadOnly = true;
            this.txtInstallationTotalCharge.Size = new System.Drawing.Size(196, 20);
            this.txtInstallationTotalCharge.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Installation Charge";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(229, 87);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmViewServiceCharge
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 124);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtInstallationTotalCharge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInspectionTotalCharge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServiceTotalCharge);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmViewServiceCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Service Charge";
            this.Load += new System.EventHandler(this.frmViewServiceCharge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServiceTotalCharge;
        private System.Windows.Forms.TextBox txtInspectionTotalCharge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInstallationTotalCharge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
    }
}