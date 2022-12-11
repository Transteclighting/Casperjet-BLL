namespace CJ.Win.Accounts
{
    partial class frmSalesInvoiceDiscountType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesInvoiceDiscountType));
            this.txtDiscountTypeName = new System.Windows.Forms.TextBox();
            this.lblDistSet = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRetail = new System.Windows.Forms.CheckBox();
            this.chkeStore = new System.Windows.Forms.CheckBox();
            this.chkB2B = new System.Windows.Forms.CheckBox();
            this.chkDealer = new System.Windows.Forms.CheckBox();
            this.chkB2C = new System.Windows.Forms.CheckBox();
            this.chkHPA = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkIsMandatoryInstrumentNo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDiscountTypeName
            // 
            this.txtDiscountTypeName.Location = new System.Drawing.Point(86, 14);
            this.txtDiscountTypeName.Name = "txtDiscountTypeName";
            this.txtDiscountTypeName.Size = new System.Drawing.Size(384, 21);
            this.txtDiscountTypeName.TabIndex = 1;
            // 
            // lblDistSet
            // 
            this.lblDistSet.AutoSize = true;
            this.lblDistSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistSet.Location = new System.Drawing.Point(9, 15);
            this.lblDistSet.Name = "lblDistSet";
            this.lblDistSet.Size = new System.Drawing.Size(69, 15);
            this.lblDistSet.TabIndex = 0;
            this.lblDistSet.Text = "Description";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(288, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(404, 46);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(66, 19);
            this.chkIsActive.TabIndex = 4;
            this.chkIsActive.Text = "IsActive";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(86, 44);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(199, 23);
            this.cmbType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRetail);
            this.groupBox1.Controls.Add(this.chkeStore);
            this.groupBox1.Controls.Add(this.chkB2B);
            this.groupBox1.Controls.Add(this.chkDealer);
            this.groupBox1.Controls.Add(this.chkB2C);
            this.groupBox1.Controls.Add(this.chkHPA);
            this.groupBox1.Location = new System.Drawing.Point(86, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 104);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applicable For";
            // 
            // chkRetail
            // 
            this.chkRetail.AutoSize = true;
            this.chkRetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetail.Location = new System.Drawing.Point(7, 22);
            this.chkRetail.Name = "chkRetail";
            this.chkRetail.Size = new System.Drawing.Size(58, 19);
            this.chkRetail.TabIndex = 49;
            this.chkRetail.Text = "Retail";
            this.chkRetail.UseVisualStyleBackColor = true;
            // 
            // chkeStore
            // 
            this.chkeStore.AutoSize = true;
            this.chkeStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkeStore.Location = new System.Drawing.Point(241, 75);
            this.chkeStore.Name = "chkeStore";
            this.chkeStore.Size = new System.Drawing.Size(62, 19);
            this.chkeStore.TabIndex = 54;
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
            this.chkB2B.TabIndex = 50;
            this.chkB2B.Text = "B2B";
            this.chkB2B.UseVisualStyleBackColor = true;
            // 
            // chkDealer
            // 
            this.chkDealer.AutoSize = true;
            this.chkDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDealer.Location = new System.Drawing.Point(241, 48);
            this.chkDealer.Name = "chkDealer";
            this.chkDealer.Size = new System.Drawing.Size(63, 19);
            this.chkDealer.TabIndex = 53;
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
            this.chkB2C.TabIndex = 51;
            this.chkB2C.Text = "B2C";
            this.chkB2C.UseVisualStyleBackColor = true;
            // 
            // chkHPA
            // 
            this.chkHPA.AutoSize = true;
            this.chkHPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHPA.Location = new System.Drawing.Point(241, 22);
            this.chkHPA.Name = "chkHPA";
            this.chkHPA.Size = new System.Drawing.Size(50, 19);
            this.chkHPA.TabIndex = 52;
            this.chkHPA.Text = "HPA";
            this.chkHPA.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(383, 186);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkIsMandatoryInstrumentNo
            // 
            this.chkIsMandatoryInstrumentNo.AutoSize = true;
            this.chkIsMandatoryInstrumentNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsMandatoryInstrumentNo.Location = new System.Drawing.Point(99, 191);
            this.chkIsMandatoryInstrumentNo.Name = "chkIsMandatoryInstrumentNo";
            this.chkIsMandatoryInstrumentNo.Size = new System.Drawing.Size(183, 19);
            this.chkIsMandatoryInstrumentNo.TabIndex = 44;
            this.chkIsMandatoryInstrumentNo.Text = "Is Mandatory Instrument No";
            this.chkIsMandatoryInstrumentNo.UseVisualStyleBackColor = true;
            // 
            // frmSalesInvoiceDiscountType
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 224);
            this.Controls.Add(this.chkIsMandatoryInstrumentNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtDiscountTypeName);
            this.Controls.Add(this.lblDistSet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesInvoiceDiscountType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Discount/Charge Type";
            this.Load += new System.EventHandler(this.frmSalesInvoiceDiscountType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiscountTypeName;
        private System.Windows.Forms.Label lblDistSet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRetail;
        private System.Windows.Forms.CheckBox chkeStore;
        private System.Windows.Forms.CheckBox chkB2B;
        private System.Windows.Forms.CheckBox chkDealer;
        private System.Windows.Forms.CheckBox chkB2C;
        private System.Windows.Forms.CheckBox chkHPA;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkIsMandatoryInstrumentNo;
    }
}