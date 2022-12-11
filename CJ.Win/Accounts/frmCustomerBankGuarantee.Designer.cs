namespace CJ.Win.Accounts
{
    partial class frmCustomerBankGuarantee
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtBGAmount = new System.Windows.Forms.TextBox();
            this.dtExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Effective Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtEffectiveDate
            // 
            this.dtEffectiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEffectiveDate.Location = new System.Drawing.Point(93, 63);
            this.dtEffectiveDate.Name = "dtEffectiveDate";
            this.dtEffectiveDate.Size = new System.Drawing.Size(124, 20);
            this.dtEffectiveDate.TabIndex = 14;
            this.dtEffectiveDate.ValueChanged += new System.EventHandler(this.dtEffectiveDate_ValueChanged);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(384, 93);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(64, 17);
            this.chkIsActive.TabIndex = 17;
            this.chkIsActive.Text = "IsActive";
            this.chkIsActive.UseVisualStyleBackColor = true;
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.chkIsActive_CheckedChanged);
            // 
            // txtBGAmount
            // 
            this.txtBGAmount.Location = new System.Drawing.Point(93, 91);
            this.txtBGAmount.Name = "txtBGAmount";
            this.txtBGAmount.Size = new System.Drawing.Size(124, 20);
            this.txtBGAmount.TabIndex = 16;
            this.txtBGAmount.Text = "0.00";
            this.txtBGAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBGAmount.TextChanged += new System.EventHandler(this.txtBGAmount_TextChanged);
            // 
            // dtExpiryDate
            // 
            this.dtExpiryDate.CustomFormat = "dd-MMM-yyyy";
            this.dtExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpiryDate.Location = new System.Drawing.Point(384, 64);
            this.dtExpiryDate.Name = "dtExpiryDate";
            this.dtExpiryDate.Size = new System.Drawing.Size(124, 20);
            this.dtExpiryDate.TabIndex = 15;
            this.dtExpiryDate.ValueChanged += new System.EventHandler(this.dtExpiryDate_ValueChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 11;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.Click += new System.EventHandler(this.lblCustomer_Click);
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(64, 6);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(444, 25);
            this.ctlCustomer1.TabIndex = 12;
            this.ctlCustomer1.Load += new System.EventHandler(this.ctlCustomer1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "BG Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Expiry Date";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(356, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(437, 153);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmCustomerBankGuarantee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 197);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtEffectiveDate);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtBGAmount);
            this.Controls.Add(this.dtExpiryDate);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.ctlCustomer1);
            this.Name = "frmCustomerBankGuarantee";
            this.Text = "frmCustomerBankGuarantee";
            this.Load += new System.EventHandler(this.frmCustomerBankGuarantee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtEffectiveDate;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtBGAmount;
        private System.Windows.Forms.DateTimePicker dtExpiryDate;
        private System.Windows.Forms.Label lblCustomer;
        private Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}