namespace CJ.Win.Accounts
{
    partial class frmBankInterest
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
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblEMINo = new System.Windows.Forms.Label();
            this.lblInterestRate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.txtEMINo = new System.Windows.Forms.TextBox();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.Location = new System.Drawing.Point(16, 9);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(63, 13);
            this.lblBankName.TabIndex = 1;
            this.lblBankName.Text = "Bank Name";
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEMINo
            // 
            this.lblEMINo.AutoSize = true;
            this.lblEMINo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMINo.Location = new System.Drawing.Point(36, 36);
            this.lblEMINo.Name = "lblEMINo";
            this.lblEMINo.Size = new System.Drawing.Size(43, 13);
            this.lblEMINo.TabIndex = 2;
            this.lblEMINo.Text = "EMI No";
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterestRate.Location = new System.Drawing.Point(238, 36);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(68, 13);
            this.lblInterestRate.TabIndex = 3;
            this.lblInterestRate.Text = "Interest Rate";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(346, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 24);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbBankName
            // 
            this.cmbBankName.BackColor = System.Drawing.SystemColors.Window;
            this.cmbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(85, 6);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(327, 21);
            this.cmbBankName.TabIndex = 6;
            // 
            // txtEMINo
            // 
            this.txtEMINo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMINo.Location = new System.Drawing.Point(85, 33);
            this.txtEMINo.Name = "txtEMINo";
            this.txtEMINo.Size = new System.Drawing.Size(141, 20);
            this.txtEMINo.TabIndex = 7;
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterestRate.Location = new System.Drawing.Point(308, 33);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(104, 20);
            this.txtInterestRate.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(270, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 24);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtEffectiveDate
            // 
            this.dtEffectiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEffectiveDate.Location = new System.Drawing.Point(85, 59);
            this.dtEffectiveDate.Name = "dtEffectiveDate";
            this.dtEffectiveDate.Size = new System.Drawing.Size(141, 20);
            this.dtEffectiveDate.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Effective Date";
            // 
            // frmBankInterest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 117);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtEffectiveDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.txtEMINo);
            this.Controls.Add(this.cmbBankName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblInterestRate);
            this.Controls.Add(this.lblEMINo);
            this.Controls.Add(this.lblBankName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBankInterest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBankInterest";
            this.Load += new System.EventHandler(this.frmBankInterest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label lblEMINo;
        private System.Windows.Forms.Label lblInterestRate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.TextBox txtEMINo;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtEffectiveDate;
        private System.Windows.Forms.Label label1;
    }
}