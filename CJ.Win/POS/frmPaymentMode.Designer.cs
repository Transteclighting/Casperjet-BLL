namespace CJ.Win.POS
{
    partial class frmPaymentMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentMode));
            this.label5 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.txtPaymentMode = new System.Windows.Forms.TextBox();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoInActive = new System.Windows.Forms.RadioButton();
            this.lblBank = new System.Windows.Forms.Label();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoReceivableItemNo = new System.Windows.Forms.RadioButton();
            this.rdoReceivableItemYes = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoFinancialInstitutionNo = new System.Windows.Forms.RadioButton();
            this.rdoFinancialInstitutionYes = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkRetail = new System.Windows.Forms.CheckBox();
            this.chkeStore = new System.Windows.Forms.CheckBox();
            this.chkB2B = new System.Windows.Forms.CheckBox();
            this.chkDealer = new System.Windows.Forms.CheckBox();
            this.chkB2C = new System.Windows.Forms.CheckBox();
            this.chkHPA = new System.Windows.Forms.CheckBox();
            this.chkIsMandatoryInstrumentNo = new System.Windows.Forms.CheckBox();
            this.chkEligableforadvance = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPaymentModeType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Payment Mode:";
            // 
            // btClose
            // 
            this.btClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(379, 308);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(87, 27);
            this.btClose.TabIndex = 12;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click_1);
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.Location = new System.Drawing.Point(284, 308);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(87, 27);
            this.btSave.TabIndex = 11;
            this.btSave.Text = "&Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // txtPaymentMode
            // 
            this.txtPaymentMode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentMode.Location = new System.Drawing.Point(143, 13);
            this.txtPaymentMode.Name = "txtPaymentMode";
            this.txtPaymentMode.Size = new System.Drawing.Size(323, 23);
            this.txtPaymentMode.TabIndex = 1;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Checked = true;
            this.rdoActive.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoActive.Location = new System.Drawing.Point(7, 16);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(59, 19);
            this.rdoActive.TabIndex = 0;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // rdoInActive
            // 
            this.rdoInActive.AutoSize = true;
            this.rdoInActive.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoInActive.Location = new System.Drawing.Point(69, 16);
            this.rdoInActive.Name = "rdoInActive";
            this.rdoInActive.Size = new System.Drawing.Size(69, 19);
            this.rdoInActive.TabIndex = 1;
            this.rdoInActive.Text = "InActive";
            this.rdoInActive.UseVisualStyleBackColor = true;
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Enabled = false;
            this.lblBank.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.Location = new System.Drawing.Point(157, 135);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(75, 15);
            this.lblBank.TabIndex = 5;
            this.lblBank.Text = "Bank Name:";
            // 
            // cmbBankName
            // 
            this.cmbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankName.Enabled = false;
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(238, 132);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(228, 23);
            this.cmbBankName.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoReceivableItemNo);
            this.groupBox1.Controls.Add(this.rdoReceivableItemYes);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 41);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Is Receivable Item";
            // 
            // rdoReceivableItemNo
            // 
            this.rdoReceivableItemNo.AutoSize = true;
            this.rdoReceivableItemNo.Checked = true;
            this.rdoReceivableItemNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReceivableItemNo.Location = new System.Drawing.Point(75, 18);
            this.rdoReceivableItemNo.Name = "rdoReceivableItemNo";
            this.rdoReceivableItemNo.Size = new System.Drawing.Size(45, 19);
            this.rdoReceivableItemNo.TabIndex = 1;
            this.rdoReceivableItemNo.TabStop = true;
            this.rdoReceivableItemNo.Text = "NO";
            this.rdoReceivableItemNo.UseVisualStyleBackColor = true;
            // 
            // rdoReceivableItemYes
            // 
            this.rdoReceivableItemYes.AutoSize = true;
            this.rdoReceivableItemYes.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoReceivableItemYes.Location = new System.Drawing.Point(10, 18);
            this.rdoReceivableItemYes.Name = "rdoReceivableItemYes";
            this.rdoReceivableItemYes.Size = new System.Drawing.Size(46, 19);
            this.rdoReceivableItemYes.TabIndex = 0;
            this.rdoReceivableItemYes.Text = "YES";
            this.rdoReceivableItemYes.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoFinancialInstitutionNo);
            this.groupBox2.Controls.Add(this.rdoFinancialInstitutionYes);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 41);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Is Financial Institution";
            // 
            // rdoFinancialInstitutionNo
            // 
            this.rdoFinancialInstitutionNo.AutoSize = true;
            this.rdoFinancialInstitutionNo.Checked = true;
            this.rdoFinancialInstitutionNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFinancialInstitutionNo.Location = new System.Drawing.Point(75, 18);
            this.rdoFinancialInstitutionNo.Name = "rdoFinancialInstitutionNo";
            this.rdoFinancialInstitutionNo.Size = new System.Drawing.Size(45, 19);
            this.rdoFinancialInstitutionNo.TabIndex = 1;
            this.rdoFinancialInstitutionNo.TabStop = true;
            this.rdoFinancialInstitutionNo.Text = "NO";
            this.rdoFinancialInstitutionNo.UseVisualStyleBackColor = true;
            this.rdoFinancialInstitutionNo.CheckedChanged += new System.EventHandler(this.rdoFinancialInstitutionNo_CheckedChanged);
            // 
            // rdoFinancialInstitutionYes
            // 
            this.rdoFinancialInstitutionYes.AutoSize = true;
            this.rdoFinancialInstitutionYes.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFinancialInstitutionYes.Location = new System.Drawing.Point(10, 18);
            this.rdoFinancialInstitutionYes.Name = "rdoFinancialInstitutionYes";
            this.rdoFinancialInstitutionYes.Size = new System.Drawing.Size(46, 19);
            this.rdoFinancialInstitutionYes.TabIndex = 0;
            this.rdoFinancialInstitutionYes.Text = "YES";
            this.rdoFinancialInstitutionYes.UseVisualStyleBackColor = true;
            this.rdoFinancialInstitutionYes.CheckedChanged += new System.EventHandler(this.rdoFinancialInstitutionYes_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoActive);
            this.groupBox3.Controls.Add(this.rdoInActive);
            this.groupBox3.Location = new System.Drawing.Point(325, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 41);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Is Active";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkRetail);
            this.groupBox4.Controls.Add(this.chkeStore);
            this.groupBox4.Controls.Add(this.chkB2B);
            this.groupBox4.Controls.Add(this.chkDealer);
            this.groupBox4.Controls.Add(this.chkB2C);
            this.groupBox4.Controls.Add(this.chkHPA);
            this.groupBox4.Location = new System.Drawing.Point(12, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(454, 104);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Applicable For";
            // 
            // chkRetail
            // 
            this.chkRetail.AutoSize = true;
            this.chkRetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetail.Location = new System.Drawing.Point(7, 22);
            this.chkRetail.Name = "chkRetail";
            this.chkRetail.Size = new System.Drawing.Size(58, 19);
            this.chkRetail.TabIndex = 0;
            this.chkRetail.Text = "Retail";
            this.chkRetail.UseVisualStyleBackColor = true;
            // 
            // chkeStore
            // 
            this.chkeStore.AutoSize = true;
            this.chkeStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkeStore.Location = new System.Drawing.Point(352, 75);
            this.chkeStore.Name = "chkeStore";
            this.chkeStore.Size = new System.Drawing.Size(62, 19);
            this.chkeStore.TabIndex = 5;
            this.chkeStore.Text = "eStore";
            this.chkeStore.UseVisualStyleBackColor = true;
            // 
            // chkB2B
            // 
            this.chkB2B.AutoSize = true;
            this.chkB2B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkB2B.Location = new System.Drawing.Point(7, 74);
            this.chkB2B.Name = "chkB2B";
            this.chkB2B.Size = new System.Drawing.Size(49, 19);
            this.chkB2B.TabIndex = 4;
            this.chkB2B.Text = "B2B";
            this.chkB2B.UseVisualStyleBackColor = true;
            // 
            // chkDealer
            // 
            this.chkDealer.AutoSize = true;
            this.chkDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDealer.Location = new System.Drawing.Point(352, 48);
            this.chkDealer.Name = "chkDealer";
            this.chkDealer.Size = new System.Drawing.Size(63, 19);
            this.chkDealer.TabIndex = 3;
            this.chkDealer.Text = "Dealer";
            this.chkDealer.UseVisualStyleBackColor = true;
            // 
            // chkB2C
            // 
            this.chkB2C.AutoSize = true;
            this.chkB2C.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkB2C.Location = new System.Drawing.Point(7, 47);
            this.chkB2C.Name = "chkB2C";
            this.chkB2C.Size = new System.Drawing.Size(49, 19);
            this.chkB2C.TabIndex = 2;
            this.chkB2C.Text = "B2C";
            this.chkB2C.UseVisualStyleBackColor = true;
            // 
            // chkHPA
            // 
            this.chkHPA.AutoSize = true;
            this.chkHPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHPA.Location = new System.Drawing.Point(352, 22);
            this.chkHPA.Name = "chkHPA";
            this.chkHPA.Size = new System.Drawing.Size(50, 19);
            this.chkHPA.TabIndex = 1;
            this.chkHPA.Text = "HPA";
            this.chkHPA.UseVisualStyleBackColor = true;
            // 
            // chkIsMandatoryInstrumentNo
            // 
            this.chkIsMandatoryInstrumentNo.AutoSize = true;
            this.chkIsMandatoryInstrumentNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsMandatoryInstrumentNo.Location = new System.Drawing.Point(12, 283);
            this.chkIsMandatoryInstrumentNo.Name = "chkIsMandatoryInstrumentNo";
            this.chkIsMandatoryInstrumentNo.Size = new System.Drawing.Size(173, 19);
            this.chkIsMandatoryInstrumentNo.TabIndex = 9;
            this.chkIsMandatoryInstrumentNo.Text = "Is Mandatory Instrument #";
            this.chkIsMandatoryInstrumentNo.UseVisualStyleBackColor = true;
            // 
            // chkEligableforadvance
            // 
            this.chkEligableforadvance.AutoSize = true;
            this.chkEligableforadvance.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEligableforadvance.Location = new System.Drawing.Point(12, 308);
            this.chkEligableforadvance.Name = "chkEligableforadvance";
            this.chkEligableforadvance.Size = new System.Drawing.Size(202, 19);
            this.chkEligableforadvance.TabIndex = 10;
            this.chkEligableforadvance.Text = "Is Eligible for Advance Payment";
            this.chkEligableforadvance.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment Mode Type:";
            // 
            // cmbPaymentModeType
            // 
            this.cmbPaymentModeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentModeType.FormattingEnabled = true;
            this.cmbPaymentModeType.Location = new System.Drawing.Point(143, 42);
            this.cmbPaymentModeType.Name = "cmbPaymentModeType";
            this.cmbPaymentModeType.Size = new System.Drawing.Size(323, 23);
            this.cmbPaymentModeType.TabIndex = 3;
            // 
            // frmPaymentMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 348);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPaymentModeType);
            this.Controls.Add(this.chkEligableforadvance);
            this.Controls.Add(this.chkIsMandatoryInstrumentNo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.cmbBankName);
            this.Controls.Add(this.txtPaymentMode);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPaymentMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Payment Mode";
            this.Load += new System.EventHandler(this.frmPaymentMode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox txtPaymentMode;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.RadioButton rdoInActive;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoReceivableItemNo;
        private System.Windows.Forms.RadioButton rdoReceivableItemYes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoFinancialInstitutionNo;
        private System.Windows.Forms.RadioButton rdoFinancialInstitutionYes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkRetail;
        private System.Windows.Forms.CheckBox chkeStore;
        private System.Windows.Forms.CheckBox chkB2B;
        private System.Windows.Forms.CheckBox chkDealer;
        private System.Windows.Forms.CheckBox chkB2C;
        private System.Windows.Forms.CheckBox chkHPA;
        private System.Windows.Forms.CheckBox chkIsMandatoryInstrumentNo;
        private System.Windows.Forms.CheckBox chkEligableforadvance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPaymentModeType;
    }
}