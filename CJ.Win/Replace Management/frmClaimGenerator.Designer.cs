namespace CJ.Win.Replace_Management
{
    partial class frmClaimGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClaimGenerator));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkPGAll = new System.Windows.Forms.CheckBox();
            this.lvwMAG = new System.Windows.Forms.ListView();
            this.colReplaceClaimNo = new System.Windows.Forms.ColumnHeader();
            this.colSubClaimNumber = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwExistingClaim = new System.Windows.Forms.ListView();
            this.colExistingClaimNo = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClaimNo = new System.Windows.Forms.TextBox();
            this.rdoNewClaim = new System.Windows.Forms.RadioButton();
            this.rdoExistingClaim = new System.Windows.Forms.RadioButton();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(508, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(412, 253);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkPGAll);
            this.groupBox6.Controls.Add(this.lvwMAG);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(328, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(270, 234);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Product Group";
            // 
            // chkPGAll
            // 
            this.chkPGAll.AutoSize = true;
            this.chkPGAll.Location = new System.Drawing.Point(8, 16);
            this.chkPGAll.Name = "chkPGAll";
            this.chkPGAll.Size = new System.Drawing.Size(88, 17);
            this.chkPGAll.TabIndex = 0;
            this.chkPGAll.Text = "Un-Check All";
            this.chkPGAll.UseVisualStyleBackColor = true;
            this.chkPGAll.CheckedChanged += new System.EventHandler(this.chkPGAll_CheckedChanged);
            // 
            // lvwMAG
            // 
            this.lvwMAG.CheckBoxes = true;
            this.lvwMAG.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReplaceClaimNo,
            this.colSubClaimNumber});
            this.lvwMAG.FullRowSelect = true;
            this.lvwMAG.GridLines = true;
            this.lvwMAG.HideSelection = false;
            this.lvwMAG.Location = new System.Drawing.Point(6, 38);
            this.lvwMAG.Name = "lvwMAG";
            this.lvwMAG.Size = new System.Drawing.Size(258, 190);
            this.lvwMAG.TabIndex = 1;
            this.lvwMAG.UseCompatibleStateImageBehavior = false;
            this.lvwMAG.View = System.Windows.Forms.View.Details;
            // 
            // colReplaceClaimNo
            // 
            this.colReplaceClaimNo.Text = "Claim No";
            this.colReplaceClaimNo.Width = 99;
            // 
            // colSubClaimNumber
            // 
            this.colSubClaimNumber.Text = "Sub Claim No";
            this.colSubClaimNumber.Width = 152;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwExistingClaim);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtClaimNo);
            this.groupBox1.Controls.Add(this.rdoNewClaim);
            this.groupBox1.Controls.Add(this.rdoExistingClaim);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Brand/Product Group";
            // 
            // lvwExistingClaim
            // 
            this.lvwExistingClaim.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colExistingClaimNo});
            this.lvwExistingClaim.FullRowSelect = true;
            this.lvwExistingClaim.GridLines = true;
            this.lvwExistingClaim.HideSelection = false;
            this.lvwExistingClaim.Location = new System.Drawing.Point(6, 68);
            this.lvwExistingClaim.Name = "lvwExistingClaim";
            this.lvwExistingClaim.Size = new System.Drawing.Size(274, 160);
            this.lvwExistingClaim.TabIndex = 4;
            this.lvwExistingClaim.UseCompatibleStateImageBehavior = false;
            this.lvwExistingClaim.View = System.Windows.Forms.View.Details;
            // 
            // colExistingClaimNo
            // 
            this.colExistingClaimNo.Text = "Existing Claim No";
            this.colExistingClaimNo.Width = 270;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Claim No:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtClaimNo
            // 
            this.txtClaimNo.Location = new System.Drawing.Point(64, 42);
            this.txtClaimNo.Name = "txtClaimNo";
            this.txtClaimNo.Size = new System.Drawing.Size(216, 20);
            this.txtClaimNo.TabIndex = 3;
            this.txtClaimNo.TextChanged += new System.EventHandler(this.txtClaimNo_TextChanged);
            // 
            // rdoNewClaim
            // 
            this.rdoNewClaim.AutoSize = true;
            this.rdoNewClaim.Checked = true;
            this.rdoNewClaim.Location = new System.Drawing.Point(6, 19);
            this.rdoNewClaim.Name = "rdoNewClaim";
            this.rdoNewClaim.Size = new System.Drawing.Size(75, 17);
            this.rdoNewClaim.TabIndex = 0;
            this.rdoNewClaim.TabStop = true;
            this.rdoNewClaim.Text = "New Claim";
            this.rdoNewClaim.UseVisualStyleBackColor = true;
            this.rdoNewClaim.CheckedChanged += new System.EventHandler(this.rdoNewClaim_CheckedChanged);
            // 
            // rdoExistingClaim
            // 
            this.rdoExistingClaim.AutoSize = true;
            this.rdoExistingClaim.Location = new System.Drawing.Point(191, 19);
            this.rdoExistingClaim.Name = "rdoExistingClaim";
            this.rdoExistingClaim.Size = new System.Drawing.Size(89, 17);
            this.rdoExistingClaim.TabIndex = 1;
            this.rdoExistingClaim.Text = "Existing Claim";
            this.rdoExistingClaim.UseVisualStyleBackColor = true;
            this.rdoExistingClaim.CheckedChanged += new System.EventHandler(this.rdoExistingClaim_CheckedChanged);
            // 
            // frmClaimGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 286);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClaimGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Claim Generator";
            this.Load += new System.EventHandler(this.frmClaimGenerator_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkPGAll;
        private System.Windows.Forms.ListView lvwMAG;
        private System.Windows.Forms.ColumnHeader colReplaceClaimNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoNewClaim;
        private System.Windows.Forms.RadioButton rdoExistingClaim;
        private System.Windows.Forms.TextBox txtClaimNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwExistingClaim;
        private System.Windows.Forms.ColumnHeader colExistingClaimNo;
        private System.Windows.Forms.ColumnHeader colSubClaimNumber;
    }
}