namespace CJ.POS
{
    partial class frmImportXML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportXML));
            this.label1 = new System.Windows.Forms.Label();
            this.txtXLFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoLeadTarget = new System.Windows.Forms.RadioButton();
            this.rdoMAGWeekTarget = new System.Windows.Forms.RadioButton();
            this.rdoCP = new System.Windows.Forms.RadioButton();
            this.rdoBankDiscount = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "XL File Path";
            // 
            // txtXLFilePath
            // 
            this.txtXLFilePath.Location = new System.Drawing.Point(103, 70);
            this.txtXLFilePath.Name = "txtXLFilePath";
            this.txtXLFilePath.ReadOnly = true;
            this.txtXLFilePath.Size = new System.Drawing.Size(412, 23);
            this.txtXLFilePath.TabIndex = 25;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(523, 68);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(87, 27);
            this.btnBrowse.TabIndex = 24;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(523, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(429, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.FileName = "openFileDialogData";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBankDiscount);
            this.groupBox1.Controls.Add(this.rdoLeadTarget);
            this.groupBox1.Controls.Add(this.rdoMAGWeekTarget);
            this.groupBox1.Controls.Add(this.rdoCP);
            this.groupBox1.Location = new System.Drawing.Point(26, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 44);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // rdoLeadTarget
            // 
            this.rdoLeadTarget.AutoSize = true;
            this.rdoLeadTarget.Location = new System.Drawing.Point(301, 14);
            this.rdoLeadTarget.Name = "rdoLeadTarget";
            this.rdoLeadTarget.Size = new System.Drawing.Size(93, 19);
            this.rdoLeadTarget.TabIndex = 2;
            this.rdoLeadTarget.Text = "Lead Target";
            this.rdoLeadTarget.UseVisualStyleBackColor = true;
            // 
            // rdoMAGWeekTarget
            // 
            this.rdoMAGWeekTarget.AutoSize = true;
            this.rdoMAGWeekTarget.Location = new System.Drawing.Point(132, 14);
            this.rdoMAGWeekTarget.Name = "rdoMAGWeekTarget";
            this.rdoMAGWeekTarget.Size = new System.Drawing.Size(129, 19);
            this.rdoMAGWeekTarget.TabIndex = 1;
            this.rdoMAGWeekTarget.Text = "MAG Week Target";
            this.rdoMAGWeekTarget.UseVisualStyleBackColor = true;
            // 
            // rdoCP
            // 
            this.rdoCP.AutoSize = true;
            this.rdoCP.Checked = true;
            this.rdoCP.Location = new System.Drawing.Point(28, 14);
            this.rdoCP.Name = "rdoCP";
            this.rdoCP.Size = new System.Drawing.Size(59, 19);
            this.rdoCP.TabIndex = 0;
            this.rdoCP.TabStop = true;
            this.rdoCP.Text = "CP/TP";
            this.rdoCP.UseVisualStyleBackColor = true;
            // 
            // rdoBankDiscount
            // 
            this.rdoBankDiscount.AutoSize = true;
            this.rdoBankDiscount.Location = new System.Drawing.Point(432, 14);
            this.rdoBankDiscount.Name = "rdoBankDiscount";
            this.rdoBankDiscount.Size = new System.Drawing.Size(104, 19);
            this.rdoBankDiscount.TabIndex = 34;
            this.rdoBankDiscount.TabStop = true;
            this.rdoBankDiscount.Text = "Bank Discount";
            this.rdoBankDiscount.UseVisualStyleBackColor = true;
            // 
            // frmImportXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 150);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXLFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import CP/TP XML";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtXLFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoLeadTarget;
        private System.Windows.Forms.RadioButton rdoMAGWeekTarget;
        private System.Windows.Forms.RadioButton rdoCP;
        private System.Windows.Forms.RadioButton rdoBankDiscount;
    }
}