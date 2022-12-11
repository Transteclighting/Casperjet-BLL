namespace CJ.Win.CSD.Workshop
{
    partial class frmChangeTechnician
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
            this.lblJob = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTechnician = new System.Windows.Forms.Label();
            this.ctlCSDTechnician1 = new CJ.Win.ctlCSDTechnician();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.SuspendLayout();
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Location = new System.Drawing.Point(41, 9);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(24, 13);
            this.lblJob.TabIndex = 1;
            this.lblJob.Text = "Job";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(492, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 26);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Assign";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTechnician
            // 
            this.lblTechnician.AutoSize = true;
            this.lblTechnician.Location = new System.Drawing.Point(12, 38);
            this.lblTechnician.Name = "lblTechnician";
            this.lblTechnician.Size = new System.Drawing.Size(60, 13);
            this.lblTechnician.TabIndex = 6;
            this.lblTechnician.Text = "Technician";
            // 
            // ctlCSDTechnician1
            // 
            this.ctlCSDTechnician1.Location = new System.Drawing.Point(44, 34);
            this.ctlCSDTechnician1.Name = "ctlCSDTechnician1";
            this.ctlCSDTechnician1.Size = new System.Drawing.Size(549, 31);
            this.ctlCSDTechnician1.TabIndex = 5;
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(68, 4);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(506, 31);
            this.ctlCSDJob1.TabIndex = 4;
            // 
            // frmChangeTechnician
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 101);
            this.Controls.Add(this.lblTechnician);
            this.Controls.Add(this.ctlCSDTechnician1);
            this.Controls.Add(this.ctlCSDJob1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblJob);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeTechnician";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Technician";
            this.Load += new System.EventHandler(this.frmChangeTechnician_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Button btnSave;
        private ctlCSDJob ctlCSDJob1;
        private ctlCSDTechnician ctlCSDTechnician1;
        private System.Windows.Forms.Label lblTechnician;
    }
}