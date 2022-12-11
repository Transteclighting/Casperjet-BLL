namespace CJ.Win
{
    partial class frmBEILDistributionSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBEILDistributionSet));
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDistSet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbExpenseType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDistType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAllowanceType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDistCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Enabled = false;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(80, 5);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(251, 21);
            this.cmbCompany.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dist. Desc";
            // 
            // txtDistDesc
            // 
            this.txtDistDesc.Location = new System.Drawing.Point(262, 88);
            this.txtDistDesc.Name = "txtDistDesc";
            this.txtDistDesc.Size = new System.Drawing.Size(243, 20);
            this.txtDistDesc.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dpt. Code";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(80, 62);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(114, 20);
            this.txtDepartment.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dist. Set";
            // 
            // txtDistSet
            // 
            this.txtDistSet.Location = new System.Drawing.Point(413, 62);
            this.txtDistSet.Name = "txtDistSet";
            this.txtDistSet.Size = new System.Drawing.Size(92, 20);
            this.txtDistSet.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Company";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(331, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbExpenseType
            // 
            this.cmbExpenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExpenseType.FormattingEnabled = true;
            this.cmbExpenseType.Items.AddRange(new object[] {
            "ALL",
            "D",
            "E"});
            this.cmbExpenseType.Location = new System.Drawing.Point(413, 10);
            this.cmbExpenseType.Name = "cmbExpenseType";
            this.cmbExpenseType.Size = new System.Drawing.Size(92, 21);
            this.cmbExpenseType.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Expn. Type";
            // 
            // cmbDistType
            // 
            this.cmbDistType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistType.FormattingEnabled = true;
            this.cmbDistType.Items.AddRange(new object[] {
            "ALL",
            "A",
            "S"});
            this.cmbDistType.Location = new System.Drawing.Point(413, 35);
            this.cmbDistType.Name = "cmbDistType";
            this.cmbDistType.Size = new System.Drawing.Size(92, 21);
            this.cmbDistType.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Dist. Type";
            // 
            // cmbAllowanceType
            // 
            this.cmbAllowanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllowanceType.FormattingEnabled = true;
            this.cmbAllowanceType.Location = new System.Drawing.Point(80, 35);
            this.cmbAllowanceType.Name = "cmbAllowanceType";
            this.cmbAllowanceType.Size = new System.Drawing.Size(251, 21);
            this.cmbAllowanceType.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Allowanced";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Dist. Code";
            // 
            // txtDistCode
            // 
            this.txtDistCode.Location = new System.Drawing.Point(80, 88);
            this.txtDistCode.Name = "txtDistCode";
            this.txtDistCode.Size = new System.Drawing.Size(114, 20);
            this.txtDistCode.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(421, 114);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 26);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBEILDistributionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 150);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDistCode);
            this.Controls.Add(this.cmbAllowanceType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDistType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbExpenseType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDistDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDistSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBEILDistributionSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BEIL Distribution Set";
            this.Load += new System.EventHandler(this.frmBEILDistributionSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDistSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbExpenseType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDistType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAllowanceType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDistCode;
        private System.Windows.Forms.Button btnClose;
    }
}