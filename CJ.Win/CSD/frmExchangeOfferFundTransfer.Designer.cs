namespace CJ.Win.CSD
{
    partial class frmExchangeOfferFundTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExchangeOfferFundTransfer));
            this.lblParentVender = new System.Windows.Forms.Label();
            this.cmbParentVender = new System.Windows.Forms.ComboBox();
            this.lblChildVender = new System.Windows.Forms.Label();
            this.cmbChildVender = new System.Windows.Forms.ComboBox();
            this.txtMotherBalance = new System.Windows.Forms.TextBox();
            this.lblParentBalance = new System.Windows.Forms.Label();
            this.txtChildBalance = new System.Windows.Forms.TextBox();
            this.lblChildBalance = new System.Windows.Forms.Label();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComfirmAmount = new System.Windows.Forms.TextBox();
            this.txtReceiveAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblParentVender
            // 
            this.lblParentVender.AutoSize = true;
            this.lblParentVender.Location = new System.Drawing.Point(19, 9);
            this.lblParentVender.Name = "lblParentVender";
            this.lblParentVender.Size = new System.Drawing.Size(78, 13);
            this.lblParentVender.TabIndex = 0;
            this.lblParentVender.Text = "Parent Vender ";
            // 
            // cmbParentVender
            // 
            this.cmbParentVender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentVender.FormattingEnabled = true;
            this.cmbParentVender.Location = new System.Drawing.Point(100, 6);
            this.cmbParentVender.Name = "cmbParentVender";
            this.cmbParentVender.Size = new System.Drawing.Size(341, 21);
            this.cmbParentVender.TabIndex = 1;
            this.cmbParentVender.SelectedIndexChanged += new System.EventHandler(this.cmbParentVender_SelectedIndexChanged);
            // 
            // lblChildVender
            // 
            this.lblChildVender.AutoSize = true;
            this.lblChildVender.Location = new System.Drawing.Point(27, 36);
            this.lblChildVender.Name = "lblChildVender";
            this.lblChildVender.Size = new System.Drawing.Size(70, 13);
            this.lblChildVender.TabIndex = 2;
            this.lblChildVender.Text = "Child Vender ";
            // 
            // cmbChildVender
            // 
            this.cmbChildVender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChildVender.FormattingEnabled = true;
            this.cmbChildVender.Location = new System.Drawing.Point(100, 33);
            this.cmbChildVender.Name = "cmbChildVender";
            this.cmbChildVender.Size = new System.Drawing.Size(341, 21);
            this.cmbChildVender.TabIndex = 3;
            this.cmbChildVender.SelectedIndexChanged += new System.EventHandler(this.cmbChildVender_SelectedIndexChanged);
            // 
            // txtMotherBalance
            // 
            this.txtMotherBalance.Location = new System.Drawing.Point(100, 60);
            this.txtMotherBalance.Name = "txtMotherBalance";
            this.txtMotherBalance.ReadOnly = true;
            this.txtMotherBalance.Size = new System.Drawing.Size(119, 20);
            this.txtMotherBalance.TabIndex = 5;
            this.txtMotherBalance.Text = "0.00";
            this.txtMotherBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblParentBalance
            // 
            this.lblParentBalance.AutoSize = true;
            this.lblParentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentBalance.Location = new System.Drawing.Point(11, 63);
            this.lblParentBalance.Name = "lblParentBalance";
            this.lblParentBalance.Size = new System.Drawing.Size(86, 13);
            this.lblParentBalance.TabIndex = 4;
            this.lblParentBalance.Text = "Parent Balance: ";
            // 
            // txtChildBalance
            // 
            this.txtChildBalance.Location = new System.Drawing.Point(325, 60);
            this.txtChildBalance.Name = "txtChildBalance";
            this.txtChildBalance.ReadOnly = true;
            this.txtChildBalance.Size = new System.Drawing.Size(119, 20);
            this.txtChildBalance.TabIndex = 7;
            this.txtChildBalance.Text = "0.00";
            this.txtChildBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChildBalance
            // 
            this.lblChildBalance.AutoSize = true;
            this.lblChildBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildBalance.Location = new System.Drawing.Point(244, 63);
            this.lblChildBalance.Name = "lblChildBalance";
            this.lblChildBalance.Size = new System.Drawing.Size(78, 13);
            this.lblChildBalance.TabIndex = 6;
            this.lblChildBalance.Text = "Child Balance: ";
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.AutoSize = true;
            this.lblAmountInWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWord.ForeColor = System.Drawing.Color.Red;
            this.lblAmountInWord.Location = new System.Drawing.Point(97, 116);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(13, 13);
            this.lblAmountInWord.TabIndex = 13;
            this.lblAmountInWord.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Amount (In Word) :";
            // 
            // txtComfirmAmount
            // 
            this.txtComfirmAmount.Location = new System.Drawing.Point(325, 86);
            this.txtComfirmAmount.Name = "txtComfirmAmount";
            this.txtComfirmAmount.Size = new System.Drawing.Size(119, 20);
            this.txtComfirmAmount.TabIndex = 11;
            this.txtComfirmAmount.Text = "0.00";
            this.txtComfirmAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtComfirmAmount.TextChanged += new System.EventHandler(this.txtComfirmAmount_TextChanged);
            // 
            // txtReceiveAmount
            // 
            this.txtReceiveAmount.Location = new System.Drawing.Point(100, 86);
            this.txtReceiveAmount.Name = "txtReceiveAmount";
            this.txtReceiveAmount.Size = new System.Drawing.Size(119, 20);
            this.txtReceiveAmount.TabIndex = 9;
            this.txtReceiveAmount.Text = "0.00";
            this.txtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Amount: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(235, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Confirm Amount: ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(100, 141);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(341, 20);
            this.txtRemarks.TabIndex = 15;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(48, 144);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(49, 13);
            this.lblRemarks.TabIndex = 14;
            this.lblRemarks.Text = "Remarks";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(369, 172);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(288, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmExchangeOfferFundTransfer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 206);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAmountInWord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtComfirmAmount);
            this.Controls.Add(this.txtReceiveAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblChildBalance);
            this.Controls.Add(this.txtChildBalance);
            this.Controls.Add(this.txtMotherBalance);
            this.Controls.Add(this.lblParentBalance);
            this.Controls.Add(this.lblChildVender);
            this.Controls.Add(this.cmbChildVender);
            this.Controls.Add(this.lblParentVender);
            this.Controls.Add(this.cmbParentVender);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmExchangeOfferFundTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExchangeOfferFundTransfer";
            this.Load += new System.EventHandler(this.frmExchangeOfferFundTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParentVender;
        private System.Windows.Forms.ComboBox cmbParentVender;
        private System.Windows.Forms.Label lblChildVender;
        private System.Windows.Forms.ComboBox cmbChildVender;
        private System.Windows.Forms.TextBox txtMotherBalance;
        private System.Windows.Forms.Label lblParentBalance;
        private System.Windows.Forms.TextBox txtChildBalance;
        private System.Windows.Forms.Label lblChildBalance;
        private System.Windows.Forms.Label lblAmountInWord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComfirmAmount;
        private System.Windows.Forms.TextBox txtReceiveAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}