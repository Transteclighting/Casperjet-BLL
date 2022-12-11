namespace CJ.POS.RT
{
    partial class frmDownloadVersion
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
            this.txtURL = new System.Windows.Forms.TextBox();
            this.Update_bttn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblDownloadStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Download URL";
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(153, 20);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(387, 23);
            this.txtURL.TabIndex = 3;
            this.txtURL.Text = "http://dl.dropbox.com/u/38091577/";
            // 
            // Update_bttn
            // 
            this.Update_bttn.BackColor = System.Drawing.Color.Gold;
            this.Update_bttn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_bttn.Location = new System.Drawing.Point(290, 123);
            this.Update_bttn.Name = "Update_bttn";
            this.Update_bttn.Size = new System.Drawing.Size(250, 36);
            this.Update_bttn.TabIndex = 5;
            this.Update_bttn.Text = "Update Application";
            this.Update_bttn.UseVisualStyleBackColor = false;
            this.Update_bttn.Click += new System.EventHandler(this.Update_bttn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(153, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(387, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // lblDownloadStatus
            // 
            this.lblDownloadStatus.AutoSize = true;
            this.lblDownloadStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadStatus.ForeColor = System.Drawing.Color.White;
            this.lblDownloadStatus.Location = new System.Drawing.Point(261, 84);
            this.lblDownloadStatus.Name = "lblDownloadStatus";
            this.lblDownloadStatus.Size = new System.Drawing.Size(109, 16);
            this.lblDownloadStatus.TabIndex = 7;
            this.lblDownloadStatus.Text = "Download 0%";
            // 
            // frmDownloadVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(555, 261);
            this.Controls.Add(this.lblDownloadStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Update_bttn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtURL);
            this.Name = "frmDownloadVersion";
            this.Text = "frmDownloadVersion";
            this.Load += new System.EventHandler(this.frmDownloadVersion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button Update_bttn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblDownloadStatus;
    }
}