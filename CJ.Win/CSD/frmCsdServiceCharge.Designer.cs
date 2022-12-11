namespace CJ.Win.CSD
{
    partial class frmCsdServiceCharge
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
            this.ctlProducts1 = new CJ.Win.Control.ctlProducts();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbServiceCharge = new System.Windows.Forms.ComboBox();
            this.txtServiceCharge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInspectionCharge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInstallationCharge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReInstallationCharge = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDismantlingCharge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctlProducts1
            // 
            this.ctlProducts1.Location = new System.Drawing.Point(121, 12);
            this.ctlProducts1.Name = "ctlProducts1";
            this.ctlProducts1.Size = new System.Drawing.Size(444, 25);
            this.ctlProducts1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service Charge Name";
            // 
            // cmbServiceCharge
            // 
            this.cmbServiceCharge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbServiceCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceCharge.FormattingEnabled = true;
            this.cmbServiceCharge.Location = new System.Drawing.Point(120, 37);
            this.cmbServiceCharge.Name = "cmbServiceCharge";
            this.cmbServiceCharge.Size = new System.Drawing.Size(296, 21);
            this.cmbServiceCharge.TabIndex = 3;
            this.cmbServiceCharge.SelectedIndexChanged += new System.EventHandler(this.cmbServiceCharge_SelectedIndexChanged);
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.Location = new System.Drawing.Point(121, 62);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.ReadOnly = true;
            this.txtServiceCharge.Size = new System.Drawing.Size(88, 20);
            this.txtServiceCharge.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Service Charge";
            // 
            // txtInspectionCharge
            // 
            this.txtInspectionCharge.Location = new System.Drawing.Point(331, 66);
            this.txtInspectionCharge.Name = "txtInspectionCharge";
            this.txtInspectionCharge.ReadOnly = true;
            this.txtInspectionCharge.Size = new System.Drawing.Size(86, 20);
            this.txtInspectionCharge.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Inspection Charge";
            // 
            // txtInstallationCharge
            // 
            this.txtInstallationCharge.Location = new System.Drawing.Point(121, 87);
            this.txtInstallationCharge.Name = "txtInstallationCharge";
            this.txtInstallationCharge.ReadOnly = true;
            this.txtInstallationCharge.Size = new System.Drawing.Size(88, 20);
            this.txtInstallationCharge.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Installation Charge";
            // 
            // txtReInstallationCharge
            // 
            this.txtReInstallationCharge.Location = new System.Drawing.Point(332, 90);
            this.txtReInstallationCharge.Name = "txtReInstallationCharge";
            this.txtReInstallationCharge.ReadOnly = true;
            this.txtReInstallationCharge.Size = new System.Drawing.Size(86, 20);
            this.txtReInstallationCharge.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Re Installation Charge";
            // 
            // txtDismantlingCharge
            // 
            this.txtDismantlingCharge.Location = new System.Drawing.Point(121, 111);
            this.txtDismantlingCharge.Name = "txtDismantlingCharge";
            this.txtDismantlingCharge.ReadOnly = true;
            this.txtDismantlingCharge.Size = new System.Drawing.Size(88, 20);
            this.txtDismantlingCharge.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Dismantling Charge";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(392, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(479, 129);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 26);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCsdServiceCharge
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 167);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDismantlingCharge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReInstallationCharge);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInstallationCharge);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInspectionCharge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServiceCharge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbServiceCharge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlProducts1);
            this.Name = "frmCsdServiceCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Csd Service Charge";
            this.Load += new System.EventHandler(this.frmCsdServiceCharge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Win.Control.ctlProducts ctlProducts1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbServiceCharge;
        private System.Windows.Forms.TextBox txtServiceCharge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInspectionCharge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInstallationCharge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReInstallationCharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDismantlingCharge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}