namespace CJ.Win.Accounts
{
    partial class frmEMITenure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEMITenure));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEMITenure = new System.Windows.Forms.TextBox();
            this.lblDistSet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(233, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEMITenure
            // 
            this.txtEMITenure.Location = new System.Drawing.Point(130, 16);
            this.txtEMITenure.Name = "txtEMITenure";
            this.txtEMITenure.ShortcutsEnabled = false;
            this.txtEMITenure.Size = new System.Drawing.Size(195, 21);
            this.txtEMITenure.TabIndex = 1;
            this.txtEMITenure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEMITenure_KeyPress);
            // 
            // lblDistSet
            // 
            this.lblDistSet.AutoSize = true;
            this.lblDistSet.Location = new System.Drawing.Point(7, 19);
            this.lblDistSet.Name = "lblDistSet";
            this.lblDistSet.Size = new System.Drawing.Size(117, 15);
            this.lblDistSet.TabIndex = 0;
            this.lblDistSet.Text = "EMI Tenure (Month)";
            // 
            // frmEMITenure
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 83);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEMITenure);
            this.Controls.Add(this.lblDistSet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEMITenure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMI Tenure (Month)";
            this.Load += new System.EventHandler(this.frmEMITenure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEMITenure;
        private System.Windows.Forms.Label lblDistSet;
    }
}